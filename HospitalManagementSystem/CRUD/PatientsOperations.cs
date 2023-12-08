using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.CRUD
{
    public class PatientsOperations
    {
        public void AddPatient() 
        {
            using (var context = new HospitalDBContext())
            {
              
                var newPatient = new Patient
                {
                    FirstName = "Mike",
                    LastName = "Mikw",
                    Email = "mike@gmail",
                    RoomID = 1 
                };

                
                context.Patients.Add(newPatient);

                context.SaveChanges();

                Console.WriteLine("Patient added successfully ...");
            }

        }
        public void ViewPatient()
        {
            using (var context = new HospitalDBContext())
            {
                
                var patientDetails = context.Patients
                    .Include(p => p.Room)
                    .FirstOrDefault();

                if (patientDetails != null)
                {
                    Console.WriteLine($"Patient ID: {patientDetails.PatientID}");
                    Console.WriteLine($"Name: {patientDetails.FirstName} {patientDetails.LastName}");
                    Console.WriteLine($"Email: {patientDetails.Email}");
                    Console.WriteLine($"Room: {patientDetails.Room.RoomNumber}, Type: {patientDetails.Room.RoomType}");
                }
            }


        }
        public void UpdatePatient()
        {
            using (var context = new HospitalDBContext())
            {
               
                var patientToUpdate = context.Patients.Find(1);

                if (patientToUpdate != null)
                {
                    
                    patientToUpdate.FirstName = "Jane";
                    patientToUpdate.LastName = "Jane";
                    patientToUpdate.Email = "jane@gmail.com";

                    
                    context.SaveChanges();

                    Console.WriteLine("Patient Updated Successfully");
                }
            }

        }
        public void DeletePatient()
        {
            using (var context = new HospitalDBContext())
            {
                
                var patientToDelete = context.Patients.Find(2);

                if (patientToDelete != null)
                {
                    
                    context.Patients.Remove(patientToDelete);

                    
                    context.SaveChanges();
                    Console.WriteLine("Patient Deleted Successfully..");
                }
            }

        }
    }
}
