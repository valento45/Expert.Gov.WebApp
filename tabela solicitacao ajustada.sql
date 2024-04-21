CREATE table solicitacao_tb(
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