namespace ElectronicsStore
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Window = new System.Windows.Forms.Panel();
            this.Autoris = new System.Windows.Forms.Label();
            this.Images = new System.Windows.Forms.PictureBox();
            this.registers = new System.Windows.Forms.Button();
            this.logind = new System.Windows.Forms.Button();
            this.lgn = new System.Windows.Forms.TextBox();
            this.psswrd = new System.Windows.Forms.TextBox();
            this.Passsowrds = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Window.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Images)).BeginInit();
            this.SuspendLayout();
            // 
            // Window
            // 
            this.Window.BackColor = System.Drawing.Color.White;
            this.Window.Controls.Add(this.Autoris);
            this.Window.Controls.Add(this.registers);
            this.Window.Controls.Add(this.Images);
            this.Window.Controls.Add(this.logind);
            this.Window.Controls.Add(this.lgn);
            this.Window.Controls.Add(this.psswrd);
            this.Window.Controls.Add(this.Passsowrds);
            this.Window.Location = new System.Drawing.Point(376, 86);
            this.Window.Name = "Window";
            this.Window.Size = new System.Drawing.Size(490, 498);
            this.Window.TabIndex = 6;
            this.Window.Paint += new System.Windows.Forms.PaintEventHandler(this.Window_Paint);
            // 
            // Autoris
            // 
            this.Autoris.AutoSize = true;
            this.Autoris.BackColor = System.Drawing.Color.Aqua;
            this.Autoris.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Autoris.Location = new System.Drawing.Point(160, 77);
            this.Autoris.Name = "Autoris";
            this.Autoris.Size = new System.Drawing.Size(173, 33);
            this.Autoris.TabIndex = 11;
            this.Autoris.Text = "Авторизация";
            // 
            // Images
            // 
            this.Images.BackColor = System.Drawing.Color.Aqua;
            this.Images.Image = ((System.Drawing.Image)(resources.GetObject("Images.Image")));
            this.Images.Location = new System.Drawing.Point(0, 0);
            this.Images.Name = "Images";
            this.Images.Size = new System.Drawing.Size(490, 110);
            this.Images.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Images.TabIndex = 10;
            this.Images.TabStop = false;
            this.Images.Click += new System.EventHandler(this.Images_Click);
            // 
            // registers
            // 
            this.registers.BackColor = System.Drawing.Color.Aqua;
            this.registers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registers.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registers.Location = new System.Drawing.Point(83, 406);
            this.registers.Name = "registers";
            this.registers.Size = new System.Drawing.Size(333, 72);
            this.registers.TabIndex = 9;
            this.registers.Text = "Регистрация";
            this.registers.UseVisualStyleBackColor = false;
            this.registers.Click += new System.EventHandler(this.registers_Click);
            // 
            // logind
            // 
            this.logind.BackColor = System.Drawing.Color.Aqua;
            this.logind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logind.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logind.ForeColor = System.Drawing.Color.Black;
            this.logind.Location = new System.Drawing.Point(83, 317);
            this.logind.Name = "logind";
            this.logind.Size = new System.Drawing.Size(333, 72);
            this.logind.TabIndex = 8;
            this.logind.Text = "Войти";
            this.logind.UseVisualStyleBackColor = false;
            this.logind.Click += new System.EventHandler(this.logind_Click);
            // 
            // lgn
            // 
            this.lgn.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lgn.Location = new System.Drawing.Point(83, 149);
            this.lgn.Name = "lgn";
            this.lgn.Size = new System.Drawing.Size(333, 39);
            this.lgn.TabIndex = 7;
            this.lgn.TextChanged += new System.EventHandler(this.lgn_TextChanged);
            // 
            // psswrd
            // 
            this.psswrd.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.psswrd.Location = new System.Drawing.Point(83, 205);
            this.psswrd.Name = "psswrd";
            this.psswrd.Size = new System.Drawing.Size(333, 39);
            this.psswrd.TabIndex = 7;
            this.psswrd.TextChanged += new System.EventHandler(this.psswrd_TextChanged);
            // 
            // Passsowrds
            // 
            this.Passsowrds.AutoSize = true;
            this.Passsowrds.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Passsowrds.Location = new System.Drawing.Point(83, 254);
            this.Passsowrds.Name = "Passsowrds";
            this.Passsowrds.Size = new System.Drawing.Size(163, 25);
            this.Passsowrds.TabIndex = 6;
            this.Passsowrds.Text = "Показать пароль";
            this.Passsowrds.UseVisualStyleBackColor = true;
            this.Passsowrds.CheckedChanged += new System.EventHandler(this.Passsowrds_CheckedChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1252, 632);
            this.Controls.Add(this.Window);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Window.ResumeLayout(false);
            this.Window.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Images)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Window;
        private System.Windows.Forms.CheckBox Passsowrds;
        private System.Windows.Forms.TextBox lgn;
        private System.Windows.Forms.TextBox psswrd;
        private System.Windows.Forms.Button logind;
        private System.Windows.Forms.Button registers;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox Images;
        private System.Windows.Forms.Label Autoris;
    }
}

