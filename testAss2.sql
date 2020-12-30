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

DROP FUNCTION IF EXISTS getMAX_IDEmployee
GO
CREATE FUNCTION getMAX_IDEmployee
(

)
RETURNS int
AS
BEGIN
	DECLARE @ans int;
	SELECT @ans = MAX(eid) FROM employee
	RETURN @ans
END;
GO

--INSERT INTO employee VALUES('bienhoa', 'thong', 'thong@gmail.com')
insert into employee(eaddress, ename, eemail)
VALUES('abc123', 'thanh', 'thanh@gmail.com')
declare @retval int;
exec @retval = getMAX_IDEmployee;
insert INTO account (username, password, type_account, accid)
SELECT 'e2', '1234', 'Employee', MAX(eid) from employee
--insert into account ('employee2', '1234', 'Employee', accid in Select cid from customer order by cid desc limit 1)
