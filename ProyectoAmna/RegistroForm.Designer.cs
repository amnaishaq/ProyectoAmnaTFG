namespace ProyectoAmna
{
    partial class RegistroForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroForm));
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtnom = new System.Windows.Forms.TextBox();
            this.txtcontra = new System.Windows.Forms.TextBox();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.btnregi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(141, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 31);
            this.label5.TabIndex = 22;
            this.label5.Text = "REGISTRO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Contraseña:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Email:";
            // 
            // txtnom
            // 
            this.txtnom.Location = new System.Drawing.Point(137, 59);
            this.txtnom.Name = "txtnom";
            this.txtnom.Size = new System.Drawing.Size(141, 20);
            this.txtnom.TabIndex = 26;
            // 
            // txtcontra
            // 
            this.txtcontra.Location = new System.Drawing.Point(137, 93);
            this.txtcontra.Name = "txtcontra";
            this.txtcontra.Size = new System.Drawing.Size(123, 20);
            this.txtcontra.TabIndex = 27;
            this.txtcontra.UseSystemPasswordChar = true;
            // 
            // txtcorreo
            // 
            this.txtcorreo.Location = new System.Drawing.Point(137, 127);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(184, 20);
            this.txtcorreo.TabIndex = 28;
            // 
            // btnregi
            // 
            this.btnregi.Location = new System.Drawing.Point(159, 167);
            this.btnregi.Name = "btnregi";
            this.btnregi.Size = new System.Drawing.Size(88, 23);
            this.btnregi.TabIndex = 29;
            this.btnregi.Text = "REGISTRAR";
            this.btnregi.UseVisualStyleBackColor = true;
            this.btnregi.Click += new System.EventHandler(this.btnregi_Click);
            // 
            // RegistroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(347, 231);
            this.Controls.Add(this.btnregi);
            this.Controls.Add(this.txtcorreo);
            this.Controls.Add(this.txtcontra);
            this.Controls.Add(this.txtnom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistroForm";
            this.Text = "RegistroForm";
            this.Load += new System.EventHandler(this.RegistroForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtnom;
        private System.Windows.Forms.TextBox txtcontra;
        private System.Windows.Forms.TextBox txtcorreo;
        private System.Windows.Forms.Button btnregi;
    }
}