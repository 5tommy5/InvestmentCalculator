using InvestmentCalculator.Entities;
using InvestmentCalculator.Extension;
using InvestmentCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentCalculator.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly ApplicationContext _db;
        private readonly Calculator _calculator;
        public InvestmentController(ApplicationContext db, Calculator calculator)
        {
            _db = db;

            _calculator = calculator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_db.Investments.ToList());
        }

        [HttpPost]
        public IActionResult Add(Investment investment)
        {
            _db.Investments.Add(investment);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Investment investment)
        {
            var inv = _db.Investments.Find(investment.Id);

            inv.Copy(investment);

            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var inv = _db.Investments.Find(id);

            _db.Investments.Remove(inv);
            _db.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult Calculate(int years)
        {
            var res = _calculator.Calculate(years);

            return Ok(res);
        }
    }
}
