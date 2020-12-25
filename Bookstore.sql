use smallDB20161002;
--------------------

drop database if exists Bookstore;
create database Bookstore;
GO
use Bookstore;
GO

drop table if exists bookstore;
create table bookstore (
    sid         int		    primary key identity(1, 1),
    sname       varchar(30) not null,
    slocation   varchar(30) not null
);

drop table if exists customer;
create table customer (
    cid         int		    primary key identity(1, 1),
    caddress    varchar(30),
    cname       varchar(30) not null,
    cemail      varchar(20) not null
);

drop table if exists employee;
create table employee (
    eid			int			not null primary key identity(1, 1),
    eaddress char(20),
    ename char(30)			not null,
    eemail char(20)			not null
);

drop table if exists account;
create table account (
	username	varchar(30) not null,
	password	varchar(30) not null,
	type_account varchar(30) not null check(type_account in ('Admin', 'Customer', 'Employee')), 
	accid	int not null
	primary key(type_account, accid)

);

drop table if exists book_isbn;
create table book_isbn (
    isbn        char(20)    primary key,
    genre		varchar(15) not null,
    title       varchar(20) not null,
    price       integer
);

drop table if exists ebook;
create table ebook(
    bid			int		    primary key identity(1, 1),
    isbn        char(20)    references book_isbn(isbn)
);

drop table if exists pbook;
create table pbook(
    bid         int		    primary key identity(1, 1),
	isbn		char(20)	references book_isbn(isbn),
    date_print  date,          
	status      varchar(10) check(status in ('waiting', 'exported', 'in stored'))
);

drop table if exists book_prop;
create table book_prop (
    isbn        char(20)    references book_isbn(isbn),
    keyword     varchar(15) not null,
    primary key	(isbn, keyword)
);

drop table if exists bill;
create table bill(
    bbid    int				not null identity(1, 1) primary key,
	cid		int				references customer(cid),
	quantity int			check(quantity > 0),
    payment	varchar(9),
    issue   varchar(100),
    price	integer,
    purchase_date date
);

--drop table if exists bill_book
--create table bill_book (
--	bbid	int				references bill(bbid),
--	isbn	char(20)		not null,
--	quantity int			not null check(quantity > 0),
--	primary key (bbid, isbn)
--);

drop table if exists credit_card;
create table credit_card (
	ccid		int			not null primary key identity(1, 1), 
    branch      varchar(20) not null, 
    bank_name	varchar(20)	not null, 
    owner		varchar(20)	not null
);

drop table if exists author;
create table author (
    aid         int		    primary key identity(1, 1),
    aname       varchar(30) not null,
    pen_name    varchar(15),
);

drop table if exists write;
create table write(
    isbn        char(20)	references book_isbn(isbn),
    aid         int			references author(aid),
    primary key (isbn, aid),
    --foreign key (isbn) references book_isbn(isbn) on delete cascade,
    --foreign key (aid) references author(aid) on delete cascade,
);

drop table if exists publisher;
create table publisher(
    pid         int			not null primary key identity(1, 1),
	pname		varchar(20) not null
);

drop table if exists order_from;
create table order_from (
    pid         int			not null,
    sid			int			not null,
    isbn        char(20)	not null,
    primary key (sid, isbn, pid),
    foreign key (isbn) references book_isbn(isbn) on delete cascade,
    foreign key (sid) references bookstore(sid) on delete cascade,
    foreign key (pid) references publisher(pid) on delete cascade 
);

drop table if exists ebuy;
create table ebuy (
    bid         int		    references pbook(bid) on delete cascade,
    cid         int			references customer(cid) on delete cascade,
	bbid		int			references bill(bbid) on delete cascade,
	link		varchar(30)	not null,
    primary key (bid, cid)
);

drop table if exists pbuy;
create table pbuy (
    bid         int		    references pbook(bid) on delete cascade,
    cid         int			references customer(cid) on delete cascade,
	bbid		int			references bill(bbid) on delete cascade,
    primary key (bid, cid)
);

drop table if exists borrow;
create table borrow (
    bid         int		    not null,
    cid         int			not null,
    borrow_date date,
    primary key (bid, cid),
    foreign key (bid) references ebook(bid) on delete cascade,
    foreign key (cid) references customer(cid) on delete cascade
);

drop table if exists manage;
create table manage (
    bid     int				not null,
    eid     int				not null,
    primary key (bid, eid),
    foreign key (bid) references pbook(bid) on delete cascade,
	foreign key (eid) references employee(eid) on delete cascade
);

drop table if exists belong_to;
create table belong_to(
    ccid	int				not null,
    cid		int				not null,
    primary key (cid, ccid),
    foreign key (ccid) references credit_card(ccid)	on delete cascade,
    foreign key (cid) references customer(cid) on delete cascade
);

drop table if exists feedback;
create table feedback (
    fid		int				not null primary key identity(1, 1),
	content varchar(200)	not null
);

drop table if exists give;
create table give (
    fid		int				not null,
    cid		int				not null,
    primary key (fid, cid),
    foreign key (fid) references feedback(fid) on delete cascade,
	foreign key (cid) references customer (cid) on delete cascade
);

drop table if exists work_for;
create table work_for (
	sid		int				not null,
	eid		int				not null,
	primary key (sid, eid),
    foreign key (sid) references bookstore(sid) on delete cascade,
	foreign key (eid) references employee(eid) on delete cascade
);

drop table if exists stored_at;
create table stored_at (
	sid		int				not null,
	bid		int				not null,
	primary key (bid, sid),
    foreign key (bid) references pbook(bid) on delete cascade,
	foreign key (sid) references bookstore(sid) on delete cascade
);

--------------------
use smallDB20161002;

--select * from Department;
--select * from customer;