use Bookstore;
----------------

drop proc if exists updateInfo_Customer;
go
create proc updateInfo_Customer
(
	@cid int,
	@caddress varchar(30), 
	@cname varchar(30), 
	@cemail varchar(20)
)
as
begin
	update customer
	SET
		caddress = @caddress,
		cname = @cname,
		cemail = @cemail
	WHERE cid = @cid;
end;
go

exec updateInfo_Customer @cid = 1, @caddress = 'abcxyz', @cname = 'thanh', @cemail = 'thanh@gmail.com';

drop proc if exists updateBill_Customer;
go
create proc updateBill_Customer
(
	@bbid int,
	@quantity int,
	@payment varchar(9),
	@issue varchar(100),
	@price int,
	@purchase_date date
)
as
begin
	print 'bbid ' + CONVERT(varchar(10), @bbid)
	print @purchase_date
	update bill
	SET
		quantity = @quantity,
		payment = @payment,
		issue = @issue,
		price = @price,
		purchase_date = @purchase_date
	WHERE bbid = @bbid;
end;
go

declare @date_now date;
set @date_now = getdate();
print @date_now
exec updateBill_Customer @bbid = 1, @quantity = 10, @payment = 'bank',  @issue = 'failed', @price = 50, @purchase_date = @date_now;

drop function if exists list_book_genre;
go
create function list_book_genre
(
	@genre varchar(15)
)
returns table
as
	return 
		select * 
		from book_isbn 
		where genre = @genre;
go

select * from list_book_genre('action')

drop function if exists list_book_author;
go
create function list_book_author
(
	@aname varchar(30)
)
returns table
as
	return 
		select book_isbn.isbn, book_isbn.genre, book_isbn.title, book_isbn.price
		from (author inner join write on author.aid = write.aid) inner join book_isbn on book_isbn.isbn = write.isbn
		where author.aname = @aname
go

select * from list_book_author('a')

drop function if exists list_book_keyword;
go
create function list_book_keyword
(
	@keyword varchar(15)
)
returns table
as
	return 
		select book_isbn.isbn, book_isbn.genre, book_isbn.title, book_isbn.price
		from book_prop inner join book_isbn on book_isbn.isbn = book_prop.isbn
		where book_prop.keyword = @keyword
go

select * from list_book_keyword('Einstein')

drop function if exists list_book_date_publish;
go
create function list_book_date_publish
(
	@date_publish date
)
returns table
as
	return 
		select book_isbn.isbn, book_isbn.genre, book_isbn.title, book_isbn.price
		from (author inner join write on author.aid = write.aid) inner join book_isbn on book_isbn.isbn = write.isbn
		where write.date_publish = @date_publish
go

declare @date_now date;
set @date_now = getdate();
select * from list_book_date_publish(@date_now);

drop function if exists list_buy_month;
go
create function list_buy_month
(
	@cid int, 
	@date_now date
)
returns table
as
	return 
		select book_isbn.isbn, book_isbn.genre, book_isbn.title, book_isbn.price
		from ebuy
			inner join bill on ebuy.bbid = bill.bbid 
			inner join ebook on ebook.bid = ebuy.bid
			inner join book_isbn on ebook.isbn = book_isbn.isbn
		where ebuy.cid = @cid and (DATEDIFF(MONTH, bill.purchase_date, @date_now) <= 1);
go

declare @date_now date;
set @date_now = getdate();
select * from list_buy_month(1, @date_now);

print DATEDIFF(MONTH, cast('1/12/2000' as datetime), @date_now)
