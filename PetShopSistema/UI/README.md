# Camada de Interface de Usuário (UI) - PetShopSistema

Esta pasta (`UI`) contém toda a parte visual e de interação com o usuário (Frontend) do nosso sistema, construída utilizando o Windows Forms (WinForms) em C#. 

O padrão utilizado no projeto separa a visualização (UI) das regras de negócio (BLL) e do acesso ao banco de dados (DAL). Isso significa que as telas aqui dentro **não** executam comandos SQL diretamente; em vez disso, elas instanciam objetos da pasta `Models` e usam métodos das pastas `DAL` (Data Access Layer) e `BLL` (Business Logic Layer) para lidar com os dados.

Abaixo está a explicação de cada tela (Form) que compõe a interface do nosso sistema, focando tanto no conceito quanto nos aspectos técnicos do código fonte (os arquivos `.cs`):

---

## 1. FormLogin
- **Objetivo:** É a porta de entrada do sistema, onde ocorre a autenticação.
- **Funcionamento Técnico:**
  - **Eventos Principais:** O botão de login (ex: `btnLogin_Click`) lê os valores de `txtEmail.Text` e `txtSenha.Text`.
  - **Tratamento de Dados:** Usa a função `Trim()` para remover espaços em branco indesejados (ex: `txtEmail.Text.Trim()`) e verifica se os campos estão em branco com `string.IsNullOrWhiteSpace()`.
  - **Segurança (Criptografia):** A senha digitada pelo usuário não vai pura para o banco de dados. Ela é passada pelo método estático `Seguranca.CriptografarSenha(senhaDigitada)` (da pasta `Utils`) para gerar o Hash que será comparado com o que está salvo no banco.
  - **Navegação (Instanciação de Telas):** Para abrir a tela de cadastro, o formulário instancia o outro com a instrução: `FormCadastro telaCadastro = new FormCadastro(this);`, passa a própria instância do FormLogin usando o `this` (para poder voltar depois) e usa o método `this.Hide()` para esconder a tela de login atual.

## 2. FormCadastro
- **Objetivo:** Permitir que novos clientes se registrem no sistema.
- **Funcionamento Técnico:**
  - **Construtor Personalizado:** Recebe por parâmetro o formulário de login (`public FormCadastro(Form login)`). Ele guarda essa instância na variável privada `telaLoginOrigem` para que o botão "Voltar" (ex: `btnVoltar_Click`) consiga chamar `telaLoginOrigem.Show()` novamente.
  - **Manipulação de Modelos:** No evento de cadastrar (`btnCadastrar_Click`), ele cria um novo objeto da classe Modelo (`Usuario novoUsuario = new Usuario()`) e preenche suas propriedades diretamente do texto dos componentes visuais (ex: `novoUsuario.Nome = txtNome.Text`).
  - **Encerramento:** Possui também manipulação do `DialogResult` usando `MessageBox.Show()` para questionar se o usuário deseja fechar a aplicação por completo, invocando `Application.Exit()`.

## 3. FormCliente
- **Objetivo:** É o painel principal (Dashboard) para o cliente.
- **Funcionamento Técnico:**
  - **Estado Global:** O formulário recebe o ID do cliente que acabou de logar através do seu construtor (`public FormCliente(int idUsuario)`) e o salva na variável privada `idClienteLogado`. Dessa forma, o formulário sempre sabe de quem são os dados que deve buscar.
  - **Comunicação com a DAL:** O formulário cria instâncias privadas globais das classes de acesso a dados: `agendamentoDAL`, `petDAL` e `servicoDAL`.
  - **Evento de Carregamento (`Load`):** O evento `FormCliente_Load` dispara as funções essenciais para preencher a tela logo ao abrir, chamando métodos que alimentam os DataGridViews, como `CarregarPets()`, `CarregarServicos()` e `AtualizarGridAgendamentos()`.

## 4. FormAdm
- **Objetivo:** É o painel de controle global para os administradores do PetShop.
- **Funcionamento Técnico:**
  - **Independência de ID:** Diferente do formulário de cliente, o `FormAdm` não precisa receber um ID no construtor, pois ele busca informações gerais do sistema inteiro (como a lista de todos os pets).
  - **Manipulação de Grids (DataBinding):** O evento `AtualizarGrid()` utiliza a propriedade `DataSource` do DataGridView (tabela visual) para atrelar diretamente a lista de dados trazida pelo banco. O código faz:
    ```csharp
    dgvPets.DataSource = null; // Limpa a tabela
    dgvPets.DataSource = petDAL.ListarTodos(); // Preenche com a nova lista de pets
    ```
  - **Variáveis de Controle:** Utiliza variáveis privadas para controle de estado da tela, como `idPetSelecionado = 0;`, para saber se o administrador clicou em uma linha do Grid e deseja editar ou excluir aquele registro específico.

---

### Dicas de Arquitetura para o Grupo:
- **Separação Responsável:** Reparem que **nenhum** desses formulários (os arquivos `.cs` da pasta UI) possui `using System.Data.SqlClient;`. Isso significa que eles não abrem conexão com o banco nem rodam comandos `SELECT` ou `INSERT`. Eles servem estritamente para capturar cliques, ler textos das caixinhas e enviar para os objetos `DAL` fazerem o "trabalho sujo".
- Os arquivos `.Designer.cs` são gerados automaticamente pelo Visual Studio. Vocês quase nunca precisarão mexer neles manualmente. O código que vocês escrevem fica sempre no arquivo `.cs` principal de cada Form.
