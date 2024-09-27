using ImoveisPrecoDesktopApp.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImoveisPrecoDesktopApp.Services
{
    internal class SvcReceitas
    {

        private static string connectionString = db.DB.ConnectionStringImoveisDB;

        internal static void AdicionarReceita(Receita receita)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    INSERT INTO receita (descricao, classificacao, valor, data_recebimento, id_imovel)
                    VALUES (@descricao, @classificacao, @valor, @data_recebimento, @id_imovel)", conn);

                command.Parameters.AddWithValue("@descricao", receita.Descricao);
                command.Parameters.AddWithValue("@classificacao", receita.Tipo.GetDescription());
                command.Parameters.AddWithValue("@valor", receita.Valor);
                command.Parameters.AddWithValue("@data_recebimento", receita.DataRecebimento.ToShortDateString());
                command.Parameters.AddWithValue("@id_imovel", receita.ImovelId);

                command.ExecuteNonQuery();
            }
        }

        public static DataTable CarregarReceitasPorImovel(int id_imovel)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    SELECT * FROM receita WHERE id_imovel = @id_imovel", conn);

                command.Parameters.AddWithValue("@id_imovel", id_imovel);

                using (var reader = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return Utils.ConvertColumnToDateTime(dataTable, "data_recebimento");
                }
            }
        }

        public static DataTable CarregarReceitaPorId(int idReceita)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    SELECT * FROM receita WHERE id = @idReceita", conn);

                command.Parameters.AddWithValue("@idReceita", idReceita);

                using (var reader = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return Utils.ConvertColumnToDateTime(dataTable, "data_recebimento");
                }
            }
        }

        public static void ExcluirReceita(int idReceita)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    DELETE FROM receita WHERE id = @idReceita", conn);

                command.Parameters.AddWithValue("@idReceita", idReceita);

                command.ExecuteNonQuery();
            }
        }

        public static void EditarReceita(Receita receita)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    UPDATE receita
                    SET descricao = @descricao,
                        classificacao = @classificacao,
                        valor = @valor,
                        data_recebimento = @data_recebimento                        
                    WHERE id=@idReceita;", conn);

                command.Parameters.AddWithValue("@idDespesa", receita.Id);
                command.Parameters.AddWithValue("@descricao", receita.Descricao);
                command.Parameters.AddWithValue("@classificacao", receita.Tipo);
                command.Parameters.AddWithValue("@valor", receita.Valor);
                command.Parameters.AddWithValue("@data_recebimento", receita.DataRecebimento);

                command.ExecuteNonQuery();
            }

        }

        public static void AdicionarReceitas(List<Receita> receitas, int idImovel)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                
                using (var transacao = conn.BeginTransaction())
                {
                    using (var comando = conn.CreateCommand())
                    {
                        comando.CommandText = "INSERT INTO receita" +
                                              "(descricao, classificacao, valor, data_recebimento, id_imovel)" +
                                              "VALUES (@descricao, @classificacao, @valor, @data_recebimento, @id_imovel)";
                                                
                        comando.Parameters.Add(new SqliteParameter("@descricao", ""));
                        comando.Parameters.Add(new SqliteParameter("@classificacao", ""));
                        comando.Parameters.Add(new SqliteParameter("@valor", 0.0));
                        comando.Parameters.Add(new SqliteParameter("@data_recebimento", ""));
                        comando.Parameters.AddWithValue("@id_imovel", idImovel);

                        try
                        {
                            foreach (var receita in receitas)
                            {
                                comando.Parameters["@descricao"].Value = receita.Descricao;
                                comando.Parameters["@classificacao"].Value = receita.Tipo.GetDescription();
                                comando.Parameters["@valor"].Value = receita.Valor;
                                comando.Parameters["@data_recebimento"].Value = receita.DataRecebimento.ToShortDateString();
                                comando.ExecuteNonQuery();
                            }

                            transacao.Commit();
                        }
                        catch (Exception ex)
                        {
                            transacao.Rollback();
                            Console.WriteLine($"Erro ao inserir registros: {ex.Message}");
                        }
                    }
                }
            }
        }
    }
}
