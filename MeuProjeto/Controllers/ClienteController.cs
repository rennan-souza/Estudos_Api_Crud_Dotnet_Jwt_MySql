using MeuProjeto.Dtos;
using MeuProjeto.Models;
using MeuProjeto.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        [Authorize(Roles = "ADMIN, USER")]
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
        [Authorize(Roles = "ADMIN")]
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

        [HttpGet]
        [Route("/clientes/{id}")]
        [Authorize(Roles = "ADMIN, USER")]
        public ActionResult BuscarPorId(int id)
        {
            try
            {
                Cliente cliente = clienteService.BuscarPorId(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("/clientes/{id}")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult Update(int id, [FromBody] ClienteReq clienteReq)
        {
            try
            {
                Cliente cliente = clienteService.Update(id, clienteReq);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete]
        [Route("/clientes/{id}")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult Delete(int id)
        {
            try
            {
                clienteService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
