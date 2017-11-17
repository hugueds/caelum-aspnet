using Blog.App_Start;
using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private PostDAO _postsDAO;

        public HomeController(PostDAO dao)
        {
            _postsDAO = dao;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_postsDAO.Lista());
        }

        [HttpGet]
        public ActionResult Visualiza(int id)
        {
            return View(_postsDAO.Busca(id));
        }


        public ActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            IList<Post> posts = _postsDAO.BuscaCategoria(categoria);
            return View("Index", posts);
        }

        [HttpGet]
        public ActionResult Busca(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return RedirectToAction("Index");
            }
            IList<Post> posts = _postsDAO.BuscaPublicado(term);
            return View("Index", posts);
        }

    }

}
