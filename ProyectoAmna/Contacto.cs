using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace ProyectoAmna
{
    public partial class Contacto : Form
    {
        // Mis credenciales de correo electrónico
        private string myEmail = "showmajesty@gmail.com"; // Mi correo electrónico
        private string myPassword = "vagnjmnsizyrenir";   // Mi contraseña
        private string myAlias = "Show Majesty";          // Mi alias

        public Contacto()
        {
            InitializeComponent();
            // Configuro el temporizador para un intervalo corto, proporcionando un movimiento suave
            timer1.Interval = 50;
            timer1.Enabled = true;

            // Ajusto el tamaño del cuadro de texto del mensaje
            txtMensaje1.Size = new System.Drawing.Size(300, 200);

        }

        // Este método se ejecuta en cada tick del temporizador
        private void timer1_Tick(object sender, EventArgs e)
        {
            int speed = 5; // Defino la velocidad de desplazamiento

            // Muevo cada PictureBox hacia la izquierda
            foreach (PictureBox pictureBox in panel1.Controls.OfType<PictureBox>())
            {
                pictureBox.Left -= speed; // Desplazo la imagen hacia la izquierda

                // Si la imagen se sale del panel por la izquierda, la coloco al final a la derecha
                if (pictureBox.Right < 0)
                {
                    pictureBox.Left = panel1.ClientSize.Width; // Muevo la imagen al borde derecho del panel
                }
            }

            // Verifico si la primera imagen se ha desplazado completamente fuera del panel
            PictureBox firstPictureBox = (PictureBox)panel1.Controls[0];
            if (firstPictureBox.Right < 0)
            {
                // Agrego un nuevo Label con el texto "Mi aplicación" al borde derecho del panel
                Label label = new Label();
                label.Text = "Mi Aplicación";
                label.AutoSize = false;
                label.Font = new Font("Arial", 16, FontStyle.Bold); // Establezco el tamaño y el estilo de fuente
                label.ForeColor = Color.White; // Color del texto
                label.BackColor = Color.Black; // Color de fondo del texto
                label.TextAlign = ContentAlignment.MiddleCenter; // Centro el texto horizontalmente
                label.Size = new Size(panel1.ClientSize.Width, panel1.ClientSize.Height); // Establezco el tamaño del Label igual al del panel
                label.Location = new Point(0, 0); // Ubicación en el borde superior izquierdo del panel
                panel1.Controls.Add(label);
                label.BringToFront(); // Muevo el texto al frente del panel
            }
        }

        // Este método crea el cuerpo del correo electrónico
        private void CrearCuerpoCorreo()
        {
            // Creo un nuevo objeto MailMessage
            MailMessage mCorreo = new MailMessage();
            mCorreo.From = new MailAddress(myEmail, myAlias, System.Text.Encoding.UTF8);
            String correoAdmin = "amnaishaq114@gmail.com"; // Dirección de correo del administrador
            mCorreo.To.Add(correoAdmin.Trim());

            // Obtengo el asunto y el cuerpo del mensaje de los cuadros de texto
            string subject = txtAsunto1.Text.Trim();
            string body = txtMensaje1.Text.Trim();

            mCorreo.Subject = subject;
            mCorreo.Body = body;
            mCorreo.IsBodyHtml = false; // Especifico que el cuerpo no es HTML
            mCorreo.Priority = MailPriority.High; // Establezco la prioridad alta

            // Llamo al método Enviar para enviar el correo
            Enviar(mCorreo);
        }

        // Este método envía el correo electrónico
        private void Enviar(MailMessage mCorreo)
        {
            try
            {
                // Configuro el cliente SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Port = 25;
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new NetworkCredential(myEmail, myPassword);
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; };
                smtp.EnableSsl = true;
                smtp.Send(mCorreo); // Envío el correo
                MessageBox.Show("Mensaje Enviado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Muestro un mensaje de éxito
            }
            catch (Exception e)
            {
                // Muestro un mensaje de error si algo sale mal
                MessageBox.Show(e.Message);
            }
        }

        // Este método se ejecuta cuando se hace clic en el botón de enviar
        private async void btnenviar1_Click(object sender, EventArgs e)
        {
            // Llamo al método para crear y enviar el correo
            CrearCuerpoCorreo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Abro el formulario de Nosotros
            Nosotros n = new Nosotros();
            n.ShowDialog();
            this.Hide();
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

                DialogResult result = MessageBox.Show("Debe estar registrado para acceder a esta página. ¿Desea registrarse ahora?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    // Abrir el formulario de registro
                    RegistroForm registroForm = new RegistroForm();
                    registroForm.Show();
                    this.Close(); // Cerrar el formulario actual
                }
                else
                {
                    // Abrir el formulario principal
                    Form1 mainForm = new Form1();
                    mainForm.Show();
                    this.Close(); // Cerrar el formulario actual
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Contacto_Load(object sender, EventArgs e)
        {
            usuario();
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
