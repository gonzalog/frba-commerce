using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class GenerarPublicacion : Form
    {
        private string user;
        private ComboBox[] combos;
        private TextBox[] boxes;
        public GenerarPublicacion(string user)
        {
            InitializeComponent();
            this.user = user;
            
            AsistenteBotones.hacerNoEditables(tipo,Visibilidad,Estado);
            
            tipo.Items.Add("Subasta");
            tipo.Items.Add("Compra inmediata");
            
            Visibilidad.Items.AddRange(AsistenteVisibilidad.getVisibilidades().Keys.ToArray());
            
            Estado.Items.AddRange(new string[2]{"Borrador","Publicada"});
            
            listadoRubros.Items.AddRange(AsistentePublicacion.getRubros().Keys.ToArray());

            combos = new ComboBox[3] {tipo,Visibilidad,Estado };
            boxes = new TextBox[3] {Precio,Stock,Descripcion };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AsistenteVistas.nombreProyecto + "\n" + "Desarrollado por THE_DISCRETABOY");
        }

        private void precio_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloReales(Precio);
        }

        private void stock_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(Stock);
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                AsistenteBotones.chequearTextboxNoNulos(Descripcion, Precio, Stock);
            }
            catch (HayCamposEnBlanco burbuja)
            {
                MessageBox.Show(burbuja.mensajeDefault());
                return;
            }

            Tipo saverTipoDeLaPublicacion = Tipo.getTipoSaver(tipo.Text);

            List<string> rubrosElegidos = new List<string>();
            
            foreach (string eleccion in listadoRubros.CheckedItems) rubrosElegidos.Add(eleccion);
            if (rubrosElegidos.Count == 0)
            {
                MessageBox.Show("Debe elegir por lo menos un rubro.");
                return;
            }

            //try
            //{
                saverTipoDeLaPublicacion.darDeALta(Descripcion.Text, Stock.Text, Precio.Text,
                    Visibilidad.Text, this.user, Estado.Text, rubrosElegidos, pregs.Checked);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Los datos ingresados no son soportados por el sistema.");
             //   return;
            //}
            MessageBox.Show("Publicación creada exitosamente.");
            Close();
        }
    }
}
