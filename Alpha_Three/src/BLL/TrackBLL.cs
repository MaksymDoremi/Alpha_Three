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
    public class TrackBLL : IFunctions<Track>
    {
        public bool Delete(int id)
        {
            try
            {
                TrackDAL dal = new TrackDAL();
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

        public List<Track>? GetAllList()
        {
            try
            {
                TrackDAL dal = new TrackDAL();
                List<Track> items = new List<Track>(dal.GetAllList());
                return items;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void ImportFromJSON(string path)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Track element)
        {
            try
            {
                TrackDAL dal = new TrackDAL();
                dal.Insert(element);
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        public bool Update(Track element)
        {
            try
            {
                TrackDAL dal = new TrackDAL();
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
