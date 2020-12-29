use Bookstore;
--------------

drop proc if exists update_book;
go
create proc bought_isbn
	@date date,
	@cid int
as
begin
	select isbn, title 
	from book_isbn inner join pbuy 
end



--------------------
use smallDB20161002;