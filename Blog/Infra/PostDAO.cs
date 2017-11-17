using Blog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Infra
{
    public class PostDAO
    {
        private BlogContext _ctx;

        public PostDAO(BlogContext ctx)
        {
            _ctx = ctx;
        }

        public IList<Post> Lista()
        {
            return _ctx.Post.ToList();
        }

        public void Adiciona(Post p)
        {
            _ctx.Post.Add(p);
            _ctx.SaveChanges();
        }

        public void Deleta(int id)
        {
            try
            {
                Post p = _ctx.Post.Find(id);
                _ctx.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public IList<Post> BuscaCategoria(string categoria)
        {
            return (from p in _ctx.Post where p.Categoria.Contains(categoria) select p).ToList();
        }

        public IList<string> ListaCategoria(string partial)
        {
            using (BlogContext ctx = new BlogContext())
            {
                return _ctx.Post.Where(p => p.Categoria.Contains(partial))
                    .Select(p => p.Categoria)
                    .Distinct()
                    .ToList();
                // return (from p in ctx.Post where p.Categoria.Contains(partial) select p).Distinct().ToList();
            }
        }

        public Post Busca(int id)
        {
            return _ctx.Post.Find(id);
        }

        public void Edita(Post p)
        {
            _ctx.Entry(p).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void Publica(int id)
        {
            Post p = Busca(id);
            p.Publicado = true;
            p.Timestamp = DateTime.Now;
            _ctx.Entry(p).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
        }

        public IList<Post> BuscaPublicado(string term)
        {
            return _ctx.Post
                .Where(p => (p.Publicado) && (p.Titulo.Contains(term) || p.Resumo.Contains(term)))
                .Select(p => p)
                .ToList();
        }
    }

}
