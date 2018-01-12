using System;
using System.Linq;

namespace DotNetMEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello MEF world");
        
            using (var db = new TodoItemsContext())
            {
                
                // Display all Blogs from the database 
                var query = from b in db.T_TodoItems
                            orderby b.Name
                            select b;

                Console.WriteLine("All todo-items in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

            }
        }
    }
}
