document.getElementById("btnFunction").addEventListener("click", function () {


    // Obter o valor do input selecionado
    var selectedOption;
    var cripRadio = document.getElementById("crip");
    var decripRadio = document.getElementById("decrip");

    console.log("click 1")

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

    // Montar os dados para a requisição AJAX
    //var data = new FormData();
    //data.append('type', selectedOption);
    //data.append('clientName', selectedValue);
    //data.append('files', selectedFile);

    if (selectedFiles.length > 0) {
        var data = new FormData();
        data.append('type', selectedOption);
        data.append('clientName', selectedValue);


        //quantidade de arquivos
        for (var i = 0; i < selectedFiles.length; i++) {
            var file = selectedFiles[i];
            data.append('files', file);
        }

        // Adicionar o atributo webkitdirectory se você deseja permitir a seleção de uma pasta
        if (fileInput.webkitdirectory) {
            data.append('isDirectory', true);
        }





        ////codigo temporario
        //// Desabilitar o botão
        //this.disabled = true;

        //// Remover o evento de clique
        //this.removeEventListener("click", arguments.callee);


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
                console.log(dataFile);
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
                    //link.href = '/download?fileName=' + encodeURIComponent(dataFile);
                    //o navegador não armazenará em cache a resposta do servidor e sempre fará uma nova solicitação ao servidor 
                    //para obter o arquivo, evitando downloads duplicados.
                    link.href = '/download?fileName=' + encodeURIComponent(dataFile) + '&timestamp=' + new Date().getTime();
                    link.download = dataFile;

                    // Chamar a função para baixar o arquivo
                    downloadFile(link);
                }
            },
            error: function (xhr, status, error) {
                // Tratar o erro da requisição AJAX
                console.log("Erro na requisição AJAX:", error);
            }
        });

        function downloadFile(link) {
            // Simular um clique no link para iniciar o download
            link.click();
        }
    }
});









