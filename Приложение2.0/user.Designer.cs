namespace ElectronicsStore
{
    partial class user
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
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.tables = new System.Windows.Forms.ComboBox();
            this.electronicsDataSet = new ElectronicsStore.ElectronicsDataSet();
            this.Back = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.Filtar = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.electronicsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.AllowUserToAddRows = false;
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Location = new System.Drawing.Point(93, 128);
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.Size = new System.Drawing.Size(831, 294);
            this.dataGridViewUser.TabIndex = 0;
            this.dataGridViewUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUser_CellContentClick);
            // 
            // tables
            // 
            this.tables.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tables.FormattingEnabled = true;
            this.tables.Location = new System.Drawing.Point(947, 107);
            this.tables.Name = "tables";
            this.tables.Size = new System.Drawing.Size(229, 30);
            this.tables.TabIndex = 1;
            this.tables.SelectedIndexChanged += new System.EventHandler(this.tables_SelectedIndexChanged);
            // 
            // electronicsDataSet
            // 
            this.electronicsDataSet.DataSetName = "ElectronicsDataSet";
            this.electronicsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Back
            // 
            this.Back.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.Location = new System.Drawing.Point(1126, 599);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(123, 41);
            this.Back.TabIndex = 9;
            this.Back.Text = "Вернуться";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search.Location = new System.Drawing.Point(303, 64);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(162, 30);
            this.search.TabIndex = 13;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // Filtar
            // 
            this.Filtar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Filtar.FormattingEnabled = true;
            this.Filtar.Location = new System.Drawing.Point(548, 64);
            this.Filtar.Name = "Filtar";
            this.Filtar.Size = new System.Drawing.Size(196, 29);
            this.Filtar.TabIndex = 14;
            this.Filtar.SelectedIndexChanged += new System.EventHandler(this.Filtar_SelectedIndexChanged);
            // 
            // user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 664);
            this.Controls.Add(this.Filtar);
            this.Controls.Add(this.search);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.tables);
            this.Controls.Add(this.dataGridViewUser);
            this.Name = "user";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.user_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.electronicsDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.ComboBox tables;
        private ElectronicsDataSet electronicsDataSet;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.ComboBox Filtar;
    }
}