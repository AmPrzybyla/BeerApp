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
        public int sumOfHop;
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

            SumOfHopFunction();


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

        private void SumOfHopFunction()
        {
            sumOfHop = listOfBeers[openIndex].SumOfHops;
            SumOfHop.DataContext = sumOfHop;

        }

        private void AddHop_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            AddHop addHop = new AddHop();
            addHop.ShowDialog();
            listOfBeers[openIndex].AddHops(addHop.AddHopName.Text, Convert.ToDouble(addHop.AddHopAcids.Text), Convert.ToInt32(addHop.AddHopTime.Text), Convert.ToInt32(addHop.AddHopWeight.Text));
            listOfBeers[openIndex].SumOfHops += Convert.ToInt32(addHop.AddHopWeight.Text);
            sumOfHop = listOfBeers[openIndex].SumOfHops;
            MessageBox.Show(sumOfHop.ToString());

            SumOfHopFunction();


        }

        private void AddHop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;

        }

        private void AddMalt_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;

        }

        private void AddMalt_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            int a = ListOfBeers.SelectedIndex;
            AddMalt addMalt = new AddMalt();
            addMalt.ShowDialog();
            listOfBeers[a].AddMalts(addMalt.AddMaltName.Text, Convert.ToInt32(addMalt.AddWeightMalt.Text),Convert.ToInt32(addMalt.AddColorMalt.Text), Convert.ToInt32(addMalt.AddYieldMalt.Text));
        }
    }
}