using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Generar_Publicacion
{
    class Finalizada : Estado 
    {
        private int codigo;
        public Finalizada()
        {
            codigo = AsistentePublicacion.getCodigoEstado("Finalizada");
        }
        public override string nombre()
        {
            return "Finalizada";    
        }

        public override int getCodigo()
        {
            return codigo;
        }

        public override void abrirEditorParaSubasta(Publicacion publi)
        {
            System.Windows.Forms.MessageBox.Show("Usted no puede editar una publicacion finalizada.");
        }

        public override void abrirEditorParaVentaDirecta(Publicacion publi)
        {
            System.Windows.Forms.MessageBox.Show("Usted no puede editar una publicacion finalizada.");
        }
    }
}
