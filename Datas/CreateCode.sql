create database Netflix
use Netflix
CREATE TABLE Clients (
  client_id float PRIMARY KEY,
  first_name nvarchar(255),
  last_name nvarchar(255),
  address nvarchar(255),
  signup_date datetime
);

CREATE TABLE ClientContact1 (
  client_id float,
  email nvarchar(255),
  FOREIGN KEY (client_id) REFERENCES Clients(client_id)
);
CREATE TABLE ClientContact2 (
  client_id float,
  phone_number nvarchar(255),
  FOREIGN KEY (client_id) REFERENCES Clients(client_id)
);

CREATE TABLE Pricing (
  subscription_type nvarchar(255) PRIMARY KEY,
  price float
);
CREATE TABLE Payment (
  payment_id float PRIMARY KEY,
  client_id float,
  payment_method nvarchar(255),
  payment_date datetime,
  amount_due float,
  FOREIGN KEY (client_id) REFERENCES Clients(client_id)
);

CREATE TABLE Login (
  Username nvarchar(255) PRIMARY KEY,
  password nvarchar(255),
  client_id float,
  FOREIGN KEY (client_id) REFERENCES Clients(client_id)
);
CREATE TABLE Movies (
  movie_id float PRIMARY KEY,
  movie_title nvarchar(255),
  release_date nvarchar(255),
  rating float
);
CREATE TABLE Genre (
  genre_id float PRIMARY KEY,
  movie_id float,
  genre_description nvarchar(255),
  FOREIGN KEY (movie_id) REFERENCES Movies(movie_id)
);
CREATE TABLE Watches (
  client_id float,
  movie_id float,
  watch_date datetime,
  FOREIGN KEY (client_id) REFERENCES Clients(client_id),
  FOREIGN KEY (movie_id) REFERENCES Movies(movie_id)
);CREATE TABLE Subscription (
  subscription_id float PRIMARY KEY,
  subscription_type nvarchar(255) ,
  client_id float,
  subscription_date datetime,
  FOREIGN KEY (client_id) REFERENCES Clients(client_id),
  FOREIGN KEY (subscription_type) REFERENCES Pricing(subscription_type)
);


