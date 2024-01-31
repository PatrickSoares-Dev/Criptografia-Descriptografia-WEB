# Documentação do Código

## Resumo

Este sistema fornece duas funcionalidades: criptografia e descriptografia de arquivos. Os usuários podem enviar arquivos e escolher entre as opções de criptografia e descriptografia. 

A Ferramente valida o nome do cliente e usa a chave pública correspondente para a criptografia. Após o processamento, retorna uma mensagem de sucesso e um link de download para o arquivo processado.

Controllers

- /crypt: Criptografa arquivos.
- /decrypt: Descriptografa arquivos.
- /downloadcrip: Baixa arquivos criptografados.
- /downloaddecrip: Baixa arquivos descriptografados.
