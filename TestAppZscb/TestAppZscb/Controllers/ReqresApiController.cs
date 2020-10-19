using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryTestApi.Model.Reqres;
using LibraryTestApi;

namespace TestAppZscb.Controllers
{
    [Route("api/[controller]")]
    public class ReqresApiController : Controller
    {
        private readonly ReqresClient _client;

        public ReqresApiController(ReqresClient client) => _client = client;
        [HttpGet("getListUsers")]
        public async Task<ListUsersModel> GetListUsers(int pageNumber)
        {
            return await _client.GetListUsers(pageNumber);
        }

        [HttpPost("createUser")]
        public async Task<UserCreateResponseModel> CreateUser(UserCreateRequestModel user)
        {
            return await _client.CreateUser(user);
        }

        [HttpPut("putUpdateUser")]
        public async Task<UserUpdateResponseModel> PutUpdateUser(UserUpdateRequestModel user)
        {
            return await _client.PutUpdateUser(user);
        }

        [HttpPatch("patchUpdateUser")]
        public async Task<UserUpdateResponseModel> PatchUpdateUser(UserUpdateRequestModel user)
        {
            return await _client.PatchUpdateUser(user);
        }

        [HttpPost("register")]
        public async Task<UserRegistrationResponseModel> Register(UserRegistrationRequestModel user)
        {
            return await _client.Register(user);
        }

        [HttpGet("getListUsersDelay")]
        public async Task<ListUsersModel> GetListUsersDelay(int delay)
        {
            return await _client.GetListUsersDelay(delay);
        }


    }
}
