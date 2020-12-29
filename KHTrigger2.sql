
use Bookstore;

--------------------
drop trigger if exists pbook_sold;
go
create trigger book_sold on pbuy for insert
as
begin

end;
go


use smallDB20161002;