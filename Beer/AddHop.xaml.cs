using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Beer
{
    /// <summary>
    /// Logika interakcji dla klasy AddHop.xaml
    /// </summary>
    public partial class AddHop : Window
    {
        public AddHop()
        {
            InitializeComponent();
        }

        

        private void AddHopButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddHopName.Text != "" && AddHopTime.Text != "" && AddHopWeight.Text != "" && AddHopAcids.Text != "")
                this.Close();
            else
                MessageBox.Show("musisz wszystko uzupełnić");
        }
    }
}
