using System;
namespace LibraryTestApi.Model.Reqres
{
    public class UserRegistrationResponseModel
    {
        public int id { get; set; }
        public string token { get; set; }
        public string error { get; set; }
    }
}
