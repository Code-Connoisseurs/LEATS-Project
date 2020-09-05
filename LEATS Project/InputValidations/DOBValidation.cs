using System;
using System.ComponentModel.DataAnnotations;

namespace LEATS_Project.InputValidations
{
   public class DOBValidation : ValidationAttribute
    {
        public override bool IsValid(object o)
        {
            DateTime dt = Convert.ToDateTime(o);
            return dt < DateTime.Now;
        }
    }
}