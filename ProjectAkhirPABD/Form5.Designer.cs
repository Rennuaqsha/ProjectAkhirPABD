namespace ProjectAkhirPABD
{
    partial class StatusKaryawan
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
            this.label4 = new System.Windows.Forms.Label();
            this.StatusId = new System.Windows.Forms.Label();
            this.JnsKrywn = new System.Windows.Forms.Label();
            this.KrywnId = new System.Windows.Forms.Label();
            this.txtStatId = new System.Windows.Forms.TextBox();
            this.cbxJenis = new System.Windows.Forms.ComboBox();
            this.Add = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.cbxKarId = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Font = new System.Drawing.Font("Impact", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(279, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 41);
            this.label4.TabIndex = 18;
            this.label4.Text = "Status Karyawan";
            // 
            // StatusId
            // 
            this.StatusId.AutoSize = true;
            this.StatusId.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.StatusId.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusId.Location = new System.Drawing.Point(389, 104);
            this.StatusId.Name = "StatusId";
            this.StatusId.Size = new System.Drawing.Size(84, 25);
            this.StatusId.TabIndex = 19;
            this.StatusId.Text = "Status ID";
            // 
            // JnsKrywn
            // 
            this.JnsKrywn.AutoSize = true;
            this.JnsKrywn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.JnsKrywn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JnsKrywn.Location = new System.Drawing.Point(389, 178);
            this.JnsKrywn.Name = "JnsKrywn";
            this.JnsKrywn.Size = new System.Drawing.Size(137, 25);
            this.JnsKrywn.TabIndex = 20;
            this.JnsKrywn.Text = "Jenis Karyawan";
            // 
            // KrywnId
            // 
            this.KrywnId.AutoSize = true;
            this.KrywnId.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.KrywnId.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KrywnId.Location = new System.Drawing.Point(389, 252);
            this.KrywnId.Name = "KrywnId";
            this.KrywnId.Size = new System.Drawing.Size(112, 25);
            this.KrywnId.TabIndex = 21;
            this.KrywnId.Text = "Karyawan Id";
            // 
            // txtStatId
            // 
            this.txtStatId.Location = new System.Drawing.Point(535, 104);
            this.txtStatId.Name = "txtStatId";
            this.txtStatId.Size = new System.Drawing.Size(150, 22);
            this.txtStatId.TabIndex = 22;
            // 
            // cbxJenis
            // 
            this.cbxJenis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxJenis.FormattingEnabled = true;
            this.cbxJenis.Items.AddRange(new object[] {
            "1. Tetap",
            "2. Magang"});
            this.cbxJenis.Location = new System.Drawing.Point(535, 178);
            this.cbxJenis.Name = "cbxJenis";
            this.cbxJenis.Size = new System.Drawing.Size(150, 24);
            this.cbxJenis.TabIndex = 24;
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Add.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(697, 126);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(91, 35);
            this.Add.TabIndex = 31;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Save.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(697, 212);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(91, 35);
            this.Save.TabIndex = 32;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Next.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Next.Location = new System.Drawing.Point(476, 403);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(86, 35);
            this.Next.TabIndex = 34;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // cbxKarId
            // 
            this.cbxKarId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxKarId.FormattingEnabled = true;
            this.cbxKarId.Location = new System.Drawing.Point(535, 253);
            this.cbxKarId.Name = "cbxKarId";
            this.cbxKarId.Size = new System.Drawing.Size(150, 24);
            this.cbxKarId.TabIndex = 35;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(353, 225);
            this.dataGridView1.TabIndex = 36;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBack.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(243, 403);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(78, 35);
            this.btnBack.TabIndex = 38;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDelete.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(363, 403);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 35);
            this.btnDelete.TabIndex = 37;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // StatusKaryawan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::ProjectAkhirPABD.Properties.Resources.NanangFutsal;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbxKarId);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.cbxJenis);
            this.Controls.Add(this.txtStatId);
            this.Controls.Add(this.KrywnId);
            this.Controls.Add(this.JnsKrywn);
            this.Controls.Add(this.StatusId);
            this.Controls.Add(this.label4);
            this.DoubleBuffered = true;
            this.Name = "StatusKaryawan";
            this.Text = "Status Karyawan";
            this.Load += new System.EventHandler(this.StatusKaryawan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label StatusId;
        private System.Windows.Forms.Label JnsKrywn;
        private System.Windows.Forms.Label KrywnId;
        private System.Windows.Forms.TextBox txtStatId;
        private System.Windows.Forms.ComboBox cbxJenis;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.ComboBox cbxKarId;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDelete;
    }
}