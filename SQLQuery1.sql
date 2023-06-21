
drop table Restaurants;
drop table FoodItems;


select * from Restaurants;
select * from FoodItems;


create table Restaurants(RName varchar(50),City varchar(50),Branch varchar(50),
                                  RType varchar(50) check( RType='Veg'
                                  or RType='Veg&Nonveg'),
                                  primary key(RName,City,Branch));
create table FoodItems(id int identity(1,1) primary key,Rname varchar(50), City varchar(50), 
                                     Branch varchar(50),Fooditem varchar(50), Price int, 
                                     Img Image, foreign key(Rname, City, Branch) 
                                     references Restaurants(Rname, City, Branch) ); 


insert into Restaurants values('Mehfil','Hyderabad','Kukatpally','Veg&Nonveg');
insert into Restaurants values('Bawarchi','Banglore','CubbonPark','Veg&Nonveg');
insert into Restaurants values('Mehfil','Banglore','LumbiniGardens','Veg&Nonveg');



