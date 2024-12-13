using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad_db;

namespace SLC
{
    internal interface ITareaService
    {
       List<tarea_soapModelo> GetTareas();
        tarea_soapModelo GetTareaID(int id);
        bool InsertarTarea(tarea_soapModelo Tareas);
        void ActualizarTarea(tarea_soapModelo Tareas);
        void EliminarTarea(int id);

    }
}
