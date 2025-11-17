# API Kaloom - README
[![Status do Projeto](https://img.shields.io/badge/status-In%20Development-yellow)]()
[![GitHub last commit](https://img.shields.io/github/last-commit/kaloom-team/api-kaloom)]()
[![License: MIT](https://img.shields.io/badge/license-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Versão](https://img.shields.io/badge/version-v0.2.0--alpha.1-blue)]()


[![CSharp](https://img.shields.io/badge/C%23-darkgreen?style=for-the-badge&logo=csharp)]()
[![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge)]()
[![ASP.NET](https://img.shields.io/badge/-ASP.NET_Core-blueviolet?style=for-the-badge)]()
[![EF](https://img.shields.io/badge/Entity_Framework_Core-8C3D65?style=for-the-badge)]()
[![EF](https://img.shields.io/badge/FluentValidation-CC0000?style=for-the-badge)]()
[![EF](https://img.shields.io/badge/MYSQL-4479A1?style=for-the-badge)]()


Esse projeto é uma **Application Programming Interface** (API) em desenvolvimento da rede social **Kaloom** para acesso e persistência de dados de alunos, usuários e intituições Etecs e Fatecs em **MySQL**, desenvolvida em **C#** com **.NET**, **ASP.NET Core**, **Entity Framework Core** e **FluentValidation**.
O projeto combina as arquiteturas **MVC** do ASP.NET e **Layered Architecture** para manter uma estrutura limpa, organizada e escalável, contendo Controllers, Models, DTOs, validações, comunicação entre camadas, tratamento de exceções costumizadas e respostas padronizadas.

<p>
    <strong>Indice</strong>: &nbsp;&nbsp;
    <a href="#arquiteturas">Arquiteturas</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
    <a href="#tecnologias">Tecnologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
    <a href="#execucao">Execução</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
    <a href="#endpoints">Endpoints</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
    <a href="#MIT-1-ov-file">Licença</a>
</p>


<h2 id="arquiteturas"> 🏛️ Arquiteturas e responsabilidades </h2>

* **API Layer (MVC)**: contém **Controllers** que expõem endpoints e **Models** que representam as entidades de domínio;
* **Communication Layer**: gerencia os **DTOs (Data Transfer Objects)** e comunicação;
* **Exceptions Layer**: centraliza o controle e padronização de erros.
* **Tests Layer**: testes unitários e mocks para testar endpoints.

Camadas da API:
* **UseCases**: casos de uso de cada entidade usada nos endpoints;
* **Facades**: facades para agregar casos de uso das controllers;
* **Factories**: fabricas de DTOs e Models;
* **Mappings**: profiles personalizados para mapear objetos;
* **SharedValidator**: utiliza **FluentValidation** para validações das requests, garantindo a integridade dos dados de entrada.

Essa combinação de **Layered + MVC** permite separar responsabilidades de forma clara, facilitando manutenção, testes e evolução do código.

<h2 id="tecnologias"> 🛠️ Tecnologias e Ferramentas Utilizadas </h2>

<div align="left">
  <table
    <thead>
      <tr>
        <th>Tipo</th>
        <th>Tecnologia</th>
        <th>Descrição</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td>💻 Linguagem</td>
        <td>C#</td>
        <td>Alto nível, moderna, orientada a objetos, multiparadigma e tipagem forte/inferida/dinâmica.</td>
      </tr>
      <tr>
        <td>⚙️ Frameworks</td>
        <td>.NET / ASP.NET Core</td>
        <td>.NET é a plataforma de desenvolvimento e o ASP.NET é um framework para criação de APIs web.</td>
      </tr>
      <tr>
        <td>🗃️ ORM</td>
        <td>Entity Framework Core</td>
        <td>O EF é um Object-Relational Mapping, técnica para traduzir e executar querys SQL com POO.</td>
      </tr>
      <tr>
        <td>🐬 Banco de Dados</td>
        <td>MySQL</td>
        <td>Sistema de Gerenciamento de Banco de Dados Relacional para armazenar dados em tabelas.</td>
      </tr>
      <tr>
        <td>🔌 Driver EF</td>
        <td>Pomelo</td>
        <td>Driver de conexão com banco de dados provedor para o EF Core, feito sobre o MySqlConnector.</td>
      </tr>
      <tr>
        <td>✅ Validação</td>
        <td>FluentValidation</td>
        <td>Biblioteca para validações de dados recebidos na API.</td>
      </tr>
      <tr>
        <td>🔁 Mapper</td>
        <td>AutoMapper</td>
        <td>Mapeador objeto-objeto baseado em convenções para mapear DTOs.</td>
      </tr>
      <tr>
        <td>🧪 Testes unitários</td>
        <td>xUnit.net</td>
        <td>Ferramenta de teste de unidade gratuita e de código aberto para .NET.</td>
      </tr>
      </tr>
        <tr>
        <td>🎭 Mock</td>
        <td>Moq</td>
        <td>Biblioteca de mocking .NET, usada para criar objetos simulados de dependências, permitindo testar unidades de código isoladamente.</td>
      </tr>
      <tr>
        <td>🧰 IDE usada e recomendada</td>
        <td>Visual Studio 2026</td>
        <td>Ambiente de Desenvolvimento Integrado mais abrangente para desenvolvimento .NET.</td>
      </tr>
      <tr>
        <td>📦 Package Manager</td>
        <td>NuGet</td>
        <td>Gerenciador de pacotes .NET para fazer instalações, atualizações e configurações de bibliotecas.</td>
      </tr>
    </tbody>
  </table>
</div>


<h2 id="execucao"> ▶️ Como executar no Visual Studio </h2>

#### 📦 Pré-requisitos:
- Sistema operacional Windows
- [.NET SDK](https://dotnet.microsoft.com/en-us/download) instalado (versão 8.0 ou superior)
- **Visual Studio** com o componente **ASP.NET e Desenvolvimento Web** instalado
- Tenha o MySQL instalado

1. **Clone o repositório**

   ```bash
   git clone https://github.com/kaloom-team/api-kaloom.git
   cd api-kaloom
   ```

2. **Abra o projeto no Visual Studio**

   - Clique duas vezes no arquivo **.sln** ou abra pelo Visual Studio via **Arquivo** > **Abrir** > **Projeto/Solução**

3. **Configure a string de conexão**

   Coloque seu usuário e senha do MySQL no arquivo `appsettings.Development.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=kaloom;User=root;Password=root;"
     }
   }
   ```
   
4. **Instale a ferramenta dotnet-ef**
   
   ```bash
   dotnet tool install --global dotnet-ef
   ```
   
6. **Execute as migrations**

   ```bash
   dotnet ef database update --project Kaloom.API
   ```
   ou
   ```bash
   cd Kaloom.API
   dotnet ef database update
   ```

7. **Inicie a aplicação**
    - Pressione ```F5``` 

    ou 
    - Clique em **Iniciar (Start)** para compilar e rodar a API

    ou via CLI
   ```bash
   cd Kaloom.API
   dotnet watch run
   ```
    O Swagger irá abrir no navegador se a aplicação estiver sendo executada em ambiente de desenvolvimento.

<h2 id="endpoints"> 📡 Endpoints </h2>

As entidades Aluno, Usuario, TipoAluno, Etec e Fatec tem os seguintes endpoints base:

<table>
    <thread>
        <tr>
            <th>
                Método
            </th>
            <th>
                Rota
            </th>
            <th>
                Descrição
            </th>
        </tr>
    </thread>
    <tbody>
        <tr>
            <th>
                GET
            </th>
            <th>
                /api/entidade
            </th>
            <th>
                Retorna todos os registros
            </th>
        </tr>
        <tr>
            <th>
                GET
            </th>
            <th>
                /api/entidade/{id}
            </th>
            <th>
                Retorna um registro pelo ID
            </th>
        </tr>
        <tr>
            <th>
                POST
            </th>
            <th>
                /api/entidade
            </th>
            <th>
                Cria um novo registro
            </th>
        </tr>
         <tr>
            <th>
                PUT
            </th>
            <th>
                /api/entidade/{id}
            </th>
            <th>
                Atualiza um registro
            </th>
        </tr>
        <tr>
            <th>
                DELETE
            </th>
            <th>
                /api/entidade/{id}
            </th>
            <th>
                Deleta um registro
            </th>
        </tr>
    </tread>
</table>

## 🤝 Contribuições
Sinta-se à vontade para abrir **Pull Requests** com melhorias de código ou **Issues** com sugestões caso queira contribur ao projeto.


## 📜 Licença

Este projeto está licenciado sob a **licença MIT**, veja o arquivo [LICENSE](LICENSE) para detalhes.<br /><br />


---

<div align="center">
  <strong>Desenvolvido pela Kaloom</strong><br>
  Etec Juscelino Kubitschek de Oliveira - Diadema/SP - 2025
</div>
