using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Entities;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{

	[OperationContract]

	List<Products> GetAllProducts();
	[OperationContract]
    Products GetProduct(int id);
    [OperationContract]
    void AddProduct(Products product);
    [OperationContract]
    void UpdateProduct(Products product);
    [OperationContract]
    void DeleteProduct(int id);

    ///////CATEGORIAS
    [OperationContract]
    List<Categories> GeAllCategories();
    [OperationContract]

    Categories GetCategory(int id);

    [OperationContract]

    void AddCategory(Categories category);

    [OperationContract]

    void UpdateCategory(Categories category);

    [OperationContract]

    void DeleteCategory(int id);

}
