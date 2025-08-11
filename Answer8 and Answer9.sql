CREATE TABLE Employees (employee_id INT PRIMARY KEY,name VARCHAR(50),exp INT, salary INT, departmentName VARCHAR(50))
GO
GO
CREATE PROCEDURE AddOrUpdateEmployee
    @employee_id INT,
    @name VARCHAR(50),
    @exp INT,
    @salary INT,
    @departmentName VARCHAR(50)
 
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Employees WHERE employee_id = @employee_id)
    BEGIN
        UPDATE Employees
        SET name=@name,exp= @exp, salary = @salary, departmentName = @departmentName
        WHERE employee_id = @employee_id;
        PRINT 'RECORD UPDATED.'
        RETURN
    END
    ELSE
    BEGIN
        INSERT INTO Employee  VALUES (@name, @exp, @salary, @departmentName);
        PRINT 'RECORD ADDED'
    END
END
--ANSWER 9
GO
CREATE PROCEDURE DeleteEmployee
    @employee_id INT
AS
BEGIN
    
    DELETE FROM Employees WHERE employee_id = @employee_id
    PRINT 'Record Deleted.'
END

      

