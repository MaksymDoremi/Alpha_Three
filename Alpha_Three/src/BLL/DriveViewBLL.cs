using Alpha_Three.src.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.BLL
{
    internal class DriveViewBLL
    {
        public DataTable? GetAllDatatable()
        {
            try
            {
                DriveViewDAL dal = new DriveViewDAL();
                return dal.GetAllDatatable();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
