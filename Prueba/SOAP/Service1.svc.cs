using SOAP.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace SOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        private readonly Sales_DBEntities DBContext = new Sales_DBEntities();
        public void DeleteCategoria(int Id)
        {
            var entity =new Categories { CategoryID = Id };

            DBContext.Categories.Attach(entity);
            DBContext.Categories.Remove(entity);
            DBContext.SaveChanges();
        }

        public void DeleteProducto(int Id)
        {
            var entity = new Products { ProductID = Id };
            DBContext.Products.Attach(entity);
            DBContext.Products.Remove(entity);
            DBContext.SaveChanges();
        }

        public List<Producto> Get()
        {
            return DBContext.Products.Select(x => new Producto
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                CategoryID = x.CategoryID,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock
            }).ToList();
        }

        public List<Categoria> GetCategoria()
        {
            return DBContext.Categories.Select(x => new Categoria
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName
            }).ToList();
        }

        public Categoria GetCategoriaById(int Id)
        {
            return DBContext.Categories.Select(x => new Categoria
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName
            }).FirstOrDefault(x => x.CategoryID == Id);
        }

        public Producto GetProductoById(int Id)
        {
            return DBContext.Products.Select(x => new Producto
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                CategoryID = x.CategoryID,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock
            }).FirstOrDefault(x => x.ProductID == Id);
        }

        public bool InsertCategoria(Categoria Categories)
        {
            var entity = new Categories
            {
                CategoryID = Categories.CategoryID,
                CategoryName = Categories.CategoryName,
                Description = Categories.Description
            };
            DBContext.Categories.Add(entity);
            DBContext.SaveChanges();
            return true;
        }

        public bool InsertProducto(Producto Products)
        {
            var entity = new Products
            {
                ProductID = Products.ProductID,
                ProductName = Products.ProductName,
                CategoryID = Products.CategoryID,
                UnitPrice = Products.UnitPrice,
                UnitsInStock = Products.UnitsInStock
            };
            DBContext.Products.Add(entity);
            DBContext.SaveChanges();
            return true;
        }

        public void UpdateCategoria(Categoria Categories)
        {
            var entity = DBContext.Categories.FirstOrDefault(x => x.CategoryID == Categories.CategoryID);
            entity.CategoryName = Categories.CategoryName;
            entity.Description = Categories.Description;
            DBContext.SaveChangesAsync();
        }

        public void UpdateProducto(Producto Products)
        {
            var entity = DBContext.Products.FirstOrDefault(x => x.ProductID == Products.ProductID);
            entity.ProductName = Products.ProductName;
            entity.CategoryID = Products.CategoryID;
            entity.UnitPrice = Products.UnitPrice;
            entity.UnitsInStock = Products.UnitsInStock;
            DBContext.SaveChangesAsync();
        }


    }
}
