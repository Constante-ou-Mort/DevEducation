using RestSharp;

namespace NewBookModelsApiTests.Models
{
    public class ResponseModel<T>
    {
        public T Model { get; set; }
        public IRestResponse Response { get; set; }
    }
}
