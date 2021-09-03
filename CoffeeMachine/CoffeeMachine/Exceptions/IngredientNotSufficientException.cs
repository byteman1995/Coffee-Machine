using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Exceptions
{
    class IngredientNotSufficientException : Exception
    {
        public IngredientNotSufficientException()
        {

        }

        public IngredientNotSufficientException(string beverageName, string ingredientName): base(String.Format("{0} cannot be prepared because {1} is not sufficient", beverageName, ingredientName))
        {

        }
    }
}
