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
            this.rtb_pseudocode = new System.Windows.Forms.RichTextBox();
            this.pb_animation = new System.Windows.Forms.PictureBox();
            this.tb_result = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxGraph = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_animation)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPrev
            // 
            this.buttonPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrev.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrev.Image")));
            this.buttonPrev.Location = new System.Drawing.Point(729, 388);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(50, 50);
            this.buttonPrev.TabIndex = 7;
            this.buttonPrev.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(785, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(841, 388);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(50, 50);
            this.buttonNext.TabIndex = 9;
            this.buttonNext.UseVisualStyleBackColor = true;
            // 
            // rtb_pseudocode
            // 
            this.rtb_pseudocode.Location = new System.Drawing.Point(727, 3);
            this.rtb_pseudocode.Margin = new System.Windows.Forms.Padding(2);
            this.rtb_pseudocode.Name = "rtb_pseudocode";
            this.rtb_pseudocode.Size = new System.Drawing.Size(257, 290);
            this.rtb_pseudocode.TabIndex = 10;
            this.rtb_pseudocode.Text = "";
            // 
            // pb_animation
            // 
            this.pb_animation.Location = new System.Drawing.Point(158, 3);
            this.pb_animation.Margin = new System.Windows.Forms.Padding(2);
            this.pb_animation.Name = "pb_animation";
            this.pb_animation.Size = new System.Drawing.Size(567, 325);
            this.pb_animation.TabIndex = 11;
            this.pb_animation.TabStop = false;
            // 
            // tb_result
            // 
            this.tb_result.Location = new System.Drawing.Point(158, 358);
            this.tb_result.Margin = new System.Windows.Forms.Padding(2);
            this.tb_result.Multiline = true;
            this.tb_result.Name = "tb_result";
            this.tb_result.Size = new System.Drawing.Size(568, 84);
            this.tb_result.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 340);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Результат";
            // 
            // comboBoxGraph
            // 
            this.comboBoxGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxGraph.FormattingEnabled = true;
            this.comboBoxGraph.Items.AddRange(new object[] {
            "Крускала и Дейкстры-Примы",
            "Поиск в глубину",
            "Поиск в ширину",
            "Минимальное остомное дерево",
            "Фундаментальные остовы циклов",
            "Кратчайшие пути",
            "Эйлеров цикл"});
            this.comboBoxGraph.Location = new System.Drawing.Point(3, 3);
            this.comboBoxGraph.Name = "comboBoxGraph";
            this.comboBoxGraph.Size = new System.Drawing.Size(150, 21);
            this.comboBoxGraph.TabIndex = 15;
            this.comboBoxGraph.Text = "Виды графов:";
            // 
            // FormGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 446);
            this.Controls.Add(this.comboBoxGraph);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_result);
            this.Controls.Add(this.pb_animation);
            this.Controls.Add(this.rtb_pseudocode);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonPrev);
            this.Name = "FormGraph";
            this.Text = "FormGraph";
            ((System.ComponentModel.ISupportInitialize)(this.pb_animation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.RichTextBox rtb_pseudocode;
        private System.Windows.Forms.PictureBox pb_animation;
        private System.Windows.Forms.TextBox tb_result;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxGraph;
    }
}