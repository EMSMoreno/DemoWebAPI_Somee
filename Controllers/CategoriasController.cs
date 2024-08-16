using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Linq;
using System.Web.Http;
using System.Xml.Linq;

namespace DemoWebAPIDemo.Controllers
{
    public class CategoriasController : ApiController
    {
        private readonly DataClasses1DataContext dc = new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["VideoClube_2ConnectionString"].ConnectionString);

        // GET: api/Categorias
        public List<Categoria> Get()
        {
            List<Categoria> categorias = new List<Categoria>();

            try
            {
                using (var dc = new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["VideoClube_2ConnectionString"].ConnectionString))
                {
                    categorias = dc.Categorias.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar acessar à tabela Categorias: " + ex.Message, ex);
            }

            return categorias;
        }

        // GET: api/Categorias/5
        public IHttpActionResult Get(string id)
        {
            var categoria = dc.Categorias.SingleOrDefault(c => c.Sigla == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // POST: api/Categorias
        public IHttpActionResult Post([FromBody] Categoria novaCategoria)
        {
            Categoria categoriaExistente = dc.Categorias.SingleOrDefault(c => c.Sigla == novaCategoria.Sigla);

            if (categoriaExistente != null)
            {
                return Conflict();
            }

            dc.Categorias.InsertOnSubmit(novaCategoria);

            try
            {
                dc.SubmitChanges();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok();
        }

        // PUT: api/Categorias/5
        public IHttpActionResult Put(string id, [FromBody] Categoria categoriaAlterada)
        {
            Categoria categoria = dc.Categorias.SingleOrDefault(c => c.Sigla == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.Sigla = categoriaAlterada.Sigla;

            try
            {
                dc.SubmitChanges();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok();
        }

        // DELETE: api/Categorias/5
        public IHttpActionResult Delete(string id)
        {
            Categoria categoria = dc.Categorias.SingleOrDefault(c => c.Sigla == id);

            if (categoria == null)
            {
                return NotFound();
            }

            dc.Categorias.DeleteOnSubmit(categoria);

            try
            {
                dc.SubmitChanges();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok();
        }
    }
}