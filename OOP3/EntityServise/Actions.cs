using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using EntityDB;

namespace EntityServise
{
  public  class Actions
    {
        
        public static void AddTov(string name, int code, DateTime dateTime, int term,string path, ref List<Entity.Entity> ent)
        {

            Entity.Entity tov = new Entity.Entity(name, code, dateTime, term);
            ent.Add(tov);
            EntityDB.MyFileEditor fw = new EntityDB.MyFileEditor();
            fw.BinaryWrite(path, ent);
            Console.WriteLine("Tovar added");
        }


        public static void RemoveTov(int index, string path, ref List<Entity.Entity> ent)
        {
            if (index < ent.Count)
            {
               ent.RemoveAt(index);
                EntityDB.MyFileEditor fw = new EntityDB.MyFileEditor();
                fw.BinaryWrite(path, ent);

            }
            else
            {
                Console.WriteLine("Wrong index!");
            }
        }

        public static List<Entity.Entity> Find(int term, List<Entity.Entity> ent)
        {
            List<Entity.Entity> list = new List<Entity.Entity>();
            for (int i = 0; i < ent.Count; i++)
            {
                if (ent[i].Term >= term)
                {
                    list.Add(ent[i]);
                }

            }
            return list;
        }
    }
}
