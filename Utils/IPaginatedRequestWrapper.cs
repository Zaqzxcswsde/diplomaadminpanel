using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace diplomaadminpanel.Utils
{
    internal interface IPaginatedRequestWrapper : IDisposable
    {
        Task<HttpStatusCode> FetchCurrentPage();
        Task<HttpStatusCode> FetchNextPage();
        Task<HttpStatusCode> FetchPreviousPage();
    }
}
