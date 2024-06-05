using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMDbLib.Client;
using TMDbLib.Objects.Discover;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Genres;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;


namespace ProyectoAmna
{
    public partial class Form1 : Form
    {
        private TMDbClient client;

        public Form1()
        {
            InitializeComponent();
            client = new TMDbClient("f87ff1449313430055c7ab1eda344eb5");

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 50; // Intervalo corto para un movimiento suave
            timer1.Enabled = true;
            LlenarComboBoxGeneros();
            LlenarComboBoxAños();
            ConfigurarEncabezadosColumnas();
            mostrar();
            usuario();
        }


        private async Task LlenarComboBoxGeneros()
        {
            try
            {
                IEnumerable<string> generos = await ObtenerGeneros();
                foreach (string genero in generos)
                {
                    combogenero.Items.Add(genero);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los géneros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboBoxAños()
        {
            try
            {
                for (int año = 2000; año <= 2023; año++)
                {
                    comboanio.Items.Add(año);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar el ComboBox de años: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<IEnumerable<string>> ObtenerGeneros()
        {
            var generos = await client.GetMovieGenresAsync();
            List<string> nombresGeneros = new List<string>();
            foreach (var genero in generos)
            {
                nombresGeneros.Add(genero.Name);
            }
            return nombresGeneros;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int speed = 5; // Ajusta la velocidad de desplazamiento según sea necesario

            // Mover cada PictureBox hacia la izquierda
            foreach (PictureBox pictureBox in panel1.Controls.OfType<PictureBox>())
            {
                pictureBox.Left -= speed; // Ajusta la velocidad de desplazamiento según sea necesario

                // Si el PictureBox se sale del Panel por la izquierda, colócalo al final a la derecha
                if (pictureBox.Right < 0)
                {
                    pictureBox.Left = panel1.ClientSize.Width; // Mueve la imagen al borde derecho del Panel
                }
            }

            // Verificar si la primera imagen se ha desplazado completamente fuera del Panel
            PictureBox firstPictureBox = (PictureBox)panel1.Controls[0];
            if (firstPictureBox.Right < 0)
            {
                // Agregar un nuevo Label con el texto "Mi aplicación" al borde derecho del Panel
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



        private async void btn_Buscar_Click(object sender, EventArgs e)
        {
            string generoSeleccionado = combogenero.SelectedItem?.ToString();
            int añoSeleccionado = int.Parse(comboanio.SelectedItem.ToString());
            int cantidadPeliculas = (int)numericUpDown1.Value;

            try
            {
                // Crear una instancia de DiscoverMovie
                var discoverMovie = new DiscoverMovie(client);

                // Definir el rango de fechas de lanzamiento (2010-01-01 a 2024-12-31)
                discoverMovie.WherePrimaryReleaseIsInYear(añoSeleccionado);


                // Obtener los resultados de la consulta
                var resultado = await discoverMovie.Query();

                // Obtener las películas de los resultados
                var películas = resultado.Results;

                // Obtener detalles de las películas por sus ID
                var películasDetalle = new List<Movie>();
                foreach (var película in películas)
                {
                    var películaDetalle = await client.GetMovieAsync(película.Id);
                    películasDetalle.Add(películaDetalle);
                }

                // Mostrar las películas en la tabla
                MostrarPeliculasEnTabla(películasDetalle, generoSeleccionado, añoSeleccionado, cantidadPeliculas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar películas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarEncabezadosColumnas()
        {
            DataGridView.Columns.Clear(); // Limpiar columnas existentes

            // Agregar columnas con sus encabezados
            DataGridView.Columns.Add("PosterPathColumn", "Número");
            DataGridView.Columns.Add("TitleColumn", "Título");
            DataGridView.Columns.Add("GenresColumn", "Géneros");
            //   DataGridView.Columns.Add("OverviewColumn", "Resumen");
            DataGridView.Columns.Add("ReleaseDateColumn", "Año de lanzamiento");
            DataGridView.Columns.Add("VoteAverageColumn", "Calificación promedio");
            DataGridView.Columns.Add("VoteCountColumn", "Número de votos");


            // Ajustar el ancho de las columnas
            DataGridView.Columns["PosterPathColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridView.Columns["TitleColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridView.Columns["GenresColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //   DataGridView.Columns["OverviewColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridView.Columns["ReleaseDateColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridView.Columns["VoteAverageColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridView.Columns["VoteCountColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }
        public async void mostrar()
        {

            try
            {
                // Crear una instancia de DiscoverMovie
                var discoverMovie = new DiscoverMovie(client);

                // Definir el rango de fechas de lanzamiento (2010-01-01 a 2024-12-31)
                discoverMovie.WherePrimaryReleaseIsInYear(2024);


                // Obtener los resultados de la consulta
                var resultado = await discoverMovie.Query();

                // Obtener las películas de los resultados
                var películas = resultado.Results;

                // Obtener detalles de las películas por sus ID
                var películasDetalle = new List<Movie>();
                foreach (var película in películas)
                {
                    var películaDetalle = await client.GetMovieAsync(película.Id);
                    películasDetalle.Add(películaDetalle);
                }

                // Mostrar las películas en la tabla
                MostrarPeliculasEnTabla2(películasDetalle, 10);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar películas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarPeliculasEnTabla2(List<Movie> películas, int cantidadPeliculas)
        {
            DataGridView.Rows.Clear();
            int i = 1;
            foreach (var película in películas)
            {



                // Agregar una fila a DataGridView y establecer los valores de las celdas
                DataGridView.Rows.Add(
                    i,
                    película.Title,
                    string.Join(", ", película.Genres.Select(g => g.Name)),
                    película.ReleaseDate?.Year.ToString(),
                    película.VoteAverage.ToString(),
                    película.VoteCount.ToString()
                );
                i++;

                // Si se han agregado la cantidad deseada de películas, salir del bucle
                if (DataGridView.Rows.Count >= cantidadPeliculas)
                    break;

            }
            Console.WriteLine(i);
        }

        private void MostrarPeliculasEnTabla(List<Movie> películas, string generoSeleccionado, int añoSeleccionado, int cantidadPeliculas)
        {
            DataGridView.Rows.Clear();
            int i = 1;
            bool seEncontraronPeliculas = false;

            foreach (var película in películas)
            {
                bool cumpleGenero = película.Genres.Any(g => g.Name == generoSeleccionado);

                if (cumpleGenero)
                {
                    seEncontraronPeliculas = true;
                    DataGridView.Rows.Add(
                        i,
                        película.Title,
                        string.Join(", ", película.Genres.Select(g => g.Name)),
                        película.ReleaseDate?.Year.ToString(),
                        película.VoteAverage.ToString(),
                        película.VoteCount.ToString()
                    );
                    i++;

                    if (DataGridView.Rows.Count >= cantidadPeliculas)
                        break;
                }
            }

            if (!seEncontraronPeliculas)
            {
                // Mostrar el diálogo indicando que no se encontraron películas que cumplan los criterios
                MessageBox.Show("No se encontraron películas que cumplan los criterios.");
            }

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
            Contacto c = new Contacto();
            c.ShowDialog();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nosotros n = new Nosotros();
            n.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
