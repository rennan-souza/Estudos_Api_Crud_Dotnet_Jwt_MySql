using MeuProjeto.Dtos;
using MeuProjeto.Models;
using MeuProjeto.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MeuProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        [Route("/clientes")]
        public ActionResult List()
        {
            try
            {
                List<Cliente> list = clienteService.List();
                return Ok(list);
            } catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("/clientes")]
        public ActionResult Cadastrar([FromBody] ClienteReq clienteReq)
        {
            try
            {
                Cliente cliente = clienteService.Cadastrar(clienteReq);
                return Ok(cliente);
            } catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
