create database BDContato
go
use BDContato
go

create table Contato
(
  IdContato   int           primary key   identity,
  Nome        varchar(60)   not null,
  Email       varchar(100)  not null
)

insert into Contato values ('Fulano', 'fulano@email.com')
insert into Contato values ('Ciclano', 'ciclano@email.com')