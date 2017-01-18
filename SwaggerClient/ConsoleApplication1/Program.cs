using IO.Swagger.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoItemApi api = new ToDoItemApi();
            var items = api.ToDoItemGetAll();

            var id = 1;

            api.ToDoItemMarkAsCompleted(id);
        }
    }
}
