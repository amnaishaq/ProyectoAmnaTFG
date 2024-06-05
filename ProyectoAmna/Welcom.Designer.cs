namespace ProyectoAmna
{
    partial class Welcom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcom));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.blogin = new System.Windows.Forms.Button();
            this.bNOlogin = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProyectoAmna.Properties.Resources.f69f3beac8804fb6a40debe5197f1b76;
            this.pictureBox1.Location = new System.Drawing.Point(154, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 175);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(148, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 31);
            this.label4.TabIndex = 29;
            this.label4.Text = "SHOW MAJETY";
            // 
            // blogin
            // 
            this.blogin.Location = new System.Drawing.Point(177, 305);
            this.blogin.Name = "blogin";
            this.blogin.Size = new System.Drawing.Size(157, 46);
            this.blogin.TabIndex = 30;
            this.blogin.Text = "LOGIN";
            this.blogin.UseVisualStyleBackColor = true;
            this.blogin.Click += new System.EventHandler(this.blogin_Click);
            // 
            // bNOlogin
            // 
            this.bNOlogin.Location = new System.Drawing.Point(177, 357);
            this.bNOlogin.Name = "bNOlogin";
            this.bNOlogin.Size = new System.Drawing.Size(157, 41);
            this.bNOlogin.TabIndex = 31;
            this.bNOlogin.Text = "CONTINUAR SIN LOGIN";
            this.bNOlogin.UseVisualStyleBackColor = true;
            this.bNOlogin.Click += new System.EventHandler(this.bNOlogin_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Plum;
            this.textBox1.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(36, 233);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(431, 57);
            this.textBox1.TabIndex = 32;
            this.textBox1.Text = "Explora el universo cinematográfico con Show Majesty. ¡Bienvenido a tu reino del " +
    "entretenimiento!";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Welcom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(520, 445);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bNOlogin);
            this.Controls.Add(this.blogin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Welcom";
            this.Text = "Welcom";
            this.Load += new System.EventHandler(this.Welcom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button blogin;
        private System.Windows.Forms.Button bNOlogin;
        private System.Windows.Forms.TextBox textBox1;
    }
}