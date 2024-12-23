import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchHotelById } from '../services/hotelServices';
import { Hotel } from '../types/Hotel';

const HotelDetail: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const [hotel, setHotel] = useState<Hotel | null>(null);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    const loadHotel = async () => {
      if (!id) {
        console.error('Hotel ID is undefined');
        setLoading(false);
        return;
      }

      try {
        const data = await fetchHotelById(id);
        setHotel(data);
      } catch (error) {
        console.error('Error fetching hotel:', error);
      } finally {
        setLoading(false);
      }
    };

    loadHotel();
  }, [id]);

  if (loading) return <div>Loading...</div>;
  if (!hotel) return <div>Hotel Not Found</div>;

  return (
    <div>
      <img src={hotel.image} alt={hotel.name} />
      <h1>{hotel.name}</h1>
      <p>{hotel.location}</p>
      <p>Rating: {hotel.rating}</p>
      <p>Dates of Travel: {hotel.datesOfTravel}</p>
      <p>Board Basis: {hotel.boardBasis}</p>
      <div>
        <h3>Rooms</h3>
        {hotel.rooms.map((room, index) => (
          <div key={index}>
            <p>Type: {room.type}</p>
            <p>Number: {room.number}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default HotelDetail;