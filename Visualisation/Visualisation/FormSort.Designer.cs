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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonStartPause = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxInText = new System.Windows.Forms.TextBox();
            this.textBoxOutText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.buttonBubble = new System.Windows.Forms.Button();
            this.buttonQuick = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonSelection = new System.Windows.Forms.Button();
            this.buttonHeapsort = new System.Windows.Forms.Button();
            this.buttonShell = new System.Windows.Forms.Button();
            this.buttonTimsort = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.Location = new System.Drawing.Point(729, 338);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Initialization";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrev.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrev.Image")));
            this.buttonPrev.Location = new System.Drawing.Point(730, 444);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(50, 50);
            this.buttonPrev.TabIndex = 6;
            this.buttonPrev.UseVisualStyleBackColor = true;
            // 
            // buttonStartPause
            // 
            this.buttonStartPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStartPause.Image = ((System.Drawing.Image)(resources.GetObject("buttonStartPause.Image")));
            this.buttonStartPause.Location = new System.Drawing.Point(786, 444);
            this.buttonStartPause.Name = "buttonStartPause";
            this.buttonStartPause.Size = new System.Drawing.Size(50, 50);
            this.buttonStartPause.TabIndex = 7;
            this.buttonStartPause.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(842, 444);
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
            // 
            // textBoxOutText
            // 
            this.textBoxOutText.Location = new System.Drawing.Point(730, 418);
            this.textBoxOutText.Name = "textBoxOutText";
            this.textBoxOutText.Size = new System.Drawing.Size(255, 20);
            this.textBoxOutText.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(728, 402);
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
            // buttonBubble
            // 
            this.buttonBubble.Location = new System.Drawing.Point(0, 3);
            this.buttonBubble.Name = "buttonBubble";
            this.buttonBubble.Size = new System.Drawing.Size(124, 23);
            this.buttonBubble.TabIndex = 14;
            this.buttonBubble.Text = "Пузырьковая";
            this.buttonBubble.UseVisualStyleBackColor = true;
            this.buttonBubble.Click += new System.EventHandler(this.buttonBubble_Click);
            // 
            // buttonQuick
            // 
            this.buttonQuick.Location = new System.Drawing.Point(0, 32);
            this.buttonQuick.Name = "buttonQuick";
            this.buttonQuick.Size = new System.Drawing.Size(124, 23);
            this.buttonQuick.TabIndex = 15;
            this.buttonQuick.Text = "Быстрая";
            this.buttonQuick.UseVisualStyleBackColor = true;
            this.buttonQuick.Click += new System.EventHandler(this.buttonQuick_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(0, 119);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(124, 23);
            this.buttonInsert.TabIndex = 16;
            this.buttonInsert.Text = "Вставками";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonSelection
            // 
            this.buttonSelection.Location = new System.Drawing.Point(0, 61);
            this.buttonSelection.Name = "buttonSelection";
            this.buttonSelection.Size = new System.Drawing.Size(124, 23);
            this.buttonSelection.TabIndex = 17;
            this.buttonSelection.Text = "Выбором";
            this.buttonSelection.UseVisualStyleBackColor = true;
            this.buttonSelection.Click += new System.EventHandler(this.buttonSelection_Click);
            // 
            // buttonHeapsort
            // 
            this.buttonHeapsort.Location = new System.Drawing.Point(0, 90);
            this.buttonHeapsort.Name = "buttonHeapsort";
            this.buttonHeapsort.Size = new System.Drawing.Size(124, 23);
            this.buttonHeapsort.TabIndex = 18;
            this.buttonHeapsort.Text = "Пирамидальная";
            this.buttonHeapsort.UseVisualStyleBackColor = true;
            this.buttonHeapsort.Click += new System.EventHandler(this.buttonHeapsort_Click);
            // 
            // buttonShell
            // 
            this.buttonShell.Location = new System.Drawing.Point(0, 148);
            this.buttonShell.Name = "buttonShell";
            this.buttonShell.Size = new System.Drawing.Size(124, 23);
            this.buttonShell.TabIndex = 19;
            this.buttonShell.Text = "Шелла";
            this.buttonShell.UseVisualStyleBackColor = true;
            this.buttonShell.Click += new System.EventHandler(this.buttonShell_Click);
            // 
            // buttonTimsort
            // 
            this.buttonTimsort.Location = new System.Drawing.Point(0, 177);
            this.buttonTimsort.Name = "buttonTimsort";
            this.buttonTimsort.Size = new System.Drawing.Size(124, 23);
            this.buttonTimsort.TabIndex = 20;
            this.buttonTimsort.Text = "TimSort";
            this.buttonTimsort.UseVisualStyleBackColor = true;
            this.buttonTimsort.Click += new System.EventHandler(this.buttonTimsort_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(130, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 445);
            this.panel1.TabIndex = 21;
            // 
            // FormSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 501);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonTimsort);
            this.Controls.Add(this.buttonShell);
            this.Controls.Add(this.buttonHeapsort);
            this.Controls.Add(this.buttonSelection);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.buttonQuick);
            this.Controls.Add(this.buttonBubble);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOutText);
            this.Controls.Add(this.textBoxInText);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonStartPause);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonStart);
            this.Name = "FormSort";
            this.Text = "Sorting algorithms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonStartPause;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxInText;
        private System.Windows.Forms.TextBox textBoxOutText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button buttonBubble;
        private System.Windows.Forms.Button buttonQuick;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonSelection;
        private System.Windows.Forms.Button buttonHeapsort;
        private System.Windows.Forms.Button buttonShell;
        private System.Windows.Forms.Button buttonTimsort;
        private System.Windows.Forms.Panel panel1;
    }
}

