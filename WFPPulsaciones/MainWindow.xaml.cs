using Entidad;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WFPPulsaciones
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonaService personaService;

        public MainWindow()
        {
            InitializeComponent();
            personaService = new PersonaService();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var persona = new Persona()
            {
                Identificacion = TxtIdentificaion.Text,
                Nombre = TxtNombre.Text,
                //Edad = int.Parse(TxtEdad.Text),
                //Sexo = CmbSexo.Text
            };
           // persona.CalcularPulsacion();
            //TxtPulsacion.Text = persona.Pulsacion.ToString();
            var response = personaService.Consultar();
            if (!response.Error)
            {
                dataGrid.ItemsSource = response.Personas;
            }
            else
            {
                MessageBox.Show(response.Mensaje, "Información al Guardar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
           
        }
    }
}
