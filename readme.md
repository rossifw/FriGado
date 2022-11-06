# Instalação e Configuração

A *solution* conta com 2 projetos, FriGado.APP e FriGado.API.<br>
O projeto ...APP é uma aplicação Desktop Windows Forms .Net Framework
O projeto ...API é uma aplicação em .Net Core 3 que pode ser instalada em Windows ou Linux.

### Instalação do Banco de dados
```sh
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=UmaSenh4@F0rteQualquer" \
           -p 1433:1433 \
           --name sql1 \
           --hostname sql1 \
           -d mcr.microsoft.com/mssql/server:2022-latest
```

Deve-se executar o script inicial, que está localizado em `banco de dados\Estrutura e Dados Iniciais.sql`

### Configuração da string de conexão da API
É necessário alterar o arquivo **appsettings.json** do projeto Frigado.API e modificar a string de conexão.
Deve-se adicionar o endereço IP onde está rodando o SQL Server, o usuário, a senha e a base de dados, que no caso é mf01.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnectionString": "Data Source=127.0.0.1;Database=mf01;User ID=sa;Password=UmaSenh4@F0rteQualquer;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  }
}

```

### Aplicação Desktop
O endereço (URL/IP) da API está parametrizado na classe `Config`.<br>
Deve-se alterar conforme seu cenário.<br>

```cs
namespace FriGado.App
{
    public static class Config
    {
        public const string APIUrl = "https://192.168.1.10/api";
      //public const string APIUrl = "https://localhost:44345/api";
    }
}
```

### Rodando direto do Visual Studio
As aplicações, app e api, podem ser executadas juntas no visual studio, para isso basta configurar os projetos de inicialização
![image](https://user-images.githubusercontent.com/11152752/200192161-80ed217e-0092-4cca-a3a3-ba4eff234079.png)

