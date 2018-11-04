using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
   public class Entity
    {
        string name;
        int code, term;
        DateTime date;
        public Entity() { }
        public Entity(string name, int code, DateTime date, int term)
        {
            this.name = name;
            this.code = code;
            this.date = date;
            this.term = term;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Code
        {
            get { return code; }
            set { code = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int Term
        {
            get { return term; }
            set { term = value; }
        }

        public static void LastDay(Entity tov)
        {
            DateTime date2;
            date2 = tov.Date.AddDays(tov.Term);
            Console.WriteLine("Кінцевий строк споживання товару: " + date2.ToString("D"));
        }
        public static void Usable(Entity tov)
        {
            if (tov.Date.AddDays(tov.Term) >= DateTime.Now)
            {
                Console.WriteLine("Товар придатний");
            }
            else Console.WriteLine("Товар непридатний");
        }
        public static void Info(Entity tovar)
        {
            Console.WriteLine("Назва товару: " + tovar.Name);
            Console.WriteLine("Код товару: " + tovar.Code);
            Console.WriteLine("Дата виготовлення: " + tovar.Date.ToString("D"));
            Console.WriteLine("Термін придатності: " + tovar.Term + " днів");
        }
    }
}
