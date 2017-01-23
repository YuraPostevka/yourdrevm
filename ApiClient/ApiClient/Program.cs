using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //var client = new RestClient("http://localhost:55624/");

            //RestRequest req = new RestRequest("Token", Method.POST);
            //req.AddParameter("username", "admin@admin.admin");
            //req.AddParameter("password", "qwerty");
            //req.AddParameter("grant_type", "password");


            var itemApi = new ToDoItemApi();
            var apiCLient = new ApiClient();

            var _params = new Dictionary<string, string>
            {
                { "username", "admin@admin.admin"},
                {"password", "qwerty" },
                {"grant_type", "password" }
            };
            var reqPath = "/Token";

            var resp = apiCLient.CallApi(reqPath, Method.POST, _params, new object(), new Dictionary<string, string>(),
                new Dictionary<string, string>(), new Dictionary<string, FileParameter>(), new Dictionary<string, string>(), "");


            Configuration c = new Configuration(apiCLient);
            c.AccessToken = "";
            itemApi = new ToDoItemApi(c);


            var items = itemApi.ToDoItemGetAll();

            var rnd = new Random();
            int id = rnd.Next(items.Count);

            itemApi.ToDoItemMarkAsCompleted(id);

            Console.WriteLine("Nice");

            Console.ReadLine();
        }
    }
}
