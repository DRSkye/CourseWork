namespace CourseWork
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 12D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 2D);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.helpButton = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicGroupBox = new System.Windows.Forms.GroupBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.startTime = new System.Windows.Forms.Label();
            this.finishTime = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.startButton = new System.Windows.Forms.Button();
            this.depthGroupBox = new System.Windows.Forms.GroupBox();
            this.depthBoxFinish = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.depthBoxStart = new System.Windows.Forms.TextBox();
            this.spectrGroupBox = new System.Windows.Forms.GroupBox();
            this.frequencyBoxFinish = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.frequencyBoxStart = new System.Windows.Forms.TextBox();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.colorBoxFinish = new System.Windows.Forms.PictureBox();
            this.colorBoxStart = new System.Windows.Forms.PictureBox();
            this.colorButtonFinish = new System.Windows.Forms.Button();
            this.colorButtonStart = new System.Windows.Forms.Button();
            this.mainOpenButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.graphicGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.settingsGroupBox.SuspendLayout();
            this.depthGroupBox.SuspendLayout();
            this.spectrGroupBox.SuspendLayout();
            this.colorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorBoxFinish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBoxStart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.helpButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(939, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openButton,
            this.exitButton});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // openButton
            // 
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(156, 22);
            this.openButton.Text = "Открыть папку";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(156, 22);
            this.exitButton.Text = "Выход";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(65, 20);
            this.helpButton.Text = "Справка";
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // graphicGroupBox
            // 
            this.graphicGroupBox.Controls.Add(this.chart);
            this.graphicGroupBox.Location = new System.Drawing.Point(13, 28);
            this.graphicGroupBox.Name = "graphicGroupBox";
            this.graphicGroupBox.Size = new System.Drawing.Size(654, 533);
            this.graphicGroupBox.TabIndex = 1;
            this.graphicGroupBox.TabStop = false;
            this.graphicGroupBox.Text = "Спектрограмма";
            // 
            // chart
            // 
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart.Legends.Add(legend3);
            this.chart.Location = new System.Drawing.Point(7, 20);
            this.chart.Name = "chart";
            this.chart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            dataPoint7.MarkerColor = System.Drawing.Color.Black;
            dataPoint8.MarkerColor = System.Drawing.Color.Red;
            dataPoint9.MarkerColor = System.Drawing.Color.Blue;
            series3.Points.Add(dataPoint7);
            series3.Points.Add(dataPoint8);
            series3.Points.Add(dataPoint9);
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(641, 507);
            this.chart.TabIndex = 0;
            this.chart.Text = "Спектрограмма";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.startTime);
            this.settingsGroupBox.Controls.Add(this.finishTime);
            this.settingsGroupBox.Controls.Add(this.progressBar);
            this.settingsGroupBox.Controls.Add(this.startButton);
            this.settingsGroupBox.Controls.Add(this.depthGroupBox);
            this.settingsGroupBox.Controls.Add(this.spectrGroupBox);
            this.settingsGroupBox.Controls.Add(this.colorGroupBox);
            this.settingsGroupBox.Controls.Add(this.mainOpenButton);
            this.settingsGroupBox.Location = new System.Drawing.Point(674, 28);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(253, 533);
            this.settingsGroupBox.TabIndex = 2;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Настройки";
            // 
            // startTime
            // 
            this.startTime.AutoSize = true;
            this.startTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startTime.Location = new System.Drawing.Point(15, 410);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(79, 20);
            this.startTime.TabIndex = 7;
            this.startTime.Text = "00:00:00";
            // 
            // finishTime
            // 
            this.finishTime.AutoSize = true;
            this.finishTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.finishTime.Location = new System.Drawing.Point(15, 443);
            this.finishTime.Name = "finishTime";
            this.finishTime.Size = new System.Drawing.Size(79, 20);
            this.finishTime.TabIndex = 6;
            this.finishTime.Text = "00:00:00";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(7, 504);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(240, 23);
            this.progressBar.TabIndex = 5;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new System.Drawing.Point(6, 466);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(241, 32);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // depthGroupBox
            // 
            this.depthGroupBox.Controls.Add(this.depthBoxFinish);
            this.depthGroupBox.Controls.Add(this.label3);
            this.depthGroupBox.Controls.Add(this.label4);
            this.depthGroupBox.Controls.Add(this.depthBoxStart);
            this.depthGroupBox.Enabled = false;
            this.depthGroupBox.Location = new System.Drawing.Point(7, 296);
            this.depthGroupBox.Name = "depthGroupBox";
            this.depthGroupBox.Size = new System.Drawing.Size(240, 101);
            this.depthGroupBox.TabIndex = 3;
            this.depthGroupBox.TabStop = false;
            this.depthGroupBox.Text = "Диапозон глубины (метры)";
            // 
            // depthBoxFinish
            // 
            this.depthBoxFinish.Location = new System.Drawing.Point(136, 68);
            this.depthBoxFinish.Name = "depthBoxFinish";
            this.depthBoxFinish.Size = new System.Drawing.Size(100, 20);
            this.depthBoxFinish.TabIndex = 7;
            this.depthBoxFinish.TextChanged += new System.EventHandler(this.depth_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Конечная:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Начальная:";
            // 
            // depthBoxStart
            // 
            this.depthBoxStart.Location = new System.Drawing.Point(136, 27);
            this.depthBoxStart.Name = "depthBoxStart";
            this.depthBoxStart.Size = new System.Drawing.Size(100, 20);
            this.depthBoxStart.TabIndex = 4;
            this.depthBoxStart.Text = "1";
            this.depthBoxStart.TextChanged += new System.EventHandler(this.depth_TextChanged);
            // 
            // spectrGroupBox
            // 
            this.spectrGroupBox.Controls.Add(this.frequencyBoxFinish);
            this.spectrGroupBox.Controls.Add(this.label2);
            this.spectrGroupBox.Controls.Add(this.label1);
            this.spectrGroupBox.Controls.Add(this.frequencyBoxStart);
            this.spectrGroupBox.Enabled = false;
            this.spectrGroupBox.Location = new System.Drawing.Point(7, 186);
            this.spectrGroupBox.Name = "spectrGroupBox";
            this.spectrGroupBox.Size = new System.Drawing.Size(240, 103);
            this.spectrGroupBox.TabIndex = 2;
            this.spectrGroupBox.TabStop = false;
            this.spectrGroupBox.Text = "Диапозон частот (Гц)";
            // 
            // frequencyBoxFinish
            // 
            this.frequencyBoxFinish.Location = new System.Drawing.Point(134, 66);
            this.frequencyBoxFinish.Name = "frequencyBoxFinish";
            this.frequencyBoxFinish.Size = new System.Drawing.Size(100, 20);
            this.frequencyBoxFinish.TabIndex = 3;
            this.frequencyBoxFinish.Text = "20000";
            this.frequencyBoxFinish.TextChanged += new System.EventHandler(this.frequency_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Конечная:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Начальная:";
            // 
            // frequencyBoxStart
            // 
            this.frequencyBoxStart.Location = new System.Drawing.Point(134, 25);
            this.frequencyBoxStart.Name = "frequencyBoxStart";
            this.frequencyBoxStart.Size = new System.Drawing.Size(100, 20);
            this.frequencyBoxStart.TabIndex = 0;
            this.frequencyBoxStart.Text = "0";
            this.frequencyBoxStart.TextChanged += new System.EventHandler(this.frequency_TextChanged);
            // 
            // colorGroupBox
            // 
            this.colorGroupBox.Controls.Add(this.colorBoxFinish);
            this.colorGroupBox.Controls.Add(this.colorBoxStart);
            this.colorGroupBox.Controls.Add(this.colorButtonFinish);
            this.colorGroupBox.Controls.Add(this.colorButtonStart);
            this.colorGroupBox.Location = new System.Drawing.Point(7, 67);
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.Size = new System.Drawing.Size(240, 112);
            this.colorGroupBox.TabIndex = 1;
            this.colorGroupBox.TabStop = false;
            this.colorGroupBox.Text = "Параметры цвета";
            // 
            // colorBoxFinish
            // 
            this.colorBoxFinish.BackColor = System.Drawing.Color.Red;
            this.colorBoxFinish.Location = new System.Drawing.Point(134, 48);
            this.colorBoxFinish.Name = "colorBoxFinish";
            this.colorBoxFinish.Size = new System.Drawing.Size(100, 50);
            this.colorBoxFinish.TabIndex = 3;
            this.colorBoxFinish.TabStop = false;
            // 
            // colorBoxStart
            // 
            this.colorBoxStart.BackColor = System.Drawing.Color.LimeGreen;
            this.colorBoxStart.Location = new System.Drawing.Point(6, 48);
            this.colorBoxStart.Name = "colorBoxStart";
            this.colorBoxStart.Size = new System.Drawing.Size(100, 50);
            this.colorBoxStart.TabIndex = 2;
            this.colorBoxStart.TabStop = false;
            // 
            // colorButtonFinish
            // 
            this.colorButtonFinish.Location = new System.Drawing.Point(134, 19);
            this.colorButtonFinish.Name = "colorButtonFinish";
            this.colorButtonFinish.Size = new System.Drawing.Size(100, 23);
            this.colorButtonFinish.TabIndex = 1;
            this.colorButtonFinish.Text = "Цвет конца";
            this.colorButtonFinish.UseVisualStyleBackColor = true;
            this.colorButtonFinish.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // colorButtonStart
            // 
            this.colorButtonStart.Location = new System.Drawing.Point(6, 19);
            this.colorButtonStart.Name = "colorButtonStart";
            this.colorButtonStart.Size = new System.Drawing.Size(100, 23);
            this.colorButtonStart.TabIndex = 0;
            this.colorButtonStart.Text = "Цвет начала";
            this.colorButtonStart.UseVisualStyleBackColor = true;
            this.colorButtonStart.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // mainOpenButton
            // 
            this.mainOpenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainOpenButton.Location = new System.Drawing.Point(7, 20);
            this.mainOpenButton.Name = "mainOpenButton";
            this.mainOpenButton.Size = new System.Drawing.Size(240, 40);
            this.mainOpenButton.TabIndex = 0;
            this.mainOpenButton.Text = "Открыть папку";
            this.mainOpenButton.UseVisualStyleBackColor = true;
            this.mainOpenButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 581);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.graphicGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Курсовая";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.graphicGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.depthGroupBox.ResumeLayout(false);
            this.depthGroupBox.PerformLayout();
            this.spectrGroupBox.ResumeLayout(false);
            this.spectrGroupBox.PerformLayout();
            this.colorGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colorBoxFinish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBoxStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openButton;
        private System.Windows.Forms.ToolStripMenuItem exitButton;
        private System.Windows.Forms.ToolStripMenuItem helpButton;
        private System.Windows.Forms.GroupBox graphicGroupBox;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.Button mainOpenButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.GroupBox colorGroupBox;
        private System.Windows.Forms.Button colorButtonFinish;
        private System.Windows.Forms.Button colorButtonStart;
        private System.Windows.Forms.PictureBox colorBoxFinish;
        private System.Windows.Forms.PictureBox colorBoxStart;
        private System.Windows.Forms.GroupBox spectrGroupBox;
        private System.Windows.Forms.GroupBox depthGroupBox;
        private System.Windows.Forms.TextBox frequencyBoxFinish;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox frequencyBoxStart;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox depthBoxFinish;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox depthBoxStart;
        private System.Windows.Forms.Label finishTime;
        private System.Windows.Forms.Label startTime;
    }
}

