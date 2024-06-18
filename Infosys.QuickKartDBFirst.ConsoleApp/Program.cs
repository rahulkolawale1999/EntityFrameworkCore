using Infosys.DBFirstCore.DataAccessLayer;
using Infosys.DBFirstCore.DataAccessLayer.Models;

namespace Infosys.QuickKartDBFirst.ConsoleApp
{
    public class Program
    {
        static QuickKartRepository repository;
        static QuickKartDbContext context;
        static Program()
        {
            context = new QuickKartDbContext();
            repository=new QuickKartRepository(context);
        }

        static void Main(string[] args)
        {
            //var categories=repository.GetAllCategories();
            //foreach(var category in categories)
            //{
            //    Console.WriteLine("{0}\t\t{1}", category.CategoryId, category.CategoryName);
            //}
            //byte categoryId = 1;
            //List<Product> lstproducts = repository.GetProductOnCategoryId(categoryId);
            //if (lstproducts.Count == 0)
            //{
            //    Console.WriteLine("No products available under the category = " + categoryId);
            //}
            //else
            //{
            //    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ProductId", "ProductName", "CategoryId", "Price", "QuantityAvailable");
            //    Console.WriteLine("---------------------------------------------------------------------------------------");
            //    foreach (var product in lstproducts)
            //    {
            //        Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", product.ProductId, product.ProductName, product.CategoryId, product.Price, product.QuantityAvailable);
            //    }
            //}

            //Product product = repository.FilterProduct(categoryId);
            //if (product == null)
            //{
            //    Console.WriteLine("No product details available");
            //}
            //else
            //{
            //    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ProductId", "ProductName", "CategoryId", "Price", "QuantityAvailable");
            //    Console.WriteLine("---------------------------------------------------------------------------------------");
            //    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", product.ProductId, product.ProductName, product.CategoryId, product.Price, product.QuantityAvailable);
            //}

            //string pattern="BMW%";
            //List<Product> p = new List<Product>();
            //p = repository.FilterProductUsingLike(pattern);
            //if (p.Count == 0 ) {
            //    Console.WriteLine("No pattern matching product found");
            //}
            //else
            //{
            //    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ProductId", "ProductName", "CategoryId", "Price", "QuantityAvailable");
            //    Console.WriteLine("---------------------------------------------------------------------------------------");
            //    foreach (var product in p)
            //    {
            //        Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", product.ProductId, product.ProductName, product.CategoryId, product.Price, product.QuantityAvailable);
            //    }
            //}

            //List<User> u=repository.GetAllUser();
            //if(u.Count==0)
            //{
            //    Console.WriteLine("No users available");
            //}
            //else
            //{
            //    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4,-15}{4}", "Email", "UserPassword", "RoleId", "Gender", "Address");
            //    Console.WriteLine("---------------------------------------------------------------------------------------");
            //    foreach (var product in u)
            //    {
            //        Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4,-15}{4}", product.EmailId, product.UserPassword, product.RoleId, product.Gender, product.Address);
            //    }
            //}


            byte categoryId = 0;
            int returnResult = repository.AddCategoryDetailsUsingUSP("Footwear", out categoryId);
            if (returnResult > 0)
            {
                Console.WriteLine("Category details added successfully with CategoryId = " + categoryId);
                
            }
            else
            {
                Console.WriteLine("Some error occurred. Try again!");
                
            }
        }
    }
}
