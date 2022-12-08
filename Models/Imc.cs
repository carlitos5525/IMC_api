namespace icm_api.Models
{
    public class Imc
    {
        public int Id {get; set;}
        public float Altura {get; set;}
        public float Peso {get; set;}
        public float Imc_resultado {get; set;}
        public string Classificacao_IMC {get; set;}
        public int UsuarioId {get; set;}
        public Usuario Usuario {get; set;}

    }
}