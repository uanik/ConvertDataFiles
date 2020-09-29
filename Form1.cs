using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ConvertDataFiles
{
    public partial class Form1 : Form
    {
        int kolvoZamen = 0;
        List<string> data = new List<string>() { }; // Лист, куда помещаются строки исходного файла       
        string fileName = "data.txt";    
        public Form1()
        {
            InitializeComponent();          
        }
        void JobForAThread(object f) //процедура обработки файла
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                //  for (int i = 0; i < 10; i++) label1.Text = bytes[i].ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e) /// кнопка выбора папки
        {
           if (textBoxLData.Text == "")
            {
                MessageBox.Show("Укажите размер блока");
                return;
            }
            fileObrabotka.filePath = textBoxfilePath.Text; //

            folderBrowserDialog1.ShowDialog();
            textBoxfilePath.Text = folderBrowserDialog1.SelectedPath;

            //-------------Удаление файлов *.dat 
            FileInfo[] path = new DirectoryInfo(textBoxfilePath.Text).GetFiles("*.dat", SearchOption.TopDirectoryOnly);
            foreach (FileInfo file in path) File.Delete(file.FullName);

            // --------- обработка оставшихся файлов ------------------------------
            //  kolvoZamen = 0;
            fileObrabotka.data.Clear(); //
            var catalog = Directory.GetFileSystemEntries(textBoxfilePath.Text);
            foreach (string fileName in catalog) // для каждого файла в каталоге
            {
                fileObrabotka.fileName = fileName;
                int linesCount = System.IO.File.ReadAllLines(fileName).Length; //количество строк в файле
                int kolvoCiklov = linesCount / Convert.ToInt32(textBoxLData.Text); // количество циклов для файла
                int linesInPorcia = Convert.ToInt32(textBoxLData.Text);

                int sch; // счетчик количества циклов
                for ( sch = 0; sch < kolvoCiklov; sch++)
                {
                    fileObrabotka.porciaReadFromFile(sch, linesInPorcia); //sch - номер текущего цикла,  linesInPorcia - количество элементов в цикле
                    fileObrabotka.fileAnalize1();
                }
               // sch++;
                int linesCount1 = System.IO.File.ReadAllLines(fileName).Length; //общее количество строк в файле
                int ostatokOfLines = linesCount1 - sch * linesInPorcia;
                fileObrabotka.porciaReadFromFile(sch, ostatokOfLines);
                fileObrabotka.fileAnalize();

                using (StreamReader sr = new StreamReader(fileName.ToString()))
                {
                       string line;

                   
                    while ((line = sr.ReadLine()) != null)  //пока не конец файла
                    {
                        data.Add(line); // добавить строку в лист
                    }
                    //for (int i = 0; i < data.Count; i++) //проверяем для всех элементов листа
                    //{
                    //    if (data[i] == "31")
                    //    {
                    //        data[i] = "1";
                    //        kolvoZamen++;
                    //        label1.Text = kolvoZamen.ToString();
                    //    }
                    //    if (data[i] == "25")
                    //    {
                    //        data[i] = "2";
                    //        kolvoZamen++;
                    //        label1.Text = kolvoZamen.ToString();
                    //    }
                    //}
                    sr.Dispose();
                    //формирование имени выходного файла
                    string fileOut = fileName.ToString();
                    fileOut = fileOut.Substring(0, fileOut.Length - 4);
                    fileOut = fileOut + ".dat";
                    if (File.Exists(fileOut)) //если выходной файл существует
                    {
                        File.Delete(fileOut); // удалить выходной файл
                    }

                    using (StreamWriter sw = new StreamWriter(fileOut))
                    {
                        // записать каждую строку листа в выходной файл 
                        for (int i = 0; i < data.Count; i++)
                        {
                            sw.WriteLine(data[i]);
                        }
                        sw.Close();  //закрыть выходной файл
                        sw.Dispose();
                    }
                                        
                }
            }
        }
    }
}




   
