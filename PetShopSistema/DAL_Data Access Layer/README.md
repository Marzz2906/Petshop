# Camada de Acesso a Dados (DAL) - PetShopSistema

A sigla **DAL** significa *Data Access Layer* (Camada de Acesso a Dados). O único propósito desta pasta é "conversar" com o banco de dados SQL Server. 

Sempre que a aplicação precisa salvar um cliente, listar os pets, fazer login ou registrar um agendamento, ela pede para uma classe DAL fazer esse trabalho. É aqui que os comandos SQL (INSERT, SELECT, UPDATE, DELETE) vivem.

## Aspectos Técnicos e de Arquitetura

### 1. Classe Base de Conexão (`Conexao.cs`)
- Todas as classes da DAL precisam acessar o banco. Para não repetirmos código, usamos a classe `Conexao.cs`.
- O método `Conectar()` utiliza `ConfigurationManager.ConnectionStrings["PetShopDB"]` para ler de forma segura onde o banco está (lá no arquivo `App.config`), e retorna um objeto `SqlConnection` prontinho para uso.

### 2. O Padrão ADO.NET
As classes aqui (como `UsuarioDAL` e `PetDAL`) utilizam a biblioteca ADO.NET (`using System.Data.SqlClient;`). O fluxo de execução segue sempre este padrão técnico rigoroso:
1. **Abre Conexão:** Instancia o `SqlConnection` e chama `con.Open()`.
2. **Prepara o Comando:** Cria o `SqlCommand(query, con)`.
3. **Passa Parâmetros:** Usa `cmd.Parameters.AddWithValue()`.
4. **Executa:**
   - Usa `ExecuteNonQuery()` quando a query for `INSERT`, `UPDATE` ou `DELETE` (pois ele só precisa saber quantas linhas foram afetadas).
   - Usa `ExecuteReader()` quando a query for um `SELECT` (pois ele precisa iterar linha por linha para ler o que voltou do banco).
5. **Fecha Conexão:** Ao usar o bloco `using (SqlConnection con = ...)`, o C# garante que a conexão com o banco será fechada automaticamente assim que terminar, evitando vazamento de memória e travamentos do servidor.

### 3. Proteção contra SQL Injection (Segurança)
Repare no arquivo `UsuarioDAL.cs` (no método `Cadastrar`). Nós escrevemos o comando SQL assim:
`INSERT INTO Usuario (...) VALUES (@nome, @email, ...)`
Nós **NÃO** concatenamos variáveis C# direto na string SQL (ex: `"VALUES ('" + usuario.Nome + "')"`). 
Utilizamos as variáveis `@nome` e repassamos o valor depois com `cmd.Parameters.AddWithValue("@nome", usuario.Nome)`. Isso protege completamente o nosso sistema contra ataques de injeção de SQL (SQL Injection)!

### 4. Transformação de Dados
Um papel muito importante das classes DAL é o mapeamento dos dados que voltam da tabela do SQL para as nossas classes da pasta `Models`.
- O banco retorna as colunas cruas: `cd_usuario`, `nm_usuario`, `ds_email`.
- A DAL (com o `SqlDataReader`) lê cada valor e coloca dentro de um objeto C#: `usuario.IdUsuario = reader.GetInt32(0);`, etc. Em seguida, devolve a "caixa" (o objeto) montada para a UI.

---

### Resumo para o Grupo:
A DAL é a operária do banco de dados. Ela é a única pasta que entende de SQL Server, de `SqlConnection` e de tabelas. O resto do sistema não sabe como salvar dados, ele apenas joga a tarefa para a DAL resolver!
