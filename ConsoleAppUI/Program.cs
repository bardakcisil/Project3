using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleAppUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ProductTest();
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }

        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            foreach (var product in productManager.GetAllByUnitPrice(4, 100))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
