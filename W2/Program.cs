using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace W2
{

    public class Price_manager
    {
        private string name;
        private float price;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
    }
    public class Sale_manager 
    {
        private string date;
        private string name;
        private int count;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }

    
    class Program
    {

        static void SaleM()
        {
            List<Sale_manager> sm = new List<Sale_manager>();
            List<Price_manager> pr = new List<Price_manager>();

            // Введення ціни та назви товару
            pr.Add(new Price_manager { Price = 41.1f, Name = "Ovoch1" });
            pr.Add(new Price_manager { Price = 24.6f, Name = "Ovoch2" });
            pr.Add(new Price_manager { Price = 10.3f, Name = "Ovoch3" });
            pr.Add(new Price_manager { Price = 32.9f, Name = "Ovoch4" });
            pr.Add(new Price_manager { Price = 24.5f, Name = "Ovoch5" });

            // Введення статистики продажу
            sm.Add(new Sale_manager { Date = "10.01.2010", Count = 140, Name = "Ovoch1" });
            sm.Add(new Sale_manager { Date = "29.11.2014", Count = 242, Name = "Ovoch2" });
            sm.Add(new Sale_manager { Date = "15.06.2020", Count = 420, Name = "Ovoch5" });
            sm.Add(new Sale_manager { Date = "01.02.2012", Count = 771, Name = "Ovoch4" });
            sm.Add(new Sale_manager { Date = "12.12.2016", Count = 342, Name = "Ovoch1" });
            sm.Add(new Sale_manager { Date = "20.20.2020", Count = 458, Name = "Ovoch4" });
            sm.Add(new Sale_manager { Date = "30.03.2001", Count = 787, Name = "Ovoch3" });
            sm.Add(new Sale_manager { Date = "16.06.2008", Count = 277, Name = "Ovoch2" });
            sm.Add(new Sale_manager { Date = "14.11.2018", Count = 150, Name = "Ovoch4" });
            sm.Add(new Sale_manager { Date = "17.07.2017", Count = 241, Name = "Ovoch5" });

            float[] temprPrice = new float[sm.Count];
            Price_manager FoundData;
            string name;
            var sorPR = pr.OrderBy(o => o.Price).ToList();

            

            // Сортування
            List<Sale_manager> newsm = new List<Sale_manager>();
            List<float> newsmp = new List<float>();
            foreach (Sale_manager smx in sm)
            {
                newsmp.Add(FindType(smx, pr).Price * smx.Count);
                newsm.Add(smx);
            }
            int cnt = newsm.Count;
            sm = new List<Sale_manager>();
            for (int i = 0; i < cnt; i++)
            {
                int index = newsmp.IndexOf(newsmp.Max());
                sm.Add(newsm[index]);
                newsmp.RemoveAt(index);
                newsm.RemoveAt(index);
                
            }
            sm.Reverse();


            // Вивід таблиці
            float totalPrice = 0, totalTempPrice = 1;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                  ╔═════════╤════════════╤═══════╤════════════╗");
            Console.WriteLine("                     Назва  │    Дата    │ К-сть │   Ціна   ");
            Console.WriteLine("                  ╠═════════╪════════════╪═══════╪════════════╣");
            float tempPrice;
            string cutPrice = "";
            foreach (Sale_manager s in sm)
            {
                for(int i = 0; i < pr.Count; i++)
                {
                    if (s.Name == pr[i].Name)
                    {
                        tempPrice = pr[i].Price * s.Count;
                        Console.WriteLine("                    " + s.Name + "  │ " + s.Date + " │  " + s.Count + "  │  " + tempPrice);
                        Console.WriteLine("                  ╟─────────┼────────────┼───────┼────────────╢");
                    }
                }
            }

            // Підрахунох всієї виручки
            foreach (Sale_manager s in sm)
            {
                for (int i = 0; i < sorPR.Count; i++)
                {
                    if (s.Name == sorPR[i].Name)
                    {
                        tempPrice = sorPR[i].Price;
                        totalTempPrice = tempPrice * s.Count;
                    }
                }
                totalPrice += totalTempPrice;
                totalTempPrice = 0;
            }
            Console.WriteLine("                  ╟─────────┴────────────┴───────┴────────────╢");
            Console.WriteLine("                    Вартість виготовленої продукції: " + totalPrice);
            
            Console.WriteLine("                  ╚═══════════════════════════════════════════╝");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            SaleM();
        }
        static Price_manager FindType(Sale_manager Object, List<Price_manager> Types)
        {
            foreach (Price_manager x in Types)
            {
                if (Object.Name == x.Name)
                {
                    return x;

                }
            }
            return null;
        }
    }
}
