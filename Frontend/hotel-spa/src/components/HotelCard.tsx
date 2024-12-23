import React from 'react';
import { Link } from 'react-router-dom';
import { Hotel } from '../types/Hotel';

interface HotelCardProps {
  hotel: Hotel;
}

const HotelCard: React.FC<HotelCardProps> = ({ hotel }) => (
  <div className="bg-white shadow-md rounded-lg overflow-hidden mb-4">
    <img src={hotel.image} alt={hotel.name} className="w-full h-48 object-cover" />
    <div className="p-4">
      <h2 className="text-xl font-bold mb-2">{hotel.name}</h2>
      <p className="text-gray-600">{hotel.location}</p>
      <p className="text-gray-600">Rating: {hotel.rating}</p>
      <p className="text-gray-600">Dates of Travel: {hotel.datesOfTravel}</p>
      <p className="text-gray-600">Board Basis: {hotel.boardBasis}</p>
      <Link to={`/hotels/${hotel.id}`} className="text-blue-500 hover:underline mt-2 inline-block">
        View Details
      </Link>
    </div>
  </div>
);

export default HotelCard;