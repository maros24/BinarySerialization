using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntityServise
{
  public  class ObjEditor
    {
        public static List<Entity.Entity> getTovar(string bdstr)
        {
            List<Entity.Entity> deserilizeEntity=new List<Entity.Entity>();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(bdstr, FileMode.OpenOrCreate))
            {
                 deserilizeEntity.Add((Entity.Entity)formatter.Deserialize(fs));
            }
            return deserilizeEntity;
        }

        public static string getInfo(Entity.Entity st)
        {

            string s = "Tovar " + st.Name + "\n{";
            s += "\"name\":\"" + st.Name + "\",\n";
            s += "\"code\":\"" + st.Code + "\",\n";
            s += "\"date\":\"" + st.Date + "\",\n";
            s += "\"term\":\"" + st.Term + "\",";
            s += "};\n";

            return s;
        }
    }
}
