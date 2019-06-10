namespace Visualisation
{
    partial class FormGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraph));
            this.buttonPrev = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.sheet = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxGraph = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.comboBoxNum = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cycleButton = new System.Windows.Forms.Button();
            this.chainButton = new System.Windows.Forms.Button();
            this.buttonInc = new System.Windows.Forms.Button();
            this.buttonAdj = new System.Windows.Forms.Button();
            this.deleteALLButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.drawEdgeButton = new System.Windows.Forms.Button();
            this.drawVertexButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPrev
            // 
            this.buttonPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrev.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrev.Image")));
            this.buttonPrev.Location = new System.Drawing.Point(6, 28);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(50, 50);
            this.buttonPrev.TabIndex = 7;
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(62, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(118, 28);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(50, 50);
            this.buttonNext.TabIndex = 9;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // sheet
            // 
            this.sheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheet.Location = new System.Drawing.Point(3, 16);
            this.sheet.Margin = new System.Windows.Forms.Padding(2);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(578, 315);
            this.sheet.TabIndex = 11;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Результат";
            // 
            // comboBoxGraph
            // 
            this.comboBoxGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxGraph.FormattingEnabled = true;
            this.comboBoxGraph.Items.AddRange(new object[] {
            "Крускала",
            "Дейкстры-Примы",
            "Поиск в глубину",
            "Поиск в ширину",
            "Минимальное остомное дерево",
            "Фундаментальные остовы циклов",
            "Кратчайшие пути",
            "Эйлеров цикл"});
            this.comboBoxGraph.Location = new System.Drawing.Point(3, 16);
            this.comboBoxGraph.Name = "comboBoxGraph";
            this.comboBoxGraph.Size = new System.Drawing.Size(147, 21);
            this.comboBoxGraph.TabIndex = 15;
            this.comboBoxGraph.Text = "Виды графов:";
            this.comboBoxGraph.SelectedIndexChanged += new System.EventHandler(this.comboBoxGraph_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(737, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 447);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.comboBoxNum);
            this.groupBox7.Controls.Add(this.button1);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(3, 312);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(255, 51);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            // 
            // comboBoxNum
            // 
            this.comboBoxNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxNum.FormattingEnabled = true;
            this.comboBoxNum.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxNum.Location = new System.Drawing.Point(118, 21);
            this.comboBoxNum.Name = "comboBoxNum";
            this.comboBoxNum.Size = new System.Drawing.Size(134, 21);
            this.comboBoxNum.TabIndex = 16;
            this.comboBoxNum.Text = "Кол-во вершин:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Создать шаблон";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.richTextBox);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 16);
            this.groupBox6.MaximumSize = new System.Drawing.Size(257, 600);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(255, 299);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonNext);
            this.groupBox5.Controls.Add(this.buttonPrev);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(3, 363);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 81);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(3, 28);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(578, 82);
            this.listBox2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cycleButton);
            this.groupBox2.Controls.Add(this.chainButton);
            this.groupBox2.Controls.Add(this.buttonInc);
            this.groupBox2.Controls.Add(this.buttonAdj);
            this.groupBox2.Controls.Add(this.deleteALLButton);
            this.groupBox2.Controls.Add(this.deleteButton);
            this.groupBox2.Controls.Add(this.drawEdgeButton);
            this.groupBox2.Controls.Add(this.drawVertexButton);
            this.groupBox2.Controls.Add(this.selectButton);
            this.groupBox2.Controls.Add(this.comboBoxGraph);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 447);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // cycleButton
            // 
            this.cycleButton.Location = new System.Drawing.Point(81, 371);
            this.cycleButton.Name = "cycleButton";
            this.cycleButton.Size = new System.Drawing.Size(69, 69);
            this.cycleButton.TabIndex = 24;
            this.cycleButton.Text = "поиск элементарных циклов";
            this.cycleButton.UseVisualStyleBackColor = true;
            this.cycleButton.Click += new System.EventHandler(this.cycleButton_Click_1);
            // 
            // chainButton
            // 
            this.chainButton.Location = new System.Drawing.Point(6, 371);
            this.chainButton.Name = "chainButton";
            this.chainButton.Size = new System.Drawing.Size(69, 69);
            this.chainButton.TabIndex = 23;
            this.chainButton.Text = "поиск элементарных цепей";
            this.chainButton.UseVisualStyleBackColor = true;
            this.chainButton.Click += new System.EventHandler(this.chainButton_Click);
            // 
            // buttonInc
            // 
            this.buttonInc.Location = new System.Drawing.Point(81, 298);
            this.buttonInc.Name = "buttonInc";
            this.buttonInc.Size = new System.Drawing.Size(69, 69);
            this.buttonInc.TabIndex = 22;
            this.buttonInc.Text = "матрица инцидентности";
            this.buttonInc.UseVisualStyleBackColor = true;
            this.buttonInc.Click += new System.EventHandler(this.buttonInc_Click_1);
            // 
            // buttonAdj
            // 
            this.buttonAdj.Location = new System.Drawing.Point(6, 298);
            this.buttonAdj.Name = "buttonAdj";
            this.buttonAdj.Size = new System.Drawing.Size(69, 69);
            this.buttonAdj.TabIndex = 21;
            this.buttonAdj.Text = "матрица смежности";
            this.buttonAdj.UseVisualStyleBackColor = true;
            this.buttonAdj.Click += new System.EventHandler(this.buttonAdj_Click_1);
            // 
            // deleteALLButton
            // 
            this.deleteALLButton.Location = new System.Drawing.Point(6, 247);
            this.deleteALLButton.Name = "deleteALLButton";
            this.deleteALLButton.Size = new System.Drawing.Size(141, 45);
            this.deleteALLButton.TabIndex = 20;
            this.deleteALLButton.Text = "Отчистить";
            this.deleteALLButton.UseVisualStyleBackColor = true;
            this.deleteALLButton.Click += new System.EventHandler(this.deleteALLButton_Click_1);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(6, 196);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(141, 45);
            this.deleteButton.TabIndex = 19;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click_1);
            // 
            // drawEdgeButton
            // 
            this.drawEdgeButton.Location = new System.Drawing.Point(6, 145);
            this.drawEdgeButton.Name = "drawEdgeButton";
            this.drawEdgeButton.Size = new System.Drawing.Size(141, 45);
            this.drawEdgeButton.TabIndex = 18;
            this.drawEdgeButton.Text = "Связь";
            this.drawEdgeButton.UseVisualStyleBackColor = true;
            this.drawEdgeButton.Click += new System.EventHandler(this.drawEdgeButton_Click_1);
            // 
            // drawVertexButton
            // 
            this.drawVertexButton.Location = new System.Drawing.Point(6, 94);
            this.drawVertexButton.Name = "drawVertexButton";
            this.drawVertexButton.Size = new System.Drawing.Size(141, 45);
            this.drawVertexButton.TabIndex = 17;
            this.drawVertexButton.Text = "Вершина";
            this.drawVertexButton.UseVisualStyleBackColor = true;
            this.drawVertexButton.Click += new System.EventHandler(this.drawVertexButton_Click_1);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(6, 43);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(141, 45);
            this.selectButton.TabIndex = 16;
            this.selectButton.Text = "Выделение";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(153, 334);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(584, 113);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.sheet);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(153, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(584, 334);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox.Location = new System.Drawing.Point(3, 16);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(249, 280);
            this.richTextBox.TabIndex = 14;
            this.richTextBox.Text = "";
            // 
            // FormGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(998, 447);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1010, 485);
            this.Name = "FormGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGraph";
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxGraph;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button cycleButton;
        private System.Windows.Forms.Button chainButton;
        private System.Windows.Forms.Button buttonInc;
        private System.Windows.Forms.Button buttonAdj;
        private System.Windows.Forms.Button deleteALLButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button drawEdgeButton;
        private System.Windows.Forms.Button drawVertexButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxNum;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}