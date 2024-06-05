using System;
using System.Windows.Forms;

namespace ProyectoAmna
{
    public partial class Welcom : Form
    {
        public Welcom()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void blogin_Click(object sender, EventArgs e)
        {
            login loginForm = new login();
            loginForm.ShowDialog();
            this.Hide();
        }

        private void Welcom_Load(object sender, EventArgs e)
        {

        }

        private void bNOlogin_Click(object sender, EventArgs e)
        {
            UsuarioSesion.NombreUsuario = string.Empty;
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsuarioSesion.NombreUsuario = string.Empty;
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
