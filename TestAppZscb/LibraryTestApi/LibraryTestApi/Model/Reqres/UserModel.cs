using System;
namespace LibraryTestApi.Model.Reqres
{
    public class UserModel
    {
        public int id { get; set; }        
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Uri avatar { get; set; }        
    }
}
