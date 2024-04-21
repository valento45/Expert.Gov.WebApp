CREATE DATABASE bd_gov
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
	
	
	
	CREATE table solicitacao_tb(
		id_solicitacao serial not null primary key,
		nome varchar(300) not null,
		celular varchar(20),
		email varchar(300) not null,
		endereco_solicitacao varchar(500),
		descricao_titulo varchar(200) not null,
			descricao_sugestao_melhoria varchar
	);
	
	create table anexos_solicitacao_tb(
		id_solicitacao integer not null,
		anexo_base64 varchar,
		tipo_anexo varchar(20) 
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
	
	select id_anexo, id_portfolio, extensao_arquivo from anexo_portfolio_tb