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
    
    public partial class Attendance
    {
        public System.Guid AppointmentID { get; set; }
        public System.Guid PersonID { get; set; }
        public bool Accepted { get; set; }
        public System.Guid AttendanceID { get; set; }
        public byte[] timestamp { get; set; }
    
        public virtual Appointment Appointment { get; set; }
        public virtual Person Person { get; set; }
    }
}