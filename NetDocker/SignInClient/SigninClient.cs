using System.Net.Http.Json;
using SignInClient.Interfaces;

namespace WebDevTest_Client
{
    public class SigninClient(HttpClient httpClient) : ISigninClient
    {
        public static string USER = "user";
        private static string SIGNIN = "signin";

        public async Task<bool> SignInAsync(string username, string password)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, USER + "/" +SIGNIN);
            var result = await httpClient.SendAsync(httpRequest);

            result.EnsureSuccessStatusCode();

            var res = await result.Content.ReadFromJsonAsync<bool>();

            return res;
        }

    }
}
