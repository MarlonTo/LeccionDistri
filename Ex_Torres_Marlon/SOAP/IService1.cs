using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SOAP.conf;

namespace SOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Task1> GetTareas();
        [OperationContract]
        Task1 GetTareaID(int id);
        [OperationContract]
        bool InsertarTarea(Task1 Tareas);

        [OperationContract]
        void ActualizarTarea(Task1 Tareas);
        [OperationContract]
        void EliminarTarea(int id);
    }
}
