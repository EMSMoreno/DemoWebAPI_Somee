using DemoWebAPIDemo___Eduardo_M.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebAPIDemo___Eduardo_M.Controllers
{
    public class EmpregadoController : ApiController
    {
        private List<Empregado> Funcionarios;

        public EmpregadoController()
        {
            Funcionarios = new List<Empregado>
            {
                new Empregado {ID = 1, Nome = "Joana", Apelido = "Matos"},
                new Empregado {ID = 2, Nome = "Carlota", Apelido = "Morais"},
                new Empregado {ID = 3, Nome = "Rui", Apelido = "Santos"}
            };
        }

        // GET: api/Empregado
        public List<Empregado> Get()
        {
            return Funcionarios;
        }

        // GET: api/Empregado/5
        /// <summary>
        /// Dados completos do empregado
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>retorna Empregado</returns>
        public Empregado Get(int id)
        {
            return Funcionarios.FirstOrDefault(x => x.ID == id);
        }

        // GET: api/Empregado/GetNomes
        /// <summary>
        /// Nome próprio de todos os empregados
        /// </summary>
        /// <returns>lista com os nomes de todos os empregados</returns>
        [Route("api/empregado/GetNomes")]

        public List<string> GetNomes()
        {
            List<string> output = new List<string>();

            foreach (var e in Funcionarios)
            {
                output.Add(e.Nome);
            }

            return output;
        }
        /// <summary>
        /// Registo de novo empregado
        /// </summary>
        /// <param name="valor">Empregado</param>
        // POST: api/Empregado
        public void Post([FromBody]Empregado valor)
        {
            Funcionarios.Add(valor);
        }

        // PUT: api/Empregado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Empregado/5
        public void Delete(int id)
        {

        }
    }
}
