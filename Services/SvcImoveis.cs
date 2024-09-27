using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ImoveisPrecoDesktopApp.db;
using ImoveisPrecoDesktopApp.Models;
using Microsoft.Data.Sqlite;

namespace ImoveisPrecoDesktopApp.Services
{
    internal static class SvcImoveis
    {
        static string connectionString = db.DB.ConnectionStringImoveisDB;

        public static Imovel CarregarImovel(int id)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    SELECT * FROM imoveis WHERE id = @id", conn);

                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Imovel.Builder()
                            .SetId(Convert.ToInt32(reader["id"]))
                            .SetApelido(reader["apelido"].ToString())
                            .SetLogradouro(reader["logradouro"].ToString())
                            .SetNumero(reader["numero"].ToString())
                            .SetComplemento(reader["complemento"].ToString())
                            .SetBairro(reader["bairro"].ToString())
                            .SetCidade(reader["cidade"].ToString())
                            .SetEstado(reader["estado"].ToString())
                            .SetCep(reader["cep"].ToString())
                            .SetFotoPath(reader["caminho_foto"].ToString())                           
                            .Build();                       
                    }
                }
            }

            return null;
        }
    
        public static DataTable ListarTodosOsImoveis()
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"SELECT * FROM imoveis", conn);                

                using (var reader = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }

            return null;
        }
    
        public static DataTable ListarImoveisFiltrados(List<string> atributosClasulasWHERE)
        {
            string consulta = ConsultasSQL.selecionarImoveis;

            var numeroAtributos = atributosClasulasWHERE.Count;

            if(numeroAtributos > 0)
            {
                consulta += " WHERE ";

                foreach (var atributo in atributosClasulasWHERE)
                {
                    if (numeroAtributos > 1)
                    {
                        consulta += $"{atributo} AND ";
                        numeroAtributos--;
                    }
                    else
                    {
                        consulta += $"{atributo}";
                    }
                }
            }            

            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                try
                {
                    var command = new SqliteCommand(consulta, conn);

                    using (var reader = command.ExecuteReader())
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
                catch
                {
                    MessageBox.Show("Nenhum imóvel encontrado");
                }
            }

            return null;
        }
    
        public static void EditarImovel(Imovel imovel)
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                var command = new SqliteCommand(@"
                    UPDATE imoveis
                    SET apelido = @apelido,
                        logradouro = @logradouro,
                        numero = @numero,
                        complemento = @complemento,
                        bairro = @bairro,
                        cidade = @cidade,
                        estado = @estado,
                        cep = @cep,
                        caminho_foto = @caminho_foto
                    WHERE id=@id;", conn);

                command.Parameters.AddWithValue("@id", imovel.Id);
                command.Parameters.AddWithValue("@apelido", imovel.Apelido);
                command.Parameters.AddWithValue("@logradouro", imovel.Logradouro);
                command.Parameters.AddWithValue("@numero", imovel.Numero);
                command.Parameters.AddWithValue("@complemento", imovel.Complemento);
                command.Parameters.AddWithValue("@bairro", imovel.Bairro);
                command.Parameters.AddWithValue("@cidade", imovel.Cidade);
                command.Parameters.AddWithValue("@estado", imovel.Estado);
                command.Parameters.AddWithValue("@cep", imovel.Cep);
                command.Parameters.AddWithValue("@caminho_foto", imovel.FotoPath);
                
                command.ExecuteNonQuery();
            }
        }
    
    }
}
