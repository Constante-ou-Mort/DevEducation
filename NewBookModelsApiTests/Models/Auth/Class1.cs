using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBookModelsApiTests.Models.Auth
{
    public class ResponseModel<T>
    {
        public T Model { get; set; }
        public IRestResponse Response { get; set; }
    }
}
