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
            var filtro = CmbFiltro.Text;
            if (filtro.Equals(""))
            {
                MessageBox.Show("Escoja una opción para filtrar", "Error al Consultar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ConsultaResponse response;
                
                if (filtro=="Todos")
                {
                    response = personaService.Consultar();
                }
                else
                {
                    string tipo;
                    tipo = MapearTipo(filtro);
                    response = personaService.Consultar(tipo);
                }
               
                if (!response.Error)
                {
                    DtgPersona.DataSource = response.Personas;
                }
                else
                {
                    MessageBox.Show(response.Mensaje, "Error al Consultar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private static string MapearTipo(string filtro)
        {
            string tipo;
            if (filtro == "Hombres")
            {
                tipo = "M";
            }
            else
            {
                tipo = "F";
            }

            return tipo;
        }

    }
}
