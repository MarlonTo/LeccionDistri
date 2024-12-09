using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace SLC
{
    public interface IProductService
    {
        Products CreateProduct(Products product);
        Products RetrieveById(int id);
        bool Update(Products product);
        bool Delete(int id);
        List<Products> Filter(string name);
        List<Products> RetrieveAll();
    }
}
