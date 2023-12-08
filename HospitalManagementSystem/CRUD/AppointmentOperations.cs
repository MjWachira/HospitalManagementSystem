using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.CRUD
{
    public class AppointmentOperations
    {
        public void MakeAppointment()
        {
            using (var context = new HospitalDBContext())
            {
               
                var newAppointment = new Appointment
                {
                    AppointmentDate = new DateOnly(2023, 12, 15),
                    AppointmentTime = new TimeOnly(11, 30),
                    PatientID = 1, 
                    DoctorID = 1   
                };
                   
                context.Appointments.Add(newAppointment);

                
                context.SaveChanges();

                Console.WriteLine("Appointment Added Successfully...");
            }

        }
        public void ViewAppointments()
        {
            using (var context = new HospitalDBContext())
            {
                
                var appointmentDetails = context.Appointments
                    .Include(a => a.Patient)
                    .Include(a => a.Doctor)
                    .FirstOrDefault();

                if (appointmentDetails != null)
                {
                    Console.WriteLine($"Appointment ID: {appointmentDetails.AppointmentID}");
                    Console.WriteLine($"Date: {appointmentDetails.AppointmentDate}, Time: {appointmentDetails.AppointmentTime}");
                    Console.WriteLine($"Patient: {appointmentDetails.Patient.FirstName} {appointmentDetails.Patient.LastName}");
                    Console.WriteLine($"Doctor: {appointmentDetails.Doctor.DoctorName}");
                }
            }

        }
        public void UpdateAppointment()
        {
            using (var context = new HospitalDBContext())
            {
                
                var appointmentToUpdate = context.Appointments.Find(1);

                if (appointmentToUpdate != null)
                {
                    
                    appointmentToUpdate.AppointmentDate = new DateOnly(2023, 12, 20);
                    appointmentToUpdate.AppointmentTime = new TimeOnly(14, 45);

                 
                    context.SaveChanges();
                    Console.WriteLine("Appointment  wass Updated ....");
                }
            }


        }
        public void DeleteAppointment()
        {
            using (var context = new HospitalDBContext())
            {
                
                var appointmentToDelete = context.Appointments.Find(2);

                if (appointmentToDelete != null)
                {
                    
                    context.Appointments.Remove(appointmentToDelete);

                    
                    context.SaveChanges();
                    Console.WriteLine("Appointment was deleted...");
                }
            }

        }
    }
}
