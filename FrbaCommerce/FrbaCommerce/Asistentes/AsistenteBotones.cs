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

        public static void chequearTextboxNoNulo(TextBox box, string nombre)
        {
            if (String.IsNullOrEmpty(box.Text)) throw new HayCamposEnBlanco("El campo "+nombre+" no puede estar vacío.");
        }

        public static void chequearTextboxNoNulos(params TextBox[] boxes)
        {
            foreach(TextBox box in boxes)
                if (String.IsNullOrEmpty(box.Text)) throw new HayCamposEnBlanco(box);
        }

        public static bool checkSoloNumericos(TextBox box) 
        {
            string tString = box.Text;
            if (tString.Trim() == "") return true;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    MessageBox.Show("Debe ingresarse un valor numérico.");
                    box.Text = "0";
                    return false;
                }

            }
            return true;
        }

        public static void checkSoloNumericosYMenorOIgualA(TextBox box,int cotaSuperiorCerrada)
        {
            string tString = box.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
                if (!char.IsNumber(tString[i]))
                {
                    MessageBox.Show("Debe ingresarse un valor numérico.");
                    box.Text = "0";
                    return;
                }

            checkMenorA(box,cotaSuperiorCerrada); 
        }

        public static void checkMenorA(TextBox box, int cotaSuperiorCerrada)
        {
            try
            {
                if (Convert.ToInt64(box.Text) > cotaSuperiorCerrada)
                {
                    MessageBox.Show("Debe ingresarse un valor menor a " + cotaSuperiorCerrada + ".");
                    box.Text = "0";
                    return;
                }
            }
            catch (FormatException)
            { 
            }
        }
        public static void checkSoloNumericosOGuion(TextBox box)
        {
            string tString = box.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if ((!char.IsNumber(tString[i])) & (tString[i]!='-'))
                {
                    MessageBox.Show("Debe ingresarse un valor numérico.");
                    box.Text = "0";
                    return;
                }

            }
        }

        public static void chequearTextboxNoNuloYMail(TextBox box, List<string> errores, string nombre) 
        {
            chequearTextboxNoNulo(box,errores,nombre);
            chequearMail(box.Text,errores);
        }

        public static void chequearTextboxNoNuloYTelCliente(TextBox box, List<string> errores, string nombre)
        {
            chequearTextboxNoNulo(box, errores, nombre);
            chequearTelCliente(box.Text, errores);
        }

        public static void chequearMail(string mail, List<string> errores)
        {
             if( ! tieneFormatoMail(mail))
            {
                errores.Add("El mail tiene un formato inválido.");
            }
        }

        public static void chequearTelCliente(string tel, List<string> errores) 
        {
            if (AsistenteCliente.existeTelefonoCliente(tel))
            {
                errores.Add("Ya existe un cliente registrado con tal número telefónico.");
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
        public static string eliminarDecimales(string entrada)
        {
            int indiceComa = entrada.IndexOf(',');
            return entrada.Remove(indiceComa);
        }

        public static bool checkSoloNumericosYComa(TextBox box)
        {
            string tString = box.Text;
            if (tString.Trim() == "") return true;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!(char.IsNumber(tString[i]) | tString[i]==','))
                {
                    MessageBox.Show("Valor incorrecto.");
                    box.Text = "0";
                    return false;
                }
            }
            return true;
        }

        public static bool checkMaximoNCaracter(char car,int maximo,TextBox box)
        {
            int veces = 0;
            foreach (char letra in box.Text)
                if (letra == car) veces++;
            if (veces > maximo)
            {
                MessageBox.Show("Valor incorrecto.");
                box.Text = "0";
                return false;
            }
            return true;
        }

        public static bool checkSoloReales(TextBox box)
        {
            if (!checkSoloNumericosYComa(box)) return false;
            if (!checkMaximoNCaracter(',', 1, box)) return false;
            return true;
        }
        public static void hacerNoEditable(ComboBox box)
        {
            box.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static void hacerNoEditables(params ComboBox[] boxes)
        {
            foreach (ComboBox box in boxes) hacerNoEditable(box);
        }


        public static void hacerNoEditable(NumericUpDown cantidadCompra)
        {
            cantidadCompra.ReadOnly = true;
        }
    }
}
