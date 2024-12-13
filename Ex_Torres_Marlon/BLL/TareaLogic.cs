using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad_db;
using DAL;
using System.IO;
using System.Xml.Serialization;


namespace BLL
{
    public class TareaLogic
    {
        //tarea

        public List<tarea_soapModelo> GetTareas()
        {
            List<tarea_soapModelo> result = null;
            try
            {
                using (IRepository repository = RepositoryFactory.CreateRepository())
                {
                    result = repository.Filter<tarea_soapModelo>(t => t.TareaID > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public tarea_soapModelo GetTareaID(int id)
        {
            tarea_soapModelo result = null;
            try
            {
                using (IRepository repository = RepositoryFactory.CreateRepository())
                {
                    result = repository.Retrieve<tarea_soapModelo>(t => t.id == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool InsertarTarea(tarea_soapModelo Tareas)
        {
            bool result = false;
            try
            {
                using (IRepository repository = RepositoryFactory.CreateRepository())
                {
                    _ = repository.Create(tarea_soapModelo);
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public void ActualizarTarea(tarea_soapModelo Tareas)
        {
            ActualizarTarea(Tareas, tarea_soapModelo);
        }

        public void ActualizarTarea(tarea_soapModelo Tareas, tarea_soapModelo tarea_soapModelo)
        {
            try
            {
                using (IRepository repository = RepositoryFactory.CreateRepository())
                {
                    _ = repository.Update(tarea_soapModelo);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void EliminarTarea(int id)
        {
            try
            {
                using (IRepository repository = RepositoryFactory.CreateRepository())
                {
                    tarea_soapModelo tarea = repository.Retrieve<tarea_soapModelo>(t => t.id == id);
                    repository.Delete(tarea);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
}
