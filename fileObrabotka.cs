using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertDataFiles
{
    class fileObrabotka
    {
        //  public static int smeshenie;
        public static List<string> data = new List<string>() { }; //cписок для порции данных
        public static string filePath; //имя каталога
        public static string fileName; //имя файла
        public static void porciaReadFromFile(int numberCicle, int kolvoIteracij)// процедура формирования порции данных  
        {
            data.Clear(); // очистка данных в листе
            int nachPozicia = numberCicle * kolvoIteracij;
            for (int i = nachPozicia; i < nachPozicia + kolvoIteracij; i++)
            {
                string line = File.ReadAllLines(fileName).ElementAt(i);
                data.Add(line);
            }
        }

        public static void fileAnalize() //процедура анализа
        {

            List<Tablica> vhogdenie = new List<Tablica> { }; //-- список чисел и количества их вхождений в массив
            //----------------- группировка данных datа ------------------
            var groupByChislo = from zapis in data //группировка данных datа
                                group zapis by zapis;
                                
            // ------------ формирование в списке уникальных значений из очередной порции данных 
            foreach (var i in groupByChislo)
            {
                string chislo = i.Key;
                int chisloInDecimal = Convert.ToInt32(chislo);
                string chisloInByte = Convert.ToString(chisloInDecimal, 2);
                int chisloInBytRazrjad = chisloInByte.Length;// количество разрядов в двоичном представлении числа
                int chisloRazrad = chisloInBytRazrjad * i.Count(); //произведение количества разрядов на количество вхождений
                vhogdenie.Add(new Tablica() { chisloInDecimal = Convert.ToInt32(chislo), kolvo = i.Count(), chisloKolvo = chisloRazrad, chisloRazrjad = chisloInBytRazrjad });
            }


            int summ = 0;
            foreach (Tablica i in vhogdenie)
            {
                summ = summ + i.chisloRazrjad;
            }
            int srednee = summ / vhogdenie.Count(); //среднее арифметическое

            var vybrannyeChisla = from zapis in vhogdenie //отбор чисел, для которых произведение число количество больше среднего арифметического
                                  where zapis.chisloKolvo > srednee
                                  orderby zapis.chisloRazrjad
                                  select zapis;
            int maxChisloRazrjad = (from x in vybrannyeChisla //----------------- поиск max числа в списке 
                                    select x.chisloRazrjad).Max();

            List<Zamena> zamena = new List<Zamena>(); // готовим список замен
                                                      //   Array [,] listOfZamen = new Array[vybrannyeChisla.Count(),2];

            int minChislo = (from x in vhogdenie   //----------------- поиск минимального числа в списке
                             select x.chisloInDecimal).Min();
            Tablica[] output = vhogdenie.ToArray();
            int cc = 1; //счетчик для цикла while
            while (cc < vybrannyeChisla.Count()) //поиск всех незадействованных цифр в массиве  вібрінніх(уникальніх) чисел
            {
                bool result = output.Any(n => n.chisloInDecimal == cc);
                if (!output.Any(n => n.chisloInDecimal == cc)) //если число не найдено в массиве выбранных чисел
                {
                    if (Convert.ToString(output[cc].chisloInDecimal, 2).Length > Convert.ToString(cc, 2).Length) // если битность числа в массиве больше битности незадействованного числа

                    {
                        zamena.Add(new Zamena() { ishod = output[cc].chisloInDecimal, result = cc }); //присвоение незадействованных чисел в таблице замен
                                                                                                      // cc--;
                    }
                }
                cc++;
            }
            Zamena[] zamenaArray = zamena.ToArray();
            //   var ss = zamenaYrray[1].result;
            //--------------------------------------- формирование выходного массива --------------------------------

            List<string> vyhod = new List<string>(); //подготовка выходного списка


            IEnumerator ie = data.GetEnumerator();


            while (ie.MoveNext())   // пока не будет возвращено false
            {
                Zamena found = zamena.Find(item => item.ishod == Convert.ToInt32(ie.Current));
                
                if (found is null) { vyhod.Add(ie.Current.ToString()); }
                else { vyhod.Add(found.result.ToString()); }

            }            

            string cd = "";
        }

        public static void fileAnalize1() //процедура анализа
        {
            List<Tablica> vhogdenie = new List<Tablica> { }; //-- список чисел и количества их вхождений в массив
            //----------------- группировка данных datа ------------------
            var groupByChislo = from zapis in data //группировка данных datа
                                group zapis by zapis;
            string f = "";
            // ------------ формирование списка уникальных значений из очередной порции данных 
            foreach (var i in groupByChislo)
            {
                string chislo = i.Key;
                int chisloInDecimal = Convert.ToInt32(chislo);
                string chisloInByte = Convert.ToString(chisloInDecimal, 2);
                int chisloInBytRazrjad = chisloInByte.Length;// количество разрядов в двоичном представлении числа
                int chisloRazrad = chisloInBytRazrjad * i.Count(); //произведение количества разрядов на количество вхождений
                vhogdenie.Add(new Tablica() { chisloInDecimal = Convert.ToInt32(chislo), kolvo = i.Count(), chisloKolvo = chisloRazrad, chisloRazrjad = chisloInBytRazrjad });
            }
            
            var vhogdenieSortByChisloRazrjad = vhogdenie.OrderByDescending(u => u.chisloRazrjad);  //отсортированный список уникальных чисeл в последовательности
            List<Zamena> zamena = new List<Zamena>(); // готовим список замен
            int cc = 1; //счетчик для цикла while
            int cv = 1; //счетик для vhogdenieSortByChisloRazrjad
            while (cc < vhogdenieSortByChisloRazrjad.Count())
            {
                int chisloKolvo = vhogdenieSortByChisloRazrjad.ElementAt(cc).chisloKolvo; // произведение число разрядов * количество повторов
                int chislo = vhogdenieSortByChisloRazrjad.ElementAt(cc).chisloKolvo; //количество повторов в числе
                int chisloBit = vhogdenieSortByChisloRazrjad.ElementAt(cc).chisloRazrjad; // количество бит в числе
                int chisloInDecimal = vhogdenieSortByChisloRazrjad.ElementAt(cc).chisloInDecimal; //число в десятичной форме
                int razr = Convert.ToString(cv, 2).Length; //количество разрядов в предлагаемом числе
                Tablica g = vhogdenie.Find(n => n.chisloInDecimal == cv); //выделить элемент, на который планируем менять
                int kolvoRazrInCC = 0;
                int sumBit = 0;
                // если предлагаемое число  не входит в список
                if (g == null)                
                {
                    if (chisloKolvo > razr + 2)
                        zamena.Add(new Zamena() { ishod = chisloInDecimal, result = cv });
                    cv++;
                    cc++;
                }
                else
                {                  
                    var MinKolvo = vhogdenieSortByChisloRazrjad.Select(x => x.chisloKolvo).Min();

                   
                                        kolvoRazrInCC = g.chisloKolvo * g.chisloRazrjad; //Число разрядов конечного числа * число повторов конечного числа
                    sumBit = kolvoRazrInCC + g.chisloKolvo * 2; //суммарное число бит при замене на конечное число


                    // var ggg = vhogdenie.ToArray();
                    //  while (ggg.Count() > 0)
                    //  {
                    //    var yyy = ggg.
                    ////      kolvoRazrInCC = ggg.
                    //  }
                    //kolvoRazrInCC = ggg.chisloKolvo * ggg.chisloRazrjad;




                    //while 
                    // int cvv = cv;
                    kolvoRazrInCC = g.chisloKolvo * g.chisloRazrjad; //Число разрядов конечного числа * число повторов конечного числа
                    sumBit = kolvoRazrInCC + g.chisloKolvo * 2; //суммарное число бит при замене на конечное число
                                                                //
                    if (chisloKolvo > kolvoRazrInCC + sumBit)
                    {
                        zamena.Add(new Zamena() { ishod = chisloInDecimal, result = cv });
                        zamena.Add(new Zamena() { ishod = cv, result = chisloInDecimal });
                        cv++;
                        cc++;
                    }
                    else
                    {
                      //  if (cvv < vhogdenieSortByChisloRazrjad.Count()) cvv++;
                       // else cc = vhogdenieSortByChisloRazrjad.Count();
                    }
                }
            }
                    //kolvoRazrInCC = g.chisloKolvo * g.chisloRazrjad; //Число разрядов конечного числа * число повторов конечного числа
                    //sumBit = kolvoRazrInCC + g.chisloKolvo * 2; //суммарное число бит при замене на конечное число
                    //}
                    // Если произведение число разрядов * количество повторов исходного числа больше разрядности числа + вставка
                    
             //   {
                    // если предлагаемое число входит в массив
                    //if (vhogdenieSortByChisloRazrjad.ElementAt(cc).chisloKolvo == 1)
                    //{
                    //    // поместить в таблицу замен исходное число и замену
                        
                    //    zamena.Add(new Zamena() { ishod = cv, result = chisloInDecimal });
                    //    cv++;
                    //}
                    //else
                    //{
                    //    zamena.Add(new Zamena() { ishod = chisloInDecimal, result = cv });
                    //    cv++;
                    //}
                    //cv--;
              //  }

              //  if (!vhogdenieSortByChisloRazrjad.Any(n => n.chisloInDecimal == cc)) //если число не найдено в массиве выбранных чисел
                //{                   
                //    // если произведение число разрядов * количество повторов сходного числа больше суммы битности исходного числа, битности замены и двух разделителей
                //    if (chisloKolvo > (Convert.ToString(cv, 2)).Length + chisloBit + 2)
                //    {
                //        // поместить в таблицу замен исходное число и замену
                //        zamena.Add(new Zamena() { ishod = chisloInDecimal, result = cv });
                //    }
                //  //  else cv--;
            //    }

                //else // если число имеется в массиве
                //{
                    
                ////    int chisloKolvo > (Convert.ToString(cv, 2)).Length + chisloBit + 2)

                //    // если произведение число разрядов * количество повторов исходного числа больше суммы битности исходного числа, битности замены и двух разделителей
                    
                //  //  else cv--;
                   
                //  //  cv--;
                //}
            //    cc++;
             //   cv++;
               
        //    }
            string gg = "";

        }

        public class Tablica
        {
            public int chislo { get; set; } // число в десятичной форме
            public int chisloRazrjad { get; set; } //количество разрядов в двоичном представлении числа
            public int kolvo { get; set; } //количество вхождений числа в текущую пор
            public int chisloKolvo { get; set; }
            public int chisloInDecimal { get; set; } // число в десятичной форме

        }
        public class Zamena
        {
            public int ishod { get; set; }
            public int result { get; set; }
        }
    }

}