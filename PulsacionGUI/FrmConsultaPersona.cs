using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PulsacionGUI
{
    public partial class FrmConsultaPersona : Form
    {
        PersonaService personaService;
        public FrmConsultaPersona()
        {
            InitializeComponent();
            personaService = new PersonaService();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            var response=personaService.Consultar();
            if (!response.Error)
            {
                DtgPersona.DataSource = response.Personas;
            }
            else
            {
                MessageBox.Show(response.Mensaje,"Error al Consultar",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
