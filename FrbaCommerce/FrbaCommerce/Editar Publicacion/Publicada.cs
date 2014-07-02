using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Editar_Publicacion;

namespace FrbaCommerce.Generar_Publicacion
{
    class Publicada : Estado
    {
        private int codigo;

        public Publicada()
        {
            codigo = AsistentePublicacion.getCodigoEstado("Publicada");
        }

        public override int getCodigo()
        {
            return codigo;
        }

        public override string nombre()
        {
            return "Publicada";
        }

        public override void abrirEditorParaSubasta(Publicacion publi)
        {
            System.Windows.Forms.MessageBox.Show("Usted no puede editar una subasta publicada.");
        }

        public override void abrirEditorParaVentaDirecta(Publicacion publi)
        {
            AsistenteVistas.mostrarSimultaneo(new EditCompraInmediataPublicada(publi));
        }

    }
}
