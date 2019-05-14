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
            this.rtb_pseudocode.BackColor = System.Drawing.Color.SeaShell;
            this.rtb_pseudocode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_pseudocode.Font = new System.Drawing.Font("Century", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtb_pseudocode.Location = new System.Drawing.Point(969, 5);
            this.rtb_pseudocode.Name = "rtb_pseudocode";
            this.rtb_pseudocode.Size = new System.Drawing.Size(341, 400);
            this.rtb_pseudocode.TabIndex = 0;
            this.rtb_pseudocode.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(969, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите значения";
            // 
            // tb_search_value
            // 
            this.tb_search_value.BackColor = System.Drawing.Color.SeaShell;
            this.tb_search_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_search_value.Location = new System.Drawing.Point(973, 534);
            this.tb_search_value.Name = "tb_search_value";
            this.tb_search_value.Size = new System.Drawing.Size(144, 25);
            this.tb_search_value.TabIndex = 2;
            // 
            // b_search
            // 
            this.b_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_search.Location = new System.Drawing.Point(1123, 534);
            this.b_search.Name = "b_search";
            this.b_search.Size = new System.Drawing.Size(190, 31);
            this.b_search.TabIndex = 5;
            this.b_search.Text = "Поиск / Старт";
            this.b_search.UseVisualStyleBackColor = true;
            this.b_search.Click += new System.EventHandler(this.b_search_Click);
            // 
            // b_add
            // 
            this.b_add.BackColor = System.Drawing.Color.LightCyan;
            this.b_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_add.Location = new System.Drawing.Point(1123, 426);
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(190, 31);
            this.b_add.TabIndex = 6;
            this.b_add.Text = "Добавить вершину";
            this.b_add.UseVisualStyleBackColor = false;
            this.b_add.Click += new System.EventHandler(this.b_add_Click);
            // 
            // b_delete
            // 
            this.b_delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_delete.Location = new System.Drawing.Point(1123, 460);
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(190, 31);
            this.b_delete.TabIndex = 7;
            this.b_delete.Text = "Удалить вершину";
            this.b_delete.UseVisualStyleBackColor = true;
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // b_random
            // 
            this.b_random.BackColor = System.Drawing.Color.Honeydew;
            this.b_random.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_random.Location = new System.Drawing.Point(972, 496);
            this.b_random.Name = "b_random";
            this.b_random.Size = new System.Drawing.Size(341, 31);
            this.b_random.TabIndex = 8;
            this.b_random.Text = "Случайное дерево";
            this.b_random.UseVisualStyleBackColor = false;
            this.b_random.Click += new System.EventHandler(this.b_random_click);
            // 
            // b_prev
            // 
            this.b_prev.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_prev.Image = ((System.Drawing.Image)(resources.GetObject("b_prev.Image")));
            this.b_prev.Location = new System.Drawing.Point(20, 566);
            this.b_prev.Name = "b_prev";
            this.b_prev.Size = new System.Drawing.Size(57, 45);
            this.b_prev.TabIndex = 9;
            this.b_prev.UseVisualStyleBackColor = true;
            this.b_prev.Click += new System.EventHandler(this.prev_click);
            // 
            // b_start_pause
            // 
            this.b_start_pause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_start_pause.Image = ((System.Drawing.Image)(resources.GetObject("b_start_pause.Image")));
            this.b_start_pause.Location = new System.Drawing.Point(83, 566);
            this.b_start_pause.Name = "b_start_pause";
            this.b_start_pause.Size = new System.Drawing.Size(57, 45);
            this.b_start_pause.TabIndex = 9;
            this.b_start_pause.UseVisualStyleBackColor = true;
            // 
            // b_next
            // 
            this.b_next.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_next.Image = ((System.Drawing.Image)(resources.GetObject("b_next.Image")));
            this.b_next.Location = new System.Drawing.Point(146, 566);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(57, 45);
            this.b_next.TabIndex = 9;
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.next_click);
            // 
            // pb_animation
            // 
            this.pb_animation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_animation.Location = new System.Drawing.Point(210, 5);
            this.pb_animation.Name = "pb_animation";
            this.pb_animation.Size = new System.Drawing.Size(756, 450);
            this.pb_animation.TabIndex = 10;
            this.pb_animation.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Результат";
            // 
            // tb_add
            // 
            this.tb_add.BackColor = System.Drawing.Color.SeaShell;
            this.tb_add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_add.Location = new System.Drawing.Point(973, 433);
            this.tb_add.Name = "tb_add";
            this.tb_add.Size = new System.Drawing.Size(144, 25);
            this.tb_add.TabIndex = 14;
            // 
            // tb_delete
            // 
            this.tb_delete.BackColor = System.Drawing.Color.SeaShell;
            this.tb_delete.Location = new System.Drawing.Point(973, 467);
            this.tb_delete.Name = "tb_delete";
            this.tb_delete.Size = new System.Drawing.Size(144, 25);
            this.tb_delete.TabIndex = 15;
            // 
            // rtb_result
            // 
            this.rtb_result.BackColor = System.Drawing.Color.SeaShell;
            this.rtb_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_result.Font = new System.Drawing.Font("Century", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtb_result.Location = new System.Drawing.Point(210, 493);
            this.rtb_result.Name = "rtb_result";
            this.rtb_result.Size = new System.Drawing.Size(756, 118);
            this.rtb_result.TabIndex = 16;
            this.rtb_result.Text = "";
            // 
            // avl_menu
            // 
            this.avl_menu.BackColor = System.Drawing.Color.LightCyan;
            this.avl_menu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.avl_menu.Location = new System.Drawing.Point(13, 15);
            this.avl_menu.Name = "avl_menu";
            this.avl_menu.Size = new System.Drawing.Size(191, 44);
            this.avl_menu.TabIndex = 17;
            this.avl_menu.Text = "АВЛ-деревья";
            this.avl_menu.UseVisualStyleBackColor = false;
            this.avl_menu.Click += new System.EventHandler(this.b_search_Click);
            // 
            // binary_tree_menu
            // 
            this.binary_tree_menu.BackColor = System.Drawing.Color.LightCyan;
            this.binary_tree_menu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.binary_tree_menu.Location = new System.Drawing.Point(13, 65);
            this.binary_tree_menu.Name = "binary_tree_menu";
            this.binary_tree_menu.Size = new System.Drawing.Size(191, 44);
            this.binary_tree_menu.TabIndex = 17;
            this.binary_tree_menu.Text = "Бинарное дерево поиска\r\n";
            this.binary_tree_menu.UseVisualStyleBackColor = false;
            this.binary_tree_menu.Click += new System.EventHandler(this.b_search_Click);
            // 
            // interpolation_menu
            // 
            this.interpolation_menu.BackColor = System.Drawing.Color.LightCyan;
            this.interpolation_menu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.interpolation_menu.Location = new System.Drawing.Point(13, 116);
            this.interpolation_menu.Name = "interpolation_menu";
            this.interpolation_menu.Size = new System.Drawing.Size(191, 44);
            this.interpolation_menu.TabIndex = 17;
            this.interpolation_menu.Text = "Интерполяционный поиск";
            this.interpolation_menu.UseVisualStyleBackColor = false;
            this.interpolation_menu.Click += new System.EventHandler(this.b_search_Click);
            // 
            // linear_menu
            // 
            this.linear_menu.BackColor = System.Drawing.Color.LightCyan;
            this.linear_menu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.linear_menu.Location = new System.Drawing.Point(12, 167);
            this.linear_menu.Name = "linear_menu";
            this.linear_menu.Size = new System.Drawing.Size(191, 44);
            this.linear_menu.TabIndex = 17;
            this.linear_menu.Text = "Линейный поиск";
            this.linear_menu.UseVisualStyleBackColor = false;
            this.linear_menu.Click += new System.EventHandler(this.b_search_Click);
            // 
            // digital_menu
            // 
            this.digital_menu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.digital_menu.Location = new System.Drawing.Point(13, 217);
            this.digital_menu.Name = "digital_menu";
            this.digital_menu.Size = new System.Drawing.Size(191, 44);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1325, 618);
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
            this.Font = new System.Drawing.Font("Ink Free", 8.765217F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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