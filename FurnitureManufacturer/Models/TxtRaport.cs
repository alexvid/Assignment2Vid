using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace FurnitureManufacturer.Models
{
    class TxtRaport : Raport
    {
        string path = @"Raport.txt";
        string Raport.getType() {

            return "Txt";
        }
        public void deleteOldFile()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void getRaport(int ID, int IDEmployee, int IDOperation, string TableName, DateTime Date)
        {


            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Id activitate: "+ID +" id angajat: "+IDEmployee+" Id operatie:  "+IDOperation+ " in tabela: "+TableName+" la data:" +Date.ToString());
                }
            }
            else
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("Id activitate: " + ID + " id angajat: " + IDEmployee + " Id operatie:  " + IDOperation + " in tabela: " + TableName + " la data:" + Date.ToString());
                }
        }
    }
}
