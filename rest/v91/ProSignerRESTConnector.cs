using Newtonsoft.Json;
using System.Text;
using static secure.logic.client.api.netstd.minimal.rest.v91.APIV91;


namespace secure.logic.client.api.netstd.minimal.rest.v91
{
    public class ProSignerRESTConnector
    {
        public static STATUS_REPLY STATUS(string serverURL, STATUS_REQUEST request, int timeout = 3)
        {
            try
            {
                string requestAsJson = JsonConvert.SerializeObject(request);
                string finalURL = $"{serverURL}/status";
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 0, timeout);
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, finalURL);
                httpRequest.Content = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequest);
                //httpResponse.Wait();
                Task<string> responseAsJson = httpResponse.Result.Content.ReadAsStringAsync();
                STATUS_REPLY rv = JsonConvert.DeserializeObject<STATUS_REPLY>(responseAsJson.Result);
                return rv;
            }
            catch
            {
                return new STATUS_REPLY
                {
                    return_code = 1,
                    return_msg = "Cant make REST call"
                };
            }
        }
        public static API_LOGIN_REPLY API_LOGIN(string serverURL, API_LOGIN_REQUEST request, int timeout = 3)
        {
            try
            {
                string requestAsJson = JsonConvert.SerializeObject(request);
                string finalURL = $"{serverURL}/login";
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 0, timeout);
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, finalURL);
                httpRequest.Content = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequest);
                //httpResponse.Wait();
                Task<string> responseAsJson = httpResponse.Result.Content.ReadAsStringAsync();
                API_LOGIN_REPLY rv = JsonConvert.DeserializeObject<API_LOGIN_REPLY>(responseAsJson.Result);
                return rv;
            }
            catch
            {
                return new API_LOGIN_REPLY
                {
                    return_code = 1,
                    return_msg = "Cant make REST call"
                };
            }
        }
        public static SIGN_PDF_REPLY SIGN_PDF(string serverURL, string accessToken, SIGN_PDF_REQUEST request, int timeout = 3)
        {
            try
            {
                string requestAsJson = JsonConvert.SerializeObject(request);
                string finalURL = $"{serverURL}/signpdf";
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 0, timeout);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, finalURL);
                httpRequest.Content = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequest);
                Task<string> responseAsJson = httpResponse.Result.Content.ReadAsStringAsync();
                SIGN_PDF_REPLY rv = JsonConvert.DeserializeObject<SIGN_PDF_REPLY>(responseAsJson.Result);
                return rv;
            }
            catch
            {
                return new SIGN_PDF_REPLY
                {
                    return_code = 1,
                    return_msg = "Cant make REST call"
                };
            }
        }
        public static SIGN_CMS_REPLY SIGN_CMS(string serverURL, string accessToken, SIGN_CMS_REQUEST request, int timeout = 3)
        {
            try
            {
                string requestAsJson = JsonConvert.SerializeObject(request);
                string finalURL = $"{serverURL}/signcms";
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 0, timeout);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, finalURL);
                httpRequest.Content = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequest);
                Task<string> responseAsJson = httpResponse.Result.Content.ReadAsStringAsync();
                SIGN_CMS_REPLY rv = JsonConvert.DeserializeObject<SIGN_CMS_REPLY>(responseAsJson.Result);
                return rv;
            }
            catch
            {
                return new SIGN_CMS_REPLY
                {
                    return_code = 1,
                    return_msg = "Cant make REST call"
                };
            }
        }
        public static CONFIG_REPLY GET_CONFIG(string serverURL, string accessToken, CONFIG_REQUEST request, int timeout = 3)
        {
            try
            {
                string requestAsJson = JsonConvert.SerializeObject(request);
                string finalURL = $"{serverURL}/config";
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 0, timeout);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, finalURL);
                httpRequest.Content = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequest);
                //httpResponse.Wait();
                Task<string> responseAsJson = httpResponse.Result.Content.ReadAsStringAsync();
                CONFIG_REPLY rv = JsonConvert.DeserializeObject<CONFIG_REPLY>(responseAsJson.Result);
                return rv;
            }
            catch
            {
                return new CONFIG_REPLY
                {
                    return_code = 1,
                    return_msg = "Cant make REST call"
                };
            }

        }
        public static SIGN_XML_REPLY SIGN_XML(string serverURL, string accessToken, SIGN_XML_REQUEST request, int timeout = 3)
        {
            try
            {
                string requestAsJson = JsonConvert.SerializeObject(request);
                string finalURL = $"{serverURL}/signxml";
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 0, timeout);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, finalURL);
                httpRequest.Content = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequest);
                Task<string> responseAsJson = httpResponse.Result.Content.ReadAsStringAsync();
                SIGN_XML_REPLY rv = JsonConvert.DeserializeObject<SIGN_XML_REPLY>(responseAsJson.Result);
                return rv;
            }
            catch
            {
                return new SIGN_XML_REPLY
                {
                    return_code = 1,
                    return_msg = "Cant make REST call"
                };
            }
        }
        public static SIGN_HASH_REPLY SIGN_HASH(string serverURL, string accessToken, SIGN_HASH_REQUEST request, int timeout = 3)
        {
            try
            {
                string requestAsJson = JsonConvert.SerializeObject(request);
                string finalURL = $"{serverURL}/signhash";
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 0, timeout);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, finalURL);
                httpRequest.Content = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequest);
                Task<string> responseAsJson = httpResponse.Result.Content.ReadAsStringAsync();
                SIGN_HASH_REPLY rv = JsonConvert.DeserializeObject<SIGN_HASH_REPLY>(responseAsJson.Result);
                return rv;
            }
            catch
            {
                return new SIGN_HASH_REPLY
                {
                    return_code = 1,
                    return_msg = "Cant make REST call"
                };
            }
        }
        internal static SIGN_CONFIG_REPLY GET_SIGN_CONFIG(string serverURL, string accessToken, SIGN_CONFIG_REQUEST request, int timeout = 3)
        {
            try
            {
                string requestAsJson = JsonConvert.SerializeObject(request);
                string finalURL = $"{serverURL}/signconfig";
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 0, timeout);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, finalURL);
                httpRequest.Content = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequest);
                //httpResponse.Wait();
                Task<string> responseAsJson = httpResponse.Result.Content.ReadAsStringAsync();
                SIGN_CONFIG_REPLY rv = JsonConvert.DeserializeObject<SIGN_CONFIG_REPLY>(responseAsJson.Result);
                return rv;
            }
            catch
            {
                return new SIGN_CONFIG_REPLY
                {
                    return_code = 1,
                    return_msg = "Cant make REST call"
                };
            }
        }
    }
}
