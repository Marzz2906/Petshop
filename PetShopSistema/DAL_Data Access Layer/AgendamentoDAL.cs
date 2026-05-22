using PetShopSistema.DAL_Data_Access_Layer;
using PetShopSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace PetShopSystem.DAL
{
    public class AgendamentoDAL
    {
        private Conexao conexao = new Conexao();

        public void Agendar(Agendamento agendamento)
        {
            string sql = @"INSERT INTO Agendamento (dt_agendamento, cd_pet, cd_servico) 
                           VALUES (@data, @idPet, @idServico)";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@data", agendamento.DataAgendamento);
                cmd.Parameters.AddWithValue("@idPet", agendamento.IdPet);
                cmd.Parameters.AddWithValue("@idServico", agendamento.IdServico);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarAgendamentosGerais()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT A.cd_agendamento AS [Código], A.dt_agendamento AS [Data], P.nm_pet AS [Pet], 
                                  S.nm_servico AS [Serviço], A.cd_statusAgendamento AS [Status]
                           FROM Agendamento A
                           INNER JOIN Pet P ON A.cd_pet = P.cd_pet
                           INNER JOIN Servico S ON A.cd_servico = S.cd_servico";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable ListarAgendamentosDoCliente(int idUsuario)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT 
                    A.cd_agendamento AS 'Nº Agendamento',
                    A.dt_agendamento AS 'Data e Hora',
                    P.nm_pet AS 'Pet',
                    S.nm_servico AS 'Serviço',
                    S.vl_preco AS 'Valor (R$)',
                    A.cd_statusAgendamento AS 'Status'
                FROM Agendamento A
                INNER JOIN Pet P ON A.cd_pet = P.cd_pet
                INNER JOIN Usuario U ON P.cd_usuario = U.cd_usuario
                INNER JOIN Servico S ON A.cd_servico = S.cd_servico
                WHERE U.cd_usuario = @idUsuario
                ORDER BY A.dt_agendamento ASC;";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // --- NOVOS MÉTODOS: ATUALIZAR E EXCLUIR ---

        public void Atualizar(Agendamento agendamento)
        {
            string sql = @"UPDATE Agendamento 
                           SET dt_agendamento = @data, cd_pet = @idPet, cd_servico = @idServico 
                           WHERE cd_agendamento = @idAgendamento";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@idAgendamento", agendamento.IdAgendamento);
                cmd.Parameters.AddWithValue("@data", agendamento.DataAgendamento);
                cmd.Parameters.AddWithValue("@idPet", agendamento.IdPet);
                cmd.Parameters.AddWithValue("@idServico", agendamento.IdServico);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int idAgendamento)
        {
            string sql = "DELETE FROM Agendamento WHERE cd_agendamento = @idAgendamento";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@idAgendamento", idAgendamento);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}