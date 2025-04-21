namespace jcorreaT2A
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // Validar que se seleccione un compañero
            if (pkCompañero.SelectedItem == null)
            {
                DisplayAlert("Error", "Por favor selecciona un compañero antes de continuar.", "OK");
                return;
            }

            // Obtener los valores de las notas desde los Entry
            if (double.TryParse(txtNota1.Text, out double seguimiento1) &&
                double.TryParse(txtExamen1.Text, out double examen1) &&
                double.TryParse(txtNota2.Text, out double seguimiento2) &&
                double.TryParse(txtExamen2.Text, out double examen2))
            {
                // Calcular las notas parciales
                double parcial1 = (seguimiento1 * 0.3) + (examen1 * 0.2);
                double parcial2 = (seguimiento2 * 0.3) + (examen2 * 0.2);

                // Mostrar las notas parciales
                txtNotaParcial1.Text = parcial1.ToString("F2");
                txtNotaParcial2.Text = parcial2.ToString("F2");

                // Calcular la nota final
                double notaFinal = parcial1 + parcial2;

                // Determinar el estado según la nota final
                string estado;
                if (notaFinal >= 7)
                {
                    estado = "Aprobado";
                }
                else if (notaFinal >= 5 && notaFinal <= 6.9)
                {
                    estado = "Complementario";
                }
                else
                {
                    estado = "REPROBADO";
                }


                // Obtener la fecha seleccionada
                string fecha = FechaDatePicker.Date.ToString("dd/MM/yyyy");

                // Mostrar el resultado en un DisplayAlert
                DisplayAlert("Resultado de Calificación",
                             $"Nombre: {pkCompañero.SelectedItem}\n" +
                             $"Fecha: {fecha}\n" +
                             $"Nota Parcial 1: {parcial1:F2}\n" +
                             $"Nota Parcial 2: {parcial2:F2}\n" +
                             $"Nota Final: {notaFinal:F2}\n" +
                             $"Estado: {estado}",
                             "OK");
            }
            else
            {
                // Mostrar un mensaje de error si las notas no se ingresaron correctamente
                DisplayAlert("Error", "Por favor ingresa todas las notas correctamente", "OK");
            }
        }
    }
}
