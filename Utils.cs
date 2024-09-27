using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImoveisPrecoDesktopApp
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class DescriptionAttribute : Attribute
    {
        public string Description { get; }

        public DescriptionAttribute(string description)
        {
            Description = description;
        }
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            // Obtém o campo do enum
            FieldInfo field = value.GetType().GetField(value.ToString());

            // Obtém o atributo DescriptionAttribute do campo
            DescriptionAttribute attribute = field
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault();

            // Retorna a descrição ou o nome do valor do enum
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static T GetEnumByDescription<T>(string description) where T : Enum
        {
            // Obtém o tipo do enum
            Type type = typeof(T);

            // Obtém todos os campos do tipo enum
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);

            // Percorre todos os campos do enum
            foreach (FieldInfo field in fields)
            {
                // Obtém o atributo DescriptionAttribute do campo
                DescriptionAttribute attribute = field
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .Cast<DescriptionAttribute>()
                    .FirstOrDefault();

                // Verifica se a descrição corresponde ao valor fornecido
                if (attribute != null && attribute.Description == description)
                {
                    // Retorna o valor correspondente
                    return (T)field.GetValue(null);
                }
            }

            // Se nenhum valor foi encontrado, retorna o valor padrão
            throw new ArgumentException($"Descrição '{description}' não encontrada para o enum '{type.Name}'.");
        }
    }

    public enum EstadosFederativos
    {
        AC,
        AL,
        AP,
        AM,
        BA,
        CE,
        DF,
        ES,
        GO,
        MA,
        MT,
        MS,
        MG,
        PA,
        PB,
        PR,
        PE,
        PI,
        RJ,
        RN,
        RS,
        RO,
        RR,
        SC,
        SP,
        SE,
        TO
    }

    public static class Utils
    {
        public static double AliquotaGanhoCapitalIR = 0.15;

        public static string GenerateUniqueKey()
        {
            return Guid.NewGuid().ToString();
        }

        public static DataTable ConvertColumnToDateTime(DataTable dataTable, string columnName)
        {
            // Verifica se a coluna existe
            if (!dataTable.Columns.Contains(columnName))
            {
                throw new ArgumentException($"A coluna {columnName} não existe no DataTable.");
            }

            // Adiciona uma nova coluna temporária do tipo DateTime
            DataColumn newColumn = new DataColumn(columnName + "_DateTime", typeof(DateTime));
            dataTable.Columns.Add(newColumn);

            // Converte os valores da coluna original para DateTime e armazena na nova coluna
            foreach (DataRow row in dataTable.Rows)
            {
                string dateString = row[columnName] as string;
                if (DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
                {
                    row[newColumn.ColumnName] = dateValue;
                }
                else
                {
                    row[newColumn.ColumnName] = DBNull.Value; // Ou defina um valor padrão, se necessário
                }
            }

            // Remove a coluna original e renomeia a nova coluna
            dataTable.Columns.Remove(columnName);
            newColumn.ColumnName = columnName;

            return dataTable;
        }

        public static int CalcularDiferencaMeses(DateTime dataInicio, DateTime dataFim)
        {
            int anos = dataFim.Year - dataInicio.Year;
            int meses = dataFim.Month - dataInicio.Month;

            return anos * 12 + meses;
        }
    }

    public static class TextBoxFormatter
    {
        public static void FormatTextBox(TextBox textBox)
        {
            // Obter o texto atual
            string text = textBox.Text;

            // Remover caracteres não numéricos (exceto vírgula)
            text = text.Replace(".", "").Replace(",", "");

            // Verificar se a entrada é um número válido
            if (double.TryParse(text, out double number))
            {
                // Formatar o número no formato #.0,00
                textBox.Text = number.ToString("#,0.00", CultureInfo.InvariantCulture).Replace(".", ",");
            }
            else
            {
                textBox.Text = "";
            }

            // Ajustar o cursor para a posição correta após a formatação
            textBox.SelectionStart = textBox.Text.Length;

            // Reassociar o evento
            //textBox.TextChanged += TextBox_TextChanged;
        }
        public static void RegisterTextBox(TextBox textBox)
        {
            textBox.Leave += TextBox_Leave;
        }

        private static void TextBox_Leave(object sender, EventArgs e)
        {
            // Método a ser utilizado no evento TextChanged dos TextBox
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                FormatTextBox(textBox);
            }
        }
    }



    
}
