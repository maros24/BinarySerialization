using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityServise;

namespace Menu
{
    public class Menu
    {
        public static List<Entity.Entity> ent;
        static string path;

        public static void menu(List<Entity.Entity> en, string paths)
        {
            ent = en;
            path = paths;
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose action: 1-Show tovar 2-add tovar 3-remove tovar 4-find tovar");
                int x = 0;
                try
                {
                    x = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Wrong format!");
                }
                if (x > 0 && x < 5)
                {
                    switch (x)
                    {
                        case 1:
                            TovarShow(ent);
                            break;
                        case 2:
                            AddTovar(ent);
                            break;
                        case 3:
                            Console.WriteLine("Enter index for removing");
                            int i = Convert.ToInt32(Console.ReadLine());
                            if (i < ent.Count)
                            {
                                EntityServise.Actions.RemoveTov(i, path, ref ent);
                                Console.WriteLine("Element was removed");
                            }
                            else
                            {
                                Console.WriteLine("Wrong index!");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter the term");
                            int t = Convert.ToInt32(Console.ReadLine());
                            Find(t);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Unknown action!");
                }
                Console.ReadKey();
            }

        }

        private static void TovarShow(List<Entity.Entity> tov)
        {
            if (tov.Count > 0)
            {
                for (int i = 0; i < tov.Count; i++)
                {
                    Console.WriteLine("Name : " + tov[i].Name);
                    Console.WriteLine("Code : " + tov[i].Code);
                    Console.WriteLine("Date : " + tov[i].Date);
                    Console.WriteLine("Term : " + tov[i].Term);
                    Console.WriteLine("\n\n");
                }
            }
            else
            {
                Console.WriteLine("Couldn't find any info");
            }
        }

        private static void AddTovar(List<Entity.Entity> en)
        {
            int code = 0, term = 0;
            string name = "";
            DateTime date;
            string input;
            try
            {
                Console.WriteLine("Enter name: ");
                name = Console.ReadLine();
                Console.WriteLine("Enter code: ");
                code = Convert.ToInt32(Console.ReadLine());
                do
                {
                    Console.WriteLine("Enter date: ");
                    input = Console.ReadLine();
                }
                while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out date));
                
                Console.WriteLine("Enter term: ");
                term = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format!");
                return;
            }
            EntityServise.Actions.AddTov(name, code, date, term, path, ref ent);
        }

        public static void Find(int term)
        {
            List<Entity.Entity> list;
            list = EntityServise.Actions.Find(term, ent);
            foreach (Entity.Entity l in list)
            {
                Console.WriteLine("Name : " + l.Name);
                Console.WriteLine("Code : " + l.Code);
                Console.WriteLine("Date : " + l.Date);
                Console.WriteLine("Term : " + l.Term);
                Console.WriteLine("\n\n");
            }

        }
    }
}
