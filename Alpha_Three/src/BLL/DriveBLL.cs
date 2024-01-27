using Alpha_Three.src.DAO;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Alpha_Three.src.BLL
{
    public class DriveBLL : IFunctions<Drive>
    {
        public bool Delete(int id)
        {
            try
            {
                DriveDAL dal = new DriveDAL();
                dal.Delete(id);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public string ExportToJSON(DataTable dataTable)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Drive> list)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable, string path)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Drive> list, string path)
        {
            throw new NotImplementedException();
        }

        public DataTable? GetAllDatatable()
        {
            throw new NotImplementedException();
        }

        public List<Drive>? GetAllList()
        {
            try
            {
                DriveDAL dal = new DriveDAL();
                List<Drive> items = dal.GetAllList();
                return items;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Drive? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void ImportFromJSON(string path)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Drive element)
        {
            try
            {
                DriveDAL dal = new DriveDAL();
                dal.Insert(element);
            } catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Update(Drive element)
        {
            try
            {
                DriveDAL dal = new DriveDAL();
                dal.Update(element);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
