namespace ProjectAkhirPABD
{
    partial class Costumer
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
            this.CostumerId = new System.Windows.Forms.Label();
            this.NamaCos = new System.Windows.Forms.Label();
            this.Alamat = new System.Windows.Forms.Label();
            this.NoTelepon = new System.Windows.Forms.Label();
            this.cosId = new System.Windows.Forms.TextBox();
            this.nmCos = new System.Windows.Forms.TextBox();
            this.Almt = new System.Windows.Forms.TextBox();
            this.NoTelp = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Font = new System.Drawing.Font("Impact", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(290, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 41);
            this.label4.TabIndex = 5;
            this.label4.Text = "Daftar Costumer";
            // 
            // CostumerId
            // 
            this.CostumerId.AutoSize = true;
            this.CostumerId.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CostumerId.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostumerId.Location = new System.Drawing.Point(334, 127);
            this.CostumerId.Name = "CostumerId";
            this.CostumerId.Size = new System.Drawing.Size(110, 25);
            this.CostumerId.TabIndex = 6;
            this.CostumerId.Text = "Costumer Id";
            // 
            // NamaCos
            // 
            this.NamaCos.AutoSize = true;
            this.NamaCos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.NamaCos.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamaCos.Location = new System.Drawing.Point(334, 183);
            this.NamaCos.Name = "NamaCos";
            this.NamaCos.Size = new System.Drawing.Size(140, 25);
            this.NamaCos.TabIndex = 7;
            this.NamaCos.Text = "Nama Costumer";
            // 
            // Alamat
            // 
            this.Alamat.AutoSize = true;
            this.Alamat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Alamat.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Alamat.Location = new System.Drawing.Point(334, 238);
            this.Alamat.Name = "Alamat";
            this.Alamat.Size = new System.Drawing.Size(68, 25);
            this.Alamat.TabIndex = 8;
            this.Alamat.Text = "Alamat";
            // 
            // NoTelepon
            // 
            this.NoTelepon.AutoSize = true;
            this.NoTelepon.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.NoTelepon.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoTelepon.Location = new System.Drawing.Point(334, 287);
            this.NoTelepon.Name = "NoTelepon";
            this.NoTelepon.Size = new System.Drawing.Size(132, 25);
            this.NoTelepon.TabIndex = 9;
            this.NoTelepon.Text = "Nomor Telepon";
            // 
            // cosId
            // 
            this.cosId.Location = new System.Drawing.Point(527, 132);
            this.cosId.Name = "cosId";
            this.cosId.Size = new System.Drawing.Size(181, 22);
            this.cosId.TabIndex = 10;
            // 
            // nmCos
            // 
            this.nmCos.Location = new System.Drawing.Point(527, 188);
            this.nmCos.Name = "nmCos";
            this.nmCos.Size = new System.Drawing.Size(181, 22);
            this.nmCos.TabIndex = 11;
            // 
            // Almt
            // 
            this.Almt.Location = new System.Drawing.Point(527, 243);
            this.Almt.Name = "Almt";
            this.Almt.Size = new System.Drawing.Size(181, 22);
            this.Almt.TabIndex = 12;
            // 
            // NoTelp
            // 
            this.NoTelp.Location = new System.Drawing.Point(527, 287);
            this.NoTelp.Name = "NoTelp";
            this.NoTelp.Size = new System.Drawing.Size(181, 22);
            this.NoTelp.TabIndex = 13;
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Add.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(714, 132);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(79, 35);
            this.Add.TabIndex = 14;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Save.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(716, 210);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(77, 35);
            this.Save.TabIndex = 15;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Clear.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.Location = new System.Drawing.Point(715, 279);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(78, 35);
            this.Clear.TabIndex = 16;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Next.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Next.Location = new System.Drawing.Point(474, 403);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(69, 35);
            this.Next.TabIndex = 17;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(304, 227);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDelete.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(370, 403);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 35);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBack.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(257, 403);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(78, 35);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Costumer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::ProjectAkhirPABD.Properties.Resources.NanangFutsal;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.NoTelp);
            this.Controls.Add(this.Almt);
            this.Controls.Add(this.nmCos);
            this.Controls.Add(this.cosId);
            this.Controls.Add(this.NoTelepon);
            this.Controls.Add(this.Alamat);
            this.Controls.Add(this.NamaCos);
            this.Controls.Add(this.CostumerId);
            this.Controls.Add(this.label4);
            this.DoubleBuffered = true;
            this.Name = "Costumer";
            this.Text = "Costumer";
            this.Load += new System.EventHandler(this.Jaminan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label CostumerId;
        private System.Windows.Forms.Label NamaCos;
        private System.Windows.Forms.Label Alamat;
        private System.Windows.Forms.Label NoTelepon;
        private System.Windows.Forms.TextBox cosId;
        private System.Windows.Forms.TextBox nmCos;
        private System.Windows.Forms.TextBox Almt;
        private System.Windows.Forms.TextBox NoTelp;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
    }
}