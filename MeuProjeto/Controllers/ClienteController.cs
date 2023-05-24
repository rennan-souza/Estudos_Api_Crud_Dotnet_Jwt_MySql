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
                return BadRequest(ex);
            }
        }
    }
}
