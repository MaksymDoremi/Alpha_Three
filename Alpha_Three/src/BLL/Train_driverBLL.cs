﻿using Alpha_Three.src.DAL;
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
    public class Train_driverBLL : IFunctions<Train_driver>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Train_driver> list)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable, string path)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Train_driver> list, string path)
        {
            throw new NotImplementedException();
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

        public Train_driver? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void ImportFromJSON(string path)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Train_driver element)
        {
            throw new NotImplementedException();
        }

        public bool Update(Train_driver element)
        {
            throw new NotImplementedException();
        }
    }
}
