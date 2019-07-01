//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EventTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EventTable()
        {
            this.Comment = new HashSet<Comment>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime Date { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string Organizer { get; set; }
        public Nullable<double> Cost { get; set; }
        public Nullable<int> LimitOfPlace { get; set; }
        public Nullable<int> AgeRequirement { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
