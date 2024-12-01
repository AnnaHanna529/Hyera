﻿namespace ElectronicsStore
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new ElectronicsStore.DataSet1();
            this.categoryTableAdapter1 = new ElectronicsStore.ElectronicsDataSet1TableAdapters.CategoryTableAdapter();
            this.electronicsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.electronicsDataSet = new ElectronicsStore.ElectronicsDataSet();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.warehouseTableAdapter1 = new ElectronicsStore.ElectronicsDataSetTableAdapters.WarehouseTableAdapter();
            this.suppliersTableAdapter1 = new ElectronicsStore.ElectronicsDataSetTableAdapters.SuppliersTableAdapter();
            this.productTableAdapter1 = new ElectronicsStore.ElectronicsDataSetTableAdapters.ProductTableAdapter();
            this.paymentsTableAdapter1 = new ElectronicsStore.ElectronicsDataSetTableAdapters.PaymentsTableAdapter();
            this.ordersTableAdapter1 = new ElectronicsStore.ElectronicsDataSetTableAdapters.OrdersTableAdapter();
            this.orderItemsTableAdapter1 = new ElectronicsStore.ElectronicsDataSetTableAdapters.OrderItemsTableAdapter();
            this.inventoryTableAdapter1 = new ElectronicsStore.ElectronicsDataSetTableAdapters.InventoryTableAdapter();
            this.deliveriesTableAdapter1 = new ElectronicsStore.ElectronicsDataSetTableAdapters.DeliveriesTableAdapter();
            this.customersTableAdapter1 = new ElectronicsStore.ElectronicsDataSetTableAdapters.CustomersTableAdapter();
            this.categoryTableAdapter = new ElectronicsStore.ElectronicsDataSetTableAdapters.CategoryTableAdapter();
            this.categoryBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.categoryBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.categoryBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.electronicsDataSet1 = new ElectronicsStore.ElectronicsDataSet1();
            this.customersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.categoryBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.warehouseTableAdapterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.electronicsDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.search = new System.Windows.Forms.TextBox();
            this.Back = new System.Windows.Forms.Button();
            this.FILTARR = new System.Windows.Forms.ComboBox();
            this.electronicsDataSet2 = new ElectronicsStore.ElectronicsDataSet();
            this.Update = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.searhss = new System.Windows.Forms.Label();
            this.work = new System.Windows.Forms.GroupBox();
            this.tabless = new System.Windows.Forms.Label();
            this.Ckues = new System.Windows.Forms.Label();
            this.clue = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.electronicsDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.electronicsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.electronicsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseTableAdapterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.electronicsDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.electronicsDataSet2)).BeginInit();
            this.work.SuspendLayout();
            this.clue.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoryTableAdapter1
            // 
            this.categoryTableAdapter1.ClearBeforeFill = true;
            // 
            // electronicsDataSetBindingSource
            // 
            this.electronicsDataSetBindingSource.DataSource = this.electronicsDataSet;
            this.electronicsDataSetBindingSource.Position = 0;
            // 
            // electronicsDataSet
            // 
            this.electronicsDataSet.DataSetName = "ElectronicsDataSet";
            this.electronicsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "Category";
            this.categoryBindingSource.DataSource = this.electronicsDataSetBindingSource;
            // 
            // customersBindingSource
            // 
            this.customersBindingSource.DataMember = "Customers";
            this.customersBindingSource.DataSource = this.electronicsDataSetBindingSource;
            // 
            // warehouseTableAdapter1
            // 
            this.warehouseTableAdapter1.ClearBeforeFill = true;
            // 
            // suppliersTableAdapter1
            // 
            this.suppliersTableAdapter1.ClearBeforeFill = true;
            // 
            // productTableAdapter1
            // 
            this.productTableAdapter1.ClearBeforeFill = true;
            // 
            // paymentsTableAdapter1
            // 
            this.paymentsTableAdapter1.ClearBeforeFill = true;
            // 
            // ordersTableAdapter1
            // 
            this.ordersTableAdapter1.ClearBeforeFill = true;
            // 
            // orderItemsTableAdapter1
            // 
            this.orderItemsTableAdapter1.ClearBeforeFill = true;
            // 
            // inventoryTableAdapter1
            // 
            this.inventoryTableAdapter1.ClearBeforeFill = true;
            // 
            // deliveriesTableAdapter1
            // 
            this.deliveriesTableAdapter1.ClearBeforeFill = true;
            // 
            // customersTableAdapter1
            // 
            this.customersTableAdapter1.ClearBeforeFill = true;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // categoryBindingSource1
            // 
            this.categoryBindingSource1.DataMember = "Category";
            this.categoryBindingSource1.DataSource = this.electronicsDataSetBindingSource;
            // 
            // categoryBindingSource2
            // 
            this.categoryBindingSource2.DataMember = "Category";
            this.categoryBindingSource2.DataSource = this.electronicsDataSetBindingSource;
            // 
            // categoryBindingSource3
            // 
            this.categoryBindingSource3.DataMember = "Category";
            this.categoryBindingSource3.DataSource = this.electronicsDataSetBindingSource;
            // 
            // electronicsDataSet1
            // 
            this.electronicsDataSet1.DataSetName = "ElectronicsDataSet1";
            this.electronicsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customersBindingSource1
            // 
            this.customersBindingSource1.DataMember = "Customers";
            this.customersBindingSource1.DataSource = this.electronicsDataSetBindingSource;
            // 
            // categoryBindingSource4
            // 
            this.categoryBindingSource4.DataMember = "Category";
            this.categoryBindingSource4.DataSource = this.electronicsDataSetBindingSource;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(414, 174);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(470, 204);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // warehouseTableAdapterBindingSource
            // 
            this.warehouseTableAdapterBindingSource.DataSource = typeof(ElectronicsStore.ElectronicsDataSet1TableAdapters.WarehouseTableAdapter);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(252, 33);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // electronicsDataSetBindingSource1
            // 
            this.electronicsDataSetBindingSource1.DataSource = this.electronicsDataSet;
            this.electronicsDataSetBindingSource1.Position = 0;
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search.Location = new System.Drawing.Point(141, 10);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(178, 30);
            this.search.TabIndex = 6;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // Back
            // 
            this.Back.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.Location = new System.Drawing.Point(51, 473);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(190, 41);
            this.Back.TabIndex = 8;
            this.Back.Text = "Вернуться";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // FILTARR
            // 
            this.FILTARR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FILTARR.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FILTARR.FormattingEnabled = true;
            this.FILTARR.Location = new System.Drawing.Point(56, 122);
            this.FILTARR.Name = "FILTARR";
            this.FILTARR.Size = new System.Drawing.Size(160, 30);
            this.FILTARR.TabIndex = 9;
            // 
            // electronicsDataSet2
            // 
            this.electronicsDataSet2.DataSetName = "ElectronicsDataSet";
            this.electronicsDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Update
            // 
            this.Update.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Update.Location = new System.Drawing.Point(35, 274);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(190, 42);
            this.Update.TabIndex = 4;
            this.Update.Text = "Обновить";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // edit
            // 
            this.edit.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edit.Location = new System.Drawing.Point(35, 335);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(190, 42);
            this.edit.TabIndex = 7;
            this.edit.Text = "Редактировать";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // Delete
            // 
            this.Delete.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete.Location = new System.Drawing.Point(35, 217);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(190, 42);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add.Location = new System.Drawing.Point(35, 158);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(190, 42);
            this.Add.TabIndex = 2;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // searhss
            // 
            this.searhss.AutoSize = true;
            this.searhss.BackColor = System.Drawing.Color.Transparent;
            this.searhss.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searhss.Location = new System.Drawing.Point(35, 9);
            this.searhss.Name = "searhss";
            this.searhss.Size = new System.Drawing.Size(86, 31);
            this.searhss.TabIndex = 10;
            this.searhss.Text = "Поиск";
            // 
            // work
            // 
            this.work.BackColor = System.Drawing.Color.Transparent;
            this.work.Controls.Add(this.tabless);
            this.work.Controls.Add(this.Add);
            this.work.Controls.Add(this.FILTARR);
            this.work.Controls.Add(this.edit);
            this.work.Controls.Add(this.Update);
            this.work.Controls.Add(this.Delete);
            this.work.Controls.Add(this.comboBox1);
            this.work.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.work.Location = new System.Drawing.Point(25, 71);
            this.work.Name = "work";
            this.work.Size = new System.Drawing.Size(287, 385);
            this.work.TabIndex = 11;
            this.work.TabStop = false;
            this.work.Text = "Инструменты для таблиц";
            // 
            // tabless
            // 
            this.tabless.AutoSize = true;
            this.tabless.BackColor = System.Drawing.Color.Transparent;
            this.tabless.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabless.Location = new System.Drawing.Point(31, 55);
            this.tabless.Name = "tabless";
            this.tabless.Size = new System.Drawing.Size(171, 23);
            this.tabless.TabIndex = 12;
            this.tabless.Text = "Выберите таблицу";
            // 
            // Ckues
            // 
            this.Ckues.AutoSize = true;
            this.Ckues.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ckues.Location = new System.Drawing.Point(82, 57);
            this.Ckues.Name = "Ckues";
            this.Ckues.Size = new System.Drawing.Size(109, 210);
            this.Ckues.TabIndex = 12;
            this.Ckues.Text = "1. Category\r\n2. Product\r\n3.Suppliers\r\n4.Warehouse\r\n5.Inventory\r\n6.Customers\r\n7.Or" +
    "ders\r\n8.OrderItems\r\n9.Deliveries\r\n10.Payments\r\n";
            // 
            // clue
            // 
            this.clue.BackColor = System.Drawing.Color.Transparent;
            this.clue.Controls.Add(this.Ckues);
            this.clue.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clue.Location = new System.Drawing.Point(1044, 71);
            this.clue.Name = "clue";
            this.clue.Size = new System.Drawing.Size(249, 287);
            this.clue.TabIndex = 13;
            this.clue.TabStop = false;
            this.clue.Text = "Порядок работы в таблицах";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1356, 526);
            this.Controls.Add(this.clue);
            this.Controls.Add(this.work);
            this.Controls.Add(this.searhss);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.search);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminForm";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.electronicsDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.electronicsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.electronicsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseTableAdapterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.electronicsDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.electronicsDataSet2)).EndInit();
            this.work.ResumeLayout(false);
            this.work.PerformLayout();
            this.clue.ResumeLayout(false);
            this.clue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource electronicsDataSetBindingSource;
        private ElectronicsDataSet electronicsDataSet;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private DataSet1 dataSet1;
        private ElectronicsDataSet1TableAdapters.CategoryTableAdapter categoryTableAdapter1;
        private ElectronicsDataSetTableAdapters.WarehouseTableAdapter warehouseTableAdapter1;
        private ElectronicsDataSetTableAdapters.SuppliersTableAdapter suppliersTableAdapter1;
        private ElectronicsDataSetTableAdapters.ProductTableAdapter productTableAdapter1;
        private ElectronicsDataSetTableAdapters.PaymentsTableAdapter paymentsTableAdapter1;
        private ElectronicsDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter1;
        private ElectronicsDataSetTableAdapters.OrderItemsTableAdapter orderItemsTableAdapter1;
        private ElectronicsDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter1;
        private ElectronicsDataSetTableAdapters.DeliveriesTableAdapter deliveriesTableAdapter1;
        private ElectronicsDataSetTableAdapters.CustomersTableAdapter customersTableAdapter1;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private ElectronicsDataSetTableAdapters.CategoryTableAdapter categoryTableAdapter;
        private System.Windows.Forms.BindingSource categoryBindingSource1;
        private System.Windows.Forms.BindingSource categoryBindingSource2;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private System.Windows.Forms.BindingSource categoryBindingSource3;
        private ElectronicsDataSet1 electronicsDataSet1;
        private System.Windows.Forms.BindingSource categoryBindingSource4;
        private System.Windows.Forms.BindingSource customersBindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource warehouseTableAdapterBindingSource;
        private System.Windows.Forms.BindingSource electronicsDataSetBindingSource1;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.ComboBox FILTARR;
        private ElectronicsDataSet electronicsDataSet2;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Label searhss;
        private System.Windows.Forms.GroupBox work;
        private System.Windows.Forms.Label tabless;
        private System.Windows.Forms.Label Ckues;
        private System.Windows.Forms.GroupBox clue;
    }
}