using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

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

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            #region Department Section
            //var departmentRepo = new DapperDepartmentRepository(conn);

            ////departmentRepo.InsertDepartment("John's New Department");

            //var departments = departmentRepo.GetAllDepartments();

            //foreach (var department in departments)
            //{
            //    Console.WriteLine(department.DepartmentID);
            //    Console.WriteLine(department.Name);
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}
            #endregion

            #region Product section
            var productRepository = new DapperProductRepository(conn);

            ///productRepository.CreateProduct("Castlevania: Curse of Darkness", 19.99, 3);

            //var productToUpdate = productRepository.GetProduct(941);

            //productToUpdate.Name = "Castlevania: Curse of Darkness UPDATED";
            //productToUpdate.Price = 24.99;
            //productToUpdate.CategoryID = 4;
            //productToUpdate.OnSale = true;
            //productToUpdate.StockLevel = 9001;

            //productRepository.UpdateProduct(productToUpdate);

            //productRepository.DeleteProduct(941);

            var products = productRepository.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }
            #endregion

        }
    }
}
