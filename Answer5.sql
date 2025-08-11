create FUNCTION CountWords(@sentence VARCHAR(MAX))
RETURNS INT
AS
BEGIN
    RETURN LEN(@sentence) - LEN(REPLACE(@sentence, ' ', '')) + 1
END



