using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSOFT.AppModelo.Data;
using CMSOFT.AppModelo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMSOFT.AppModelo.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _context;

        public TesteCrudController(MeuDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Nome = "Cristiano",
                DataNascimento = DateTime.Now,
                Email = "cristiano@cristiano.com.br"

            };

            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            var aluno2 = _context.Alunos.Find(aluno.Id);
            var aluno3 = _context.Alunos.FirstOrDefault(a => a.Email == "cristiano@cristiano.com.br");
            var aluno4 = _context.Alunos.Where(a => a.Nome == "Cristiano");

            aluno.Nome = "Paulo";

            _context.Alunos.Update(aluno);
            _context.SaveChanges();

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();

            return View("_Layout");
        }
    }
}