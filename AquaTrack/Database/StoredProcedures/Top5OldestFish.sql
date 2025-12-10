CREATE OR ALTER PROCEDURE dbo.Top5OldestFish
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 5
        Id,
        Name,
        Species,
        Age,
        TankId
    FROM Fish
    ORDER BY Age DESC;
END
