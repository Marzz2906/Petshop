# Camada de Modelos (Models) - PetShopSistema

A pasta `Models` é o coração estrutural do nosso sistema. Ela contém as classes que representam as "Entidades" do nosso mundo real (ou do nosso banco de dados) dentro do código C#.

Essa camada é a mais simples de todas e tem um papel muito claro: **transportar dados de um lado para o outro** (por exemplo, da UI para a DAL, ou da DAL para a UI).

## Aspectos Técnicos e de Arquitetura

1. **Classes "Puras" (POCO):** 
   Repare que os arquivos aqui dentro (`Usuario.cs`, `Pet.cs`, `Agendamento.cs`) são apenas declarações de classes com propriedades. Eles **não fazem acesso a banco de dados** e **não lidam com telas**. São apenas "moldes" para criarmos objetos.

2. **Propriedades (`get; set;`):**
   Usamos o padrão de auto-implementação de propriedades do C#. Quando você vê algo como `public string Nome { get; set; }`, significa que qualquer outra parte do sistema pode ler o valor do nome (`get`) ou atribuir um novo valor (`set`).

3. **Mapeamento com o Banco de Dados:**
   - Se você olhar o arquivo `Usuario.cs`, verá comentários detalhando como cada propriedade do C# se relaciona com as colunas criadas no arquivo `SQLQuery1.sql`.
   - Por exemplo, `IdUsuario` (tipo `int` no C#) corresponde à coluna `cd_usuario` (`INT IDENTITY(1,1)` no SQL).
   - O objeto `Usuario` é o que preenchemos na tela de Cadastro e enviamos inteirinho para a classe `UsuarioDAL` gravar.

4. **Objetos de Serviço (Ex: CepModel):**
   Nem tudo na pasta Models precisa ir para o nosso banco de dados. O `CepModel.cs` existe puramente para capturar a resposta em formato JSON da API do ViaCEP e transformar num objeto C# que possamos entender.

---

### Resumo para o Grupo:
Pensem nos Models como as "caixas" onde guardamos as informações. O usuário digita os dados na `UI`, nós colocamos esses dados dentro da "caixa" (o `Model`), passamos essa caixa fechada para a `BLL` validar, e a `BLL` entrega a caixa para a `DAL` finalmente descarregar os dados lá no SQL Server.
