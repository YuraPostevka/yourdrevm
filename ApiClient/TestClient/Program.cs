using IO.Swagger.Api;
using IO.Swagger.Client;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = "http://localhost/webApi/";
             var client = new RestClient(basePath);

            RestRequest req = new RestRequest("Token", Method.POST);
            req.AddParameter("username", "admin@admin.admin");
            req.AddParameter("password", "qwerty");
            req.AddParameter("grant_type", "password");

            var resp = client.Execute(req);

            dynamic data = JObject.Parse(resp.Content);

            var token = data.access_token;

            //var apiCLient = new ApiClient();
            //var itemApi = new ToDoItemApi();

            //itemApi.AddDefaultHeader("Authorization", "bearer " + token);
            //itemApi.Configuration.Password = "qwerty";
            //itemApi.Configuration.Username = "admin@admin.admin";


            //var items = itemApi.ToDoItemGetAll();

            //var rnd = new Random();
            //int id = rnd.Next(items.Count);

            //itemApi.ToDoItemMarkAsCompleted(id);

            //Console.WriteLine("Nice");

            var claimsApi = new ClaimsApi(basePath);
            claimsApi.AddDefaultHeader("Authorization", "bearer " + token);

            var claims = claimsApi.ClaimsGetClaims();
            

            Console.ReadLine();
        }
    }
}
