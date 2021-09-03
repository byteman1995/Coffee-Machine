using CoffeeMachine.Dispenser;
using System.Collections.Generic;

namespace CoffeeMachine.Model
{
    public class Machine
    {
        public int outlets { get; set; }
        public List<Ingredient> totalItemsQuantity {get; set; }
        public List<Beverage> beverages { get; set; }
    }
}
