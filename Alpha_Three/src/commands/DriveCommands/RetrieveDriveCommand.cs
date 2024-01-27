using Alpha_Three.src.BLL;
using Alpha_Three.src.interfaces;
using Alpha_Three.src.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.commands.DriveCommands
{
    internal class RetrieveDriveCommand : ICommand
    {
        public string Execute()
        {
            DriveBLL bll = new DriveBLL();
            StringBuilder stringBuilder= new StringBuilder();
            List<Drive> drives = new List<Drive> (bll.GetAllList());
            drives.ForEach(drive => stringBuilder.AppendLine(drive.ToString()));

            return "Drives: \n"+stringBuilder.ToString();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public string View()
        {
            throw new NotImplementedException();
        }
    }
}
