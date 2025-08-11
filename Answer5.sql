create FUNCTION CountWords(@sentence VARCHAR(MAX))
RETURNS INT
AS 
BEGIN 
     DECLARE @count INT;
     SELECT @count= LEN(LTRIM(RTRIM(@sentence)))- LEN(REPLACE(LTRIM(RTRIM(@sentence)), '' , ''))+1;
     RETURN @count;
END

