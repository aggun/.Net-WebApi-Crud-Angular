CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DepartmentCode INT NOT NULL,
    DepartmentName VARCHAR(255) NOT NULL
);

INSERT INTO Departments (DepartmentCode, DepartmentName) VALUES
    (1, 'Information Technology'),
    (2, 'Human Resources'),
    (3, 'Finance'),
    (4, 'Marketing');
	
		CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY(1,1),
    RegistrationNumber VARCHAR(50) NOT NULL,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    HireDate DATE NOT NULL,
    TerminationDate DATE,
    MainAddress VARCHAR(255),
    Gender VARCHAR(10),
    MobilePhone VARCHAR(20),
    HomePhone VARCHAR(20),
    DepartmentCode INT NOT NULL,
);,



INSERT INTO Employees (RegistrationNumber, FirstName, LastName, HireDate, TerminationDate, MainAddress, Gender, MobilePhone, HomePhone, DepartmentCode) VALUES
    (111, 'John', 'Doe', '2022-01-01', NULL, '123 Main St', 'Male', '555-1234', '555-5678', 1),
    (122, 'Jane', 'Smith', '2022-02-01', NULL, '456 Oak St', 'Female', '555-4321', '555-8765', 1),
    (2333, 'Bob', 'Johnson', '2022-03-01', NULL, '789 Pine St', 'Male', '555-9876', '555-1234', 2),
    (311, 'Alice', 'Williams', '2022-04-01', NULL, '321 Elm St', 'Female', '555-8765', '555-4321', 3);