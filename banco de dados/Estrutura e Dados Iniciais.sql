USE master;

ALTER DATABASE mf01 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE mf01 ;
GO

create database mf01;
go
use mf01;
go

create table Tb_Usuario (
	Id int not null primary key identity(1,1),
	Login varchar(50) not null,
	Nome varchar(100) not null,
	Senha varchar(64) not null
)

create table Tb_Pecuarista (
	Id int not null primary key identity(1,1),
	Nome varchar(100)
);

create table Tb_Animal(
	Id int not null primary key identity(1,1),
	Descricao varchar(255),
	Preco money
);

create table Tb_CompraGado(
	Id int not null identity(1,1),
	IdPecuarista int,
	DataEntrega smalldatetime,

	primary key(Id, IdPecuarista),
	foreign key (IdPecuarista) references Tb_Pecuarista(Id)
);

create table Tb_CompraGadoItem(
	Id int not null identity(1,1),
	IdCompraGado int,
	IdPecuaristaCompraGado int,
	IdAnimal int,
	Quantidade int not null check(Quantidade > 0),

	unique(IdCompraGado, IdPecuaristaCompraGado, IdAnimal),

	primary key(Id, IdCompraGado, IdAnimal),
	foreign key (IdCompraGado, IdPecuaristaCompraGado) references Tb_CompraGado(Id, IdPecuarista),
	foreign key (IdAnimal) references Tb_Animal(Id)
);


SET IDENTITY_INSERT Tb_Pecuarista ON
insert into Tb_Pecuarista(Id, Nome) values (01, 'José Leôncio');
insert into Tb_Pecuarista(Id, Nome) values (02, 'Veio do Rio');
insert into Tb_Pecuarista(Id, Nome) values (03, 'Rei do gado');
SET IDENTITY_INSERT Tb_Pecuarista OFF

SET IDENTITY_INSERT Tb_Animal ON
insert into Tb_Animal(Id, Preco, Descricao) values(01, '3800.00', 'Boi Magro Nelore');
insert into Tb_Animal(Id, Preco, Descricao) values(02, '3000.00', 'Garrote Nelore');
insert into Tb_Animal(Id, Preco, Descricao) values(03, '2600.00', 'Bezerro Nelore');
insert into Tb_Animal(Id, Preco, Descricao) values(04, '3000.00', 'Vaca Boiadeira Nelore');
insert into Tb_Animal(Id, Preco, Descricao) values(05, '2500.00', 'Vaca Novilha Nelore');
insert into Tb_Animal(Id, Preco, Descricao) values(06, '3400.00', 'Boi Magro Mestiço');
insert into Tb_Animal(Id, Preco, Descricao) values(07, '2700.00', 'Garrote Mestiço');
insert into Tb_Animal(Id, Preco, Descricao) values(08, '2600.00', 'Vaca Boiadeira Mestiça');
insert into Tb_Animal(Id, Preco, Descricao) values(09, '2100.00', 'Vaca Novilha Mestiça');
SET IDENTITY_INSERT Tb_Animal OFF


SET IDENTITY_INSERT Tb_CompraGado ON
insert into Tb_CompraGado(Id, IdPecuarista, DataEntrega) values(01, 01, '01/01/2023');
insert into Tb_CompraGado(Id, IdPecuarista, DataEntrega) values(02, 01, '01/01/2023');
insert into Tb_CompraGado(Id, IdPecuarista, DataEntrega) values(03, 01, '01/01/2023');
insert into Tb_CompraGado(Id, IdPecuarista, DataEntrega) values(04, 01, '01/01/2023');
insert into Tb_CompraGado(Id, IdPecuarista, DataEntrega) values(05, 01, '01/01/2023');
SET IDENTITY_INSERT Tb_CompraGado OFF



SET IDENTITY_INSERT Tb_CompraGadoItem ON
insert into Tb_CompraGadoItem(Id, IdCompraGado, IdPecuaristaCompraGado, IdAnimal, Quantidade) values(01, 01, 01, 01, 100);
insert into Tb_CompraGadoItem(Id, IdCompraGado, IdPecuaristaCompraGado, IdAnimal, Quantidade) values(02, 02, 01, 02, 100);
insert into Tb_CompraGadoItem(Id, IdCompraGado, IdPecuaristaCompraGado, IdAnimal, Quantidade) values(03, 03, 01, 03, 100);
insert into Tb_CompraGadoItem(Id, IdCompraGado, IdPecuaristaCompraGado, IdAnimal, Quantidade) values(04, 04, 01, 04, 100);
insert into Tb_CompraGadoItem(Id, IdCompraGado, IdPecuaristaCompraGado, IdAnimal, Quantidade) values(05, 05, 01, 05, 100);
SET IDENTITY_INSERT Tb_CompraGadoItem OFF


SET IDENTITY_INSERT Tb_Usuario ON
insert into Tb_Usuario(id, Login, Nome, Senha) values(01, 'admin', 'Administrador', 'd46260eef61364d92354eea0cd5acdc2e475e6b205ea64cfb583f5ce2a61aa0e');
SET IDENTITY_INSERT Tb_Usuario OFF

select i.Id, a.Descricao, i.Quantidade, a.Preco [Preço unitário], a.Preco*i.Quantidade Total, p.Nome Pecuarista, c.DataEntrega from Tb_CompraGadoItem i
inner join Tb_Animal a on a.Id = i.IdAnimal
inner join Tb_Pecuarista p on p.Id = i.IdPecuaristaCompraGado
inner join Tb_CompraGado c on c.Id = i.IdCompraGado and c.IdPecuarista = i.IdPecuaristaCompraGado;