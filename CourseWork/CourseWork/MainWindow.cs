using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cloo;
using OpenCLTemplate;

namespace CourseWork
{
    public partial class MainWindow : Form
    {
        private Color colorStart, colorFinish; //Ranga of Colors
        private int fileCount = 0; //Count of files
        private string path; //Path to the directory with data
        private string[] sourseCode; //Код FFT

        public MainWindow()
        {
            InitializeComponent();
            colorStart = Color.White;
            colorFinish = Color.White;
        }

        //Exit
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Opening a directory with data
        private void openButton_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    path = folderBrowserDialog.SelectedPath;
                    fileCount = Directory.GetFiles(path).Length;
                    depthBoxFinish.Text = Convert.ToString(fileCount);
                    progressBar.Value = 0;
                    progressBar.Maximum = fileCount;
                    spectrGroupBox.Enabled = true;
                    depthGroupBox.Enabled = true;
                }

              //  finishTime.Text 
            }
            catch
            {
                MessageBox.Show("Ошибка при открытии папки!");
            }
        }

        //Choose colors
        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if ((Button)sender == colorButtonStart)
                {
                    colorStart = colorDialog.Color;
                    colorBoxStart.BackColor = colorStart;
                }
                else
                {
                    colorFinish = colorDialog.Color;
                    colorBoxFinish.BackColor = colorFinish;
                }
            }
        }

        //Create kernel code
        private void CreateCode()
        {
            StreamReader sr = new StreamReader("FFT.cl");
            List<string> l = new List<string>();
            string str = "";
            while (str!=null)
            {
                str = sr.ReadLine();
                if (str != null)
                    l.Add(str);
            }
            sourseCode = l.ToArray();
        }

        //Для степени двойки
        private short[] PowOfTwo(short[] soundLine)
        {
            int len = soundLine.Length;
            uint pow = 2;
            while (len > pow)
            {
                pow *= 2;
            }

            if (len == pow)
                return soundLine;
            else
            {
                short[] newMas = new short[pow];
                for (int i =0;i<pow;i++)
                {
                    if (i < len)
                        newMas[i] = soundLine[i];
                    else
                        newMas[i] = 0;
                }

                return newMas;
            }
        }

        //Start
        private void startButton_Click(object sender, EventArgs e)
        {
            //Время начала работы (для статистики)
            startTime.Text = DateTime.Now.ToString();

            CLCalc.InitCL(); //Инициализируем все доступные GPU и СPU (без аргументов только GPU)
            List<ComputeDevice> Devices = CLCalc.CLDevices; //Собираем их вместе

            CLCalc.Program.DefaultCQ = 0; //Выбираем устройство

            CreateCode();
            CLCalc.Program.Compile(sourseCode); //Компилим код

            CLCalc.Program.Kernel FFT = new CLCalc.Program.Kernel("FFT"); //Задаём главную функцию

            string[] fileList;
            fileList = Directory.GetFiles(path);
            fileCount = fileList.Length;
           

            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes"); //Показатель памяти
            bool stop = false;
            int fileIndex = 0;
            List<short[]> Data = new List<short[]>();
            short[] dataMas;

            while (fileIndex < fileCount) //Проверить!
            {
                //Оставляем в запасе 1 гб оперативы с учётом того, что потребуется не больше 200 мб на вычисление звуковой дорожки
                while (!stop && ramCounter.NextValue()-1024 > 200 ) 
                {
                    byte[] byteMas;
                    byteMas = File.ReadAllBytes(fileList[fileIndex]);
                    short[] soundLine = new short[byteMas.Length / 2];

                    for (int i = 0; i < byteMas.Length; i += 2)
                    {
                        byte[] b = new byte[] { byteMas[i], byteMas[i + 1] };
                        soundLine[i / 2] = BitConverter.ToInt16(b, 0);
                    }

                    Data.Add(PowOfTwo(soundLine));
                    
                    //Сборщик мусора
                    byteMas = null; //Удаляем ссылку
                    soundLine = null;
                    GC.Collect(); //Запуск сборщика мусора; Мусор- это всё, на что не указывает ссылка

                    fileIndex++;
                    if (fileIndex == fileCount)
                        stop = true;
                }

                //Вычисляем, что считали
                dataMas = new short[Data.Count*Data[0].Length];
                int[] NMas = new int[] { Data.Count };
                int[] LenMas = new int[] { Data[0].Length };
                var count = 0;
                for (int i = 0; i < Data.Count; i++)
                {
                    for (int j =0; j<Data[i].Length;j++)
                    {
                        dataMas[count] = Data[i][j];
                        count++;
                    }
                }
                Data.Clear();

                //Загружаем Даные в память устройства
                CLCalc.Program.Variable varData = new CLCalc.Program.Variable(dataMas);
                CLCalc.Program.Variable varNMas = new CLCalc.Program.Variable(NMas);
                CLCalc.Program.Variable varLenMas = new CLCalc.Program.Variable(LenMas);

                //Объявление массив агрументов функции kernel
                CLCalc.Program.Variable[] args = new CLCalc.Program.Variable[] { varData, varNMas, varLenMas };

                //Исполняем ядро FFT с аргументами args и колличеством потоков NMas
                FFT.Execute(args, NMas);

                //выгружаем из памяти
                varData.ReadFromDeviceTo(dataMas);
            }

            finishTime.Text = DateTime.Now.ToString();
        }

        //Chenging depth
        private void depth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(depthBoxStart.Text) < 1)
                    depthBoxStart.Text = 1.ToString();
                if (Convert.ToInt32(depthBoxStart.Text) > fileCount)
                    depthBoxStart.Text = fileCount.ToString();
                if (Convert.ToInt32(depthBoxFinish.Text) < Convert.ToInt32(depthBoxStart.Text))
                    depthBoxFinish.Text = depthBoxStart.Text;
                if (Convert.ToInt32(depthBoxFinish.Text) > fileCount)
                    depthBoxFinish.Text = fileCount.ToString();
            }
            catch
            {
                MessageBox.Show("Неправильно задан диапозон глубины!");
            }
        }

        //Chenging frequency
        private void frequency_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(frequencyBoxStart.Text) < 1)
                    frequencyBoxStart.Text = 1.ToString();
                if (Convert.ToInt32(frequencyBoxStart.Text) > Int32.MaxValue)
                    frequencyBoxStart.Text = Int32.MaxValue.ToString();
                if (Convert.ToInt32(frequencyBoxFinish.Text) < Convert.ToInt32(frequencyBoxStart.Text))
                    frequencyBoxFinish.Text = frequencyBoxStart.Text;
                if (Convert.ToInt32(frequencyBoxFinish.Text) > Int32.MaxValue)
                    frequencyBoxFinish.Text = Int32.MaxValue.ToString();
            }
            catch
            {
                MessageBox.Show("Неправильно задан диапозон Частот!");
            }
        }

        //About the program
        private void helpButton_Click(object sender, EventArgs e)
        {
            try
            {
                HelpForm helpForm = new HelpForm();
                helpForm.Show(); //Не ShowDialog чтобы не прерывать главный процесс
            }
            catch
            {
                MessageBox.Show("Произошла ошибка, справка не может быть открыта!");
            }
        }
    }
}
