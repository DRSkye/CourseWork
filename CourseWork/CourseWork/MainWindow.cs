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
        private string path; ///Path to the directory with data

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
                }

                spectrGroupBox.Enabled = true;
                depthGroupBox.Enabled = true;
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

        //Start
        private void startButton_Click(object sender, EventArgs e)
        {
            //Время начала работы (для статистики)
            startTime.Text = DateTime.Now.ToString(); 

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
