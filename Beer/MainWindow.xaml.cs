//using System.Collections.Generic.List;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Beer
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Recipe> listOfBeers = new ObservableCollection<Recipe>();
        public int openIndex;


        public MainWindow()
        {

            InitializeComponent();
            listOfBeers.Add(new Recipe() { Name = "pale Ale", SumOfHops = 12 });
            listOfBeers.Add(new Recipe() { Name = "PiPa", SumOfHops = 20 });
            listOfBeers.Add(new Recipe() { Name = "American Wheat", SumOfHops = 36 });

            for (int i = 0; i < listOfBeers.Count; i++)
            {
                listOfBeers[i].AddHops();
            }


             
            ListOfBeers.ItemsSource = listOfBeers;
        }

    
       
       
      

        private void ListOfBeers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            openIndex = ListOfBeers.SelectedIndex;
            ListOfHops.ItemsSource = listOfBeers[openIndex].listOfHops;
            ListOfMalts.ItemsSource = listOfBeers[openIndex].listOfMalts;



        }

        private void MaltsAddButton_Click(object sender, RoutedEventArgs e)
        {
           
            listOfBeers[openIndex].AddMalts();
            MessageBox.Show(listOfBeers[openIndex].SumOfHops.ToString());
        }

      
        
        /*
         * 
         * Opis Przycisków w Menu
         * 
         * New ->Nowa Receptura
         * 
         * 
         */
        private void New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            NewRecipe newRecipe = new NewRecipe();

            newRecipe.ShowDialog();
            listOfBeers.Add(new Recipe() { Name = newRecipe.NameOfBeerBox.Text });
            MessageBox.Show(newRecipe.NameOfBeerBox.Text);
        }



        private void AddHop_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            AddHop addHop = new AddHop();
            addHop.ShowDialog();
            listOfBeers[openIndex].AddHops(addHop.AddHopName.Text, Convert.ToDouble(addHop.AddHopAcids.Text), Convert.ToInt32(addHop.AddHopTime.Text), Convert.ToInt32(addHop.AddHopWeight.Text));
            listOfBeers[openIndex].SumOfHops += Convert.ToInt32(addHop.AddHopWeight.Text);




        }

        private void AddHop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (HopItem != null)
            {
                if (HopItem.IsSelected == true)
                {
                    e.CanExecute = true;
                }
                else
                    e.CanExecute = false;
            }


        }

        private void AddMalt_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (MaltItem != null)
            {
                if (MaltItem.IsSelected == true)
                {
                    e.CanExecute = true;
                }
                else
                {
                    e.CanExecute = false;
                }
            }

        }

        private void AddMalt_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            AddMalt addMalt = new AddMalt();
            addMalt.ShowDialog();
            listOfBeers[openIndex].AddMalts(addMalt.AddMaltName.Text, Convert.ToDouble(addMalt.AddWeightMalt.Text),Convert.ToInt32(addMalt.AddColorMalt.Text), Convert.ToInt32(addMalt.AddYieldMalt.Text));
            MessageBox.Show(HopItem.IsSelected.ToString());
            listOfBeers[openIndex].CalculateColorOfBeer();
            EbcWindow.DataContext = Math.Round(listOfBeers[openIndex].ColorOfBeer);

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(MaltItem.IsSelected==true)
            {
                AddMalt addMalt = new AddMalt();
                addMalt.ShowDialog();
                listOfBeers[openIndex].AddMalts(addMalt.AddMaltName.Text, Convert.ToInt32(addMalt.AddWeightMalt.Text), Convert.ToInt32(addMalt.AddColorMalt.Text), Convert.ToInt32(addMalt.AddYieldMalt.Text));
                MessageBox.Show(HopItem.IsSelected.ToString());
            }
            else if(HopItem.IsSelected==true)
            {
                AddHop addHop = new AddHop();
                addHop.ShowDialog();
                listOfBeers[openIndex].AddHops(addHop.AddHopName.Text, Convert.ToDouble(addHop.AddHopAcids.Text), Convert.ToInt32(addHop.AddHopTime.Text), Convert.ToInt32(addHop.AddHopWeight.Text));
                listOfBeers[openIndex].SumOfHops += Convert.ToInt32(addHop.AddHopWeight.Text);



            }
        }

        private void Size_TextChanged(object sender, TextChangedEventArgs e)
        {
            listOfBeers[openIndex].SizeBefore = Convert.ToDouble(Size.Text);
        }
    }
}
