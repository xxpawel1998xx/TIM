using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AdminController : BaseApiController
    {


        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;

        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("user/{username}")]
        public async Task<ActionResult<ClientDto>> GetClientByNameAsync(string username)
        {
            try
            {
                var client = await _adminService.GetClientsByNameAsyncService(username);
                return Ok(client);
            }
            catch (Exception)
            {

                return BadRequest("User doesn't exist");
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("users")]
        public async Task<ActionResult<ClientDto>> GetClientsAsync(string username)
        {
            try
            {
                var clients = await _adminService.GetClientsAsyncService();
                return Ok(clients);
            }
            catch (Exception)
            {

                return BadRequest("Can't get these users");
            }
        }





    }

}
