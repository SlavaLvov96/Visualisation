namespace Visualisation
{
    partial class FormSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearch));
            this.rtb_pseudocode = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_search_value = new System.Windows.Forms.TextBox();
            this.tb_add = new System.Windows.Forms.TextBox();
            this.tb_delete = new System.Windows.Forms.TextBox();
            this.b_search = new System.Windows.Forms.Button();
            this.b_add = new System.Windows.Forms.Button();
            this.b_delete = new System.Windows.Forms.Button();
            this.b_rotation = new System.Windows.Forms.Button();
            this.b_prev = new System.Windows.Forms.Button();
            this.b_start_pause = new System.Windows.Forms.Button();
            this.b_next = new System.Windows.Forms.Button();
            this.pb_animation = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_result = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.бинарныйПоискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.интерполяционныйПоискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.линейныйПоискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цифровойПоискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pb_animation)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb_pseudocode
            // 
            this.rtb_pseudocode.Location = new System.Drawing.Point(969, 4);
            this.rtb_pseudocode.Name = "rtb_pseudocode";
            this.rtb_pseudocode.Size = new System.Drawing.Size(341, 356);
            this.rtb_pseudocode.TabIndex = 0;
            this.rtb_pseudocode.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(969, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите значения";
            // 
            // tb_search_value
            // 
            this.tb_search_value.Location = new System.Drawing.Point(972, 475);
            this.tb_search_value.Name = "tb_search_value";
            this.tb_search_value.Size = new System.Drawing.Size(171, 22);
            this.tb_search_value.TabIndex = 2;
            this.tb_search_value.Text = "Значение для поиска...";
            // 
            // tb_add
            // 
            this.tb_add.Location = new System.Drawing.Point(972, 384);
            this.tb_add.Name = "tb_add";
            this.tb_add.Size = new System.Drawing.Size(171, 22);
            this.tb_add.TabIndex = 3;
            this.tb_add.Text = "Добавить вершину...";
            // 
            // tb_delete
            // 
            this.tb_delete.Location = new System.Drawing.Point(972, 413);
            this.tb_delete.Name = "tb_delete";
            this.tb_delete.Size = new System.Drawing.Size(171, 22);
            this.tb_delete.TabIndex = 4;
            this.tb_delete.Text = "Удалить вершину...";
            // 
            // b_search
            // 
            this.b_search.Location = new System.Drawing.Point(1160, 475);
            this.b_search.Name = "b_search";
            this.b_search.Size = new System.Drawing.Size(150, 23);
            this.b_search.TabIndex = 5;
            this.b_search.Text = "Поиск / Старт";
            this.b_search.UseVisualStyleBackColor = true;
            // 
            // b_add
            // 
            this.b_add.Location = new System.Drawing.Point(1160, 384);
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(150, 23);
            this.b_add.TabIndex = 6;
            this.b_add.Text = "Добавить";
            this.b_add.UseVisualStyleBackColor = true;
            // 
            // b_delete
            // 
            this.b_delete.Location = new System.Drawing.Point(1160, 413);
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(150, 23);
            this.b_delete.TabIndex = 7;
            this.b_delete.Text = "Удалить";
            this.b_delete.UseVisualStyleBackColor = true;
            // 
            // b_rotation
            // 
            this.b_rotation.Location = new System.Drawing.Point(972, 441);
            this.b_rotation.Name = "b_rotation";
            this.b_rotation.Size = new System.Drawing.Size(341, 28);
            this.b_rotation.TabIndex = 8;
            this.b_rotation.Text = "Вращение";
            this.b_rotation.UseVisualStyleBackColor = true;
            // 
            // b_prev
            // 
            this.b_prev.Image = ((System.Drawing.Image)(resources.GetObject("b_prev.Image")));
            this.b_prev.Location = new System.Drawing.Point(972, 503);
            this.b_prev.Name = "b_prev";
            this.b_prev.Size = new System.Drawing.Size(57, 40);
            this.b_prev.TabIndex = 9;
            this.b_prev.UseVisualStyleBackColor = true;
            this.b_prev.Click += new System.EventHandler(this.prev_click);
            // 
            // b_start_pause
            // 
            this.b_start_pause.Image = ((System.Drawing.Image)(resources.GetObject("b_start_pause.Image")));
            this.b_start_pause.Location = new System.Drawing.Point(1035, 503);
            this.b_start_pause.Name = "b_start_pause";
            this.b_start_pause.Size = new System.Drawing.Size(57, 40);
            this.b_start_pause.TabIndex = 9;
            this.b_start_pause.UseVisualStyleBackColor = true;
            // 
            // b_next
            // 
            this.b_next.Image = ((System.Drawing.Image)(resources.GetObject("b_next.Image")));
            this.b_next.Location = new System.Drawing.Point(1098, 503);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(57, 40);
            this.b_next.TabIndex = 9;
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.next_click);
            // 
            // pb_animation
            // 
            this.pb_animation.Location = new System.Drawing.Point(210, 4);
            this.pb_animation.Name = "pb_animation";
            this.pb_animation.Size = new System.Drawing.Size(756, 400);
            this.pb_animation.TabIndex = 10;
            this.pb_animation.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Результат";
            // 
            // tb_result
            // 
            this.tb_result.Location = new System.Drawing.Point(210, 441);
            this.tb_result.Multiline = true;
            this.tb_result.Name = "tb_result";
            this.tb_result.Size = new System.Drawing.Size(756, 102);
            this.tb_result.TabIndex = 12;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.бинарныйПоискToolStripMenuItem,
            this.интерполяционныйПоискToolStripMenuItem,
            this.линейныйПоискToolStripMenuItem,
            this.цифровойПоискToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(220, 549);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.765218F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(4);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(207, 32);
            this.toolStripMenuItem1.Text = "АВЛ-деревья";
            this.toolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.avl_click);
            // 
            // бинарныйПоискToolStripMenuItem
            // 
            this.бинарныйПоискToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.бинарныйПоискToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 8.765218F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.бинарныйПоискToolStripMenuItem.Name = "бинарныйПоискToolStripMenuItem";
            this.бинарныйПоискToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            this.бинарныйПоискToolStripMenuItem.Size = new System.Drawing.Size(207, 32);
            this.бинарныйПоискToolStripMenuItem.Text = "Бинарный поиск";
            this.бинарныйПоискToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.бинарныйПоискToolStripMenuItem.Click += new System.EventHandler(this.binary_click);
            // 
            // интерполяционныйПоискToolStripMenuItem
            // 
            this.интерполяционныйПоискToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.интерполяционныйПоискToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 8.765218F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.интерполяционныйПоискToolStripMenuItem.Name = "интерполяционныйПоискToolStripMenuItem";
            this.интерполяционныйПоискToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            this.интерполяционныйПоискToolStripMenuItem.Size = new System.Drawing.Size(207, 32);
            this.интерполяционныйПоискToolStripMenuItem.Text = "Интерполяционный поиск";
            this.интерполяционныйПоискToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.интерполяционныйПоискToolStripMenuItem.Click += new System.EventHandler(this.interpolation_click);
            // 
            // линейныйПоискToolStripMenuItem
            // 
            this.линейныйПоискToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.линейныйПоискToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 8.765218F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.линейныйПоискToolStripMenuItem.Name = "линейныйПоискToolStripMenuItem";
            this.линейныйПоискToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            this.линейныйПоискToolStripMenuItem.Size = new System.Drawing.Size(207, 32);
            this.линейныйПоискToolStripMenuItem.Text = "Линейный поиск";
            this.линейныйПоискToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.линейныйПоискToolStripMenuItem.Click += new System.EventHandler(this.linear_click);
            // 
            // цифровойПоискToolStripMenuItem
            // 
            this.цифровойПоискToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.цифровойПоискToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 8.765218F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.цифровойПоискToolStripMenuItem.Name = "цифровойПоискToolStripMenuItem";
            this.цифровойПоискToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            this.цифровойПоискToolStripMenuItem.Size = new System.Drawing.Size(207, 32);
            this.цифровойПоискToolStripMenuItem.Text = "Цифровой поиск";
            this.цифровойПоискToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.цифровойПоискToolStripMenuItem.Click += new System.EventHandler(this.numeral_click);
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 549);
            this.Controls.Add(this.tb_result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pb_animation);
            this.Controls.Add(this.b_next);
            this.Controls.Add(this.b_start_pause);
            this.Controls.Add(this.b_prev);
            this.Controls.Add(this.b_rotation);
            this.Controls.Add(this.b_delete);
            this.Controls.Add(this.b_add);
            this.Controls.Add(this.b_search);
            this.Controls.Add(this.tb_delete);
            this.Controls.Add(this.tb_add);
            this.Controls.Add(this.tb_search_value);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb_pseudocode);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSearch";
            ((System.ComponentModel.ISupportInitialize)(this.pb_animation)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_pseudocode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_search_value;
        private System.Windows.Forms.TextBox tb_add;
        private System.Windows.Forms.TextBox tb_delete;
        private System.Windows.Forms.Button b_search;
        private System.Windows.Forms.Button b_add;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Button b_rotation;
        private System.Windows.Forms.Button b_prev;
        private System.Windows.Forms.Button b_start_pause;
        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.PictureBox pb_animation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_result;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem бинарныйПоискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem интерполяционныйПоискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem линейныйПоискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цифровойПоискToolStripMenuItem;
    }
}