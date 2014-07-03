using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public class Factura
    {
        public string user;
        public List<Renglon> renglones;
        public Factura(string user)
        {
            renglones = new List<Renglon>();
            this.user = user;
        }

        public void addRenglon(params Renglon[] renglones)
        {
            this.renglones.AddRange(renglones);
        }

        public void perdurar()
        {
            AdaptadorBD.ejecutarProcedure("alta_factura");
            int codigo = AdaptadorBD.ejecutarProcedureWithReturnValue("ultima_factura");
       
            for (int i = 0; i < renglones.Count; i++)
                renglones[i].perdurar(codigo,i);
            System.Windows.Forms.MessageBox.Show("El número correspondiente a esta nueva factura es: " + codigo);
        }
    }
}
