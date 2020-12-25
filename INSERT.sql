
use Bookstore;

insert into customer(caddress, cname, cemail) 
values ('HCM', 'A', 'A@email.com');
insert into customer(caddress, cname, cemail) 
values ('HCM', 'B', 'B@email.com');
insert into customer(caddress, cname, cemail) 
values ('HCM', 'C', 'C@email.com');
insert into customer(caddress, cname, cemail) 
values ('HCM', 'D', 'D@email.com');
insert into customer(caddress, cname, cemail) 
values ('HCM', 'E', 'E@email.com');
insert into customer(caddress, cname, cemail) 
values ('HCM', 'F', 'F@email.com');
insert into customer(caddress, cname, cemail) 
values ('HCM', 'G', 'G@email.com');

insert into book_isbn
values ('1111', 'science', 'book 1', 1000);
insert into book_isbn
values ('2222', 'action', 'book 2', 2000);
insert into book_isbn
values ('3333', 'action', 'book 2', 2001);
insert into book_isbn
values ('4444', 'action', 'book 2', 2001);

insert into book_prop
values ('1111', 'Newton');
insert into book_prop
values ('1111', 'Einstein');
insert into book_prop
values ('1111', 'gravity');

insert into pbook(isbn, date_print)
values ('1111', cast('1/1/2000' as datetime));
insert into pbook(isbn, date_print)
values ('1111', cast('1/1/2000' as datetime));
insert into pbook(isbn, date_print)
values ('1111', cast('1/1/2000' as datetime));

insert into pbuy
values (1, 1, 1);
insert into pbuy
values (2, 1, 1);
insert into pbuy
values (3, 1, 1);

insert into bill(issue, price, purchase_date, quantity)
values ('not finished', 2000, cast('1/12/2000' as datetime), 2);
insert into bill(issue, price, purchase_date, quantity)
values ('not finished', 1000, cast('1/12/2000' as datetime), 1);

insert into author(aname, pen_name)
values ('a', 'Pete');
insert into author(aname, pen_name)
values ('b', 'Val');

declare @date_now date;
set @date_now = getdate();
insert into write(isbn, aid, date_publish)
values ('1111', 1, @date_now);
set @date_now = getdate();
insert into write(isbn, aid, date_publish)
values ('2222', 1, @date_now);
set @date_now = getdate();
insert into write(isbn, aid, date_publish)
values ('3333', 1, @date_now);
set @date_now = getdate();
insert into write(isbn, aid, date_publish)
values ('4444', 1, @date_now);

insert into ebook(isbn)
VALUES('1111')
insert into ebuy(bid, cid, bbid, link)
VALUES(1, 1, 1, 'youtube.com')

--delete from pbuy where 1 = 1;
--delete from book_isbn where 1 = 1;

select * from customer;
select * from pbook;
select * from book_isbn;
select * from book_prop;
select * from bill;
select * from pbuy;
select * from author;
select * from write;
select * from ebuy;
select * from ebook;

--------------------
use smallDB20161002;