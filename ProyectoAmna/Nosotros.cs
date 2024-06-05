using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAmna
{
    public partial class Nosotros : Form
    {
        public Nosotros()
        {
            InitializeComponent();
            timer1.Interval = 50; // Establece el intervalo corto para un movimiento suave
            timer1.Enabled = true; // Activa el temporizador
            usuario();
        }

        // Método para mover las imágenes dentro del panel
        private void timer1_Tick(object sender, EventArgs e)
        {
            int speed = 5; // Ajusta la velocidad de desplazamiento según sea necesario

            // Mueve cada PictureBox hacia la izquierda
            foreach (PictureBox pictureBox in panel1.Controls.OfType<PictureBox>())
            {
                pictureBox.Left -= speed;

                // Si el PictureBox se sale del Panel por la izquierda, lo coloca al final a la derecha
                if (pictureBox.Right < 0)
                {
                    pictureBox.Left = panel1.ClientSize.Width;
                }
            }

            // Verifica si la primera imagen se ha desplazado completamente fuera del Panel
            PictureBox firstPictureBox = (PictureBox)panel1.Controls[0];
            if (firstPictureBox.Right < 0)
            {
                // Agrega un nuevo Label con el texto "Mi aplicación" al borde derecho del Panel
                Label label = new Label();
                label.Text = "Mi Aplicación";
                label.AutoSize = false;
                label.Font = new Font("Arial", 16, FontStyle.Bold); // Establece el tamaño y el estilo de fuente
                label.ForeColor = Color.White; // Color del texto
                label.BackColor = Color.Black; // Color de fondo del texto
                label.TextAlign = ContentAlignment.MiddleCenter; // Centra el texto horizontalmente
                label.Size = new Size(panel1.ClientSize.Width, panel1.ClientSize.Height); // Establece el tamaño del Label igual al del Panel
                label.Location = new Point(0, 0); // Ubicación en el borde superior izquierdo del Panel
                panel1.Controls.Add(label);
                label.BringToFront(); // Mueve el texto al frente del Panel
            }
        }

        // Método para cambiar el color de fondo del RichTextBox cuando cambia el texto
        private void richTextBoxSobreNosotros_TextChanged(object sender, EventArgs e)
        {
            richTextBoxSobreNosotros.BackColor = Color.Plum; // Cambia el color de fondo del RichTextBox a "Plum"
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();

            this.Hide();
            // Aquí puedes agregar la lógica para el botón si es necesario
        }

        private void Nosotros_Load(object sender, EventArgs e)
        {
            usuario();
            // Este método se llama cuando se carga el formulario, aquí puedes realizar acciones de inicialización si es necesario
        }
        private void usuario()
        {
            if (!string.IsNullOrEmpty(UsuarioSesion.NombreUsuario))
            {
                lbluser.Text = UsuarioSesion.NombreUsuario;
                lbluser.Visible = true;
                userpic.Visible = true;
            }
            else
            {
                lbluser.Visible = false;
                userpic.Visible = true;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Abro el formulario de Contacto
            Contacto c = new Contacto();
            c.ShowDialog();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void userpic_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de diálogo de opción para que el usuario elija entre registro e inicio de sesión
            DialogResult result = MessageBox.Show("¿Desea registrarse o iniciar sesión?", "Opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Abrir el formulario de registro si el usuario elige registrarse
                RegistroForm registroForm = new RegistroForm();
                registroForm.ShowDialog();
            }
            else if (result == DialogResult.No)
            {
                // Abrir el formulario de inicio de sesión si el usuario elige iniciar sesión
                login loginForm = new login();
                loginForm.ShowDialog();
            }
        }

    }
}
