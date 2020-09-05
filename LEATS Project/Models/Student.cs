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
    using InputValidations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.Appointments = new HashSet<Appointment>();
            this.ModuleRequests = new HashSet<ModuleRequest>();
            this.Tutors = new HashSet<Tutor>();
            this.TutorApplications = new HashSet<TutorApplication>();
            this.Appointments1 = new HashSet<Appointment>();
        }
    
        public int StudentID { get; set; }
        public string Id { get; set; }
        [Display(Name ="First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Ethnicity { get; set; }
        [DOBValidation]
        [Display(Name = "Date of Birth")]
        [Required]
        public System.DateTime DateOfBirth { get; set; }
        [Display(Name = "Cell No.")]
        [StringLength(10, MinimumLength = 10)]
        [Required]
        public string CellphoneNo { get; set; }
        public string Email { get; set; }
        [Display(Name = "Level of Study")]
        [Required]
        public string LevelOfStudy { get; set; }
        [Required]
        public string Campus { get; set; }
        [Required]
        public string College { get; set; }
        [Display(Name = "Street Name")]
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string Suburb { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Display(Name = "Postal Code")]
        [Required]
        //[StringLength(5, MinimumLength = 0)]
        public int PostalCode { get; set; }
        [Display(Name = "Profile Picture")]
        public byte[] ProfilePicture { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModuleRequest> ModuleRequests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tutor> Tutors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TutorApplication> TutorApplications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments1 { get; set; }
    }
}
