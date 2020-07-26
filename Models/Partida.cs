using System;
using E_Players.Interfaces;

namespace E_Players.Models
{
    public class Partida : EPlayersBase , IPartida
    {
        public int IdPartida { get; set; }

        public int IdEquipe1 { get; set; }

        public int IdEquipe2 { get; set; }

        public DateTime Horario { get; set; }
    }
}