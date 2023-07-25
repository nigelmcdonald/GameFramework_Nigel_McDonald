using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//CONSIDER CONVERTING TO A SINGLETON
namespace GameFramework
{
    public class InputValidator
    {        
        public bool ValidateInput(string input, int min, int max)
        {
            if (int.TryParse(input, out int number))
            {
                return number >= min && number <= max;
            }
            return false;
        }
    }
}
