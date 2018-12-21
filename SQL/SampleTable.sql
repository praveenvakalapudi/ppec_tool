CREATE TABLE Sample (
    Id int NOT NULL IDENTITY(1,1),
    Name varchar(255) NOT NULL,
    IsActive bit,
    PRIMARY KEY (Id)
);

Select * from sample

select * from sample

INSERT INTO Sample(Name, IsActive) values('Kumar', 1)