using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretIngredients
{
    class Suzanne
    {
        public GetSecretIngredient MySecretIngredientMethod
        {
            get
            {
                return new GetSecretIngredient(SuzannesSecretIngredient);
            }
        }
        private string SuzannesSecretIngredient(int amount)
        {
            return amount.ToString() + " ounces of cloves";
        }
    }
}
