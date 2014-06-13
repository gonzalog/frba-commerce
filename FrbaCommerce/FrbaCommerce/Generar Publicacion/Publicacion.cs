using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Editar_Publicacion;
using FrbaCommerce.Abm_Visibilidad;
using FrbaCommerce.Asistentes;
using System.Data;

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
        }

        public void abrirEditor()
        {
            tipo.abrirEditorEnEstado(estado,this);
        }

        /*public CheckedIndexCollection getTusRubros()
        {
            //return AsistentePublicacion.getRubrosDe(this);
        }*/
    }
}
