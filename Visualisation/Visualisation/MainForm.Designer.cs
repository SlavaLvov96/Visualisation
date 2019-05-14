namespace Visualisation
{
    partial class MainForm
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
            this.buttonSort = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonGraph = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSort
            // 
            this.buttonSort.BackColor = System.Drawing.Color.Honeydew;
            this.buttonSort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSort.Location = new System.Drawing.Point(22, 21);
            this.buttonSort.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(138, 65);
            this.buttonSort.TabIndex = 0;
            this.buttonSort.Text = "Алгоритмы сортировки";
            this.buttonSort.UseVisualStyleBackColor = false;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Honeydew;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSearch.Location = new System.Drawing.Point(170, 21);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(138, 65);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Алгоритмы поиска";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonGraph
            // 
            this.buttonGraph.BackColor = System.Drawing.Color.Honeydew;
            this.buttonGraph.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGraph.Location = new System.Drawing.Point(319, 21);
            this.buttonGraph.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonGraph.Name = "buttonGraph";
            this.buttonGraph.Size = new System.Drawing.Size(138, 65);
            this.buttonGraph.TabIndex = 2;
            this.buttonGraph.Text = "Алгоритмы на графах";
            this.buttonGraph.UseVisualStyleBackColor = false;
            this.buttonGraph.Click += new System.EventHandler(this.buttonGraph_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(484, 122);
            this.Controls.Add(this.buttonGraph);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonSort);
            this.Font = new System.Drawing.Font("Century Gothic", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите алгоритм...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonGraph;
    }
}