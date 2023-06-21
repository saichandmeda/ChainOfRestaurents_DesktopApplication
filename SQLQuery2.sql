



drop table Restaurants;
drop table FoodItems;
drop table Users;


select * from Restaurants;
select * from FoodItems;
select * from Users;


create table Restaurants(RName varchar(50),City varchar(50),Branch varchar(50),
                                  RType varchar(50) check( RType='Veg'
                                  or RType='Veg&Nonveg'),
                                  primary key(RName,City,Branch));
alter table Restaurants ADD Picture Image;
create table FoodItems(id int identity(1,1) primary key,Rname varchar(50), City varchar(50), 
                                     Branch varchar(50),Fooditem varchar(50), Price int, 
                                     Img Image, foreign key(Rname, City, Branch) 
                                     references Restaurants(Rname, City, Branch) ); 


insert into Restaurants values('Mehfil','Hyderabad','Kukatpally','Veg&Nonveg');
insert into Restaurants values('Bawarchi','Banglore','CubbonPark','Veg&Nonveg');
insert into Restaurants values('Mehfil','Banglore','LumbiniGardens','Veg&Nonveg');


create table Users(Id varchar(50) primary key, Pass varchar(50));

create table Cart(id int identity(1,1) primary key,FoodItem varchar(50),Price int);
alter table cart add Restaurant varchar(50);
alter table cart add Branch varchar(50);
select * from cart;


create table History(id int identity(1,1) primary key,UserId varchar(50),Restaurant varchar(50),
                                         Branch varchar(50),FoodItem varchar(50),Price int);
alter table History add DaTi DateTime;
select * from History;