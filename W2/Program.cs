using System;
using System.Collections.Generic;
using System.Text;

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

            // Сортування
            for (int i = 0; i < sm.Count; i++)
            {
                for (int k = 0; k < sm.Count; k++)
                {
                    float price1 = 0;
                    float price2 = 0;
                    for (int j = 0; j < pr.Count; j++)
                    {
                        if (pr[j].Name == sm[i].Name)
                        {
                            price1 = pr[j].Price * sm[i].Count;
                        }
                    }
                    for (int d = 0; d < pr.Count; d++)
                    {
                        if (pr[d].Name == sm[k].Name)
                        {
                            price2 = pr[d].Price * sm[k].Count;
                        }
                    }
                    if (price1 < price2)
                    {
                        Sale_manager SS = sm[k];
                        sm[k] = sm[i];
                        sm[i] = SS;
                    }
                }
            }

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
                for (int i = 0; i < pr.Count; i++)
                {
                    if (s.Name == pr[i].Name)
                    {
                        tempPrice = pr[i].Price;
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
    }
}
