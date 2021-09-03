using CoffeeMachine.Exceptions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CoffeeMachine.Dispenser
{
    public abstract class BeverageA
    {
        public string name;
        public Dictionary<Ingredient, int> ingredientsQty;
        /*
         Helper method to check if beverage make is possible or not by checking:-
         a. Presence of invalid ingredients having quantity of -1
         b. Present of insufficient ingredients
         */
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool CanMakeBeverage(string name, Dictionary<Ingredient, int> ingredientsQty)
        {
            List<string> outOfStockIngredients = new List<string>();

            List<string> invalidIngredients = new List<string>();


            foreach (var ingredient in ingredientsQty)
            {
                //Invalid ingredients will have total quantity as -1
                if (ingredient.Key.GetTotalQuantity() == -1)
                    invalidIngredients.Add(ingredient.Key.name);
                if (ingredient.Key.GetTotalQuantity() < ingredient.Value)
                    outOfStockIngredients.Add(ingredient.Key.name);
            }

            if (invalidIngredients.Count > 0)
            {
                throw new IngredientNotAvailableException(name, invalidIngredients[0]);
            }
            if (outOfStockIngredients.Count > 0)
            {
                throw new IngredientNotSufficientException(name, outOfStockIngredients[0]);
            }
            return true;
        }
        //Helper method to make the beverage and then update the ingredient quantities.
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static string MakeBeverage(string name, Dictionary<Ingredient, int> ingredientsQty)
        {
            if (CanMakeBeverage(name, ingredientsQty))
            {
                foreach (var ingredient in ingredientsQty)
                {
                    Ingredient ingredientItem = ingredient.Key;
                    ingredientItem.SetTotalQuantity(ingredientItem.GetTotalQuantity() - ingredient.Value);
                }
            }
            return name + " is prepared";
        }
    }
    public class Beverage: BeverageA
    {
        public Beverage(string name, Dictionary<Ingredient, int> ingredientsQty)
        {
            this.name = name;
            this.ingredientsQty = ingredientsQty;
        }
    }
}
