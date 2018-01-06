using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MVCCalendar.Models
{
    class Storage
    {
        public Person logInPerson(string login)
        {
            Person p;
            using (var db = new StorageContext())
                p = db.Persons.Where(b => b.UserID == login).FirstOrDefault();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} {1} logged in.", p.FirstName, p.LastName));
            return p;
        }

        public List<Appointment> getAppointments(int week, Person p)
        {
            using (var db = new StorageContext())
            {
                var q = from a in db.Appointments
                        join att in db.Attendances on a.AppointmentID equals att.Appointment.AppointmentID
                        where att.Person.PersonID == p.PersonID
                        select a;

                var list = new List<Appointment>(q.OrderBy(i => i.AppointmentDate));
                return new List<Appointment>(list.Where(a => a.AppointmentDate.DayOfYear > (week - 1) * 7 && 
                                                             a.AppointmentDate.DayOfYear < (week + 3) * 7));
            }
        }

        public void addAppointment(Appointment a, Person p)
        {
            Console.WriteLine(a.AppointmentDate);
            using (var db = new StorageContext())
            {
                a.AppointmentID = Guid.NewGuid();
                db.Appointments.Add(a);

                Attendance at = new Attendance
                {
                    AttendanceID = Guid.NewGuid(),
                    PersonID = p.PersonID,
                    AppointmentID = a.AppointmentID
                };

                db.Attendances.Add(at);
                db.SaveChanges();
            }
        }

        public void addPerson()
        {
            Person p = new Person
            {
                PersonID = Guid.NewGuid(),
                UserID = "baby",
                FirstName = "Baby",
                LastName = "Driver"
            };

            using (var db = new StorageContext())
            {
                db.Persons.Add(p);
                db.SaveChanges();
            }
        }

        public bool updateAppointment(Appointment Old, Appointment New)
        {
            using (var db = new StorageContext())
            {
                var original = db.Appointments.Find(Old.AppointmentID);
                if (original != null)
                {
                    original.StartTime = New.StartTime;
                    original.Title = New.Title;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Error while updating database! Try again.");
                        return false;
                    }
                }
            }
            return true;
        }

        public bool removeAppointment(Appointment Old)
        {
            using (var db = new StorageContext())
            {
                var original = db.Appointments.Find(Old.AppointmentID);
                if (original != null)
                {
                    db.Appointments.Remove(original);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Error while updating database! Try again.");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}