using System;
namespace LibraryTestApi.Model.Httpbin.Auth
{
    public class DigestAuthRequestModel
    {
        public string qop { get; set; }
        public string user { get; set; }
        public string passwd { get; set; }
    }
}
