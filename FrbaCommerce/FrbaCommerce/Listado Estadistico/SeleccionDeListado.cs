using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Abm_Visibilidad;

namespace FrbaCommerce.Listado_Estadistico
{
    public partial class SeleccionDeListado : Form
    {
        public SeleccionDeListado()
        {
            InitializeComponent();
            AsistenteBotones.hacerNoEditables(elecAnio,elecTrimestre);
            List<string> anios = AsistentePublicacion.getAnios();
            foreach (string anio in anios)
                elecAnio.Items.Add(anio);
            for (int i = 1; i < 5; i++)
                elecTrimestre.Items.Add(i);
            elecAnio.Text = "2013";
            elecTrimestre.Text = "1";  
        }

        private void prodsNoVendidos_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo
                (
                new MuestraTop5
                    (
                        delegate(string visi, int mes, bool usarMes) 
                        {
                            if (usarMes)
                            {
                                System.Diagnostics.Debug.WriteLine("Se ejecuta vendedores_con_mas_no_vendidos_en_mes con args: "
                                    + Convert.ToInt32(elecAnio.Text) + " \"" + visi + "\" " + mes);
                                return AdaptadorBD.traerDataTable("vendedores_con_mas_no_vendidos_en_mes",
                                    Convert.ToInt32(elecAnio.Text), visi, mes);
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("Se ejecuta vendedores_con_mas_no_vendidos con args: "
                                    + Convert.ToInt32(elecAnio.Text) + " " + Convert.ToInt32(elecTrimestre.Text) + " \"" + visi + "\"");
                                return AdaptadorBD.traerDataTable("vendedores_con_mas_no_vendidos",
                                    Convert.ToInt32(elecAnio.Text), Convert.ToInt32(elecTrimestre.Text), visi);
                            }
                        },
                        "TOP 5 Vendedores con mayor cantidad de productos no vendidos.",
                        Convert.ToInt32(elecTrimestre.Text),
                        120
                    )
                );
        }

        private void masFacturacion_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo
                (
                new MuestraTop5
                    (
                    delegate(string visi, int mes, bool usarMes)
                    {
                        return AdaptadorBD.traerDataTable("vendedores_con_mas_facturacion", Convert.ToInt32(elecAnio.Text), Convert.ToInt32(elecTrimestre.Text));
                    },
                    "TOP 5 Vendedores con mayor facturación"
                    )
                );
        }

        private void mayorCalif_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo
                (
                new MuestraTop5
                    (
                    delegate(string visi, int mes, bool usarMes)
                    {
                        return AdaptadorBD.traerDataTable("vendedores_con_mayor_califs", Convert.ToInt32(elecAnio.Text), Convert.ToInt32(elecTrimestre.Text));
                    },
                    "TOP 5 Vendedores con mayores calificaciones."
                    )
                );
        }

        private void masSinCalif_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo
                (
                new MuestraTop5
                    (
                    delegate(string visi, int mes, bool usarMes)
                    {
                        return AdaptadorBD.traerDataTable("clientes_con_mas_sin_calif", elecAnio.Text, elecTrimestre.Text);
                    },
                    "TOP 5 Clientes con mayor cantidad de publicaciones sin calificar."
                    )
                );
        }
    }
}
