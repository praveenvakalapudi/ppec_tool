CREATE TABLE Sample (
    Id int NOT NULL IDENTITY(1,1),
    Name varchar(255) NOT NULL,
    Email varchar(255) NOT NULL,
    Mobile varchar(255) NOT NULL,
    PRIMARY KEY (Id)
);
drop table sample
Select * from sample
delete from sample
select * from sample

INSERT INTO Sample(Name, Email, Mobile) values('Praveen', 'praveen@praveen.com','1234567890')