CREATE DATABASE bd_gov
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
	


	create table cadastro_usuario_tb
	( 
	id_cadastroUsuario serial not null primary key,
	nome varchar(300) not null,
	normalizedNome varchar (100),
	user_name varchar(50) not null,
	senha varchar (100) not null,
	endereco varchar (500),
	numero VARCHAR (100),
	cidade varchar (100),
	cep varchar(100),
	celular varchar (100)not null,
	email varchar (100) not null
	);
	insert into cadastro_usuario_tb (nome, user_name, senha, celular, email) values ('admin', 'admin', 'admin!@#', 'admin', 'admin')

	
	
CREATE  table solicitacao_tb(
		id_solicitacao serial not null primary key,
		nome varchar(300) not null,
		celular varchar(20),
		email varchar(300) not null,
		endereco_solicitacao varchar(500),
		numero_solicitacao varchar(100),
		cep_solicitacao varchar(100),
		descricao_titulo varchar(200) not null,
			descricao_sugestao_melhoria varchar
	);
	

	create table anexo_solicitacao_tb(
		id_anexo serial not null primary key,
		id_solicitacao integer not null,
		anexo_base64 varchar not null,
		extensao_arquivo varchar(10),
		constraint id_solicitacao_fk foreign key(id_solicitacao)
		references solicitacao_tb(id_solicitacao)
	);
	
	

	create table portfolio_tb(
		id_portfolio serial not null primary key,
		descricao varchar(400) not null,
		data_hora timestamp not null,
		resumo varchar,
		endereco varchar(200) not null	,
		ordem_apresentacao integer
	);
	

	create table anexo_portfolio_tb(
		id_anexo serial not null primary key,
		id_portfolio integer not null,
		anexo_base64 varchar not null,
		extensao_arquivo varchar(10),
		constraint id_portfolio_fk foreign key(id_portfolio)
		references portfolio_tb(id_portfolio)
	);
	
	
	
	
