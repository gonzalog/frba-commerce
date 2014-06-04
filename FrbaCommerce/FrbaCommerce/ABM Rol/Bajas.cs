using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.ABM_Rol
{
    public partial class Bajas : Form
    {
        Form ventanaPadre { get; set; }
        PantallaPrincipal pantPrincipal { get; set; }
        DataTable vista;
        Dictionary<int, bool> estadoOriginal;


        public Bajas(Form padre, PantallaPrincipal pantallaPrincipal)
        {
            InitializeComponent();
            this.ventanaPadre = padre;
            this.pantPrincipal = pantallaPrincipal;
            this.estadoOriginal = AsistenteRol.getRolesConEstado();
            this.vista = AsistenteRol.getCodNombreRoles();

            cargarRolesEnElListado();
        }

        private void cargarRolesEnElListado()
        {
            foreach (KeyValuePair<int, bool> rol in this.estadoOriginal)
            {
                int index = boxDeRoles.Items.Add(AsistenteRol.getNombreRol(rol.Key));
                if(rol.Value)
                {
                    boxDeRoles.SetItemCheckState(index, CheckState.Checked);
                }
                else
                {
                    boxDeRoles.SetItemCheckState(index, CheckState.Unchecked);
                }
            }
        }

        private void boxDeRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorBox.Text = "¡Atención! Se han producido cambios en las selecciones. Esto se efectivizará si presiona 'Efectiviar'.\n Si no está de acuerdo puede presionar 'Cancelar'. \n Si desea ver el estado inicial de cada rol, haga click en 'Recordar el estado inicial'.";
        }

        private string palabraPara(bool estado)
        {
            return (estado ? "" : "in") + "habilitado";
        }

        private void Recordatorio_Click(object sender, EventArgs e)
        {
            string mensaje = "Estado inicial de los roles:\n ";
            foreach (KeyValuePair<int, bool> rol in this.estadoOriginal)
            {
                mensaje += "\t El rol " + AsistenteRol.getNombreRol(rol.Key) + " está " + palabraPara(rol.Value) + ".\n";
            }
            MessageBox.Show(mensaje);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(ventanaPadre, this);
        }

        private void Efectivizar_Click(object sender, EventArgs e)
        {
            Dictionary<int, bool> estadoFinal = new Dictionary<int, bool>();
            foreach (KeyValuePair<int, bool> est in estadoOriginal)
            {
                if (boxDeRoles.CheckedItems.Contains(AsistenteRol.getNombreRol(est.Key)))
                {
                    estadoFinal.Add(est.Key,true);
                }
                else
                {
                    estadoFinal.Add(est.Key,false);
                }
            }

            string mensajeBajas = "Fueron dados de baja:\n";
            string mensajeAltas = "Fueron dados de alta:\n";

            foreach(KeyValuePair<int,bool> estadoViejo in this.estadoOriginal)
            {
                if ((!estadoFinal[estadoViejo.Key]) && estadoViejo.Value)
                {
                    AsistenteRol.inhabilitarRol(estadoViejo.Key);
                    mensajeBajas += ("\t"+AsistenteRol.getNombreRol(estadoViejo.Key)+"\n");
                }
                if (estadoFinal[estadoViejo.Key] && (!estadoViejo.Value))
                {
                    AsistenteRol.habilitarRol(estadoViejo.Key);
                    mensajeAltas += ("\t" + AsistenteRol.getNombreRol(estadoViejo.Key) + "\n");
                }
            }
            MessageBox.Show(mensajeBajas + mensajeAltas);
            AsistenteVistas.volverAPadreYCerrar(ventanaPadre, this);
        }
    }
}
