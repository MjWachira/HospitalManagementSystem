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
            using (var context = new HospitalDBContext())
            {

                var newRoom = new Room
                {
                    RoomNumber = "101",
                    RoomType = "Standard"
                };


                context.Rooms.Add(newRoom);

                
                context.SaveChanges();
                Console.WriteLine("Room added successfully");
            }

        }
        public void ViewRooms()
        {
            using (var context = new HospitalDBContext())
            {
                
                var roomDetails = context.Rooms
                    .Include(r => r.Patients)
                    .FirstOrDefault();

                if (roomDetails != null)
                {
                    Console.WriteLine($"Room ID: {roomDetails.RoomID}");
                    Console.WriteLine($"Room Number: {roomDetails.RoomNumber}");
                    Console.WriteLine($"Room Type: {roomDetails.RoomType}");

                    foreach (var patient in roomDetails.Patients)
                    {
                        Console.WriteLine($"Patient: {patient.FirstName} {patient.LastName}");
                    }
                }
            }

        }
        public void UpdateRoom()
        {
            using (var context = new HospitalDBContext())
            {
               
                var roomToUpdate = context.Rooms.Find(1);

                if (roomToUpdate != null)
                {
                   
                    roomToUpdate.RoomNumber = "102";
                    roomToUpdate.RoomType = "ICU";

                   
                    context.SaveChanges();
                    Console.WriteLine("room updated successfully");
                }
            }

        } public void DeleteRoom()
        {
            using (var context = new HospitalDBContext())
            {
               
                var roomToDelete = context.Rooms.Find(2);

                if (roomToDelete != null)
                {
                   
                    context.Rooms.Remove(roomToDelete);

                   
                    context.SaveChanges();
                    Console.WriteLine("deleted successfully....");
                }
            }

        }
    }
   
}
