using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Generar_Publicacion;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public class Renglon
    {
        public FormaDePago formaDePago;
        public Publicacion publicacion;
        public decimal comisionVisibilidad;
        public decimal comisionUnidades;

        public Renglon(SiguienteARendir form)
        {
            formaDePago = FormaDePago.newFormaDePago(form);
            publicacion = form.publiAFacturar;
            comisionVisibilidad = form.getComiVisi();
            comisionUnidades = form.getComiUnis();
        }

        public void perdurar(int factura,int nroDeRenglon)
        {
            AdaptadorBD.ejecutarProcedure("alta_renglon",
                factura,
                nroDeRenglon,
                publicacion.id,
                comisionVisibilidad,
                comisionUnidades,
                formaDePago.getNombre());

            formaDePago.perdurar(factura,nroDeRenglon);
            publicacion.setEstado("Finalizada");
            publicacion.perdurar();
        }
    }
}
