using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Registro_de_Usuario;
using FrbaCommerce.Excepciones;
using FrbaCommerce.Generar_Publicacion;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class EditBorrador : Form
    {
        public Publicacion publiAEditar;
        public EditBorrador(Publicacion publi)
        {
            InitializeComponent();
            this.publiAEditar = publi;
            tipo.Text = publi.tipo.nombreTipo();
            Descripcion.Text = publi.descripcion;
            Stock.Text = Convert.ToString(publi.tipo.stock);
            Precio.Text = Convert.ToString(publi.tipo.precioInicial);

            cargarRubros();
            cargarSiHayPreguntas();

            Visibilidad.Items.AddRange(AsistenteVisibilidad.getVisibilidades().Keys.ToArray());
            Visibilidad.Text = publi.visibilidad.descripcion;
            estado.Items.AddRange(Estado.estados.Keys.ToArray());
            estado.Text = "Borrador";

            AsistenteBotones.hacerNoEditables(Visibilidad, estado);
        }

        private void cargarSiHayPreguntas()
        {
            pregs.Checked = publiAEditar.hayPreguntas;
        }

        private void cargarRubros()
        {
            string[] rubros = publiAEditar.getTusRubros().Keys.ToArray();
            int i;
            for(i = 0;i<rubros.Length;i++)
            {
                listadoRubros.Items.Add(rubros[i]);
                listadoRubros.SetItemChecked(i,true);
            }

            string[] rubrosAjenos = publiAEditar.getRubrosNoTuyos().Keys.ToArray();
            for (int j = i; j < rubrosAjenos.Length; j++)
            {
                listadoRubros.Items.Add(rubrosAjenos[j-i]);
                listadoRubros.SetItemChecked(j, false);
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AsistenteVistas.nombreProyecto + "\n" + "Desarrollado por THE_DISCRETABOY");
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Stock_TextChanged(object sender, EventArgs e)
        {
            if (AsistenteBotones.checkSoloNumericos(Stock))
                publiAEditar.tipo.stock = Convert.ToInt32(Stock.Text);
        }

        private void Precio_TextChanged(object sender, EventArgs e)
        {
            if(AsistenteBotones.checkSoloReales(Precio))
                publiAEditar.tipo.precioInicial = Convert.ToDecimal(Precio.Text);
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer realizar estos cambios?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    try
                    {
                        AdaptadorBD.ejecutarProcedure("alta_visibilidad_por_user",publiAEditar.visibilidad.cod,publiAEditar.usuarioCreador);
                    }
                    catch (Exception)
                    {
                        //Significa que esta visibilidad ya fue usada por el usuario.
                    }
                    this.publiAEditar.perdurar();
                    this.Close();
                }
                catch (HayCamposEnBlanco)
                {
                    MessageBox.Show("La operación no puede concretarse porque hay campos en blanco.");
                }
                catch (ElTamanioDeLosDatosExcedeAlSistema)
                {
                    MessageBox.Show("El tamaño de los datos ingresados excede las capacidades del sistema.");
                }
            }  
        }

        private void pregs_CheckedChanged(object sender, EventArgs e)
        {
            publiAEditar.hayPreguntas = pregs.Checked;
            System.Diagnostics.Debug.WriteLine("Se altera la casilla de preguntas.");
        }

        private void Descripcion_TextChanged(object sender, EventArgs e)
        {
            publiAEditar.descripcion = Descripcion.Text;
        }

        private void Visibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            publiAEditar.setVisibilidad(Visibilidad.Text);
        }

        private void Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            publiAEditar.setEstado(estado.Text);
        }

        private void listadoRubros_SelectedIndexChanged(object sender, EventArgs e)
        {
            publiAEditar.setRubrosPropiosPotenciales(listadoRubros);
        }

    }
}
