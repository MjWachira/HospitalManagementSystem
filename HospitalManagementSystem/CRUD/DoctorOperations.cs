using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.CRUD
{
    public class DoctorOperations
    {
        public void AddDoctor()
        {
            using (var context = new HospitalDBContext())
            {
                // Creating a new Doctor
                var newDoctor = new Doctor
                {
                    DoctorName = "Dr. James",
                    DocSpecialty = "Ears"
                };

                // Add the new Doctor to the context
                context.Doctors.Add(newDoctor);

                Console.WriteLine(" Doctor Added Successfully...");
                // Save changes to the database
                context.SaveChanges();
            }

        }
        public void ViewDoctors()
        {
            using (var context = new HospitalDBContext())
            {
                // Retrieve a Doctor and their Appointments
                var doctorWithAppointments = context.Doctors
                    .Include(d => d.Appointments)
                    .FirstOrDefault();

                if (doctorWithAppointments != null)
                {
                    Console.WriteLine($"Doctor: {doctorWithAppointments.DoctorName}");

                    foreach (var appointment in doctorWithAppointments.Appointments)
                    {
                        Console.WriteLine($"Appointment Date: {appointment.AppointmentDate}, Time: {appointment.AppointmentTime}");
                    }
                }
            }
          
        }
        public void UpdateDoctor() 
        {
            using (var context = new HospitalDBContext())
            {
                // Find a Doctor by ID
                var doctorToUpdate = context.Doctors.Find(1);

                if (doctorToUpdate != null)
                {
                    // Update properties
                    doctorToUpdate.DoctorName = "Dr. Jane";
                    doctorToUpdate.DocSpecialty = "Skin";
                    Console.WriteLine("Doctor Updated Successfully...");
                    // Save changes to the database
                    context.SaveChanges();
                }
            }

        }
        public void DeleteDoctor()
        {
            using (var context = new HospitalDBContext())
            {
                // Find a Doctor by ID
                var doctorToDelete = context.Doctors.Find(3);

                if (doctorToDelete != null)
                {
                    // Remove the Doctor from the context
                    context.Doctors.Remove(doctorToDelete);

                    // Save changes to the database
                    Console.WriteLine("Doctor deleted successfully...");
                    context.SaveChanges();
                }
            }

        }

    }
}
