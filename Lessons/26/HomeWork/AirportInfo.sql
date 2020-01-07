--CREATE DATABASE AirportInfo; 

CREATE TABLE DepartureBoard(
    FlightNumber VARCHAR(7),
    DepartureCity VARCHAR(15),
    DepartureCountry VARCHAR(15),
    ArrivalCity VARCHAR(15),
    ArrivalCountry VARCHAR(15),
    DepartureDateTime DATETIMEOFFSET(7),
    ArrivalDateTime DATETIMEOFFSET(7),
    TravelTime VARCHAR(5),
    Airline VARCHAR(15),
    AirplaneModel VARCHAR(15)
);

INSERT INTO DepartureBoard VALUES  ('EN-231', 'LONDON', 'ENGLAND', 'MOSCOW', 'RUSSIA', '2007-05-08 12:35:29 +12:15', '2007-05-08 12:35:29 +12:15', '3:30', 'Airlines', 'BOING'),
        ('EN-2312', 'LONDON', 'ENGLAND', 'MOSCOW', 'RUSSIA', '2007-05-08 12:35:29 +12:15', '2007-05-08 12:35:29 +12:15', '3:30', 'Airlines', 'BOING');

SELECT * FROM DepartureBoard;

DROP TABLE DepartureBoard;

--DROP DATABASE AirportInfo;