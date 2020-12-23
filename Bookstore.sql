use smallDB20161002;
--------------------

drop database if exists Bookstore;
create database Bookstore;
use Bookstore;

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

drop table if exists book;
create table book (
    bid         int		    primary key identity(1, 1),
    isbn        char(20)    not null
);

drop table if exists ebook;
create table ebook(
    bid			int		    primary key,
    foreign key (bid) references book(bid)
);

drop table if exists physical_book;
create table physical_book(
    bid         int		    primary key,
    DatePrint   Date,
    Btype       char(9),          
    foreign key (bid) references book(bid)
);

drop table if exists book_isbn;
create table book_isbn (
    isbn        char(20)    primary key,
    title       varchar(20) not null,
    price       integer,
    status      varchar(10) check(status in ('waiting', 'exported'))
);

drop table if exists book_prop;
create table book_prop (
    isbn        char(20)    not null,
    domain      varchar(15) not null,
    keyword     varchar(15) not null,
    primary key	(isbn, domain, keyword)
);

drop table if exists bill;
create table bill(
    bbid    int				primary key,
    payment	varchar(9),
    issue   varchar(20),
    price	integer,
    purchase_date date
);

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
    pen_name    varchar(15)
);

drop table if exists write;
create table write(
    bid         int			not null,
    aid         int			not null,
    primary key (bid, aid),
    foreign key (bid) references book(bid) on delete cascade,
    foreign key (aid) references author(aid) on delete cascade,
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
    bid         int		    not null,
    cid         int			not null,
	bbid		int			not null,
	link		varchar(30)	not null,
    primary key (bid, cid),
	foreign key (bid) references ebook(bid) on delete cascade,
    foreign key (cid) references customer(cid) on delete cascade,
	foreign key (bbid) references bill(bbid) on delete cascade
);

drop table if exists pbuy;
create table pbuy (
    bid         int		    not null,
    cid         int			not null,
	bbid		int			not null,
    primary key (bid, cid),
	foreign key (bid) references physical_book(bid) on delete cascade,
    foreign key (cid) references customer(cid) on delete cascade,
	foreign key (bbid) references bill(bbid) on delete cascade
);

drop table if exists borrow;
create table borrow (
    bid         int		    not null,
    cid         int			not null,
    borrow_date date,
    primary key (bid, cid),
    foreign key (bid) references book(bid) on delete cascade,
    foreign key (cid) references customer(cid) on delete cascade
);

drop table if exists employee;
create table employee (
    eid			int			not null primary key identity(1, 1),
    eaddress char(20),
    ename char(30)			not null,
    eemail char(20)			not null
);

drop table if exists manage;
create table manage (
    bid     int				not null,
    eid     int				not null,
    primary key (bid, eid),
    foreign key (bid) references book(bid) on delete cascade,
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

drop table if exists work_for;
create table stored_at (
	sid		int				not null,
	bid		int				not null,
	primary key (sid, eid),
    foreign key (sid) references book(bid) on delete cascade,
	foreign key (eid) references employee(eid) on delete cascade
);

--------------------
use smallDB20161002;

--select * from Department;