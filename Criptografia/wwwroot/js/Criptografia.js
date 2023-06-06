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
    var selectedFile = fileInput.files[0];

    // Montar os dados para a requisição AJAX
    var data = new FormData();
    data.append('type', selectedOption);
    data.append('clientName', selectedValue);
    data.append('files', selectedFile);

    console.log(data)

    // Fazer a requisição AJAX
    $.ajax({
        url: '/crypt',
        type: 'POST',
        dataType: 'json',
        data: data,
        processData: false,
        contentType: false,
        success: function (response) {
            let dataFile = response.fileName;
            console.log(dataFile)
            if (response != null && response.fileName != null) {
                // Verificar se o link de download já existe
                var link = document.getElementById("downloadLink");
                if (!link) {
                    // Se o link de download não existir, criar um novo
                    link = document.createElement('a');
                    link.id = "downloadLink";
                    link.style.display = "none";
                    document.body.appendChild(link);
                }

                // Atualizar os atributos do link de download
                link.href = '/download?fileName=' + encodeURIComponent(dataFile);
                link.download = dataFile;

                // Simular um clique no link para iniciar o download
                link.click();
            }
        },
        error: function (response) {
            // Tratar o erro da requisição AJAX
        }
    });

});
