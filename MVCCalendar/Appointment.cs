//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCCalendar
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appointment
    {
        public Appointment()
        {
            this.Attendances = new HashSet<Attendance>();
        }
    
        public System.Guid AppointmentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime AppointmentDate { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public byte[] timestamp { get; set; }
    
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}