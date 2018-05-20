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
    /// Logika interakcji dla klasy NewRecipe.xaml
    /// </summary>
    public partial class NewRecipe : Window
    {

        public NewRecipe()
        {
            InitializeComponent();
                 
        }

        private void AddBeer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
