using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.DAO
{
    public class StationDAO : IDAO<Station>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Station> list)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(DataTable dataTable, string path)
        {
            throw new NotImplementedException();
        }

        public string ExportToJSON(List<Station> list, string path)
        {
            throw new NotImplementedException();
        }

        public DataTable? GetAllDatatable()
        {
            throw new NotImplementedException();
        }

        public List<Station>? GetAllList()
        {
            throw new NotImplementedException();
        }

        public Station? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void ImportFromJSON(string path)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Station element)
        {
            throw new NotImplementedException();
        }

        public bool Update(Station element)
        {
            throw new NotImplementedException();
        }
    }
}
