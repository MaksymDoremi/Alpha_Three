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
    public class TrainBLL : IFunctions<Train>
    {
        public bool Delete(int id)
        {
            try
            {
                TrainDAL dal = new TrainDAL();
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

        public List<Train>? GetAllList()
        {
            try
            {
                TrainDAL dal = new TrainDAL();
                List<Train> items = dal.GetAllList();
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
                TrainDAL dal = new TrainDAL();
                dal.ImportFromJSON(path);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Insert(Train element)
        {
            try
            {
                TrainDAL dal = new TrainDAL();
                dal.Insert(element);
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        public bool Update(Train element)
        {
            try
            {
                TrainDAL dal = new TrainDAL();
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
