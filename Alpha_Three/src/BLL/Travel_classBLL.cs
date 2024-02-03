using Alpha_Three.src.DAL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.BLL
{
    public class Travel_classBLL : IFunctions<Travel_class>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable? GetAllDatatable()
        {
            throw new NotImplementedException();
        }

        public List<Travel_class>? GetAllList()
        {
            try
            {
                Travel_classDAL dal = new Travel_classDAL();
                List<Travel_class> items = dal.GetAllList();
                return items;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ImportFromJSON(string path)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Travel_class element)
        {
            throw new NotImplementedException();
        }

        public bool Update(Travel_class element)
        {
            throw new NotImplementedException();
        }
    }
}
