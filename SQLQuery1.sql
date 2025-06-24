CREATE PROCEDURE Sp_Product_CRUD
    @Action NVARCHAR(10),
    @Id INT = NULL,
    @Name NVARCHAR(100) = NULL,
    @Price DECIMAL(18, 2) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Action = 'CREATE'
    BEGIN
        INSERT INTO Products (Name, Price)
        VALUES (@Name, @Price)
    END

    ELSE IF @Action = 'READ'
    BEGIN
        SELECT * FROM Products
    END

    ELSE IF @Action = 'READBYID'
    BEGIN
        SELECT * FROM Products WHERE Id = @Id
    END

    ELSE IF @Action = 'UPDATE'
    BEGIN
        UPDATE Products
        SET Name = @Name, Price = @Price
        WHERE Id = @Id
    END

    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM Products WHERE Id = @Id
    END
END


SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Products';


CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL
);
