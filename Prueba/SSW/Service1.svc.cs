using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using BLL;
using Entities;

namespace SSW
{
    public class Service1 : IService1
    {
        private readonly ProductsLogic _logic = new ProductsLogic();
        private readonly CategoriesLogic _logicC = new CategoriesLogic();

        public Categories CreateCategory(Categories category)
        {
            throw new NotImplementedException();
        }

        public Products CreateProduct(Products product)
        {
            try
            {
                return _logic.Create(product);
            }
            catch (Exception ex)
            {
                throw new FaultException($"Error al crear el producto: {ex.Message}");
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _logic.Delete(id);
            }
            catch (Exception ex)
            {
                throw new FaultException($"Error al eliminar el producto: {ex.Message}");
            }
        }

        public bool DeleteC(int id)
        {
            throw new NotImplementedException();
        }

        public string RetrieveAllC()
        {
            try
            {
                // Llama al método RetrieveAllAsXml que devuelve XML como string
                return _logicC.RetrieveAllAsXmlC();
            }
            catch (Exception ex)
            {
                throw new FaultException($"Error al recuperar productos: {ex.Message}");
            }
        }

        public string RetrieveAllP()
        {
            try
            {
                // Llama al método RetrieveAllAsXml que devuelve XML como string
                return _logic.RetrieveAllAsXml();
            }
            catch (Exception ex)
            {
                throw new FaultException($"Error al recuperar productos: {ex.Message}");
            }
        }

        public Products RetrieveById(int id)
        {
            try
            {
                return _logic.RetrieveById(id);
            }
            catch (Exception ex)
            {
                throw new FaultException($"Error al recuperar el producto por ID: {ex.Message}");
            }
        }

        public Categories RetrieveByIdC(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Products product)
        {
            try
            {
                return _logic.Update(product);
            }
            catch (Exception ex)
            {
                throw new FaultException($"Error al actualizar el producto: {ex.Message}");
            }
        }

        public bool UpdateC(Categories category)
        {
            throw new NotImplementedException();
        }
    }
}

