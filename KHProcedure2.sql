use Bookstore;

---------------------------------------------
drop function if exists list_all_transaction;
go
create function list_all_transaction(@cid int, @month int, @year int)
returns @res table(bbid int, quantity int, payment varchar(9), issue varchar(100), price int, purchase_date date)
as
begin
	insert @res
	select distinct bill.bbid, quantity, payment, issue, price, purchase_date
	from (bill inner join pbuy on bill.bbid = pbuy.bbid) inner join customer on pbuy.cid = customer.cid
	where @cid = customer.cid and month(purchase_date) = @month and year(purchase_date) = @year
	and (customer.cid = pbuy.cid and bill.bbid = pbuy.bbid);
	insert @res
	select distinct bill.bbid, quantity, payment, issue, price, purchase_date
	from (bill inner join ebuy on bill.bbid = ebuy.bbid) inner join customer on ebuy.cid = customer.cid
	where @cid = customer.cid and month(purchase_date) = @month and year(purchase_date) = @year
	and (customer.cid = ebuy.cid and bill.bbid = ebuy.bbid);
	return
end
go

select * from list_all_transaction(1, 1, 2000)

-----------------------------------------------
drop function if exists list_error_transaction;
go
create function list_error_transaction(@cid int, @month int, @year int)
returns @res table(bbid int, quantity int, payment varchar(9), issue varchar(100), price int, purchase_date date)
as
begin
	insert @res
	select distinct bill.bbid, quantity, payment, issue, price, purchase_date
	from (bill inner join pbuy on bill.bbid = pbuy.bbid) inner join customer on pbuy.cid = customer.cid
	where @cid = customer.cid and month(purchase_date) = @month and year(purchase_date) = @year
	and (customer.cid = pbuy.cid and bill.bbid = pbuy.bbid) and issue is not null;
	insert @res
	select distinct bill.bbid, quantity, payment, issue, price, purchase_date
	from (bill inner join ebuy on bill.bbid = ebuy.bbid) inner join customer on ebuy.cid = customer.cid
	where @cid = customer.cid and month(purchase_date) = @month and year(purchase_date) = @year
	and (customer.cid = ebuy.cid and bill.bbid = ebuy.bbid) and issue is not null;
	return
end
go

select * from list_error_transaction(1, 1, 2000);

----------------------------------------------------
drop function if exists list_unfinished_transaction;
go
create function list_unfinished_transaction(@cid int, @month int, @year int)
returns @res table(bbid int, quantity int, payment varchar(9), issue varchar(100), price int, purchase_date date)
as
begin
	insert @res
	select distinct bill.bbid, quantity, payment, issue, price, purchase_date
	from (bill inner join pbuy on bill.bbid = pbuy.bbid) inner join customer on pbuy.cid = customer.cid
	where @cid = customer.cid and month(purchase_date) = @month and year(purchase_date) = @year
	and (customer.cid = pbuy.cid and bill.bbid = pbuy.bbid) and issue = 'not finished';
	insert @res
	select distinct bill.bbid, quantity, payment, issue, price, purchase_date
	from (bill inner join ebuy on bill.bbid = ebuy.bbid) inner join customer on ebuy.cid = customer.cid
	where @cid = customer.cid and month(purchase_date) = @month and year(purchase_date) = @year
	and (customer.cid = ebuy.cid and bill.bbid = ebuy.bbid) and issue = 'not finished';
	return
end
go

select * from list_unfinished_transaction(1, 1, 2000);

---------------------------------
drop function if exists author_genre;
go
create function author_genre(@genre varchar(15))
returns table
as
	return 
		select distinct author.aid, pen_name
		from ((author inner join write on author.aid = write.aid) inner join book_isbn on book_isbn.isbn = write.isbn)
		where genre = @genre or @genre = 'null';
go

select * from author_genre('science')

-----------------------------------
drop function if exists author_keyword;
go
create function author_keyword(@keyword varchar(15))
returns table
as
	return
		select distinct author.aid, pen_name
		from ((author inner join write on author.aid = write.aid) inner join book_prop on book_prop.isbn = write.isbn)
		where keyword = @keyword or @keyword = 'null';
go

select * from author_keyword('gravity');

-----------------------------------
drop function if exists get_author;
go
create function get_author(@genre varchar(15), @keyword varchar(15))
returns @res table(aid int, pen_name varchar(20))
as
begin
	insert @res 
	select * from author_keyword(@keyword)
	intersect
	select * from author_genre(@genre)
	return
end
go
select * from get_author('null', 'null');

-------------------------------
drop proc if exists total_book;
go
create proc total_book(@genre varchar(15), @cid int)
as
declare @a int, @b int
set @a = (
	select count(distinct pbook.bid)
	from ((pbuy inner join pbook on pbuy.bid = pbook.bid) inner join book_isbn on book_isbn.isbn = pbook.isbn)
	where pbuy.cid = @cid and @genre = book_isbn.genre
)
set @b = (
	select count(distinct ebook.bid)
	from ((ebuy inner join ebook on ebuy.bid = ebook.bid) inner join book_isbn on book_isbn.isbn = ebook.isbn)
	where ebuy.cid = @cid and @genre = book_isbn.genre
)
set @a = @a + @b;
return @a
go

declare @tmp int;
exec @tmp = total_book @genre = 'science', @cid = 1;
print(@tmp);

---------------------------------
drop function if exists max_bill;
go
create function max_bill(@cid int, @month int, @year int)
returns @res table(bbid int, quantity int, payment varchar(9), issue varchar(100), price int, purchase_date date)
as
begin
	declare @mx1 int, @mx2 int;
	set @mx1 = (
		select max(quantity)
		from bill inner join pbuy on pbuy.bbid = bill.bbid 
		where pbuy.cid = @cid
	)
	set @mx2 = (
		select max(quantity)
		from bill inner join ebuy on ebuy.bbid = bill.bbid 
		where ebuy.cid = @cid
	)
	if @mx1 < @mx2
		set @mx1 = @mx2
	insert @res
	select distinct bill.bbid, quantity, payment, issue, price, purchase_date
	from (bill inner join pbuy on bill.bbid = pbuy.bbid) inner join customer on pbuy.cid = customer.cid
	where @cid = customer.cid and month(purchase_date) = @month and year(purchase_date) = @year
	and (customer.cid = pbuy.cid and bill.bbid = pbuy.bbid) and quantity = @mx1;
	insert @res
	select distinct bill.bbid, quantity, payment, issue, price, purchase_date
	from (bill inner join ebuy on bill.bbid = ebuy.bbid) inner join customer on ebuy.cid = customer.cid
	where @cid = customer.cid and month(purchase_date) = @month and year(purchase_date) = @year
	and (customer.cid = ebuy.cid and bill.bbid = ebuy.bbid) and quantity = @mx1;
	return
end
go

select * from max_bill(1, 1, 2000);

-------------------------------
drop function if exists mixed_bill;
go 
create function mixed_bill(@cid int, @month int, @year int)
returns table
as
	return
		select distinct bill.bbid, quantity, payment, issue, price, purchase_date
		from ((pbuy inner join ebuy on pbuy.bbid = ebuy.bbid) inner join bill on ebuy.bbid = bill.bbid)
		where @month = month(purchase_date) and @year = year(purchase_date) and (@cid = pbuy.cid or @cid = ebuy.cid);
go
select * from mixed_bill(1, 1, 2000);

----------------------------------
drop function if exists book_type; -- 1-> pbook, 2->ebook
go
create function book_type(@isbn char(20)) 
returns int
as
begin
	declare @tmp int;
	set @tmp = (
	select count(book_isbn.isbn) 
	from book_isbn inner join ebook on book_isbn.isbn = ebook.isbn
	where book_isbn.isbn = @isbn); 
	if @tmp = 0
	begin
		return 1 
	end
	else
	begin
		return 2
	end
	return 0
end
go
declare @tmp int;
set @tmp = dbo.book_type('2222');
print(@tmp)

-----------------------------------------
drop function if exists get_book_by_isbn;
go
create function get_book_by_isbn(@isbn char(20))
returns @res table(isbn char(20), bid int, title varchar(20))
as
begin
	declare @typ int;
	set @typ = dbo.book_type(@isbn);
	if @typ = 1
	begin
		insert @res 
		select book_isbn.isbn, pbook.bid, title 
		from pbook inner join book_isbn on book_isbn.isbn = pbook.isbn
		where pbook.isbn = @isbn;
		return
	end
	insert @res 
		select book_isbn.isbn, ebook.bid, title 
		from ebook inner join book_isbn on book_isbn.isbn = ebook.isbn
		where ebook.isbn = @isbn;
	return
end
go
select * from get_book_by_isbn('4444')

use smallDB20161002;