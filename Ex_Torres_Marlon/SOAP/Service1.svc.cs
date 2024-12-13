using SOAP.conf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        private readonly tarea_soapEntities DBContext = new tarea_soapEntities();
        public void ActualizarTarea(Task1 Tareas)
        {
            var entity = DBContext.Tareas.FirstOrDefault(x => x.TareaID == Tareas.TareaID);
            entity.ProyectoID = Tareas.ProyectoID;
            entity.Descripcion = Tareas.Descripcion;
            entity.Estado = Tareas.Estado;
            entity.FechaLimite = Tareas.FechaLimite;
            DBContext.SaveChangesAsync();
        }

        public void EliminarTarea(int id)
        {
            var entity = DBContext.Tareas.FirstOrDefault(x => x.TareaID == id);
            DBContext.Tareas.Remove(entity);
            DBContext.SaveChangesAsync();
        }

        public Task1 GetTareaID(int id)
        {
            return DBContext.Tareas.Select(x => new Task1
            {
                TareaID = x.TareaID,
                ProyectoID = x.ProyectoID,
                Descripcion = x.Descripcion,
                Estado = x.Estado,
                FechaLimite = x.FechaLimite
            }).FirstOrDefault(x => x.TareaID == id);
        }

        public List<Task1> GetTareas()
        {
            return DBContext.Tareas.Select(x => new Task1
            {
                TareaID = x.TareaID,
                ProyectoID = x.ProyectoID,
                Descripcion = x.Descripcion,
                Estado = x.Estado,
                FechaLimite = x.FechaLimite
            }).ToList();
        }

        public bool InsertarTarea(Task1 Tareas)
        {
            return InsertTareaAsync(Tareas).GetAwaiter().GetResult();
        }
        private async Task<bool> InsertTareaAsync(Task1 Tareas)
        {
            //Que no repita  el ProyectoID
            var entity = new Tarea
            {
                ProyectoID = Tareas.ProyectoID,
                Descripcion = Tareas.Descripcion,
                Estado = Tareas.Estado,
                FechaLimite = Tareas.FechaLimite
            };
            DBContext.Tareas.Add(entity);
            await DBContext.SaveChangesAsync();
            return true;
        }
    }
}
