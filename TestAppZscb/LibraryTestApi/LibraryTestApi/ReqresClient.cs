using System;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Net.Http.Headers;
using LibraryTestApi.Model.Reqres;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LibraryTestApi
{
    public class ReqresClient
    {        
        public string Path { get; set; }

        public ReqresClient(string path)
        {
            Path = path;
        }
        public async Task<ListUsersModel> GetListUsers(int pageNumber)
        {
            using var client = new HttpClient();
            var content = await client.GetStringAsync($"{Path}/api/users?page={pageNumber}");
            ListUsersModel deserializeList = JsonConvert.DeserializeObject<ListUsersModel>(content);
            return deserializeList;

        }

        public async Task<UserCreateResponseModel> CreateUser (UserCreateRequestModel user)
        {
            using var client = new HttpClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(user, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"{Path}/api/users", stringContent);
            var responseUser = JsonConvert.DeserializeObject<UserCreateResponseModel>(await response.Content.ReadAsStringAsync());
            return responseUser;
        }

        public async Task<UserUpdateResponseModel> PutUpdateUser (UserUpdateRequestModel user)
        {
            using (var client = new HttpClient())
            {                
                var stringContent = new StringContent(JsonConvert.SerializeObject(user, Formatting.Indented),Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"{Path}/api/users{user.id}", stringContent);    
                var responseUser = JsonConvert.DeserializeObject<UserUpdateResponseModel>(await response.Content.ReadAsStringAsync());
                return responseUser;
            }
        }
                        
        public async Task<UserUpdateResponseModel> PatchUpdateUser(UserUpdateRequestModel user)
        {
            using var client = new HttpClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(user, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{Path}/api/users{user.id}", stringContent);
            var responseUser = JsonConvert.DeserializeObject<UserUpdateResponseModel>(await response.Content.ReadAsStringAsync());
            return responseUser;
        }

        public async Task<UserRegistrationResponseModel> Register(UserRegistrationRequestModel user)
        {
            using var client = new HttpClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{Path}/api/register", stringContent);
            //response.EnsureSuccessStatusCode();
            var responseUser = JsonConvert.DeserializeObject<UserRegistrationResponseModel>(await response.Content.ReadAsStringAsync());
            return responseUser;

        }

        public async Task<ListUsersModel> GetListUsersDelay(int delay)
        {

            using var client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(delay + 1)
            };
            var content = await client.GetStringAsync($"{Path}/api/users?delay={delay}");
            ListUsersModel deserializeList = JsonConvert.DeserializeObject<ListUsersModel>(content);
            return deserializeList;

        }

    }
}
