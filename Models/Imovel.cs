
namespace ImoveisPrecoDesktopApp.Models
{
    public class Imovel
    {        
        public int Id { get; private set; }
        public string Apelido { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; } = "-";
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string FotoPath { get; set; }
        //public virtual ICollection<Receita> Receitas { get; set; }
        //public virtual ICollection<Despesa> Despesas { get; set; }

        // Construtor privado
        private Imovel() { }

        // Método para criar o Builder
        public static ImovelBuilder Builder()
        {
            return new ImovelBuilder();
        }

        // Classe interna Builder
        public class ImovelBuilder
        {
            private readonly Imovel _imovel;

            public ImovelBuilder()
            {
                _imovel = new Imovel();
            }

            public ImovelBuilder SetId(int id)
            {
                _imovel.Id = id;
                return this;
            }

            public ImovelBuilder SetApelido(string apelido)
            {
                _imovel.Apelido = apelido;
                return this;
            }

            public ImovelBuilder SetLogradouro(string logradouro)
            {
                _imovel.Logradouro = logradouro;
                return this;
            }

            public ImovelBuilder SetNumero(string numero)
            {
                _imovel.Numero = numero;
                return this;
            }

            public ImovelBuilder SetComplemento(string complemento)
            {
                if (!string.IsNullOrEmpty(complemento))
                {
                    _imovel.Complemento = complemento;
                }
                return this;
            }

            public ImovelBuilder SetBairro(string bairro)
            {
                _imovel.Bairro = bairro;
                return this;
            }

            public ImovelBuilder SetCidade(string cidade)
            {
                _imovel.Cidade = cidade;
                return this;
            }

            public ImovelBuilder SetEstado(string estado)
            {
                _imovel.Estado = estado;
                return this;
            }

            public ImovelBuilder SetCep(string cep)
            {
                _imovel.Cep = cep;
                return this;
            }

            public ImovelBuilder SetFotoPath(string fotoPath)
            {
                _imovel.FotoPath = fotoPath;
                return this;
            }

            public Imovel Build()
            {
                // Aqui você pode adicionar validações, se necessário
                return _imovel;
            }
        }
    }
}
