using HotelAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelAPI.Repositories
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetAllHotels();
        Hotel GetHotelById(int id);
        // AddHotel, UpdateHotel, DeleteHotel... 

        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
    }
} 