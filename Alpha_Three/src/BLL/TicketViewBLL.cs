using Alpha_Three.src.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.BLL
{
    internal class TicketViewBLL
    {
        public DataTable? GetAllDatatable()
        {
            try
            {
                TicketViewDAL dal = new TicketViewDAL();
                return dal.GetAllDatatable();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
