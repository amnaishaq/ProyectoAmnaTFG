using System;
using System.Data.SqlClient; // Importo el espacio de nombres para trabajar con SQL Server
using System.Windows.Forms;

namespace ProyectoAmna
{
    public partial class RegistroForm : Form
    {
        // Cadena de conexión a la base de datos
        private string con = "Data Source=AMNA_PC\\SQLEXPRESS;Initial Catalog=MiAplicacion;Integrated Security=True;TrustServerCertificate=True";

        public RegistroForm()
        {
            InitializeComponent();
        }

        // Evento click del botón de registro
        private void btnregi_Click(object sender, EventArgs e)
        {
            // Obtengo los datos ingresados en los campos de txt_passord.
            txtcontra.PasswordChar = '*';
            string nombreUsuario = txtnom.Text.Trim();
            string contraseña = txtcontra.Text.Trim();
            string email = txtcorreo.Text.Trim();

            // Validar que todos los campos estén completos
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Intentar registrar el usuario en la base de datos
            if (RegistrarUsuario(nombreUsuario, contraseña, email))
            {
                // Mostrar un mensaje de registro exitoso y preguntar si desea iniciar sesión
                MessageBox.Show("Registro exitoso. Ahora puedes iniciar sesión.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("¿Deseas iniciar sesión ahora?", "Iniciar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Abrir el formulario de inicio de sesión y cerrar el formulario de registro
                    login loginForm = new login();
                    loginForm.Show();
                    this.Close();
                }
                // No hacer nada si el usuario decide no iniciar sesión por ahora
            }
            else
            {
                // Mostrar un mensaje de error si falla el registro
                MessageBox.Show("Error al registrar usuario. Por favor, inténtalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para registrar el usuario en la base de datos
        private bool RegistrarUsuario(string nombreUsuario, string contraseña, string email)
        {
            try
            {
                // Conexión a la base de datos y ejecución de la consulta SQL para insertar el nuevo usuario
                using (SqlConnection connection = new SqlConnection(con))
                {
                    string query = "INSERT INTO Usuarios (NombreUsuario, Contraseña, Email) VALUES (@nombreUsuario, @contraseña, @email)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);
                    cmd.Parameters.AddWithValue("@email", email);
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Retorna true si se registró correctamente
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si falla la operación
                MessageBox.Show("Error al registrar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void RegistroForm_Load(object sender, EventArgs e)
        {

        }
    }
}
