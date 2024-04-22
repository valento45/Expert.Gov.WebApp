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

    model.IdTrabalho = +$("#txtCodigo").val();
    model.Descricao = $("#txtDescricao").val();
    model.DataHora = $("#txtData").val();
    model.Resumo = $("#txtResumo").val();
    model.Local = $("#txtLocal").val();


    var inputFiles = document.getElementById('btnCarregarImagens');


    if (inputFiles.files.length > 0) {
        for (var indice = 0; indice < inputFiles.files.length; indice++) {
            model.Anexos.append('files', inputFiles.files.item(indice));
        }
    }


    util.ajax.post("../TrabalhoRealizado/SalvarTrabalho", model,
        (data) => {
            console.log(data);
        },

        (error) => {
            console.log(error);
        });
}





