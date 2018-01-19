using System;
using System.Linq;

namespace DotNetMEF
{
    class Program
    {
        struct ItemCategory
        {
            T_TodoItems Item { get; set; }
            T_Category Category { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
        
            using (var db = new TodoItemsContext())
            {
                
                // Display all TodoItems from the database 
                var query = from b in db.T_TodoItems
                            orderby b.Name
                            select b;

                Console.WriteLine("All todo-items in the database:");
                Console.WriteLine();
                foreach (var item in query)
                {
                    Console.WriteLine("  > " +item.Name);
                }
                Console.WriteLine();

                // Query LINQ style
                var query2 =
                           from item in db.T_TodoItems
                           join category in db.T_Category on item.Category equals category.ID
                           select new { Item = item, Category = category };

                Console.WriteLine();
                Console.WriteLine("All todo-items in the database with their category:");
                Console.WriteLine();
                foreach (var item in query2)
                {
                    Console.WriteLine("  > " + item.Item.ID + " " + item.Item.Name + " (" + item.Category.Category +")");
                }
                Console.WriteLine();

                // Query Functional Style (Lambda)
                var filtered = query2.Where(item => item.Category.Category == "Svago");

                Console.WriteLine();
                Console.WriteLine("All todo-items in the database with category=:");
                Console.WriteLine();
                foreach (var item in filtered)
                {
                    Console.WriteLine("  > " + item.Item.ID + " " + item.Item.Name + " (" + item.Category.Category + ")");
                }
                Console.WriteLine();


                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

            }
        }
    }
}
