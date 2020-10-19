using System;
using System.Collections.Generic;
namespace LibraryTestApi.Model.Reqres
{
    public class ListUsersModel
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<UserModel> data { get; set; }
        public AdModel ad { get; set; }

    }
    
}
