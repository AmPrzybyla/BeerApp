using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer
{

    public class Recipe
    {
        public string Name { get; set; }
        public int SumOfHops { get; set; }
        public double SizeBefore { get; set; }

        public double ColorOfBeer { get; set; }

        public ObservableCollection<Hops> listOfHops = new ObservableCollection<Hops>();

        public ObservableCollection<Malts> listOfMalts = new ObservableCollection<Malts>();

      
        public void CalculateColorOfBeer()
        {
            double temp=0;
            foreach (var item in listOfMalts)
            {
                temp += item.WeightOfMalt * 2.204622 * item.ColorOfMalt / 1.97;
            }
            temp = temp / (SizeBefore / 3.7854);
            temp = 1.97 *(1.4922* (Math.Pow(temp,0.6859)));
            ColorOfBeer = temp;
        }
       
        //public Recipe(string name)
        //{
        //    Name = name;
        //    Console.WriteLine(Name);
        //}
        
        public void AddMalts()
        {
            listOfMalts.Add(new Malts { NameOfMalt = this.Name + " malt" });
            listOfMalts.Add(new Malts { NameOfMalt = this.Name + " malt 2" });
        }


        public void AddHops(string name, double alpha, int time, int weight)
        {
            listOfHops.Add(new Hops { NameOfHop = name, AlphaAcidsOfHop = alpha, TimeOfBoiling = time, WeightOfHop = weight });
        }

        public void AddHops()
        {
            listOfHops.Add(new Hops { NameOfHop = Name, AlphaAcidsOfHop = 12, TimeOfBoiling = 30, WeightOfHop = 30 });
            listOfHops.Add(new Hops { NameOfHop = Name + "edi", AlphaAcidsOfHop = 8, TimeOfBoiling = 60, WeightOfHop = 10, });
            listOfHops.Add(new Hops { NameOfHop = Name+ "piwo", AlphaAcidsOfHop = 10, TimeOfBoiling = 15, WeightOfHop = 60, });

        }

        public void AddMalts(string name, double weight, int color, int yield)
        {
            listOfMalts.Add(new Malts { NameOfMalt = name, WeightOfMalt = weight, ColorOfMalt = color, YieldOfMalt = yield });
        }




    }
}
