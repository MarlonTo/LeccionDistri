using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
using System.Xml.Serialization;
using System.IO;

namespace BLL
{
    public class ProductsLogic
    {
        public Products Create(Products product)
        {
            try
            {
                using (var repository = RepositoryFactory.CreateRepository())
                {
                    var existingProduct = repository.Retrieve<Products>(p => p.ProductName == product.ProductName);
                    if (existingProduct == null)
                    {
                        return repository.Create<Products>(product);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción o registrar el error
                throw new Exception("Error al crear el producto.", ex);
            }
            return null;
        }

        public Products RetrieveById(int id)
        {
            try
            {
                using (var repository = RepositoryFactory.CreateRepository())
                {
                    return repository.Retrieve<Products>(p => p.ProductID == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar el producto por ID.", ex);
            }
        }

        public bool Update(Products product)
        {
            try
            {
                using (var repository = RepositoryFactory.CreateRepository())
                {
                    var existingProduct = repository.Retrieve<Products>(p => p.ProductID == product.ProductID);
                    if (existingProduct != null)
                    {
                        return repository.Update<Products>(product);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el producto.", ex);
            }
            return false;
        }

        public bool Delete(int id)
        {
            try
            {
                var product = RetrieveById(id);
                if (product != null)
                {
                    using (var repository = RepositoryFactory.CreateRepository())
                    {
                        return repository.Delete<Products>(product);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto.", ex);
            }
            return false;
        }

        public List<Products> Filter(string name)
        {
            try
            {
                using (var repository = RepositoryFactory.CreateRepository())
                {
                    return repository.Filter<Products>(p => p.ProductName.Contains(name));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar productos.", ex);
            }
        }

        public List<Products> RetrieveAll()
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                // Devuelve una lista de instancias de Products
                return repository.Filter<Products>(p => p.ProductID > 0).ToList();
            }
        }
        public string RetrieveAllAsXml()
        {
            try
            {
                var products = RetrieveAll(); // Llama al método que obtiene todos los productos
                if (products == null || products.Count == 0)
                {
                    return "<Products></Products>"; // Devuelve una lista vacía en formato XML
                }

                // Serializa la lista de productos
                var serializer = new XmlSerializer(typeof(List<Products>));
                using (var stringWriter = new StringWriter())
                {
                    serializer.Serialize(stringWriter, products);
                    return stringWriter.ToString(); // Devuelve el XML como cadena
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al serializar productos a XML.", ex);
            }
        }
    }

}

