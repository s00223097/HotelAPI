using HotelAPI.Models;
using System.Collections.Generic;
namespace HotelAPI.Services
{
    public interface IHotelService
    {
        // Async method to get all hotels
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
        // Non-async method to get all hotels 
        IEnumerable<Hotel> GetAllHotels();
        // Method to get a hotel by its id
        Hotel GetHotelById(int id);
    } 
}