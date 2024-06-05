using System;
using System.Data.SqlClient; // Importo el espacio de nombres para trabajar con SQL Server
using System.Windows.Forms;

namespace ProyectoAmna
{
    public partial class login : Form
    {
        // Cadena de conexión a la base de datos
        private string con = "Data Source=AMNA_PC\\SQLEXPRESS;Initial Catalog=MiAplicacion;Integrated Security=True;TrustServerCertificate=True";

        public login()
        {
            InitializeComponent();
        }

        // Evento click del botón de inicio de sesión
        private void button1_Click(object sender, EventArgs e)
        {
            // Obtengo el nombre de usuario y contraseña ingresados en los campos de texto
            txt_passord.PasswordChar = '*';
            string nombreUsuario = txtuser.Text.Trim();
            string contraseña = txt_passord.Text.Trim();
          

            // Verifico si el usuario y la contraseña son válidos
            if (AuthenticateUser(nombreUsuario, contraseña))
            {
                // Guardo el nombre de usuario en la clase UsuarioSesion
                UsuarioSesion.NombreUsuario = nombreUsuario;

                // Muestro un mensaje de inicio de sesión exitoso
                MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abro el formulario principal y oculto el formulario de inicio de sesión
                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                // Muestro un mensaje de error si las credenciales son incorrectas
                MessageBox.Show("Nombre de usuario o contraseña incorrectos. Por favor, inténtelo de nuevo.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Limpio los campos de texto
                txtuser.Clear();
                txt_passord.Clear();
            }
        }

        // Método para autenticar al usuario en la base de datos
        private bool AuthenticateUser(string nombreUsuario, string contraseña)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                // Consulta SQL para verificar las credenciales del usuario
                string query = "SELECT COUNT(1) FROM Usuarios WHERE NombreUsuario=@nombreUsuario AND Contraseña=@contraseña";

                // Creo un comando SQL y establezco los parámetros
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);

                // Abro la conexión y ejecuto el comando
                connection.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                // Retorno true si se encuentra una coincidencia, de lo contrario, retorno false
                return count == 1;
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
