using Alpha_Three.src.DAL;
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
    public class Train_driverBLL : IFunctions<Train_driver>
    {
        public bool Delete(int id)
        {
            try
            {
                Train_driverDAL dal = new Train_driverDAL();
                dal.Delete(id);
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        public DataTable? GetAllDatatable()
        {
            throw new NotImplementedException();
        }

        public List<Train_driver>? GetAllList()
        {
            try
            {
                Train_driverDAL dal = new Train_driverDAL();
                List<Train_driver> items = dal.GetAllList();
                return items;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public void ImportFromJSON(string path)
        {
            try
            {
                Train_driverDAL dal = new Train_driverDAL();
                dal.ImportFromJSON(path);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Insert(Train_driver element)
        {
            try
            {
                Train_driverDAL dal = new Train_driverDAL();
                dal.Insert(element);
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        public bool Update(Train_driver element)
        {
            try
            {
                Train_driverDAL dal = new Train_driverDAL();
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
