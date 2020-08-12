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
    
    public partial class Tutor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tutor()
        {
            this.Appointments = new HashSet<Appointment>();
            this.Specialisations = new HashSet<Specialisation>();
        }
    
        public int TutorID { get; set; }
        public int StudentID { get; set; }
        public string Experience { get; set; }
        public string Qualification { get; set; }
        public string Tut_StreetName { get; set; }
        public string RatePerHour { get; set; }
        public string Status { get; set; }
        public int TotalRating { get; set; }
        public int NoOfSessions { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specialisation> Specialisations { get; set; }
        public virtual Student Student { get; set; }
    }
}