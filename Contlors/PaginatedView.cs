using diplomaadminpanel.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplomaadminpanel
{
    public partial class PaginatedView : UserControl
    {
        public PaginatedView()
        {
            InitializeComponent();
        }

        private IPaginatedRequestWrapper? _request;


        //public async Task<HttpStatusCode> SendPaginatedRequest<T>(
        //    bool usePagination,
        //    HttpMethod method,
        //    string url,
        //    Dictionary<string, string?>? parameters = null,
        //    object? payload = null,
        //    Action<HttpStatusCode, T>? onSuccess = null,
        //    Action<HttpStatusCode, string>? onError = null
        //)
        //{
        //    var req = new PaginatedRequest<T>(
        //        usePagination: usePagination,
        //        method: method,
        //        url: url,
        //        parameters: parameters,
        //        payload: payload,
        //        onSuccess: onSuccess,
        //        onError: onError,
        //        nextPageButton: btnNext,
        //        previousPageButton: btnPrev,
        //        labelCurrentPage: lblPage
        //    );

        //    return await req.FetchCurrentPage();
        //}

        private Func<object, object>? _rowBuilder;
        //private Func<object, DataGridViewRow>? _rowBuilder;
        // хочется добавить

        public void SetRowBuilder<T>(Func<T, object[]> builder)
        {
            _rowBuilder = obj => builder((T)obj);
        }

        public void SetRowBuilder<T>(Func<T, DataGridViewRow> builder)
        {
            _rowBuilder = obj => builder((T)obj);
        }


        public void Bind<T>(
            HttpMethod method,
            string url,
            object? payload = null,
            Dictionary<string, string?>? parameters = null
            //int pageSize = 10
        //Action<HttpStatusCode, T>? onSuccess = null,
        //Action<HttpStatusCode, string>? onError = null
        )
        {
            if (_request != null)
            {
                _request.Dispose();
                _request = null;
            }


            bool hScrollVisible = dgvView.Controls
                .OfType<HScrollBar>()
                .Any(sb => sb.Visible);
            int headerHeight = dgvView.ColumnHeadersHeight;
            int rowHeight = dgvView.RowTemplate.Height;
            int dgvHeight = dgvView.Height;
            int horizontalScrollbarHeight = SystemInformation.HorizontalScrollBarHeight;


            int rowsAmount = (int)Math.Floor((double)(dgvHeight - headerHeight - (hScrollVisible ? horizontalScrollbarHeight : 0)) / rowHeight);


            _request = new PaginatedRequest<List<T>>(
                usePagination: true,
                method: method,
                url: url,
                parameters: parameters,
                payload: payload,
                pageSize: rowsAmount,
                onSuccess: (StatusCode, response) =>
                {
                    dgvView.SuspendLayout();
                    dgvView.Rows.Clear();
             
                    if (dgvView.Columns.Count != 0)
                    {
                        foreach (T row in response!)
                        {
                            var built = _rowBuilder!(row);
                            int rowIndex = -1;

                        

                            if (built is object[] cellValues)
                            {
                                rowIndex = dgvView.Rows.Add(cellValues);
                                //dgvView.Rows[rowIndex].Tag = row;
                            }
                            else if (built is DataGridViewRow dgvRow)
                            {
                                rowIndex = dgvView.Rows.Add(dgvRow);
                                //dgvView.Rows[rowIndex].Tag = row;
                            }
                            else
                            {
                                throw new InvalidOperationException("Неверный тип данных, возвращённый rowBuilder.");
                            }


                            //int rowIndex = dgvView.Rows.Add(_rowBuilder!(row));

                            dgvView.Rows[rowIndex].Tag = row;
                        }
                    }
                    dgvView.ResumeLayout();
                },
                //onError: onError,
                nextPageButton: btnNext,
                previousPageButton: btnPrev,
                labelCurrentPage: lblPage
            );
        }

        public async Task<HttpStatusCode> FetchCurrentPage()
        {
            if (_request is null)
                throw new InvalidOperationException("Call Bind<T>() first!");

            return await _request.FetchCurrentPage();
        }

        public void LoadColumns(List<DataGridViewColumn> columns)
        {
            foreach (var col in columns)
            {
                int CurrId = dgvView.Columns.Add(col);
                dgvView.Columns[CurrId].ReadOnly = true;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RowSelectionVisibility { get; set; } = true;

        public void ChangeRowSelecttionVisibility(bool to)
        {
            Debug.WriteLine(to.ToString());
            dgvView.EnableHeadersVisualStyles = to;
            RowSelectionVisibility = to;
            if (to)
            {
                dgvView.DefaultCellStyle.SelectionBackColor = originalSelectionBackColor;
                dgvView.DefaultCellStyle.SelectionForeColor = originalSelectionForeColor;
                dgvView.ColumnHeadersDefaultCellStyle.Padding = new Padding(0);
            }
            else
            {
                dgvView.DefaultCellStyle.SelectionBackColor = dgvView.DefaultCellStyle.BackColor;
                dgvView.DefaultCellStyle.SelectionForeColor = dgvView.DefaultCellStyle.ForeColor;
                dgvView.ColumnHeadersDefaultCellStyle.Padding = new Padding(1);
            }

        }

        private Color originalSelectionBackColor;
        private Color originalSelectionForeColor;
        //private Color originalHeaderSelectionBackColor;
        //private Color originalHeaderSelectionForeColor;

        private void PaginatedView_Load(object sender, EventArgs e)
        {
            originalSelectionBackColor = dgvView.DefaultCellStyle.SelectionBackColor;
            originalSelectionForeColor = dgvView.DefaultCellStyle.SelectionForeColor;
            dgvView.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Window;
            dgvView.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Window;

            ChangeRowSelecttionVisibility(RowSelectionVisibility);
        }


        public event EventHandler<object>? RowDoubleClick;
        public event EventHandler<(string ColumnName, object? RowTag, object? Value)>? CellContentClick;

        private void dgvView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvView.Rows[e.RowIndex];

            RowDoubleClick?.Invoke(sender, row.Tag!);
        }


        public void ChangeHeaderHeight(int height)
        {
            if (height == 0)
            {
                dgvView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                return;
            }
            else
            {
                dgvView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvView.ColumnHeadersHeight = height;
            }
        }


        private void dgvView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            CellContentClick?.Invoke(sender, (dgvView.Columns[e.ColumnIndex].Name, dgvView.Rows[e.RowIndex].Tag, dgvView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
        }

        //private bool _isForcesullydisabled = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool PageButtonsEnabled
        {
            get => pnlBtns.Enabled;
            set => pnlBtns.Enabled = value;
        }

        public void SetColumnVisibility(string ColumnName, bool visibility)
        {
            //Debug.WriteLine(dgvView.Columns[0].Width);
            //Debug.WriteLine(dgvView.Columns[1].Width);
            //Debug.WriteLine(dgvView.Columns[2].Width);
            //Debug.WriteLine(dgvView.Columns[3].Width);
            //Debug.WriteLine(dgvView.Columns[4].Width);
            //Debug.WriteLine(dgvView.Columns[5].Width);
            //Debug.WriteLine(dgvView.Columns[6].Width);
            if (!dgvView.Columns.Contains(ColumnName)) return;
            dgvView.Columns[ColumnName]!.Visible = visibility;
        }

    }
}
