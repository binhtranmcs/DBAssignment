use Bookstore;
----------------

----------------------------------------
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

----------------------------------------
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

----------------------------------------
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
		where genre = @genre or @genre = 'null';
go

select * from list_book_genre('action')

-----------------------------------------
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
		where author.aname = @aname or @aname = 'null';
go

select * from list_book_author('a')

------------------------------------------
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
		where book_prop.keyword = @keyword or @keyword = 'null';
go

select * from list_book_keyword('Einstein')

-------------------------------------------------
drop function if exists list_book_date_published;
go
create function list_book_date_published
(
	@date_published date
)
returns table
as
	return 
		select book_isbn.isbn, book_isbn.genre, book_isbn.title, book_isbn.price
		from (author inner join write on author.aid = write.aid) inner join book_isbn on book_isbn.isbn = write.isbn
		where write.date_published = @date_published or @date_published is null
go

declare @date_now date;
set @date_now = getdate();
select * from list_book_date_published(@date_now);


---------------------------------------
drop function if exists list_buy_month;
go
create function list_buy_month
(
	@cid int, 
	@date_now date
)
returns @res table(isbn char(20), genre varchar(15), title varchar(20), price int)
as
begin
	insert @res
	select book_isbn.isbn, book_isbn.genre, book_isbn.title, book_isbn.price
	from ebuy
		inner join bill on ebuy.bbid = bill.bbid 
		inner join ebook on ebook.bid = ebuy.bid
		inner join book_isbn on ebook.isbn = book_isbn.isbn
	where ebuy.cid = @cid and (DATEDIFF(MONTH, bill.purchase_date, @date_now) <= 1);
	insert @res
	select book_isbn.isbn, book_isbn.genre, book_isbn.title, book_isbn.price
	from pbuy
		inner join bill on pbuy.bbid = bill.bbid 
		inner join pbook on pbook.bid = pbuy.bid
		inner join book_isbn on pbook.isbn = book_isbn.isbn
	where pbuy.cid = @cid and (DATEDIFF(MONTH, bill.purchase_date, @date_now) <= 1);
	return
end
go

declare @date_now date;
set @date_now = getdate();
select * from list_buy_month(8, @date_now);

print DATEDIFF(MONTH, cast('1/12/2000' as datetime), @date_now)

---------------------------------
drop function if exists get_book;
go
create function get_book(
	@genre varchar(20), 
	@aname varchar(20),
	@keyword varchar(20),
	@date_published date
	--@date_now date
)
returns @res table(isbn char(20), genre varchar(15), title varchar(20), price int)
as
begin
	insert @res 
	select *
	from list_book_author(@aname)
	intersect 
	select *
	from list_book_genre(@genre)
	intersect 
	select *
	from list_book_keyword(@keyword)
	intersect 
	select *
	from list_book_date_published(@date_published)
	return
end
go
select * from get_book('science', 'a', 'null', null);


