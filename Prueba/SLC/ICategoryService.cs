using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace SLC
{
    public interface ICategoryService
    {
        Categories CreateCategory(Categories category);
        Categories RetrieveById(int id);
        bool Update(Categories category);
        bool Delete(int id);
        List<Categories> Filter(string name);
        List<Categories> RetrieveAll();


    }
}
