document.getElementById("btnFunction").addEventListener("click", function () {
    // Obter o valor do input selecionado
    var selectedOption;
    var cripRadio = document.getElementById("crip");
    var decripRadio = document.getElementById("decrip");

    if (cripRadio.checked) {
        selectedOption = cripRadio.value;
    } else if (decripRadio.checked) {
        selectedOption = decripRadio.value;
    }

    // Obter o valor selecionado do select
    var selectClient = document.getElementById("selectClient");
    var selectedValue = selectClient.value;

    // Obter o arquivo selecionado
    var fileInput = document.getElementById("fileInput");
    var selectedFiles = fileInput.files;

    if (selectedFiles.length > 0) {
        var data = new FormData();
        data.append('type', selectedOption);
        data.append('clientName', selectedValue);

        // quantidade de arquivos
        for (var i = 0; i < selectedFiles.length; i++) {
            var file = selectedFiles[i];
            data.append('files', file);
        }

        // Adicionar o atributo webkitdirectory se você deseja permitir a seleção de uma pasta
        if (fileInput.webkitdirectory) {
            data.append('isDirectory', true);
        }

        // URLs dinâmicas
        var ajaxUrl, downloadUrl;

        if (selectedOption === "crip") {
            ajaxUrl = '/crypt';
            downloadUrl = '/downloadcrip';
        } else if (selectedOption === "decrip") {
            ajaxUrl = '/decrypt';
            downloadUrl = '/downloaddecrip';
        }

        // Chamar a função para fazer a requisição AJAX
        performAjaxRequest(ajaxUrl, data, downloadUrl);
    }
});

function performAjaxRequest(ajaxUrl, formData, downloadUrl) {
    // Fazer a requisição AJAX
    $.ajax({
        url: ajaxUrl,
        type: 'POST',
        dataType: 'json',
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response != null && response.fileName != null) {

                $("#successText").text("Arquivo " + response.fileName + " processado com sucesso!");
                $("#successMessage").show();
                $("#errorMessage").hide();

                $('#fileInput').val('');

                var link = document.getElementById("downloadLink");
                if (!link) {
                    // Se o link de download não existir, criar um novo
                    link = document.createElement('a');
                    link.id = "downloadLink";
                    link.style.display = "none";
                    document.body.appendChild(link);
                }

                link.href = downloadUrl + '?fileName=' + encodeURIComponent(response.fileName) + '&timestamp=' + new Date().getTime();
                link.download = response.fileName;

                // Chamar a função para baixar o arquivo
                downloadFile(link);
            } else {
                $("#errorText").text(response);
                $("#errorMessage").show();
                $("#successMessage").hide();

                $('#fileInput').val('');

            }
        },
        error: function (xhr, status, error) {
            $("#errorText").text(error);
            $("#errorMessage").show();

            // Exibir mensagem de erro específica
            if (xhr.responseJSON && xhr.responseJSON.error) {
                $("#errorText").text(xhr.responseJSON.error);
            }

            // Esconder mensagem de sucesso, se estiver visível
            $("#successMessage").hide();

            $('#fileInput').val('');

        }
    });
}


function downloadFile(link) {
    // Simular um clique no link para iniciar o download
    link.click();
}
