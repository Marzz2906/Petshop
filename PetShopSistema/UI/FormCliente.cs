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

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            if (cmbPets.SelectedValue == null || cmbServicos.SelectedValue == null)
            {
                MessageBox.Show("Selecione um Pet e um Serviço!");
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
                MessageBox.Show("Erro ao agendar: " + ex.Message);
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

        private void dgvAgendamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbPets_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}