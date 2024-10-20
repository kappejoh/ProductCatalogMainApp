using Microsoft.VisualBasic;
using ProductCatalogResources.Models;
using ProductCatalogResources.Services;
using System;

namespace ProductCatalogMainApp.Menus;
public static class MenuService
{

    private static readonly ProductService _productService = new ProductService();


    private static void CreateProductMenu()
    {
        var product = new Product();

        Console.Clear();
        Console.WriteLine("--- CREATE NEW PRODUCT ---");

        Console.Write("Enter product name: ");
        product.ProductName = Console.ReadLine() ?? "";

        Console.Write("Enter product price: ");
        product.ProductPrice = Console.ReadLine() ?? "";

        var response = _productService.CreateProduct(product);
        Console.WriteLine(response.Message);
        Console.WriteLine($"Product ID: {product.ProductId}");

        Console.WriteLine("Press any key to continue.");

    }

    private static void ListAllProductsMenu()
    {
        Console.Clear();
        Console.WriteLine("--- PRODUCT LIST ---");

        var products = _productService.GetAllProducts();
        if (products != null)
        {
            foreach (var product in _productService.GetAllProducts())
            {
                Console.WriteLine($"{product.ProductName} // {product.ProductPrice} // Product ID: {product.ProductId}");
            }
        }
        else
        {
            Console.WriteLine("No product was found");
        }

        Console.WriteLine("Press any key to continue.");
    }

    private static string RemoveProductMenu()
    {
        Console.Clear();
        Console.WriteLine("--- Remove product from the list ---");

        var products = _productService.GetAllProducts();
        if (products != null)
        {
            foreach (var product in _productService.GetAllProducts())
            {
                Console.WriteLine($"{product.ProductName} // {product.ProductPrice} // Product ID: {product.ProductId}");
            }
        }
        else
        {
            Console.WriteLine("No product was found");
        }

        Console.Write("Copy and enter product ID to remove: ");
        var productId = Console.ReadLine() ?? "";

       var result = _productService.RemoveProduct(productId);


        Console.WriteLine(result.Message);

        Console.WriteLine("Press any key to continue.");

        return productId!;

    }

    private static void ExitApplicationMenu()
    {
        Console.Clear();
        Console.Write("Are you sure you want to exit? (y/n)");
        var answer = Console.ReadLine() ?? "";
        if (answer.ToLower() == "y")
            Environment.Exit(0);
    }

    private static bool MenuOptions(string selectedOption)
    {
        if (int.TryParse(selectedOption, out int option))
        {
            switch (option)
            {
                case 1:
                    CreateProductMenu();
                    Console.ReadKey();
                    break;

                case 2:
                    ListAllProductsMenu();
                    Console.ReadKey();
                    break;

                case 3:
                    RemoveProductMenu();
                    break;

                case 0:
                    ExitApplicationMenu();
                    break;

                default:
                    Console.WriteLine("Invalid option selected");
                    return false;
            }

            return true;
        }

        return false;
    }


    public static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Add a new product");
        Console.WriteLine("2. List all products");
        Console.WriteLine("3. Remove a product from the list");
        Console.WriteLine("0. Exit");

        Console.WriteLine("Enter an option: ");
        MenuOptions(Console.ReadLine() ?? "");

        var result = MenuOptions(Console.ReadLine() ?? "");
        if (result == false)
        {
            Console.WriteLine("Invalid option selected");
        }
    }
}