import axios from 'axios';
import { Hotel } from '../types/Hotel';

// Base API endpoint for hotel operations
const API_URL = 'http://localhost:5170/api/hotels';

// Fetch all hotels from the API
export const fetchHotels = async (): Promise<Hotel[]> => {
  const response = await axios.get<Hotel[]>(API_URL);
  return response.data;
};

// Fetch a specific hotel by its ID
export const fetchHotelById = async (id: string): Promise<Hotel> => {
  const response = await axios.get<Hotel>(`${API_URL}/${id}`);
  return response.data;
};