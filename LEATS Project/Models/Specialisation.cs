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
    
    public partial class Specialisation
    {
        public int SpecialisationID { get; set; }
        public int ModuleID { get; set; }
        public int TutorID { get; set; }
    
        public virtual Module Module { get; set; }
        public virtual Tutor Tutor { get; set; }
    }
}
