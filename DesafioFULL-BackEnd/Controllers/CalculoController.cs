using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFULL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFULL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            try
            {
                return "Teste";
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new MensagemDeErro { Mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Divida>> Post(Divida divida)
        {
            try
            {
                divida.CalculaDivida();

                return Ok(divida);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new MensagemDeErro { Mensagem = ex.Message });
            }
        }
    }
}
