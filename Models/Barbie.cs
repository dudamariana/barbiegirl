namespace barbiegirl.Models;

    public class Barbie
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<string> Tipo { get; set; }
        public string Imagem { get; set; }
        // Método Construtor
        public Barbie()
        {
            Tipo = new List<string>();
        }
    }
