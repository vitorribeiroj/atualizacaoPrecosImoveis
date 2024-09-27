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
    public static class SvcAluguel
    {
        private static string connectionString = db.DB.ConnectionStringImoveisDB;

        public static DataTable BuscarAluguelPorImovel(int idImovel)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    SELECT * FROM aluguel WHERE idImovel = @idImovel", conn);

                command.Parameters.AddWithValue("@idImovel", idImovel);

                using (var reader = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
        }

        public static void AdicionarAluguel(Aluguel aluguel)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    INSERT INTO aluguel (valor, taxaIntermediacao, taxaAdministracao, impostoDeRenda, idImovel)
                    VALUES (@valor, @taxaIntermediacao, @taxaAdministracao, @impostoDeRenda, @idImovel)"
                , conn);

                command.Parameters.AddWithValue("@valor", aluguel.Valor);
                command.Parameters.AddWithValue("@taxaIntermediacao", aluguel.TaxaIntermediacao);
                command.Parameters.AddWithValue("@taxaAdministracao", aluguel.TaxaAdministracao);
                command.Parameters.AddWithValue("@impostoDeRenda", aluguel.ImpostoDeRenda);
                command.Parameters.AddWithValue("@idImovel", aluguel.IdImovel);                

                command.ExecuteNonQuery();
            }
        }

        internal static void AtualizarAluguel(Aluguel aluguel)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    UPDATE aluguel 
                    SET valor = @valor,
                        taxaIntermediacao = @taxaIntermediacao,
                        taxaAdministracao = @taxaAdministracao,
                        impostoDeRenda = @impostoDeRenda                        
                    WHERE idImovel = @idImovel"
                , conn);

                command.Parameters.AddWithValue("@valor", aluguel.Valor);
                command.Parameters.AddWithValue("@taxaIntermediacao", aluguel.TaxaIntermediacao);
                command.Parameters.AddWithValue("@taxaAdministracao", aluguel.TaxaAdministracao);
                command.Parameters.AddWithValue("@impostoDeRenda", aluguel.ImpostoDeRenda);
                command.Parameters.AddWithValue("@idImovel", aluguel.IdImovel);

                command.ExecuteNonQuery();
            }
        }
    }
}
