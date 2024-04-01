using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace Equipments.Api
{
    public class ApiService : ApiClient
    {
        public ApiService(string baseAddress) : base(baseAddress)
        {

        }
    }
}
