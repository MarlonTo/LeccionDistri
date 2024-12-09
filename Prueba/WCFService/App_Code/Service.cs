using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
    private Sales_DBEntities _db = new Sales_DBEntities();
    public void AddCategory(Categories category)
    {
        throw new NotImplementedException();
    }

    public void AddProduct(Products product)
    {
        throw new NotImplementedException();
    }

    public void DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public List<Categories> GeAllCategories()
    {
        return _db.Categories.ToList();
    }

    public List<Products> GetAllProducts()
    {
        return _db.Products.ToList();
    }

    public Categories GetCategory(int id)
    {
        return _db.Categories.Find(id);
    }

    public Products GetProduct(int id)
    {
        return _db.Products.Find(id);
    }

    public void UpdateCategory(Categories category)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(Products product)
    {
        throw new NotImplementedException();
    }
}
