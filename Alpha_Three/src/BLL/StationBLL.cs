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
    public class StationBLL : IFunctions<Station>
    {
        public bool Delete(int id)
        {
            try
            {
                StationDAL dal = new StationDAL();
                dal.Delete(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public DataTable? GetAllDatatable()
        {
            throw new NotImplementedException();
        }

        public List<Station>? GetAllList()
        {
            try
            {
                StationDAL dal = new StationDAL();
                List<Station> items = dal.GetAllList();
                return items;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ImportFromJSON(string path)
        {
            try
            {
                StationDAL dal = new StationDAL();
                dal.ImportFromJSON(path);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Insert(Station element)
        {
            try
            {
                StationDAL dal = new StationDAL();
                dal.Insert(element);
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public bool Update(Station element)
        {
            try
            {
                StationDAL dal = new StationDAL();
                dal.Update(element);
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }
    }
}
