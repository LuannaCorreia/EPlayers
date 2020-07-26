using System.Collections.Generic;
using E_Players.Models;


namespace E_Players.Interfaces
{
    public interface INoticias
    {
        void Create(Noticias n);

         List<Noticias> ReadAll();

         void Update (Noticias n);

         void Delete(int IdNoticias);
    }
}