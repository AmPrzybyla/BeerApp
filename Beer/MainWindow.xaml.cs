﻿//using System.Collections.Generic.List;
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
         
        }






        private void ListOfBeers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            openIndex = ListOfBeers.SelectedIndex;
            Open(openIndex);
        }

        private void MaltsAddButton_Click(object sender, RoutedEventArgs e)
        {

            listOfBeers[openIndex].AddMalts();
        }


        public void Open(int open)
        {

            ListOfHops.ItemsSource = listOfBeers[open].listOfHops;
            ListOfMalts.ItemsSource = listOfBeers[open].listOfMalts;
            NameBox.DataContext = listOfBeers[open];
            listOfBeers[openIndex].CalculateColorOfBeer();
            EbcWindow.DataContext = Math.Round(listOfBeers[open].ColorOfBeer);
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
            ListOfBeers.ItemsSource = listOfBeers;

            Open(listOfBeers.Count - 1);
        }



        private void AddHop_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            AddHop();

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

            AddMalt();
        }

        private void AddMalt()
        {
            AddMalt addMalt = new AddMalt();
            addMalt.ShowDialog();
            if (addMalt.AddMaltName.Text != "" && addMalt.AddWeightMalt.Text != "" && addMalt.AddColorMalt.Text != "" && addMalt.AddYieldMalt.Text != "")
            {
                listOfBeers[openIndex].AddMalts(addMalt.AddMaltName.Text, double.Parse(addMalt.AddWeightMalt.Text.Replace('.', ',')), Convert.ToInt32(addMalt.AddColorMalt.Text), double.Parse(addMalt.AddYieldMalt.Text.Replace('.', ',')));
            }
            MessageBox.Show(HopItem.IsSelected.ToString());

            if (double.TryParse(Size.Text.Replace('.', ','), out double a))
            {
                listOfBeers[openIndex].SizeBefore = a;

                listOfBeers[openIndex].CalculateColorOfBeer();
                EbcWindow.DataContext = Math.Round(listOfBeers[openIndex].ColorOfBeer);
            }

            if (int.TryParse(EfficientyBox.Text.Replace('.', ','), out int efficienty))
            {
                listOfBeers[openIndex].Efficienty = efficienty;
                listOfBeers[openIndex].CalculateBLGOfBeer();
                BLGWindow.DataContext = Math.Round(listOfBeers[openIndex].BLG, 1);
            }
        }

        private void AddHop()
        {

            AddHop addHop = new AddHop();
            addHop.ShowDialog();
          //  if(addHop.AddHopAcids.Text!="" && addHop.AddHopName.Text!=""&& addHop.AddHopTime.Text!="" && addHop.AddHopWeight.Text!="")
            listOfBeers[openIndex].AddHops(addHop.AddHopName.Text, double.Parse(addHop.AddHopAcids.Text.Replace('.', ',')), Convert.ToInt32(addHop.AddHopTime.Text), Convert.ToInt32(addHop.AddHopWeight.Text));


            listOfBeers[openIndex].CalculateIBU();
            IBUBox.DataContext = Math.Round(listOfBeers[openIndex].IBU, 1);
            MessageBox.Show(listOfBeers[openIndex].IBU.ToString());

        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (MaltItem.IsSelected == true)
            {
                AddMalt();
            }
            else if (HopItem.IsSelected == true)
            {
                AddHop();
            }
        }


        private void ValueChange(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(Size.Text.Replace('.', ','), out double a))
                if(openIndex>0)
                listOfBeers[openIndex].SizeBefore = a;
        }

        private void bye(object sender, RoutedEventArgs e)
        {
            listOfBeers[openIndex].Efficienty = Convert.ToInt32(EfficientyBox.Text);
            listOfBeers[openIndex].CalculateBLGOfBeer();
            BLGWindow.DataContext = Math.Round(listOfBeers[openIndex].BLG, 1);
        }

        new private void SizeChanged(object sender, TextChangedEventArgs e)
        {
            listOfBeers[openIndex].SizeBefore = Convert.ToDouble(Size.Text);
        }
    }
}
