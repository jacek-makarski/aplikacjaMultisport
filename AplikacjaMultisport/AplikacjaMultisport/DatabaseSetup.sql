use AppMultisportDB;

CREATE TABLE Departments (
	DepartmentID INT PRIMARY KEY IDENTITY(1,1),
	Ordering INT NOT NULL DEFAULT 0,  --Numer w kolejno�ci nie musi by� tu unikalny (�atwiejsza zmiana, stosunkowo niewielka istotno��)
	Name NVARCHAR(100) UNIQUE NOT NULL,
)

CREATE TABLE Employees (
	EmployeeID INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID) ON DELETE CASCADE NOT NULL
)

CREATE TABLE CardUpdates (
	ValidationDate DATE NOT NULL,
	EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID) ON DELETE CASCADE NOT NULL,
	CardActivation BIT NOT NULL,
	CardType BIT NOT NULL,
	PRIMARY KEY (ValidationDate, EmployeeID)
)

CREATE INDEX EmployeeIndex ON CardUpdates (EmployeeID)

GO

CREATE FUNCTION dbo.CardStatus(@DayStatusFor DATE, @EmployeeWhoseCard INT) RETURNS TABLE AS
RETURN SELECT
	CU.CardActivation,
	CU.CardType
	FROM	
		CardUpdates CU
		JOIN (
			SELECT 
				MAX(ValidationDate) AS RecentValidationDate,
				EmployeeID
				FROM CardUpdates
				WHERE 
					ValidationDate <= @DayStatusFor
					AND EmployeeID = @EmployeeWhoseCard
				GROUP BY EmployeeID
		) Recent
			ON CU.ValidationDate = Recent.RecentValidationDate AND CU.EmployeeID = Recent.EmployeeID
			
GO

CREATE FUNCTION dbo.CardStatusTable(@DayStatusFor DATE) RETURNS TABLE AS
RETURN SELECT
	D.DepartmentID DeptID,
	D.Ordering DeptOrdering,
	D.Name DeptName,
	E.EmployeeID,
	E.FirstName,
	E.LastName,
	CU.CardActivation,
	CU.CardType
	FROM
		CardUpdates CU
		JOIN (
			SELECT 
				MAX(ValidationDate) AS RecentValidationDate,
				EmployeeID
				FROM CardUpdates
				WHERE ValidationDate <= @DayStatusFor
				GROUP BY EmployeeID
		) Recent
			ON CU.ValidationDate = Recent.RecentValidationDate AND CU.EmployeeID = Recent.EmployeeID
		JOIN Employees E
			ON CU.EmployeeID = E.EmployeeID
		JOIN Departments D
			ON E.DepartmentID = D.DepartmentID
GO

CREATE FUNCTION dbo.CardDeactivationsTable(@DeactivationMonth DATE) RETURNS TABLE AS
RETURN SELECT
	E.EmployeeID,
	E.FirstName,
	E.LastName,
	E.DepartmentID
	FROM
		(SELECT
			EmployeeID
			FROM
				CardUpdates CU
				JOIN (  --JOIN zast�puje WHERE
					SELECT DATEADD(DAY, 1, EOMONTH(DATEADD(MONTH, -1, @DeactivationMonth))) FirstDayOfMonth
				) SelectFirstDayOfMonth
					ON CU.ValidationDate = SelectFirstDayOfMonth.FirstDayOfMonth
				WHERE CU.CardActivation = 0  --Tylko dla wierszy z dezaktywacjami kart CU.CardActivation = 0
		) CardDeactivators
		JOIN Employees E
			ON CardDeactivators.EmployeeID = E.EmployeeID
GO

CREATE FUNCTION dbo.EmployeesWhoJoined(@MonthOfJoining DATE) RETURNS TABLE AS
RETURN SELECT
	E.EmployeeID,
	E.FirstName,
	E.LastName,
	E.DepartmentID,
	CU.CardType
	FROM 
		(SELECT
			EmployeeID,
			MIN(ValidationDate) MonthJoined
			FROM CardUpdates
			GROUP BY EmployeeID
		) DatesOfJoining
		JOIN (  --JOIN zast�puje WHERE
			SELECT DATEADD(DAY, 1, EOMONTH(DATEADD(MONTH, -1, @MonthOfJoining))) FirstDayOfMonth
		) SelectFirstDayOfMonth
			ON DatesOfJoining.MonthJoined = SelectFirstDayOfMonth.FirstDayOfMonth
		JOIN CardUpdates CU
			ON DatesOfJoining.MonthJoined = CU.ValidationDate AND DatesOfJoining.EmployeeID = CU.EmployeeID
		JOIN Employees E
			ON DatesOfJoining.EmployeeID = E.EmployeeID;