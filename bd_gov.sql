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
	
	