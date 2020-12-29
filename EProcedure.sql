use Bookstore;

drop function if exists ISBN_Bought_Oneday;
go
create function ISBN_Bought_Oneday
(
 @date date
)
returns table
as
return select book_isbn.isbn as ISBN,book_isbn.title as TenSach, pbuy.bid as BookID
       from book_isbn
	   inner join pbook on book_isbn.isbn = pbook.isbn
	   inner join pbuy on pbook.bid = pbuy.bbid
	   inner join bill on pbuy.bbid = bill.bbid
	   where purchase_date = @date
	   union all
	   select book_isbn.isbn as ISBN,book_isbn.title as TenSach, ebuy.bid as BookID
	   from book_isbn
	   inner join ebook on book_isbn.isbn = ebook.isbn
	   inner join ebuy on ebook.bid = ebuy.bbid
	   inner join bill on ebuy.bbid = bill.bbid
	   where purchase_date = @date;
go

drop function if exists Totalof_ISBN_Bought_Oneday
go
create function Totalof_ISBN_Bought_Oneday
(
 @date date
)
returns table
as
return select pbook.isbn as ISBN, count(pbuy.bid) as SoLuong
       from pbook
	   inner join pbuy on pbook.bid = pbuy.bbid
	   inner join bill on pbuy.bbid = bill.bbid
	   where purchase_date = @date
	   group by pbook.isbn	   
	   union all
	   select ebook.isbn as ISBN,count(ebuy.bid) as SoLuong
	   from ebook
	   inner join ebuy on ebook.bid = ebuy.bbid
	   inner join bill on ebuy.bbid = bill.bbid
	   where purchase_date = @date
	   group by ebook.isbn;
go

drop function if exists Totalof_Pbook_ISBN_Bought_Oneday;
go
create function Totalof_Pbook_ISBN_Bought_Oneday
(
 @date date
)
returns table
as
return select pbook.isbn as ISBN, count(pbuy.bid) as SoLuong
       from pbook
	   inner join pbuy on pbook.bid = pbuy.bbid
	   inner join bill on pbuy.bbid = bill.bbid
	   where purchase_date = @date
	   group by pbook.isbn;	   	   
go

drop function if exists Ebook_Bought_Oneday;
go
create function Ebook_Bought_Oneday
(
 @date date
)
returns int
as
begin
    Declare @value int
    select @value = count(ebuy.bid) 
	   from ebook
	   inner join ebuy on ebook.bid = ebuy.bbid
	   inner join bill on ebuy.bbid = bill.bbid
	   where purchase_date = @date;
	return @value;
end;
go

drop function if exists Ebook_Borrowed_Oneday;
go
create function Ebook_Borrowed_Oneday
(
 @date date
)
returns int
as
begin
    Declare @value int
    select @value = count(borrow.bid) 
	   from ebook
	   inner join borrow on ebook.bid = borrow.bid
	   where borrow_date = @date;
	   return @value;
end;
go

drop function if exists Most_Author_Bought_Oneday;
go
create function Most_Author_Bought_Oneday
(
@date date
)
returns table
as
return
      Select author.pen_name as TenTacGia, count(pbuy.bid) as SoLuongSachTruyenThongBan
	  from author
	  inner join write on author.aid = write.aid
	  inner join book_isbn on book_isbn.isbn = write.isbn
	  inner join pbook on pbook.isbn = book_isbn.isbn
	  inner join pbuy on pbuy.bid = pbook.bid
	  inner join bill on bill.bbid = pbuy.bbid
	  where purchase_date = @date 
	  group by author.aid, author.pen_name
	  having count(pbuy.bid) in (
														select top 1 count(pbuy.bid) 
												  	    from author
														inner join write on author.aid = write.aid
														inner join book_isbn on book_isbn.isbn = write.isbn
													    inner join pbook on pbook.isbn = book_isbn.isbn
														inner join pbuy on pbuy.bid = pbook.bid
														inner join bill on bill.bbid = pbuy.bbid
														where purchase_date = @date
														group by author.aid, author.pen_name
														order by count(pbuy.bid) desc
			   					  )
	 union
	 Select author.pen_name as TenTacGia, count(ebuy.bid) as SoLuongSachDienTuBan
	  from author
	  inner join write on author.aid = write.aid
	  inner join book_isbn on book_isbn.isbn = write.isbn
	  inner join ebook on ebook.isbn = book_isbn.isbn
	  inner join ebuy on ebuy.bid = ebook.bid
	  inner join bill on bill.bbid = ebuy.bbid
	  where purchase_date = @date 
	  group by author.aid, author.pen_name
	  having count(ebuy.bid) in (
														select top 1 count(ebuy.bid) 
												  	    from author
														inner join write on author.aid = write.aid
														inner join book_isbn on book_isbn.isbn = write.isbn
													    inner join ebook on ebook.isbn = book_isbn.isbn
														inner join ebuy on ebuy.bid = ebook.bid
														inner join bill on bill.bbid = ebuy.bbid
														where purchase_date = @date
														group by author.aid, author.pen_name
														order by count(ebuy.bid) desc
			   					  )
	  
	  
go

drop function if exists Most_Author_Bought_Onemonth;
go
create function Most_Author_Bought_Onemonth
(
@month int
)
returns table
as
return
      Select author.pen_name as TenTacGia, count(pbuy.bid) as SoLuongSachTruyenThongBan
	  from author
	  inner join write on author.aid = write.aid
	  inner join book_isbn on book_isbn.isbn = write.isbn
	  inner join pbook on pbook.isbn = book_isbn.isbn
	  inner join pbuy on pbuy.bid = pbook.bid
	  inner join bill on bill.bbid = pbuy.bbid
	  where month(purchase_date) = @month 
	  group by author.aid, author.pen_name
	  having count(pbuy.bid) in (
														select top 1 count(pbuy.bid) 
												  	    from author
														inner join write on author.aid = write.aid
														inner join book_isbn on book_isbn.isbn = write.isbn
													    inner join pbook on pbook.isbn = book_isbn.isbn
														inner join pbuy on pbuy.bid = pbook.bid
														inner join bill on bill.bbid = pbuy.bbid
														where month(purchase_date) = @month 
														group by author.aid, author.pen_name
														order by count(pbuy.bid) desc
			   					  )
	 union
	 Select author.pen_name as TenTacGia, count(ebuy.bid) as SoLuongSachDienTuBan
	  from author
	  inner join write on author.aid = write.aid
	  inner join book_isbn on book_isbn.isbn = write.isbn
	  inner join ebook on ebook.isbn = book_isbn.isbn
	  inner join ebuy on ebuy.bid = ebook.bid
	  inner join bill on bill.bbid = ebuy.bbid
	  where month(purchase_date) = @month  
	  group by author.aid, author.pen_name
	  having count(ebuy.bid) in (
														select top 1 count(ebuy.bid) 
												  	    from author
														inner join write on author.aid = write.aid
														inner join book_isbn on book_isbn.isbn = write.isbn
													    inner join ebook on ebook.isbn = book_isbn.isbn
														inner join ebuy on ebuy.bid = ebook.bid
														inner join bill on bill.bbid = ebuy.bbid
														where month(purchase_date) = @month 
														group by author.aid, author.pen_name
														order by count(ebuy.bid) desc
			   					  )
	  
	  
go

drop function if exists Most_Book_Bought_Onemonth;
go
create function Most_Book_Bought_Onemonth
(
@month int
)
returns table
as
return select book_isbn.title as TenSach, count(pbuy.bid) as SoLuong
       from pbook
	   inner join pbuy on pbook.bid = pbuy.bbid
	   inner join bill on pbuy.bbid = bill.bbid
	   inner join book_isbn on book_isbn.isbn = pbook.isbn
	   where month(purchase_date) = @month
	   group by book_isbn.title   
	   union all
	   select book_isbn.title as TenSach,count(ebuy.bid) as SoLuong
	   from ebook
	   inner join ebuy on ebook.bid = ebuy.bbid
	   inner join bill on ebuy.bbid = bill.bbid
	   inner join book_isbn on book_isbn.isbn = ebook.isbn
	   where month(purchase_date) = @month
	   group by book_isbn.title;
go

drop function if exists Credit_Bought_Oneday;
go
create function Credit_Bought_Oneday
(
 @date date
)
returns table
as
return select pbuy.bid as BookID,pbuy.cid as KhachHangID
       from pbook
	   inner join pbuy on pbook.bid = pbuy.bbid
	   inner join bill on pbuy.bbid = bill.bbid
	   inner join customer on customer.cid = pbuy.cid
	   inner join belong_to on belong_to.cid = customer.cid
	   where purchase_date = @date
	   union all
	   select ebook.bid as BookID,ebuy.cid as KhachHangID
	   from ebook
	   inner join ebuy on ebook.bid = ebuy.bbid
	   inner join bill on ebuy.bbid = bill.bbid
	   inner join customer on customer.cid = ebuy.cid
	   inner join belong_to on belong_to.cid = customer.cid
	   where purchase_date = @date;
go

drop function if exists Issue_Bought_Oneday;
go
create function Issue_Bought_Oneday
(
 @date date
)
returns table
as
 return select bbid as BillID, issue as Issue
		from bill
		where issue is not null;
 go

--drop function if exists ISBN_Under10_Oneday;
--go
--create function ISBN_Under10_Oneday;

--drop function if exists Totalof_Pbook_ISBN_Bought_Oneday_Eachstore;
--go
--create function Totalof_Pbook_ISBN_Bought_Oneday_Eachstore


drop function if exists Most_Store;
go
create function Most_Store_OneMonth
(
@month int
)
returns table
as
return select top 1 bookstore.sname as TenCuaHang, count(pbuy.bid) as SoLuongSachBan
       from pbook
	   inner join pbuy on pbook.bid = pbuy.bbid
	   inner join bill on pbuy.bbid = bill.bbid
	   inner join book_isbn on book_isbn.isbn = pbook.isbn
	   inner join stored_at on stored_at.bid = pbook.bid
	   inner join bookstore on bookstore.sid = stored_at.sid
	   where month(purchase_date) = @month
	   group by bookstore.sid,bookstore.sname
	   order by count(pbuy.bid);
go
