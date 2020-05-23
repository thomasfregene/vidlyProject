using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    //this is a reference data used to populate drop down list    
    public class MembershipType
    {
        //the id is the key to the customer model for this model
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        //refactoring magic numbers
        //see Min18YearsIfAMember class for implementation
        public static readonly byte Unkown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}