﻿using Alpha_Three.src.DAO;
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
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Train> list)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable, string path)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Train> list, string path)
        {
            throw new NotImplementedException();
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

        public Train? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void ImportFromJSON(string path)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Train element)
        {
            throw new NotImplementedException();
        }

        public bool Update(Train element)
        {
            throw new NotImplementedException();
        }
    }
}
