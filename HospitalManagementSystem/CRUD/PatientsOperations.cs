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
            try
            {
                RoomOperations roomOperations = new RoomOperations();
                roomOperations.ViewRooms();

                using (var context = new HospitalDBContext())
                {
                    Console.WriteLine("Enter First Name");
                    string fName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name");
                    string lName = Console.ReadLine();
                    Console.WriteLine("Enter Email Name");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter Room to Admit");

                    if (int.TryParse(Console.ReadLine(), out int rmID))
                    {
                        var newPatient = new Patient
                        {
                            FirstName = fName,
                            LastName = lName,
                            Email = email,
                            RoomID = rmID
                        };

                        context.Patients.Add(newPatient);
                        context.SaveChanges();

                        Console.WriteLine("Patient added successfully ...");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Room ID. Please enter a valid  Room ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                
            }
        }

        public void ViewPatients()
        {
            try
            {
                using (var context = new HospitalDBContext())
                {
                    var allPatients = context.Patients
                        .Include(p => p.Room)
                        .ToList();

                    if (allPatients.Count > 0)
                    {
                        Console.WriteLine("All Patients:");

                        foreach (var patientDetails in allPatients)
                        {
                            Console.WriteLine($"Patient ID: {patientDetails.PatientID}");
                            Console.WriteLine($"Name: {patientDetails.FirstName} {patientDetails.LastName}");
                            Console.WriteLine($"Email: {patientDetails.Email}");
                            Console.WriteLine($"Room: {patientDetails.Room.RoomNumber}, Type: {patientDetails.Room.RoomType}");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No patients found in the database.");
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }

        public void UpdatePatient()
        {
            try
            {
                using (var context = new HospitalDBContext())
                {
                    ViewPatients();

                    Console.WriteLine("Enter Patient ID to Update");
                    int patID = int.Parse(Console.ReadLine());
                    var patientToUpdate = context.Patients.Find(patID);

                    Console.WriteLine("Enter First Name");
                    string fName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name");
                    string lName = Console.ReadLine();
                    Console.WriteLine("Enter Email Name");
                    string email = Console.ReadLine();

                    if (patientToUpdate != null)
                    {

                        patientToUpdate.FirstName = fName;
                        patientToUpdate.LastName = lName;
                        patientToUpdate.Email = email;


                        context.SaveChanges();

                        Console.WriteLine("Patient Updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Patient ID not found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

            }


        }
        public void DeletePatient()
        {
            try
            {
                using (var context = new HospitalDBContext())
                {
                    ViewPatients();
                    Console.WriteLine("Enter Patient ID to delete");
                    int patID = int.Parse(Console.ReadLine());
                    var patientToDelete = context.Patients.Find(patID);

                    if (patientToDelete != null)
                    {

                        context.Patients.Remove(patientToDelete);


                        context.SaveChanges();
                        Console.WriteLine("Patient Deleted Successfully..");
                    }
                    else
                    {
                        Console.WriteLine(" Patient ID not found");
                    }
                }

            } catch (Exception ex)
            { Console.WriteLine($"An error occurred: {ex.Message}"); }


        }
    }
}
