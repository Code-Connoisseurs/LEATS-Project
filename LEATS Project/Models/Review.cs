//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LEATS_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int ReviewID { get; set; }
        public int AppointmentID { get; set; }
        public System.DateTime Date { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    
        public virtual Appointment Appointment { get; set; }
    }
}
