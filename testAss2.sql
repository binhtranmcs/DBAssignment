use Bookstore;

--INSERT INTO account (username, password, type_account, accid)
--VALUES ('admin', 'admin', 'Admin', 0)

--INSERT INTO customer (caddress, cname, cemail)
--VALUES ('123', 'Thanh', 'a@gmail.com')

DROP FUNCTION IF EXISTS getMAX_IDCustomer
GO
CREATE FUNCTION getMAX_IDCustomer
(

)
RETURNS int
AS
BEGIN
	DECLARE @ans int;
	SELECT @ans = MAX(cid) FROM customer
	RETURN @ans
END;
GO

--INSERT INTO employee VALUES('bienhoa', 'thong', 'thong@gmail.com')
declare @retval int;
exec @retval = getMAX_IDCustomer;
insert INTO account (username, password, type_account, accid)
SELECT 'employyee1', '1234', 'Employee', (@retval) + 1