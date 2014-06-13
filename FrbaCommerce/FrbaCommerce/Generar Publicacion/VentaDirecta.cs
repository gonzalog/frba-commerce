using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Asistentes;
using System.Data;
using FrbaCommerce.Abm_Visibilidad;
using FrbaCommerce.Editar_Publicacion;

namespace FrbaCommerce.Generar_Publicacion
{
    class VentaDirecta : Tipo
    {
        public override string procedure()
        {
            return "alta_venta_directa";
        }

        private VentaDirecta() { }
        public static VentaDirecta newSaver()
        {
            return new VentaDirecta();
        }

        public VentaDirecta(int idPubli)
        {
            DataRow fila = AdaptadorBD.traerDataTable("venta_dir_por_pub", idPubli).Rows[0];
            this.id = Convert.ToInt32(fila["id"].ToString());
            this.stock = Convert.ToInt32(fila["stock"].ToString());
            this.precioInicial = Convert.ToDecimal(fila["precio"].ToString());
        }

        public override void abrirEditorEnEstado(Estado estado,Publicacion publi)
        {
            estado.abrirEditorParaVentaDirecta(publi);
        }
        public override string nombreTipo()
        {
            return "Venta directa";
        }
    }
}
