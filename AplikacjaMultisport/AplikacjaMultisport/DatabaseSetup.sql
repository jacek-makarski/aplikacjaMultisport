use AppMultisportDB;

CREATE TABLE Departments (
	DepartmentID INT PRIMARY KEY IDENTITY(1,1),
	Ordering INT NOT NULL DEFAULT 0,  --Numer w kolejnoœci nie musi byæ tu unikalny (³atwiejsza zmiana, stosunkowo niewielka istotnoœæ)
	Name NVARCHAR(100) UNIQUE NOT NULL,
	ShortName NVARCHAR(50) UNIQUE
)

CREATE TABLE Employees (
	EmployeeID INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
	Retirement BIT NOT NULL,
	CONSTRAINT CHK_RetirementDepartment CHECK (Retirement = 1 OR DepartmentID IS NOT NULL)  --Informacjê o dziale mo¿na pomin¹æ tylko w przypadku pracowników emerytowanych.
)

CREATE TABLE CardUpdates (
	ValidationDate DATE NOT NULL CHECK (DAY(ValidationDate) = 1),
	EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID) ON DELETE CASCADE NOT NULL,
	CardActivation BIT NOT NULL,
	CardType BIT NOT NULL,
	PRIMARY KEY (ValidationDate, EmployeeID)
)

CREATE TABLE InvoiceTotals (
	InvoiceDate DATE PRIMARY KEY CHECK (DAY(InvoiceDate) = 1),
	Total MONEY NOT NULL
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
	E.Retirement,
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
		LEFT JOIN Departments D  --LEFT JOIN, gdy¿ pracownicy emerytowani mog¹ nie mieæ okreœlonego dzia³u
			ON E.DepartmentID = D.DepartmentID
GO

CREATE FUNCTION dbo.CardDeactivationsTable(@DeactivationMonth DATE) RETURNS TABLE AS
RETURN SELECT
	E.EmployeeID,
	E.FirstName,
	E.LastName,
	E.DepartmentID,
	E.Retirement
	FROM
		(SELECT
			EmployeeID
			FROM
				CardUpdates CU
				JOIN (  --JOIN zastêpuje WHERE
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
	E.Retirement,
	CU.CardType
	FROM 
		(SELECT
			EmployeeID,
			MIN(ValidationDate) MonthJoined
			FROM CardUpdates
			GROUP BY EmployeeID
		) DatesOfJoining
		JOIN (  --JOIN zastêpuje WHERE
			SELECT DATEADD(DAY, 1, EOMONTH(DATEADD(MONTH, -1, @MonthOfJoining))) FirstDayOfMonth
		) SelectFirstDayOfMonth
			ON DatesOfJoining.MonthJoined = SelectFirstDayOfMonth.FirstDayOfMonth
		JOIN CardUpdates CU
			ON DatesOfJoining.MonthJoined = CU.ValidationDate AND DatesOfJoining.EmployeeID = CU.EmployeeID
		JOIN Employees E
			ON DatesOfJoining.EmployeeID = E.EmployeeID;