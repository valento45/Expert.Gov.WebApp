	create table anexo_solicitacao_tb(
		id_anexo serial not null primary key,
		id_solicitacao integer not null,
		anexo_base64 varchar not null,
		extensao_arquivo varchar(10),
		constraint id_solicitacao_fk foreign key(id_solicitacao)
		references solicitacao_tb(id_solicitacao)
	);