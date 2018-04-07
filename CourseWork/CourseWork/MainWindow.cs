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

        //Start
        private void startButton_Click(object sender, EventArgs e)
        {
            //Время начала работы (для статистики)
            startTime.Text = DateTime.Now.ToString();
            
            CLCalc.InitCL(ComputeDeviceTypes.All); //Инициализируем все доступные GPU и СPU (без аргументов только GPU)
            List<ComputeDevice> Devices = CLCalc.CLDevices; //Собираем их вместе

            CLCalc.Program.DefaultCQ = 0; //Выбираем устройсто

            CreateCode();
            CLCalc.Program.Compile(sourseCode); //Компилим код

            CLCalc.Program.Kernel FFT = new CLCalc.Program.Kernel("FFT"); //Задаём главную функцию

            var n = 5;
            float[] v1 = new float[n], v2 = new float[n];

            //Инициализация и присвоение векторов, которые мы будем складывать.
            for (int i = 0; i < n; i++)
            {
                v1[i] = i;
                v2[i] = i * 2;
            }

            //Загружаем вектора в память устройства
            CLCalc.Program.Variable varV1 = new CLCalc.Program.Variable(v1);
            CLCalc.Program.Variable varV2 = new CLCalc.Program.Variable(v2);

            //Объявление того, кто из векторов кем является
            CLCalc.Program.Variable[] args = new CLCalc.Program.Variable[] { varV1, varV2 };

            //Сколько потоков будет запущенно
            int[] workers = new int[1] { n };

            //Исполняем ядро VectorSum с аргументами args и колличеством потоков workers
            FFT.Execute(args, workers);

            //выгружаем из памяти
            varV1.ReadFromDeviceTo(v1);

            for (int i=0;i<n;i++)
            {
                MessageBox.Show(v1[i].ToString());
            }
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
