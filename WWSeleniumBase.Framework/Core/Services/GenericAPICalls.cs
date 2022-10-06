using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using System.Text.Json.Nodes;

namespace SeleniumBase.Framework.Core.Services
{
    public class GenericAPICalls
    {

        public static RestResponse Get(string BaseUrl,HttpStatusCode httpStatusCode)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(Method.Get.ToString());
            request.AddHeader("Content-Type", "application/json");
            var response = client.Get(request);
            Assert.AreEqual(httpStatusCode, response.StatusCode);
            if (httpStatusCode == HttpStatusCode.OK)
            {
                Assert.AreEqual(true, response.IsSuccessful);
            }
            else 
            {
                Assert.AreEqual(false, response.IsSuccessful);
            }
            return response;

        }


        public static RestResponse Post(string BaseUrl,JsonObject Body,HttpStatusCode httpStatusCode)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(Method.Post.ToString());
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", Body, ParameterType.RequestBody);
            var response = client.Post(request);
            Assert.AreEqual(response.StatusCode, httpStatusCode);
            Assert.AreEqual(true, response.IsSuccessful);
            return response;

        }

        public static RestResponse Delete(string BaseUrl, string Token, HttpStatusCode httpStatusCode)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(Method.Delete.ToString());
            request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Authorization", $"Bearer {Token}");
            var response = client.Delete(request);
            Assert.AreEqual(response.StatusCode, httpStatusCode);
            Assert.AreEqual(true, response.IsSuccessful);
            return response;

        }
    }
}
