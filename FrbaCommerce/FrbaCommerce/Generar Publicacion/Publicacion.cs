using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Editar_Publicacion;
using FrbaCommerce.Abm_Visibilidad;
using FrbaCommerce.Asistentes;
using System.Data;
using System.Windows.Forms;

namespace FrbaCommerce.Generar_Publicacion
{
    public class Publicacion
    {
        public int id;
        public Estado estado;
        public Visibilidad visibilidad;
        public string usuarioCreador;
        public string descripcion;
        public DateTime fechaInicio;
        public DateTime vencimiento;
        public bool hayPreguntas;
        public Tipo tipo;

        public Dictionary<string, int> rubrosPropiosPotenciales;
        public Dictionary<string, int> rubrosAjenos;

        public Publicacion(int id)
        {
            this.id = id;
            DataRow fila = AsistentePublicacion.getFila(id);
            estado = Estado.getEstado(fila["estado"].ToString());
            int codVisi = Convert.ToInt32(fila["Visibilidad"].ToString());
            visibilidad = new Visibilidad(AsistenteVisibilidad.getDataVisi(codVisi));
            usuarioCreador = fila["usuario"].ToString();
            descripcion = fila["Descripcion"].ToString();
            fechaInicio = Convert.ToDateTime(fila["fecha"]);
            vencimiento = Convert.ToDateTime(fila["fecha_venc"]);
            hayPreguntas = Convert.ToBoolean(fila["hay_preguntas"].ToString());
            tipo = AsistentePublicacion.getTipo(id);

            this.rubrosPropiosPotenciales = getTusRubros();
            this.rubrosAjenos = getRubrosNoTuyos();
        }

        public void abrirEditor()
        {
            tipo.abrirEditorEnEstado(estado,this);
        }

        public Dictionary<string, int> getTusRubros()
        {
            return AsistentePublicacion.getRubrosDe(this);
        }

        public Dictionary<string, int> getRubrosNoTuyos()
        {
            return AsistentePublicacion.getRubrosNoDe(this);
        }

        public void setVisibilidad(string descripNueva)
        {
            DataRow filaDeVisi = AsistenteVisibilidad.getDataVisi(descripNueva);
            this.visibilidad = new Visibilidad(filaDeVisi);
        }
        public void setEstado(string nombre)
        {
            estado = Estado.getEstado(nombre);
        }

        public void setRubrosPropiosPotenciales(CheckedListBox box)
        {
            List<string> chequeados = AsistenteColecciones.getCheckedItemsList(box);
            rubrosPropiosPotenciales = chequeados.ToDictionary(descripcion=>descripcion,descripcion=>AsistentePublicacion.getRubros()[descripcion]);
        }

        public void perdurar()
        { 
            //Primero, edita los valores en la entidad Publicacion.
            if (descripcion == "")
                throw new HayCamposEnBlanco("La descripción no puede estar en blanco");
            AsistentePublicacion.editarPublicacion(this);
            //Segundo, edita los de la entidad Venta_directa o Subasta.
            tipo.perdurar();
            //Tercero se editan los rubros asignados.
            //Se quitan los deseleccionados.
            Dictionary<string,int> rubrosPrevios = AsistentePublicacion.getRubrosDe(this);
            foreach (KeyValuePair<string, int> rubroViejo in rubrosPrevios)
                if (rubrosPropiosPotenciales.All(unRubroNuevo => !unRubroNuevo.Value.Equals(rubroViejo.Value))) 
                    AdaptadorBD.ejecutarProcedure("baja_rubro_por_publicacion",rubroViejo.Value,this.id);
            
            //Se agregan los que antes no estaban
            foreach (KeyValuePair<string, int> rubroNuevo in rubrosPropiosPotenciales)
                if (rubrosPrevios.All(unRubroViejo => !unRubroViejo.Value.Equals(rubroNuevo.Value)))
                    AdaptadorBD.ejecutarProcedure("alta_rubro_cod_por_publicacion", rubroNuevo.Value, this.id);
        }

        public void aumentarStockEn(int aumento)
        {
            this.tipo.stock += aumento;
        }

        public void hayUnInteresado(string user)
        {
            tipo.abrirVentanaInteresado(this,user);
        }
    }
}
