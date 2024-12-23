   // src/pages/HotelsListPage.tsx
   import React from 'react';
   import HotelList from '../components/HotelList';

   const HotelsListPage: React.FC = () => {
      return (
        <div>
          <h1>List of Hotels from the API</h1>
          <HotelList />
        </div>
      );
    };

   export default HotelsListPage;