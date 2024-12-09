using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SOAP.Modelo;

namespace SOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Producto> Get();

        [OperationContract]
        Producto GetProductoById(int Id);

        [OperationContract]
        bool InsertProducto(Producto Products);

        [OperationContract]
        void UpdateProducto(Producto Products);

        [OperationContract]
        void DeleteProducto(int Id);

        //Categoria
        [OperationContract]
        List<Categoria> GetCategoria();
        [OperationContract]
        Categoria GetCategoriaById(int Id);
        [OperationContract]
        bool InsertCategoria(Categoria Categorie);
        [OperationContract]
        void UpdateCategoria(Categoria Categoria);
        [OperationContract]
        void DeleteCategoria(int Id);
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]

    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }


}
