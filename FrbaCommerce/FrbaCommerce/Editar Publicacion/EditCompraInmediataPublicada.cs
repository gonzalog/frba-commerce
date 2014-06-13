using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Generar_Publicacion;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class EditCompraInmediataPublicada : Form
    {
        public Publicacion publiAEditar;
        public EditCompraInmediataPublicada(Publicacion publi)
        {
            InitializeComponent();
            this.publiAEditar = publi;
        }
    }
}
