using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Editar_Publicacion;

namespace FrbaCommerce.Generar_Publicacion
{
    class Borrador : Estado
    {
        public string nombre()
        {
            return "Borrador";
        }

        public override void abrirEditorParaSubasta(Publicacion publi)
        {
            AsistenteVistas.mostrarSimultaneo(new EditBorrador(publi));
        }

        public override void abrirEditorParaVentaDirecta(Publicacion publi)
        {
            AsistenteVistas.mostrarSimultaneo(new EditBorrador(publi));
        }
    }
}
