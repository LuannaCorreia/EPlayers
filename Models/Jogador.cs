using E_Players.Interfaces;

namespace E_Players.Models
{
    public class Jogador : EPlayersBase , IJogador 
    {
        public int IdJogador { get; set; }
        
        public string Nome { get; set; }

        public int IdEquipe { get; set; }
    }
}
