using System;
using System.Data;
using System.Windows.Forms;
using PetShopSystem.DAL;
using PetShopSystem.Models;

namespace PetShopSistema.UI
{
    public partial class FormCliente : Form
    {
        private int idClienteLogado;
        private int idAgendamentoSelecionado = 0;

        private AgendamentoDAL agendamentoDAL = new AgendamentoDAL();
        private PetDAL petDAL = new PetDAL();
        private ServicoDAL servicoDAL = new ServicoDAL();

        public FormCliente(int idUsuario)
        {
            InitializeComponent();
            idClienteLogado = idUsuario;
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            CarregarPets();
            CarregarServicos();
            AtualizarGridAgendamentos();
        }

        private void CarregarPets()
        {
            cmbPets.DataSource = petDAL.ListarPorCliente(idClienteLogado);
            cmbPets.DisplayMember = "Nome";
            cmbPets.ValueMember = "IdPet";
        }

        private void CarregarServicos()
        {
            cmbServicos.DataSource = servicoDAL.ListarTodos();
            cmbServicos.DisplayMember = "NomeServico";
            cmbServicos.ValueMember = "IdServico";
        }

        private void AtualizarGridAgendamentos()
        {
            dgvAgendamentos.DataSource = agendamentoDAL.ListarAgendamentosDoCliente(idClienteLogado);
        }

        private void btnAgendar_Click_1(object sender, EventArgs e)
        {
            if (cmbPets.SelectedValue == null || cmbServicos.SelectedValue == null)
            {
                MessageBox.Show("Selecione um Pet e um Serviço!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Agendamento novoAgendamento = new Agendamento();
                novoAgendamento.DataAgendamento = dtpDataHora.Value;
                novoAgendamento.IdPet = (int)cmbPets.SelectedValue;
                novoAgendamento.IdServico = (int)cmbServicos.SelectedValue;

                agendamentoDAL.Agendar(novoAgendamento);

                MessageBox.Show("Agendamento realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarGridAgendamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao agendar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAgendamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgvAgendamentos.Rows[e.RowIndex];

                idAgendamentoSelecionado = Convert.ToInt32(linha.Cells["Nº Agendamento"].Value);

                cmbPets.Text = linha.Cells["Pet"].Value.ToString();
                cmbServicos.Text = linha.Cells["Serviço"].Value.ToString();
                dtpDataHora.Value = Convert.ToDateTime(linha.Cells["Data e Hora"].Value);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idAgendamentoSelecionado == 0)
            {
                MessageBox.Show("Clique em um agendamento na tabela primeiro para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Agendamento agendamentoEditado = new Agendamento();
                agendamentoEditado.IdAgendamento = idAgendamentoSelecionado;
                agendamentoEditado.DataAgendamento = dtpDataHora.Value;
                agendamentoEditado.IdPet = (int)cmbPets.SelectedValue;
                agendamentoEditado.IdServico = (int)cmbServicos.SelectedValue;

                agendamentoDAL.Atualizar(agendamentoEditado);

                MessageBox.Show("Agendamento atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idAgendamentoSelecionado = 0;
                AtualizarGridAgendamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (idAgendamentoSelecionado == 0)
            {
                MessageBox.Show("Clique em um agendamento na tabela para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacao = MessageBox.Show("Deseja realmente cancelar este agendamento?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    agendamentoDAL.Excluir(idAgendamentoSelecionado);
                    MessageBox.Show("Agendamento cancelado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    idAgendamentoSelecionado = 0;
                    AtualizarGridAgendamentos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao remover: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Sair;
            Sair = MessageBox.Show("Deseja mesmo sair do sistema?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Sair == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cmbPets_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}