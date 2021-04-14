using Entidad;
using Logica;
using System;
using System.Windows.Forms;

namespace PulsacionGUI
{
    public partial class FrmRegistroPersona : Form
    {
        private PersonaService personaService;
        public FrmRegistroPersona()
        {
            InitializeComponent();
            personaService = new PersonaService();
        }
        private bool Validar() {
            if (TxtIdentificacion.Text=="")
            {
                return false;
            }
            return true;
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if(Validar())
            Guardar();
        }

        private void Guardar()
        {
            var persona = new Persona()
            {
                Identificacion = TxtIdentificacion.Text,
                Nombre = TxtNombre.Text,
                Edad = int.Parse(TxtEdad.Text),
                Sexo = CmbSexo.Text
            };
            persona.CalcularPulsacion();
            TxtPulsacion.Text = persona.Pulsacion.ToString();
            var mensaje = personaService.Guardar(persona);
            MessageBox.Show(mensaje, "Información al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
