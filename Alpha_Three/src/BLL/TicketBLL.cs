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
    public class TicketBLL : IFunctions<Ticket>
    {
        public bool Delete(int id)
        {
            try
            {
                TicketDAL dal = new TicketDAL();
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

        public List<Ticket>? GetAllList()
        {
            try
            {
                TicketDAL dal = new TicketDAL();
                List<Ticket> items = dal.GetAllList();
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

        public bool Insert(Ticket element)
        {
            try
            {
                TicketDAL dal = new TicketDAL();
                dal.Insert(element);
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public bool Update(Ticket element)
        {
            try
            {
                TicketDAL dal = new TicketDAL();
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
