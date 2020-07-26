using System.Collections.Generic;
using E_Players.Models;


namespace E_Players.Interfaces
{
    public interface IEquipe
    {
         void Create(Equipe e);

         List<Equipe> ReadAll();

         void Update (Equipe e);

         void Delete(int IdEquipe);
    }
}