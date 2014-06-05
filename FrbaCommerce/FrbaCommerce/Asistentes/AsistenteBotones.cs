using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Asistentes
{
    class AsistenteBotones : AdaptadorBD
    {
        public static void addListToListBox(ListBox box,List<string> stringList) 
        {
            box.Items.AddRange(stringList.ToArray());
        }

        public static void addListToComboBox(ComboBox box, List<string> stringList)
        {
            box.Items.AddRange(stringList.ToArray());
        }

        public static void vaciarComboBox(ComboBox box) 
        {
            box.Items.Clear();
        }

        public static void vaciarListBox(ListBox box)
        {
            box.Items.Clear();
        }

        public static void chequearTextboxNoNulo(TextBox box, List<string> errores, string nombre) 
        {
            if (String.IsNullOrEmpty(box.Text))
                errores.Add("El campo "+nombre+" no puede estar vacío.");
        }

        public static void checkSoloNumericos(TextBox box) 
        {
            string tString = box.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    MessageBox.Show("Debe ingresarse un valor numérico.");
                    box.Text = "";
                    return;
                }

            }
        }

        public static void chequearTextboxNoNuloYMail(TextBox box, List<string> errores, string nombre) 
        {
            chequearTextboxNoNulo(box,errores,nombre);
            chequearMail(box.Text,errores);
        }

        public static void chequearMail(string mail, List<string> errores)
        {
             if( ! tieneFormatoMail(mail))
            {
                errores.Add("El mail tiene un formato inválido.");
            }
        }

        public static bool tieneFormatoMail(string mail)
        {
            return ejecutarProcedureWithReturnValue("tiene_formato_mail",mail).Equals(1);
        }

        public static string hacerListadoErrores(List<string> errores) 
        {
            string listado = "ERROR EN EL INGRESO DE DATOS: \n";
            foreach (string alerta in errores)
            {
                listado += ("\t" + alerta + "\n");
            }
            return listado;
        }
    }
}
