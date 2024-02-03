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
    public class PassengerBLL : IFunctions<Passenger>
    {
        public bool Delete(int id)
        {
            try
            {
                PassengerDAL dal = new PassengerDAL();
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

        public List<Passenger>? GetAllList()
        {
            try
            {
                PassengerDAL dal = new PassengerDAL();
                List<Passenger> items = dal.GetAllList();
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
                PassengerDAL dal = new PassengerDAL();
                dal.ImportFromJSON(path);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Insert(Passenger element)
        {
            try
            {
                PassengerDAL dal = new PassengerDAL();
                dal.Insert(element);
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public bool Update(Passenger element)
        {
            try
            {
                PassengerDAL dal = new PassengerDAL();
                dal.Update(element);
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }
    }
}
