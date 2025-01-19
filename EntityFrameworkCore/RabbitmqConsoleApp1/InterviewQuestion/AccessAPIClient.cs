
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LearningConsoleApp.InterviewQuestion
{
    internal class AccessAPIClient
    {
        public async Task callapi() {

            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("https://jsonplaceholder.typicode.com/todos/1"); //URI  
                Console.WriteLine(Environment.NewLine + result);
            }


            try
            {

                using (var client = new HttpClient())
                {
                    string reqUrl = $"https://jsonplaceholder.typicode.com/todos/1";
                    HttpResponseMessage httpResponseMessage = await client.GetAsync(reqUrl);
                    var response = httpResponseMessage;
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();

                    }


                }



            }
            catch (Exception ex) { }
        }

        public async Task<object> TestMethod(TestModel model)
        {
            try
            {
                //TestModel apicallObject = new
                //{
                //    Id = model.Id,
                //    name = model.name
                //};
                string _token = "";
                string _url = "";
                if (model != null)
                {
                    var bodyContent = JsonConvert.SerializeObject(model);
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(bodyContent.ToString(), Encoding.UTF8, "application/json");
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        client.DefaultRequestHeaders.Add("access-token", _token); // _token = access token
                        var response = await client.PostAsync(_url, content); // _url =api endpoint url
                        if (response != null)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();

                            try
                            {
                                var result = JsonConvert.DeserializeObject<TestModel>(jsonString); // TestModel2 = deserialize object
                            }
                            catch (Exception e)
                            {
                                //msg
                                throw e;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}
