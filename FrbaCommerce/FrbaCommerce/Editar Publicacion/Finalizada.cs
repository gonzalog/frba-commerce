using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generar_Publicacion
{
    class Finalizada : Estado 
    {
        public override string nombre()
        {
            return "Finalizada";
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
