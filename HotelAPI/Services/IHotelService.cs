using HotelAPI.Models;
using System.Collections.Generic;
public interface IHotelService
{
    Task<IEnumerable<Hotel>> GetAllHotelsAsync();
    IEnumerable<Hotel> GetAllHotels();
    Hotel GetHotelById(int id);
} 