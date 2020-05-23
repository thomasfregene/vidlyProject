using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    //implementing a custom validation
    public class Min18YearsIfAMember : ValidationAttribute
    {
        //overriding validationAttrobute class using the second overload
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //validation logic
            var customer = (Customer)validationContext.ObjectInstance;

            //to check for selected membership type
            if (customer.MembershipTypeId == MembershipType.Unkown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
          
            //checking for null in birthdate field
            if (customer.BirthDate == null)
                return new ValidationResult("Birth Date is Required");

            //calculation for age
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18years old to go on a membership");

            

            
        }
    }
}