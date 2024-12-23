# Simple Hotel Single Page Application (SPA) and Web API
- Frontend - React, Typescript
- Backend API - C#, .NET Core 
## Running the frontend
```
cd /Frontend/hotel-spa
npm install # install dependencies - some may be out of date, (sorry, my Angular setup is much better...)
npm start # start the server
```
The server should be running at: http://localhost:3000/hotels

## Running the backend
```
cd HotelAPI
dotnet restore # to retrieve all the packages in projectreference
dotnet run
```
The backend API should be running at http://localhost:5170/api/hotels
