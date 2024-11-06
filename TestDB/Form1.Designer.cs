namespace TestDB
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numMinimumSalary = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numMaximumSalary = new System.Windows.Forms.NumericUpDown();
            this.btnInsertJob = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvJobs = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMinimumSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximumSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
            this.SuspendLayout();
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Location = new System.Drawing.Point(43, 90);
            this.txtJobTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(110, 26);
            this.txtJobTitle.TabIndex = 3;
            this.txtJobTitle.TextChanged += new System.EventHandler(this.txtJobTitle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Job Title";
            // 
            // numMinimumSalary
            // 
            this.numMinimumSalary.Location = new System.Drawing.Point(43, 173);
            this.numMinimumSalary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numMinimumSalary.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numMinimumSalary.Name = "numMinimumSalary";
            this.numMinimumSalary.Size = new System.Drawing.Size(180, 26);
            this.numMinimumSalary.TabIndex = 5;
            this.numMinimumSalary.ValueChanged += new System.EventHandler(this.numMinimumSalary_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Minimum Salary";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 234);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Maximum Salary";
            // 
            // numMaximumSalary
            // 
            this.numMaximumSalary.Location = new System.Drawing.Point(43, 259);
            this.numMaximumSalary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numMaximumSalary.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numMaximumSalary.Name = "numMaximumSalary";
            this.numMaximumSalary.Size = new System.Drawing.Size(180, 26);
            this.numMaximumSalary.TabIndex = 7;
            this.numMaximumSalary.ValueChanged += new System.EventHandler(this.numMaximumSalary_ValueChanged);
            // 
            // btnInsertJob
            // 
            this.btnInsertJob.Enabled = false;
            this.btnInsertJob.Location = new System.Drawing.Point(43, 344);
            this.btnInsertJob.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInsertJob.Name = "btnInsertJob";
            this.btnInsertJob.Size = new System.Drawing.Size(112, 35);
            this.btnInsertJob.TabIndex = 9;
            this.btnInsertJob.Text = "Insert";
            this.btnInsertJob.UseVisualStyleBackColor = true;
            this.btnInsertJob.Click += new System.EventHandler(this.btnInsertJob_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Select Job";
            // 
            // dgvJobs
            // 
            this.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobs.Location = new System.Drawing.Point(267, 87);
            this.dgvJobs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvJobs.Name = "dgvJobs";
            this.dgvJobs.RowHeadersWidth = 62;
            this.dgvJobs.Size = new System.Drawing.Size(868, 672);
            this.dgvJobs.TabIndex = 13;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(357, 48);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 35);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(478, 48);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 798);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvJobs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnInsertJob);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numMaximumSalary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numMinimumSalary);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJobTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numMinimumSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximumSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMinimumSalary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numMaximumSalary;
        private System.Windows.Forms.Button btnInsertJob;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvJobs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
    }
}

