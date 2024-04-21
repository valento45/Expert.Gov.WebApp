$(document).ready(() => {



});




function onClickCarregarImagens(e) {


    $('#btnCarregarImagens').click();
}


function onChangeImagens(e) {

    var qtdAnexos = e.files.length;


    $("#lblQtdAnexos").text(`( ${qtdAnexos} )`);
}

function onClickSalvar(e) {

    var model = new Object();
    model.Anexos = new FormData();

    model.Id_Solicitacao = +$("#txtCodigo").val();
    model.Nome = $("#txtNome").val();
    model.Celular = $("#txtCelular").val();
    model.Email = $("#txtEmail").val();
    model.Endereco_solicitacao = $("#txtEndereco").val();
    model.Numero_solicitacao = +$("#txtNº").val();
    model.Cep_solicitacao = $("#txtCep").val();
    model.Descricao_Titulo = $("#txtDescreva Seu Problema").val();
    model.Solicitacao_melhoria = $("#txtDecreve sua sugestão").val();
   

    var inputFiles = document.getElementById('btnCarregarImagens');


    if (inputFiles.files.length > 0) {
        for (var indice = 0; indice < inputFiles.files.length; indice++) {
            model.Anexos.append('files', inputFiles.files.item(indice));
        }
    }


    util.ajax.post("../Solicitacao/SalvarSolicitacao", model,
        (data) => {
            console.log(data);
        },

        (error) => {
            console.log(error);
        });
}

