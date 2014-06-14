using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Editar_Publicacion;

namespace FrbaCommerce.Generar_Publicacion
{
    class Pausa : Estado
    {
        public override string nombre()
        {
            return "Pausa";
        }

        public override void abrirEditorParaSubasta(Publicacion publi)
        {
            System.Windows.Forms.MessageBox.Show("Usted no puede editar una publicacion Pausada.");
        }

        public override void abrirEditorParaVentaDirecta(Publicacion publi)
        {
            System.Windows.Forms.MessageBox.Show("Usted no puede editar una publicacion Pausada.");
        }
    }
}
