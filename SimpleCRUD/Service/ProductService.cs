using System;
using SimpleCRUD.Data;
using SimpleCRUD.Models;

namespace SimpleCRUD.Service;

public class ProductService
{
    private readonly ApplicationDbContext _context;
    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    // private static List<Product> _products = new(){
    //     new Product(){ Id = 1, Name = "Laptop", Price = 10000 },
    //     new Product(){ Id = 2, Name = "Mouse", Price = 500 },
    //     new Product(){ Id = 3, Name = "Keyboard", Price = 1000 },
    // };

    public List<Product> AllProducts() => _context.Products.ToList();

    public void AddProduct(Product product)
    {
        try
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public Product FindProduct(int id) => _context.Products.FirstOrDefault(p => p.Id == id);

    public void UpdateProduct(Product product)
    {
        try
        {
            var oldProduct = FindProduct(product.Id);
            if (oldProduct != null)
            {
                oldProduct.Name = product.Name;
                oldProduct.Price = product.Price;
                _context.Products.Update(product);
                _context.SaveChanges();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


    }

    public void DeleteProduct(int id)
    {
        try
        {
            var product = FindProduct(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
