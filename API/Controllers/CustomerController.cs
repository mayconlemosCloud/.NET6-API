using Application.DTOs;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IServiceCustomer _serviceCustomer;

        public CustomerController(IServiceCustomer serviceCustomer)
        {
            _serviceCustomer = serviceCustomer;
        }

        [HttpGet]            
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            try
            {
                var response = await _serviceCustomer.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]     
        public async Task<IActionResult> Post(CustomerDTO customerDTO)
        {
            try
            {
                _serviceCustomer.Add(customerDTO);
                return Created("Criado", customerDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _serviceCustomer.Delete(id);
                return Ok("Deletado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Customer obj)
        {
            try
            {
                await _serviceCustomer.Update(obj);
                return Ok("Atualizado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}