using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ImoveisPrecoDesktopApp.Services
{
    public static class SvcCorrecaoMonetaria
    {
        private static readonly HttpClient _client = new HttpClient();
        public static Dictionary<DateTime, double> indicesCorrecao = new Dictionary<DateTime, double>();

        private static string GetTaxaTR(DateTime dataInicial)
        {
            string dataFinal = DateTime.Today.ToShortDateString();             

            string url = $"https://api.bcb.gov.br/dados/serie/bcdata.sgs.226/dados?formato=json&dataInicial={dataInicial.ToShortDateString()}&dataFinal={dataFinal}";
            HttpResponseMessage response = _client.GetAsync(url).Result; // Sincrono
            response.EnsureSuccessStatusCode(); // Lança exceção se o status não for 200-299
            return response.Content.ReadAsStringAsync().Result; // Sincrono
        }

        private static string ConvertJsonToCsv(string jsonData)
        {
            JArray jsonArray = JArray.Parse(jsonData);
            using (StringWriter sw = new StringWriter())
            {
                // Adiciona cabeçalho CSV
                sw.WriteLine("Data,Valor");

                foreach (JObject item in jsonArray)
                {
                    string date = item["data"]?.ToString();
                    string value = item["valor"]?.ToString();
                    sw.WriteLine($"{date},{value}");
                }

                return sw.ToString();
            }
        }

        public static void BuscarHistoricoTRCsv()
        {
            try
            {
                
                DateTime dataInicial = DateTime.ParseExact("21/02/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //SvcCorrecaoMonetaria apiService = new SvcCorrecaoMonetaria();
                string trDataJson = GetTaxaTR(dataInicial);

                // Converta os dados JSON para CSV
                string csvData = ConvertJsonToCsv(trDataJson);

                string relativeFolderPath = @"resources"; // Nome da pasta relativa dentro do diretório do projeto
                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName; // Diretório do projeto
                string folderPath = Path.Combine(projectDirectory, relativeFolderPath);
                string filePath = Path.Combine(folderPath, "taxa_tr.csv");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                File.WriteAllText(Path.Combine(folderPath, "taxa_tr.csv"), csvData);

                Console.WriteLine("Taxas TR salvas com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }


        private static Dictionary<DateTime, double> ConvertJsonToDictionary(string jsonData)
        {
            var dictionary = new Dictionary<DateTime, double>();
            JArray jsonArray = JArray.Parse(jsonData);

            foreach (JObject item in jsonArray)
            {
                string dateStr = item["data"]?.ToString();
                string valueStr = item["valor"]?.ToString();

                try
                {
                    var data = DateTime.Parse(dateStr);
                    var valor = double.Parse(valueStr, CultureInfo.InvariantCulture);

                    dictionary[data] = valor;
                }
                catch
                {
                }
            }

            return dictionary;
        }

        //public static Dictionary<DateTime, double> BuscarHistoricoTR(DateTime dataInicial)
        //{
        //    try
        //    {
        //        string trDataJson = GetTaxaTR(dataInicial);

        //        // Converta os dados JSON para um dicionário
        //        return ConvertJsonToDictionary(trDataJson);                               
                
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Erro ao coletar os índices de correção monetária no BACEN");
        //        return new Dictionary<DateTime, double> { };
        //    }
        //}

        public static void BuscarHistoricoTR(DateTime dataInicial)
        {
            try
            {
                string trDataJson = GetTaxaTR(dataInicial);

                // Converta os dados JSON para um dicionário
                indicesCorrecao = ConvertJsonToDictionary(trDataJson);

            }
            catch
            {
                MessageBox.Show("Erro ao coletar os índices de correção monetária no BACEN");                
            }
        }
    }

}
