export interface Room {
    type: string;
    number: number;
  }

  export interface Hotel {
    id: string;
    name: string;
    location: string;
    rating: number;
    image: string;
    datesOfTravel: string;
    boardBasis: string;
    rooms: Room[];
  }