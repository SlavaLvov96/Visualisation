namespace Visualisation
{
    partial class FormSort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSort));
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.comboBoxGraph = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxInText = new System.Windows.Forms.TextBox();
            this.textBoxOutText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "Merge",
            "Shell",
            "Bubble",
            "Bucket",
            "Insertion"});
            this.comboBoxSort.Location = new System.Drawing.Point(3, 3);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSort.TabIndex = 1;
            this.comboBoxSort.Text = "Sorting";
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Items.AddRange(new object[] {
            "Sequential",
            "Interval",
            "Linear",
            "Binary",
            "Jump"});
            this.comboBoxSearch.Location = new System.Drawing.Point(3, 27);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSearch.TabIndex = 2;
            this.comboBoxSearch.Text = "Searching";
            // 
            // comboBoxGraph
            // 
            this.comboBoxGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxGraph.FormattingEnabled = true;
            this.comboBoxGraph.Items.AddRange(new object[] {
            "Minimax",
            "Kernel",
            "Kruskal\'s",
            "Tree traversal"});
            this.comboBoxGraph.Location = new System.Drawing.Point(3, 51);
            this.comboBoxGraph.Name = "comboBoxGraph";
            this.comboBoxGraph.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGraph.TabIndex = 3;
            this.comboBoxGraph.Text = "Graphs";
            // 
            // buttonStart
            // 
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.Location = new System.Drawing.Point(27, 415);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(130, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(591, 435);
            this.dataGridView1.TabIndex = 5;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrev.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrev.Image")));
            this.buttonPrev.Location = new System.Drawing.Point(729, 388);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(50, 50);
            this.buttonPrev.TabIndex = 6;
            this.buttonPrev.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(785, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(841, 388);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(50, 50);
            this.buttonNext.TabIndex = 8;
            this.buttonNext.UseVisualStyleBackColor = true;
            // 
            // textBoxInText
            // 
            this.textBoxInText.Location = new System.Drawing.Point(729, 312);
            this.textBoxInText.Name = "textBoxInText";
            this.textBoxInText.Size = new System.Drawing.Size(255, 20);
            this.textBoxInText.TabIndex = 9;
            this.textBoxInText.Text = "Введите значения...";
            // 
            // textBoxOutText
            // 
            this.textBoxOutText.Location = new System.Drawing.Point(729, 362);
            this.textBoxOutText.Name = "textBoxOutText";
            this.textBoxOutText.Size = new System.Drawing.Size(255, 20);
            this.textBoxOutText.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(727, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Result:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(727, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Enter values";
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(727, 3);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(257, 290);
            this.richTextBox.TabIndex = 13;
            this.richTextBox.Text = "";
            // 
            // FormSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 446);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOutText);
            this.Controls.Add(this.textBoxInText);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.comboBoxGraph);
            this.Controls.Add(this.comboBoxSearch);
            this.Controls.Add(this.comboBoxSort);
            this.Name = "FormSort";
            this.Text = "Visualization";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxGraph;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxInText;
        private System.Windows.Forms.TextBox textBoxOutText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}

