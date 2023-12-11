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
            try {
                using (var context = new HospitalDBContext())
                {
                    Console.WriteLine("Enter Doctor Names");
                    string docName = Console.ReadLine();
                    Console.WriteLine("Enter Doctor Speciality");
                    string docSpec = Console.ReadLine();
                    var newDoctor = new Doctor
                    {
                        DoctorName = docName,
                        DocSpecialty = docSpec
                    };

                    context.Doctors.Add(newDoctor);
                    Console.WriteLine(" Doctor Added Successfully...");
                    context.SaveChanges();
                }
            }
            catch(Exception ex) 
            { Console.WriteLine(ex.Message); }
            

        }
        public void ViewDoctors()
        {
            try {
                using (var context = new HospitalDBContext())
                {
                    var allDoctors = context.Doctors
                        .Include(d => d.Appointments)
                        .ToList();

                    if (allDoctors.Count > 0)
                    {
                        Console.WriteLine("All Doctors and Their Appointments:");

                        foreach (var doctorWithAppointments in allDoctors)

                        {
                            Console.WriteLine($"Doctor ID: {doctorWithAppointments.DoctorID}");
                            Console.WriteLine($"Doctor: {doctorWithAppointments.DoctorName}");

                            foreach (var appointment in doctorWithAppointments.Appointments)
                            {
                                Console.WriteLine($"Appointment Date: {appointment.AppointmentDate}, Time: {appointment.AppointmentTime}");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No doctors found in the database.");
                    }
                }
             }catch(Exception ex) { Console.WriteLine($"Error occored due to{ ex.Message}"); }

            
        }

        public void UpdateDoctor() 
        {
            try {
                using (var context = new HospitalDBContext())
                {
                    ViewDoctors();
                    Console.WriteLine("Enter Doctor ID yo want to update");
                    int docID = int.Parse(Console.ReadLine());
                    var doctorToUpdate = context.Doctors.Find(docID);

                    Console.WriteLine("Enter Doctor Names");
                    string docName = Console.ReadLine();
                    Console.WriteLine("Enter Doctor Speciality");
                    string docSpec = Console.ReadLine();

                    if (doctorToUpdate != null)
                    {

                        doctorToUpdate.DoctorName = docName;
                        doctorToUpdate.DocSpecialty = docSpec;
                        Console.WriteLine("Doctor Updated Successfully...");
                        context.SaveChanges();
                    }
                }


            }
            catch (Exception ex) { Console.WriteLine($"Error occored due to{ex.Message}"); }
            
        }
        public void DeleteDoctor()
        {
            try {
                using (var context = new HospitalDBContext())
                {
                    ViewDoctors();
                    Console.WriteLine("Enter Doctor ID yo want to delete");
                    int docID = int.Parse(Console.ReadLine());

                    var doctorToDelete = context.Doctors.Find(docID);

                    if (doctorToDelete != null)
                    {
                        context.Doctors.Remove(doctorToDelete);
                        Console.WriteLine("Doctor deleted successfully...");
                        context.SaveChanges();
                    }
                }

            } catch (Exception ex) { Console.WriteLine($"Error occored due to{ex.Message}"); }
           

        }

    }
}
