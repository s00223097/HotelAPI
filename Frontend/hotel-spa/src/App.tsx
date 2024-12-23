// Imports
import React from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import HotelsListPage from './pages/HotelsListPage';
import HotelDetailPage from './pages/HotelDetailPage';

// Main App component that handles routing
const App: React.FC = () => (
  <Router>
    <Routes>
      {/* Route to display list of all hotels */}
      <Route path="/hotels" element={<HotelsListPage />} />
      {/* Route to display details of a specific hotel using ID parameter */}
      <Route path="/hotels/:id" element={<HotelDetailPage />} />
      {/* Redirect all unknown routes to hotels list page */}
      <Route path="*" element={<Navigate to="/hotels" />} />
    </Routes>
  </Router>
);

export default App;