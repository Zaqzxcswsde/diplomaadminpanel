using diplomaadminpanel.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private Func<object, object[]>? _rowBuilder;

        public void SetRowBuilder<T>(Func<T, object[]> builder)
        {
            _rowBuilder = obj => builder((T)obj);
        }



        public void Bind<T>(
            HttpMethod method,
            string url,
            object? payload = null,
            Dictionary<string, string?>? parameters = null
            //Action<HttpStatusCode, T>? onSuccess = null,
            //Action<HttpStatusCode, string>? onError = null
        )
        {
            if ( _request != null)
            {
                _request.Dispose();
                _request = null;
            }

            _request = new PaginatedRequest<List<T>>(
                usePagination: true,
                method: method,
                url: url,
                parameters: parameters,
                payload: payload,
                onSuccess: (StatusCode, response) =>
                {
                    dgvView.SuspendLayout();
                    dgvView.Rows.Clear();
                    foreach (T row in response!)
                    {
                        int rowIndex = dgvView.Rows.Add(_rowBuilder!(row));
                        dgvView.Rows[rowIndex].Tag = row;
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



        private void PaginatedView_Load(object sender, EventArgs e)
        {

        }


        public event EventHandler<object>? RowDoubleClick;

        private void dgvView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvView.Rows[e.RowIndex];

            RowDoubleClick?.Invoke(sender, row.Tag!);
        }
    }
}
