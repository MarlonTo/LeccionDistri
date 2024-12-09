using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Entities;
using DAL;

namespace SSW
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string RetrieveAllP();
        [OperationContract]
        Products RetrieveById(int id);
        [OperationContract]
        Products CreateProduct(Products product);
        [OperationContract]
        bool Update(Products product);
        [OperationContract]
        bool Delete(int id);

        //Categories

        [OperationContract]

        string RetrieveAllC();
        [OperationContract]
        Categories RetrieveByIdC(int id);
        [OperationContract]
        Categories CreateCategory(Categories category);
        [OperationContract]
        bool UpdateC(Categories category);
        [OperationContract]
        bool DeleteC(int id);

        // TODO: agregue aquí sus operaciones de servicio
    }
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }
        [DataMember]
        public int UnitsInStock { get; set; }
    }

    [DataContract]

    public class Category
    {
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
    }

}
