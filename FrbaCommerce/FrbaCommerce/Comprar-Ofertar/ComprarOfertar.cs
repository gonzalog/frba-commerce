using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Generar_Publicacion;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class ComprarOfertar : Form
    {
        public List<int> codigosDePublicaciones;
        public int indiceMostrador; //Señala la posición que tiene en la lista de códigos el primer índice mostrado.
        public string user;
        private int publicacionesPorVez;
        private MuestraDePublicacion[] muestras = new MuestraDePublicacion[5];
        public ComprarOfertar(string user)
        {
            InitializeComponent();
            
            publicacionesPorVez = 5;
            this.user = user;
            List<string> rubros=AsistentePublicacion.getRubros().Keys.ToList();
            rubros.Add("");
            rubroSearcher.Items.AddRange(rubros.ToArray());
            AsistenteBotones.hacerNoEditable(rubroSearcher);

            inicializar();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void inicializar()
        {
            indiceMostrador = 0;
            codigosDePublicaciones = AsistentePublicacion.getCodPublicsAVer(user, buscador.Text, rubroSearcher.Text);
            System.Diagnostics.Debug.WriteLine("LA CANTIDAD DE PUBLICACIONES TRAIDAS ES: "+codigosDePublicaciones.Count);
            numPag.Text = ((this.indiceMostrador / this.publicacionesPorVez) + 1).ToString() + 
                " de " + (((this.codigosDePublicaciones.Count -1)/ this.publicacionesPorVez)+1).ToString();
            cargarPublicaciones();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            buscador.Text = "";
            rubroSearcher.Text = "";
            inicializar();
        }

        public void cargarPublicaciones()
        {
            if (codigosDePublicaciones.Count > indiceMostrador)
            {
                muestras[0] = new MuestraDePublicacion(codigosDePublicaciones[indiceMostrador], Descripcion1, precio1, boton1);
            }
            else
            {
                esconder(Descripcion1, precio1, boton1);
            }
            if (codigosDePublicaciones.Count > indiceMostrador+1)
                muestras[1] = new MuestraDePublicacion(codigosDePublicaciones[indiceMostrador + 1], Descripcion2, precio2, boton2);
            else
            {
                esconder(Descripcion2, precio2, boton2);
            }
            if (codigosDePublicaciones.Count > indiceMostrador+2)
                muestras[2] = new MuestraDePublicacion(codigosDePublicaciones[indiceMostrador + 2], Descripcion3, precio3, boton3);
            else
            {
                esconder(Descripcion3, precio3, boton3);
            }
            if (codigosDePublicaciones.Count > indiceMostrador+3)
                muestras[3] = new MuestraDePublicacion(codigosDePublicaciones[indiceMostrador + 3], Descripcion4, precio4, boton4);
            else
            {
                esconder(Descripcion4, precio4, boton4);
            }
            if (codigosDePublicaciones.Count > indiceMostrador+4)
                muestras[4] = new MuestraDePublicacion(codigosDePublicaciones[indiceMostrador + 4], Descripcion5, precio5, boton5);
            else
            {
                esconder(Descripcion5, precio5, boton5);
            }
        }

        private void esconder(Label Descripcion, Label precio, Button boton)
        {
            Descripcion.Hide();
            precio.Hide();
            boton.Hide();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            inicializar();
        }

        private void irAInicio_Click(object sender, EventArgs e)
        {
            this.indiceMostrador = 0;
            numPag.Text = ((this.indiceMostrador / this.publicacionesPorVez) + 1).ToString() + 
                " de " + (((this.codigosDePublicaciones.Count -1)/ this.publicacionesPorVez)+1).ToString();
            cargarPublicaciones();
        }

        private void irAFinal_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Se quiere ir a la pagina: " + indiceMostrador / publicacionesPorVez);
            
            int incongruencia = codigosDePublicaciones.Count() % publicacionesPorVez;
            if (incongruencia != 0)
            {
                this.indiceMostrador = codigosDePublicaciones.Count() - incongruencia;
            }
            else
            {
                //Este if está controlando el caso de que la última página sea también la primera.
                if (codigosDePublicaciones.Count() >= publicacionesPorVez)
                    this.indiceMostrador = codigosDePublicaciones.Count() - publicacionesPorVez;
                else
                    this.indiceMostrador = 0;
            }
            cargarPublicaciones();
            numPag.Text = ((this.indiceMostrador / this.publicacionesPorVez) + 1).ToString() +
                " de " + (((this.codigosDePublicaciones.Count - 1) / this.publicacionesPorVez) + 1).ToString();
        }

        private void posterior_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Se quiere incrementar a la pagina: " + indiceMostrador / publicacionesPorVez);
       
            if (codigosDePublicaciones.Count() > indiceMostrador + publicacionesPorVez)
            {
                this.indiceMostrador += publicacionesPorVez;
                cargarPublicaciones();
            }
            else
            {
                MessageBox.Show("No hay más páginas.");
            }
            numPag.Text = ((this.indiceMostrador / this.publicacionesPorVez) + 1).ToString() +
                " de " + (((this.codigosDePublicaciones.Count - 1) / this.publicacionesPorVez) + 1).ToString();
        }

        private void anterior_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Se quiere decrementar a la pagina: " + indiceMostrador / publicacionesPorVez);
            if (0 <= indiceMostrador - publicacionesPorVez)
            {
                this.indiceMostrador -= publicacionesPorVez;
                cargarPublicaciones();
            }
            else
            {
                MessageBox.Show("Usted ya se encuentra en la primer página.");
            }
            numPag.Text = ((this.indiceMostrador / this.publicacionesPorVez)+1).ToString()+
                " de " + (((this.codigosDePublicaciones.Count - 1) / this.publicacionesPorVez) + 1).ToString();
        }

        private void rubroSearcher_SelectedIndexChanged(object sender, EventArgs e)
        {
            inicializar();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            cargarPublicaciones();//Se vuelve a buscar la publicación a la base para evitar que muestren datos desactualizados.
            muestras[0].hayUnInteresado(user);
        }

        private void boton2_Click(object sender, EventArgs e)
        {
            cargarPublicaciones();
            muestras[1].hayUnInteresado(user);
        }

        private void boton3_Click(object sender, EventArgs e)
        {
            cargarPublicaciones();
            muestras[2].hayUnInteresado(user);
        }

        private void boton4_Click(object sender, EventArgs e)
        {
            cargarPublicaciones();
            muestras[3].hayUnInteresado(user);
        }

        private void boton5_Click(object sender, EventArgs e)
        {
            cargarPublicaciones();
            muestras[4].hayUnInteresado(user);
        }
    }
}
