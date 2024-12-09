using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using DAL;
using Entities;

namespace BLL
{
    public class CategoriesLogic
    {
        public Categories Create(Categories category)
        {
            Categories _categories = null;
            using (var repository = RepositoryFactory.CreateRepository())
            {
                Categories _result = repository.Retrieve<Categories>(c => c.CategoryName == category.CategoryName);
                if (_result == null)
                {
                    _categories = repository.Create<Categories>(category);
                }
                else
                {

                }
            }
            return _categories;
        }

        public Categories RetrieveById(int id)
        {
            Categories _categories = null;
            using (var repository = RepositoryFactory.CreateRepository())
            {
                _categories = repository.Retrieve<Categories>(c => c.CategoryID == id);
            }
            return _categories;
        }
        public bool Update(Categories category)
        {
            bool _updated = false;
            using (var repository = RepositoryFactory.CreateRepository())
            {
                Categories _result = repository.Retrieve<Categories>(c => c.CategoryID == category.CategoryID);
                if (_result != null)
                {
                    _updated = repository.Update<Categories>(category);
                }
            }
            return _updated;
        }

        public bool Delete(int id)
        {
            bool _deleted = false;
            var _category = RetrieveById(id);
            if (_category != null)
            {
                using (var repository = RepositoryFactory.CreateRepository())
                {
                    _deleted = repository.Delete<Categories>(_category);
                }
            }
            return _deleted;
        }
        public List<Categories> Filter(string name)
        {
            List<Categories> _categories = null;
            using (var repository = RepositoryFactory.CreateRepository())
            {
                _categories = repository.Filter<Categories>(c => c.CategoryName.Contains(name));
            }
            return _categories;
        }
        public List<object> RetrieveAll()
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                 var _categories = repository.Filter<Categories>(c => true);
                return _categories.Select(c => new
                {
                    c.CategoryID,
                    c.CategoryName,
                    c.Description
                }).ToList<object>();
            }

        }
        //serializacion a XML
        public string RetrieveAllAsXmlC()
        {
            try
            {
                var categories = RetrieveAll(); // Llama al método que obtiene todos los productos
                if (categories == null || categories.Count == 0)
                {
                    return "<Categories></Categories>"; // Devuelve una lista vacía en formato XML
                }

                // Serializa la lista de productos
                var serializer = new XmlSerializer(typeof(List<Categories>));
                using (var stringWriter = new StringWriter())
                {
                    serializer.Serialize(stringWriter, categories);
                    return stringWriter.ToString(); // Devuelve el XML como cadena
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al serializar categories a XML.", ex);
            }
        }
    }
}
