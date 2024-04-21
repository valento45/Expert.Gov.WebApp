create table cadastroUsuari_tb
( 
	id_cadastroUsuario serial not null primary key,
	nome varchar(300) not null,
	normalizedNome varchar (100),
	senha varchar (100) not null,
	endereco varchar (500),
	numero VARCHAR (100),
	cidade varchar (100),
	cep varchar(100),
	celular varchar (100)not null,
	email varchar (100) not null
	);
	