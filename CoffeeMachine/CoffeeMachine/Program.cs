using CoffeeMachine.Dispenser;
using CoffeeMachine.Constants;
using CoffeeMachine.Model;
using CoffeeMachine.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class Program
    {
        //Method to map the input JSON to Machine object having fields outlets, totalItemsQuantity, beverages
        public static Machine initializeMachine(string filepath)
        {
            Machine machine = new Machine();
            JObject machineData = (JObject)JObject.Parse(File.ReadAllText(filepath))[Constant.machineNode];
            
            //Assign value of count_n node of outlets to machine.outlets
            machine.outlets = machineData[Constant.outletsNode][Constant.countN].ToObject<int>();

            //Assign value of totalItemsQuantity node of outlets to machine.totalItemsQuantity
            Dictionary<string, string> totalQtyDict = ((JObject)machineData[Constant.totalItemsQuantity]).ToObject<Dictionary<string, string>>();
            machine.totalItemsQuantity = new List<Ingredient>();
            IngredientsFactory ingredientsFactory = new IngredientsFactory();
            foreach (KeyValuePair<string, string> totalQtyKey in totalQtyDict)
            {
                machine.totalItemsQuantity.Add(ingredientsFactory.CreateIngredients(totalQtyKey.Key, int.Parse(totalQtyKey.Value)));
            }

            //Assign value of beverages node of outlets to machine.beverage
            machine.beverages = new List<Beverage>();
            Dictionary<string, JObject> beveragesDict = ((JObject)machineData[Constant.beverages]).ToObject<Dictionary<string, JObject>>();
            foreach (var beverage in beveragesDict)
            {
                Dictionary<string, string> beverageDict = beverage.Value.ToObject<Dictionary<string, string>>();
                Dictionary<Ingredient, int> beverageIngredients = new Dictionary<Ingredient, int>();
                foreach(var beverageIngredient in beverageDict)
                {
                    Ingredient ingredient = machine.totalItemsQuantity.Where(ing => ing.name.Equals(beverageIngredient.Key)).FirstOrDefault();
                    if (ingredient == null)
                        ingredient = ingredientsFactory.CreateIngredients(beverageIngredient.Key, -1);
                    beverageIngredients.Add(ingredient, int.Parse(beverageIngredient.Value));
                }
                machine.beverages.Add(new Beverage(beverage.Key, beverageIngredients));
            }
            return machine;
        }

        public static void Main(string[] args)
        {
            //Initialize input and output paths
            string inputPath = args.Length ==2 ? args[0] : Constant.inputPath;
            string outputPath = args.Length == 2 ? args[1] : Constant.outputPath;
            
            //Initialize Machine object from input.json
            Machine machine = initializeMachine(inputPath);

            //Initialize PrinterService responsible for outputing data to output.txt
            PrinterService printService = new PrinterService(outputPath);
            printService.clearFile();

            //Making beverages in a multi-threaded environment when number of threads=machine.outlets
            Parallel.For(0, machine.beverages.Count, new ParallelOptions { MaxDegreeOfParallelism = machine.outlets }, i =>
             {
                 try
                 {
                     Beverage beverage = machine.beverages[i];
                     string response = Beverage.MakeBeverage(beverage.name, beverage.ingredientsQty);
                     printService.print(response);
                 }
                 catch(Exception e)
                 {
                     printService.print(e.Message);
                 }
             });
        }
    }
}
