using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //Attribute/*enforcing business logic*/
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        /*overriding conventions*/
        //validation using data annotation
        //overriding error message
        [Required(ErrorMessage ="Please Enter a Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }  

        //this is referred to as a navigation property 
        public MembershipType MembershipType { get; set; }
        
        //foreign key
        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name ="Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

    }
}