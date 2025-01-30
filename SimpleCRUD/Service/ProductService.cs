using System;
using SimpleCRUD.Models;

namespace SimpleCRUD.Service;

public static class ProductService
{
    private static List<Product> _products = new(){
        new Product(){ Id = 1, Name = "Laptop", Price = 10000 },
        new Product(){ Id = 2, Name = "Mouse", Price = 500 },
        new Product(){ Id = 3, Name = "Keyboard", Price = 1000 },
    };

    public static List<Product> AllProducts() => _products.ToList();

    public static void AddProduct(Product product){
        product.Id = _products.Count + 1;
        _products.Add(product);
    }

    public static Product FindProduct(int id) => _products.FirstOrDefault(p => p.Id == id);

    public static void UpdateProduct(Product product){
        var oldProduct = FindProduct(product.Id);
        if(oldProduct != null){
            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
        }
    }

    public static void DeleteProduct(int id){
        var product = FindProduct(id);
        if(product != null){
            _products.Remove(product);
        }
    }

}
