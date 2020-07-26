using System;
using System.Collections.Generic;
using System.IO;
using E_Players.Interfaces;

namespace E_Players.Models
{
    public class Noticias : EPlayersBase , INoticias
    {
        public int IdNoticias { get; set; }

        public string Titulo { get; set; }

        public string Texto { get; set; }
        
        public string Imagem { get; set; }

        private const string PATH = "Database/noticias.csv";

         public Noticias(){
            CreateFolderAndFile(PATH);
        }

        private string PrepararTexto (Noticias n){
            return $"{n.IdNoticias};{n.Titulo};{n.Texto}; {n.Imagem}";
        }

        /// <summary>
        /// Criar um método que volta uma linha(criada em outro métofo PrepararTexto)
        /// </summary>
        /// <param name="n">noticia</param>
        public void Create(Noticias n)
        {
            string[] linha = { PrepararTexto(n) };
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Cria um método que remove linhas
        /// </summary>
        /// <param name="IdNoticias"></param>
        public void Delete(int IdNoticias)
        {
             List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticias.ToString());
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        ///  Uma lista que lê informações como: Titulo
        /// </summary>
        /// <returns>Linha</returns>
        public List<Noticias> ReadAll()
        { 
            List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticia = new Noticias();
                noticia.IdNoticias = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];
               

                noticias.Add(noticia);
            }
            return noticias;
        }

        /// <summary>
        /// Atualiza, lê e remove
        /// </summary>
        /// <param name="n"></param>
        public void Update(Noticias n)
        {
             List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticias.ToString());
            linhas.Add( PrepararTexto(n) );
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        ///  Lista que lê linhas csv
        /// </summary>
        /// <param name="PATH"></param>
        /// <returns></returns>
        public List<string> ReadAllLinesCSV(string PATH){
            
            List<string> linhas = new List<string>();
            using(StreamReader file = new StreamReader(PATH))
            {
                string linha;
                while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }

        /// <summary>
        /// Reescreve o CSV
        /// </summary>
        /// <param name="PATH">Caminho do arquivo</param>
        /// <param name="linhas">Linhas para reescrever o arquivo</param>
        public void RewriteCSV(string PATH, List<string> linhas)
        {
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}