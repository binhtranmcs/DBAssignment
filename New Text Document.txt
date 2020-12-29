use Bookstore;

-----------------------------------------
drop proc if exists list_all_transaction;
go
create proc list_all_transaction(@cid int, @month int, @year int)
as
select *
from bill
where @cid = cid and month(purchase_date) = @month and year(purchase_date) = @year;
go

-------------------------------------------
drop proc if exists list_error_transaction;
go
create proc list_error_transaction(@cid int, @month int, @year int)
as
select *
from bill
where @cid = cid and month(purchase_date) = @month and year(purchase_date) = @year and issue is not null;
go

------------------------------------------------
drop proc if exists list_unfinished_transaction;
go
create proc list_unfinished_transaction(@cid int, @month int, @year int)
as
select *
from bill
where @cid = cid and month(purchase_date) = @month and year(purchase_date) = @year and issue = 'not finished';
go

---------------------------------
drop proc if exists author_genre;
go
create proc author_genre(@genre varchar(15))
as
select distinct author.aid, pen_name
from ((author inner join write on author.aid = write.aid) inner join book_isbn on book_isbn.isbn = write.isbn)
where genre = @genre;
go

exec author_genre @genre = 'science'

-----------------------------------
drop proc if exists author_keyword;
go
create proc author_keyword(@keyword varchar(15))
as
select distinct author.aid, pen_name
from ((author inner join write on author.aid = write.aid) inner join book_prop on book_prop.isbn = write.isbn)
where keyword = @keyword;
go

exec author_keyword @keyword = 'gravity'

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

-----------------------------
drop proc if exists max_bill;
go
create proc max_bill(@cid int, @month int, @year int)
as
declare @mx int;
set @mx = (
select max(quantity)
from bill
where cid = @cid
)
select *
from bill
where @cid = cid and month(purchase_date) = @month and year(purchase_date) = @year and quantity = @mx;
go

exec max_bill @cid = 1, @month = 1, @year = 2000;

use smallDB20161002;