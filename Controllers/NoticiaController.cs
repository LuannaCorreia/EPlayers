using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Players.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace E_Players.Controllers
{
    public class NoticiaController : Controller
    {
        Noticias noticiaModel = new Noticias();

        public IActionResult Index()
        {
          
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();
        }

        public IActionResult Cadastro(IFormCollection form){

        Noticias noticia = new Noticias();
        noticia.IdNoticias = Int32.Parse(form ["IdNoticias"]);
        noticia.Titulo = form["Titulo"];
        noticia.Texto = form["Texto"];

        noticia.Imagem = form["Imagem"];
        var file    = form.Files[0];
        var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            if(file != null)
            {
            if(!Directory.Exists(folder)){
            Directory.CreateDirectory(folder);
            }
            //FileName -> arquivo.pdf ou jpg
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))  
            {  
                file.CopyTo(stream);  
            }
             noticia.Imagem   = file.FileName;
            }
            else
            {
                noticia.Imagem   = "padrao.png";
            }

        noticiaModel.Create(noticia);

        ViewBag.Noticia = noticiaModel.ReadAll();
        return LocalRedirect("~/Noticia");

        }

       [Route("[controller]/{id}")]
        public IActionResult Excluir(int id){
            noticiaModel.Delete(id);
            return LocalRedirect("~/Noticia");
        }
    }
}
