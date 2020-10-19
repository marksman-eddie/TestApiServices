using System;
namespace LibraryTestApi.Model.Httpbin.Auth
{
    public class BasicAuthRequestModel
    {
        public string user { get; set; }
        public string passwd { get; set; }
    }
}
