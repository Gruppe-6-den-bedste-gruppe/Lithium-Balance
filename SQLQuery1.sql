/*
create table Customer (
customerID int Identity(1,1) not null primary key ,
companyName NVarchar(255),
email NVarchar(255),
address NVarchar(255))
create table responsible (
responsibleID int Identity(1,1) not null primary key ,
name NVarchar(255))
create table software(
softwareID int Identity(1,1) not null primary key ,
softwareType NVarchar(255),
softwareVersion NVarchar(255))
create table bms(
bmsID int Identity(1,1) not null primary key ,
bmsType NVarchar(255),
bmsVersion NVarchar(255))

create table orders (
orderID int Identity(1,1) not null primary key ,
orderNumber NVarchar(255),
date NVarchar(255),
licenseduration NVarchar(255),
customerID int foreign key references Customer(customerID),
responsibleID int foreign key references responsible(responsibleID),
softwareID int foreign key references software(softwareID),
bmsID int foreign key references bms(bmsID))
*/
select * from orders 
join customer on customer.customerID = orders.customerID
join bms on bms.bmsID = orders.bmsID
join software on software.softwareID = orders.softwareID

