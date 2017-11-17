using Blog.App_Start;
using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    public class PostController : Controller
    {

        private PostDAO _postDAO;

        public PostController()
        {
        }

        public PostController(PostDAO dao)
        {
            _postDAO = dao;
        }

        public ActionResult Index()
        {
            //return View();
            return View(_postDAO.Lista());
        }

        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Post p)
        {
            if (ModelState.IsValid)
            {
                _postDAO.Adiciona(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Post p = _postDAO.Busca(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Post p)
        {
            if (ModelState.IsValid)
            {
                _postDAO.Edita(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            _postDAO.Deleta(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Publicar(int id)
        {
            await TelegramConfig.Bot.SendTextMessageAsync(170236635, "Publicando artigo de ID " + Convert.ToString(id) + " as " + DateTime.Now);
            _postDAO.Publica(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutoComplete(string term)
        {
            return Json(_postDAO.ListaCategoria(term));
        }

        [HttpGet]
        public ActionResult Dummy()
        {
            Post p = new Post { Categoria = "Dummy", Resumo = "Dummmy", Titulo = "Dumie" };
            _postDAO.Adiciona(p);
            return RedirectToAction("Index");
        }


    }
}