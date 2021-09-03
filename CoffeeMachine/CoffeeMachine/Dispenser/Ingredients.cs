using System;

namespace CoffeeMachine.Dispenser
{
    public class IngredientsFactory
    {
        //Factory method to generate Ingredients based on their name
        public Ingredient CreateIngredients(string name, int totalQuantity)
        {
            switch (name)
            {
                case "hot_water":
                    return new HotWater(name, totalQuantity);
                case "hot_milk":
                    return new HotMilk(name, totalQuantity);
                case "ginger_syrup":
                    return new GingerSyrup(name, totalQuantity);
                case "sugar_syrup":
                    return new SugarSyrup(name, totalQuantity);
                case "tea_leaves_syrup":
                    return new TeaLeavesSyrup(name, totalQuantity);
                //In case of invalid item invalid ingredient class is returned
                default:
                    return new InValidIngredient(name, totalQuantity);
            }
            throw new Exception("Invalid Ingredients Found");
        }
    }
    public abstract class Ingredient
    {
        public string name;
        private int totalQuantity;
        public void SetTotalQuantity(int value)
        {
            this.totalQuantity = value;
        }
        public int GetTotalQuantity()
        {
            return this.totalQuantity;
        }
    }
    public class HotWater : Ingredient
    {
        public HotWater(string name, int totalQuantity)
        {
            this.name = name;
            this.SetTotalQuantity(totalQuantity);
        }
    }
    public class HotMilk : Ingredient
    {
        public HotMilk(string name, int totalQuantity)
        {
            this.name = name;
            this.SetTotalQuantity(totalQuantity);
        }
    }
    public class GingerSyrup : Ingredient
    {
        public GingerSyrup(string name, int totalQuantity)
        {
            this.name = name;
            this.SetTotalQuantity(totalQuantity);
        }
    }
    public class SugarSyrup : Ingredient
    {
        public SugarSyrup(string name, int totalQuantity)
        {
            this.name = name;
            this.SetTotalQuantity(totalQuantity);
        }
    }
    public class TeaLeavesSyrup : Ingredient
    {
        public TeaLeavesSyrup(string name, int totalQuantity)
        {
            this.name = name;
            this.SetTotalQuantity(totalQuantity);
        }
    }

    public class InValidIngredient: Ingredient
    {
        public InValidIngredient(string name, int totalQuantity)
        {
            this.name = name;
            this.SetTotalQuantity(totalQuantity);
        }
    }
}
