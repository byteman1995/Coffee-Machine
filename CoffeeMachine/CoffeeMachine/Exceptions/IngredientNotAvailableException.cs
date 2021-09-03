using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Exceptions
{
    class IngredientNotAvailableException : Exception
    {
        public IngredientNotAvailableException()
        {

        }

        public IngredientNotAvailableException(string beverageName, string ingredientName): base(String.Format("{0} cannot be prepared because {1} is not available", beverageName, ingredientName))
        {

        }
    }
}
