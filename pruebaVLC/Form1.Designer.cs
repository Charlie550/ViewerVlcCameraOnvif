namespace pruebaVLC
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
            this.txt_ruta = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_captura = new System.Windows.Forms.Button();
            this.btn_conectar = new System.Windows.Forms.Button();
            this.txt_estado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_subirImg = new System.Windows.Forms.Button();
            this.txt_usrFTP = new System.Windows.Forms.TextBox();
            this.txt_urlFTP = new System.Windows.Forms.TextBox();
            this.txt_passFTP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_rutaRemota = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_ruta
            // 
            this.txt_ruta.Location = new System.Drawing.Point(250, 341);
            this.txt_ruta.Name = "txt_ruta";
            this.txt_ruta.Size = new System.Drawing.Size(253, 20);
            this.txt_ruta.TabIndex = 1;
            this.txt_ruta.Text = "C:\\Users\\jgomez\\Desktop";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(454, 25);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(146, 20);
            this.txt_password.TabIndex = 2;
            this.txt_password.Text = "Contel123.";
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(250, 25);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(146, 20);
            this.txt_user.TabIndex = 3;
            this.txt_user.Text = "Contel";
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(22, 25);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(181, 20);
            this.txt_url.TabIndex = 4;
            this.txt_url.Text = "172.16.0.155";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(22, 99);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 121);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btn_captura
            // 
            this.btn_captura.Location = new System.Drawing.Point(509, 333);
            this.btn_captura.Name = "btn_captura";
            this.btn_captura.Size = new System.Drawing.Size(84, 28);
            this.btn_captura.TabIndex = 6;
            this.btn_captura.Text = "Tomar captura";
            this.btn_captura.UseVisualStyleBackColor = true;
            this.btn_captura.Click += new System.EventHandler(this.btn_captura_Click);
            // 
            // btn_conectar
            // 
            this.btn_conectar.Location = new System.Drawing.Point(22, 62);
            this.btn_conectar.Name = "btn_conectar";
            this.btn_conectar.Size = new System.Drawing.Size(120, 31);
            this.btn_conectar.TabIndex = 7;
            this.btn_conectar.Text = "Conectar";
            this.btn_conectar.UseVisualStyleBackColor = true;
            this.btn_conectar.Click += new System.EventHandler(this.btn_conectar_Click);
            // 
            // txt_estado
            // 
            this.txt_estado.Location = new System.Drawing.Point(22, 247);
            this.txt_estado.Multiline = true;
            this.txt_estado.Name = "txt_estado";
            this.txt_estado.Size = new System.Drawing.Size(120, 59);
            this.txt_estado.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dirección IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ruta local:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Contraseña:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "label5";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(160, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 244);
            this.panel1.TabIndex = 14;
            // 
            // btn_subirImg
            // 
            this.btn_subirImg.Location = new System.Drawing.Point(509, 402);
            this.btn_subirImg.Name = "btn_subirImg";
            this.btn_subirImg.Size = new System.Drawing.Size(84, 27);
            this.btn_subirImg.TabIndex = 15;
            this.btn_subirImg.Text = "Subir";
            this.btn_subirImg.UseVisualStyleBackColor = true;
            this.btn_subirImg.Click += new System.EventHandler(this.btn_subirImg_Click);
            // 
            // txt_usrFTP
            // 
            this.txt_usrFTP.Enabled = false;
            this.txt_usrFTP.Location = new System.Drawing.Point(104, 37);
            this.txt_usrFTP.Name = "txt_usrFTP";
            this.txt_usrFTP.Size = new System.Drawing.Size(100, 20);
            this.txt_usrFTP.TabIndex = 16;
            // 
            // txt_urlFTP
            // 
            this.txt_urlFTP.Enabled = false;
            this.txt_urlFTP.Location = new System.Drawing.Point(104, 11);
            this.txt_urlFTP.Name = "txt_urlFTP";
            this.txt_urlFTP.Size = new System.Drawing.Size(100, 20);
            this.txt_urlFTP.TabIndex = 17;
            // 
            // txt_passFTP
            // 
            this.txt_passFTP.Enabled = false;
            this.txt_passFTP.Location = new System.Drawing.Point(104, 63);
            this.txt_passFTP.Name = "txt_passFTP";
            this.txt_passFTP.Size = new System.Drawing.Size(100, 20);
            this.txt_passFTP.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Usuario FTP :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Contraseña FTP :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "IP FTP :";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txt_usrFTP);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txt_urlFTP);
            this.panel2.Controls.Add(this.txt_passFTP);
            this.panel2.Location = new System.Drawing.Point(22, 331);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 100);
            this.panel2.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(247, 392);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Url del metodo Post en el servidor:";
            // 
            // txt_rutaRemota
            // 
            this.txt_rutaRemota.Location = new System.Drawing.Point(250, 408);
            this.txt_rutaRemota.Name = "txt_rutaRemota";
            this.txt_rutaRemota.Size = new System.Drawing.Size(253, 20);
            this.txt_rutaRemota.TabIndex = 24;
            this.txt_rutaRemota.Text = "http://localhost:60673/Home/SubirArchivo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 445);
            this.Controls.Add(this.btn_subirImg);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_rutaRemota);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_estado);
            this.Controls.Add(this.btn_conectar);
            this.Controls.Add(this.btn_captura);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_ruta);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_ruta;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_captura;
        private System.Windows.Forms.Button btn_conectar;
        private System.Windows.Forms.TextBox txt_estado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_subirImg;
        private System.Windows.Forms.TextBox txt_usrFTP;
        private System.Windows.Forms.TextBox txt_urlFTP;
        private System.Windows.Forms.TextBox txt_passFTP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_rutaRemota;
    }
}

