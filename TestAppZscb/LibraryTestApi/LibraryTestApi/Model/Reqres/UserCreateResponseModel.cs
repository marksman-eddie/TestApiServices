using System;
namespace LibraryTestApi.Model.Reqres
{
    public class UserCreateResponseModel
    {
        public int id { get; set; }
        public string job { get; set; }
        public string name { get; set; }
        public DateTime createdAt { get; set; }
    }
}
