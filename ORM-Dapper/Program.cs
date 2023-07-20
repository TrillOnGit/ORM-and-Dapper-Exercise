using System.Configuration;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string? connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var departmentRepo = new DapperDepartmentRepository(conn);

            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
                Console.WriteLine();
                
            }
            
            var productRepo = new DapperProductRepository(conn);

            var products = productRepo.GetAllProducts();

            //productRepo.CreateProduct("test", 999.99, 1);
            
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine("ID: " + product.ProductID);
                Console.WriteLine("$" + product.Price);
                Console.WriteLine($"{product.StockLevel} units remaining");
                // if (product.Name == "test")
                // {
                //     Console.WriteLine(product.Name);
                //     Console.WriteLine("ID: " + product.ProductID);
                //     Console.WriteLine("$" + product.Price);
                //     Console.WriteLine($"{product.StockLevel} units remaining");
                // }
            }
        }
    }
}
