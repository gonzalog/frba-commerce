using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Asistentes
{
    class AsistenteBotones
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
    }
}
