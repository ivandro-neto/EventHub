# EventHub API
# Guia para Rodar um Projeto ASP.NET Core no VSCode e no VS2022

Este guia descreve como rodar seu projeto no Visual Studio Code (VSCode) e no Visual Studio 2022. As instruções incluem desde a configuração do ambiente até o uso de recursos como Swagger.

## Requisitos

Para seguir este guia, você precisará de:
- [.NET SDK 6 ou superior](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [MySQL Server para o banco de dados](/Docs/SETUP_DATABASE.md)
- [Visual Studio Code](https://code.visualstudio.com/Download) ou [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

### Requisitos adicionais para VSCode
Para usar o Visual Studio Code com projetos ASP.NET Core, recomenda-se instalar as seguintes extensões:
- [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [C# Extensions](https://marketplace.visualstudio.com/items?itemName=jchannon.csharpextensions)
- [NuGet Package Manager](https://marketplace.visualstudio.com/items?itemName=jmrog.vscode-nuget-package-manager)
- [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) (para testar APIs)

## Configuração do Banco de Dados

Antes de rodar a aplicação, é necessário configurar a string de conexão com o banco de dados. Siga estas instruções para customizar a connection string:

1. Abra o arquivo `appsettings.json` no seu projeto.
2. Procure pela seção `"EventHubDBConnectionString"` dentro de `"ConnectionStrings"`.
3. Edite a string de conexão para refletir as configurações do seu banco de dados, incluindo o nome do servidor, a porta, o nome do banco de dados, o usuário e a senha.

Exemplo de uma string de conexão customizada:
```json
"EventHubDBConnectionString": "server=nome_servidor;port=porta;database=nome_banco_dados;user=nome_usuario;password=senha;"
```

## Rodando no Visual Studio Code

1. **Abra o Projeto no VSCode**: Abra o VSCode e use "Open Folder" para abrir a pasta do seu projeto.

2. **Instale Dependências**: No terminal do VSCode, execute `dotnet restore` para garantir que todas as dependências estão instaladas.

3. **Configuração do Depurador**: Se necessário, configure o depurador para ASP.NET Core. Normalmente, o VSCode faz isso automaticamente ao abrir o projeto pela primeira vez.

4. **Rodar a Aplicação**:
   - Para iniciar com depuração, pressione `F5`.
   - Para iniciar sem depuração, use `CTRL + F5`.

5. **Acessar a Aplicação**: Após iniciar a aplicação, ela será executada em uma porta local, como `http://localhost:5000`. Abra um navegador para acessar a aplicação.

6. **Acessar o Swagger**: Para acessar a documentação do Swagger, vá para `http://localhost:5000/api-docs`.

## Rodando no Visual Studio 2022

1. **Abrir o Projeto no VS2022**: No Visual Studio 2022, selecione "Open a project or solution" e abra a solução do seu projeto.

2. **Restaurar Dependências**: No menu superior, clique em "Build" e selecione "Restore NuGet Packages".

3. **Configurações de Inicialização**: Verifique se a configuração de inicialização está definida para o seu projeto ASP.NET Core. No menu superior, selecione "Project" > "Properties" para definir as configurações desejadas.

4. **Rodar a Aplicação**:
   - Para iniciar com depuração, clique no botão "Start" (ícone verde de depuração).
   - Para iniciar sem depuração, use `CTRL + F5`.

5. **Acessar a Aplicação**: Após iniciar, a aplicação estará disponível em um endereço local, como `http://localhost:5000`.

6. **Acessar o Swagger**: Para acessar o Swagger, vá para `http://localhost:5000/api-docs` ou para a rota configurada para o Swagger.

## Solução de Problemas

- **Conexão com o Banco de Dados**: Se houver problemas para conectar ao banco de dados, verifique a string de conexão no arquivo `appsettings.json`. Certifique-se de que o MySQL está rodando e de que as credenciais estão corretas.

- **Erros de Compilação**: Se houver erros ao compilar, leia a saída do build no terminal para entender o problema. Verifique se as referências estão corretas e se todos os pacotes NuGet estão instalados.

- **Depuração**: Se precisar depurar, use pontos de interrupção para investigar o comportamento do código. Verifique variáveis e saídas do console para entender a causa do problema.

## Dicas Finais

- Faça backup do banco de dados antes de fazer alterações significativas.
- Mantenha as informações sensíveis, como senhas, protegidas e seguras.
- Atualize suas ferramentas e extensões regularmente para garantir a compatibilidade.
