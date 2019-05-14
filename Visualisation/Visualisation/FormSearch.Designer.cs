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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearch));
            this.rtb_pseudocode = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_search_value = new System.Windows.Forms.TextBox();
            this.b_search = new System.Windows.Forms.Button();
            this.b_add = new System.Windows.Forms.Button();
            this.b_delete = new System.Windows.Forms.Button();
            this.b_random = new System.Windows.Forms.Button();
            this.b_prev = new System.Windows.Forms.Button();
            this.b_start_pause = new System.Windows.Forms.Button();
            this.b_next = new System.Windows.Forms.Button();
            this.pb_animation = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_add = new System.Windows.Forms.TextBox();
            this.tb_delete = new System.Windows.Forms.TextBox();
            this.rtb_result = new System.Windows.Forms.RichTextBox();
            this.avl_menu = new System.Windows.Forms.Button();
            this.binary_tree_menu = new System.Windows.Forms.Button();
            this.interpolation_menu = new System.Windows.Forms.Button();
            this.linear_menu = new System.Windows.Forms.Button();
            this.digital_menu = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_animation)).BeginInit();
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
            this.tb_search_value.Size = new System.Drawing.Size(144, 22);
            this.tb_search_value.TabIndex = 2;
            // 
            // b_search
            // 
            this.b_search.Location = new System.Drawing.Point(1123, 475);
            this.b_search.Name = "b_search";
            this.b_search.Size = new System.Drawing.Size(190, 28);
            this.b_search.TabIndex = 5;
            this.b_search.Text = "Поиск / Старт";
            this.b_search.UseVisualStyleBackColor = true;
            this.b_search.Click += new System.EventHandler(this.b_search_Click);
            // 
            // b_add
            // 
            this.b_add.Location = new System.Drawing.Point(1123, 384);
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(190, 28);
            this.b_add.TabIndex = 6;
            this.b_add.Text = "Добавить вершину";
            this.b_add.UseVisualStyleBackColor = true;
            this.b_add.Click += new System.EventHandler(this.b_add_Click);
            // 
            // b_delete
            // 
            this.b_delete.Location = new System.Drawing.Point(1123, 413);
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(190, 28);
            this.b_delete.TabIndex = 7;
            this.b_delete.Text = "Удалить вершину";
            this.b_delete.UseVisualStyleBackColor = true;
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // b_random
            // 
            this.b_random.Location = new System.Drawing.Point(972, 441);
            this.b_random.Name = "b_random";
            this.b_random.Size = new System.Drawing.Size(341, 28);
            this.b_random.TabIndex = 8;
            this.b_random.Text = "Случайное дерево";
            this.b_random.UseVisualStyleBackColor = true;
            this.b_random.Click += new System.EventHandler(this.b_random_click);
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
            // tb_add
            // 
            this.tb_add.Location = new System.Drawing.Point(973, 385);
            this.tb_add.Name = "tb_add";
            this.tb_add.Size = new System.Drawing.Size(144, 22);
            this.tb_add.TabIndex = 14;
            // 
            // tb_delete
            // 
            this.tb_delete.Location = new System.Drawing.Point(973, 415);
            this.tb_delete.Name = "tb_delete";
            this.tb_delete.Size = new System.Drawing.Size(144, 22);
            this.tb_delete.TabIndex = 15;
            // 
            // rtb_result
            // 
            this.rtb_result.Location = new System.Drawing.Point(210, 438);
            this.rtb_result.Name = "rtb_result";
            this.rtb_result.Size = new System.Drawing.Size(756, 105);
            this.rtb_result.TabIndex = 16;
            this.rtb_result.Text = "";
            // 
            // avl_menu
            // 
            this.avl_menu.Location = new System.Drawing.Point(13, 13);
            this.avl_menu.Name = "avl_menu";
            this.avl_menu.Size = new System.Drawing.Size(191, 39);
            this.avl_menu.TabIndex = 17;
            this.avl_menu.Text = "АВЛ-деревья";
            this.avl_menu.UseVisualStyleBackColor = true;
            this.avl_menu.Click += new System.EventHandler(this.b_search_Click);
            // 
            // binary_tree_menu
            // 
            this.binary_tree_menu.Location = new System.Drawing.Point(13, 58);
            this.binary_tree_menu.Name = "binary_tree_menu";
            this.binary_tree_menu.Size = new System.Drawing.Size(191, 39);
            this.binary_tree_menu.TabIndex = 17;
            this.binary_tree_menu.Text = "Бинарное дерево поиска\r\n";
            this.binary_tree_menu.UseVisualStyleBackColor = true;
            this.binary_tree_menu.Click += new System.EventHandler(this.b_search_Click);
            // 
            // interpolation_menu
            // 
            this.interpolation_menu.Location = new System.Drawing.Point(13, 103);
            this.interpolation_menu.Name = "interpolation_menu";
            this.interpolation_menu.Size = new System.Drawing.Size(191, 39);
            this.interpolation_menu.TabIndex = 17;
            this.interpolation_menu.Text = "Интерполяционный поиск";
            this.interpolation_menu.UseVisualStyleBackColor = true;
            this.interpolation_menu.Click += new System.EventHandler(this.b_search_Click);
            // 
            // linear_menu
            // 
            this.linear_menu.Location = new System.Drawing.Point(12, 148);
            this.linear_menu.Name = "linear_menu";
            this.linear_menu.Size = new System.Drawing.Size(191, 39);
            this.linear_menu.TabIndex = 17;
            this.linear_menu.Text = "Линейный поиск";
            this.linear_menu.UseVisualStyleBackColor = true;
            this.linear_menu.Click += new System.EventHandler(this.b_search_Click);
            // 
            // digital_menu
            // 
            this.digital_menu.Location = new System.Drawing.Point(13, 193);
            this.digital_menu.Name = "digital_menu";
            this.digital_menu.Size = new System.Drawing.Size(191, 39);
            this.digital_menu.TabIndex = 17;
            this.digital_menu.Text = "Цифровой поиск";
            this.digital_menu.UseVisualStyleBackColor = true;
            this.digital_menu.Click += new System.EventHandler(this.b_search_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 549);
            this.Controls.Add(this.digital_menu);
            this.Controls.Add(this.linear_menu);
            this.Controls.Add(this.interpolation_menu);
            this.Controls.Add(this.binary_tree_menu);
            this.Controls.Add(this.avl_menu);
            this.Controls.Add(this.rtb_result);
            this.Controls.Add(this.tb_delete);
            this.Controls.Add(this.tb_add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pb_animation);
            this.Controls.Add(this.b_next);
            this.Controls.Add(this.b_start_pause);
            this.Controls.Add(this.b_prev);
            this.Controls.Add(this.b_random);
            this.Controls.Add(this.b_delete);
            this.Controls.Add(this.b_add);
            this.Controls.Add(this.b_search);
            this.Controls.Add(this.tb_search_value);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb_pseudocode);
            this.Name = "FormSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSearch";
            this.Load += new System.EventHandler(this.FormSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_animation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_pseudocode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_search_value;
        private System.Windows.Forms.Button b_search;
        private System.Windows.Forms.Button b_add;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Button b_random;
        private System.Windows.Forms.Button b_prev;
        private System.Windows.Forms.Button b_start_pause;
        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.PictureBox pb_animation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_add;
        private System.Windows.Forms.TextBox tb_delete;
        private System.Windows.Forms.RichTextBox rtb_result;
        private System.Windows.Forms.Button avl_menu;
        private System.Windows.Forms.Button binary_tree_menu;
        private System.Windows.Forms.Button interpolation_menu;
        private System.Windows.Forms.Button linear_menu;
        private System.Windows.Forms.Button digital_menu;
        private System.Windows.Forms.Timer timer1;
    }
}