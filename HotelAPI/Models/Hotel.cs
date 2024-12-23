namespace HotelAPI.Models
{
    /// <summary>
    /// Represents the properties of a Room in a hotel. Many-to-one rel with Hotel.
    /// </summary>
    public class Room
    {
        public string? RoomType { get; set; }
        public int Amount { get; set; }
    }

    /// <summary>
    /// Represents all the properties of a Hotel. 
    /// </summary>
    public class Hotel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public double Rating { get; set; }
        public string? ImageUrl { get; set; }
        public List<string> DatesOfTravel { get; set; } = new List<string>();
        public string? BoardBasis { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
