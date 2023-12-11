using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.CRUD
{
    public class RoomOperations
    {
        public void AddRoom()
        {
            try {
                using (var context = new HospitalDBContext())
                {
                    Console.WriteLine("Enter Room Numer");
                    string rmNum = Console.ReadLine();
                    Console.WriteLine("Enter Room Type");
                    string rmType = Console.ReadLine();

                    var newRoom = new Room
                    {
                        // RoomID=0,
                        RoomNumber = rmNum,
                        RoomType = rmType
                    };


                    context.Rooms.Add(newRoom);


                    context.SaveChanges();
                    Console.WriteLine("Room added successfully");
                }
            } catch (Exception ex) { Console.WriteLine($"Error occored due to{ex.Message}"); }
            

        }
        public void ViewRooms()
        {
            try {
                using (var context = new HospitalDBContext())
                {
                    var allRooms = context.Rooms
                        .Include(r => r.Patients)
                        .ToList();

                    if (allRooms.Count > 0)
                    {
                        Console.WriteLine("All Rooms and Their Patients:");

                        foreach (var roomDetails in allRooms)
                        {
                            Console.WriteLine($"Room ID: {roomDetails.RoomID}");
                            Console.WriteLine($"Room Number: {roomDetails.RoomNumber}");
                            Console.WriteLine($"Room Type: {roomDetails.RoomType}");
                            Console.WriteLine();
                            foreach (var patient in roomDetails.Patients)
                            {
                                Console.WriteLine($"Patient: {patient.FirstName} {patient.LastName}");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rooms found in the database.");
                    }
                }
            } catch (Exception ex) { Console.WriteLine($"Error occored due to{ex.Message}"); }
            
        }

        public void UpdateRoom()
        {
            try {
                using (var context = new HospitalDBContext())
                {
                    ViewRooms();
                    Console.WriteLine("Enter room Id you wan to update");
                    int rmID = int.Parse(Console.ReadLine());
                    var roomToUpdate = context.Rooms.Find(rmID);

                    Console.WriteLine("Enter Room Numer");
                    string rmNum = Console.ReadLine();
                    Console.WriteLine("Enter Room Type");
                    string rmType = Console.ReadLine();


                    if (roomToUpdate != null)
                    {

                        roomToUpdate.RoomNumber = rmNum;
                        roomToUpdate.RoomType = rmType;


                        context.SaveChanges();
                        Console.WriteLine("room updated successfully");
                    }
                }
            } catch (Exception ex) { Console.WriteLine($"Error occored due to{ex.Message}"); }
            

        } public void DeleteRoom()
        {
            try {
                using (var context = new HospitalDBContext())
                {
                    ViewRooms();
                    Console.WriteLine("Enter room Id you wan to delete");
                    int rmID = int.Parse(Console.ReadLine());
                    var roomToDelete = context.Rooms.Find(rmID);

                    if (roomToDelete != null)
                    {

                        context.Rooms.Remove(roomToDelete);


                        context.SaveChanges();
                        Console.WriteLine("deleted successfully....");
                    }
                    
                }

            } catch (Exception ex) { Console.WriteLine($"Error occored due to{ex.Message}"); }
            

        }
    }
   
}
