using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LibraryTestApi.Model.Httpbin.Auth;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace LibraryTestApi
{
    public class HttpbinClient
    {
        public string Path { get; set; }

        public HttpbinClient(string path)
        {
            Path = path;
        }
        public BasicAuthResponseModel BasicAuth(BasicAuthRequestModel authQuery)
        {
            NetworkCredential myCred = new NetworkCredential(authQuery.user, authQuery.passwd);
            var request = WebRequest.Create($"{Path}/basic-auth/{authQuery.user}/{authQuery.passwd}");
            request.Credentials = myCred;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            BasicAuthResponseModel deserializeList = JsonConvert.DeserializeObject<BasicAuthResponseModel>(responseFromServer);
            reader.Close();
            response.Close();
            return deserializeList;
        }

        public DigestAuthResponseModel DigestAuth(DigestAuthRequestModel authQuery)
        {
            NetworkCredential myCred = new NetworkCredential(authQuery.user, authQuery.passwd);
            var request = WebRequest.Create($"{Path}/digest-auth/{authQuery.qop}/{authQuery.user}/{authQuery.passwd}");
            request.Credentials = myCred;
            using WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            using StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            var deserializeList = JsonConvert.DeserializeObject<DigestAuthResponseModel>(responseFromServer);
            return deserializeList;
        }

        public byte[] GetImage()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest
                .Create("http://httpbin.org/image/jpeg");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            using BinaryReader reader = new BinaryReader(dataStream);
            return reader.ReadBytes(1 * 1024 * 1024 * 10);
        }

    }
}
      

