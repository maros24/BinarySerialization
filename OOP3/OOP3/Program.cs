using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using EntityDB;

namespace OOP3
{
    class Program
    {
        static string path = "C:/Users/Юрий/source/repos/OOP3/data.dat";
        static void Main(string[] args)
        {
            DateTime date1 = new DateTime(2018, 10, 15);
            DateTime date2 = new DateTime(2018, 10, 15);
            List<Entity.Entity> entity = new List<Entity.Entity>();
            entity.Add(new Entity.Entity("lemon", 234, date1, 50));
            entity.Add(new Entity.Entity("sdv", 454, date2, 70));
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, entity);
            }
            Menu.Menu.menu(entity, path);
            Console.ReadKey();
        
        }
    }
}
