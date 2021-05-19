using System;
using System.Threading.Tasks;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClientController : BaseApiController
    {
        private readonly IClientService _clientService;
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientService clientService, IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            _clientService = clientService;

        }

        [Authorize]
        [HttpPost("{userid}/pick/{id}")]
        public async Task<ActionResult> AddCarToClient(int userid, int id)
        {

          try
          {
              return Ok(await _clientService.AddCarToClient(userid, id));
          }
          catch (Exception)
          {
              
              return BadRequest();
          }

        }

         [Authorize]
        [HttpPost("{userid}/unpick/{id}")]
        public async Task<ActionResult> RemoveCarFromClient(int userid, int id)
        {

          try
          {
              return Ok(await _clientService.RemoveCarFromClient(userid, id));
          }
          catch (Exception)
          {
              
              return BadRequest();
          }

        }



    }
}