using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paella.Application.OrderUseCases.Create;
using Paella.Application.OrderUseCases.Create.Parameters;
using Paella.WebApi.Services;

namespace Paella.WebApi.UseCases.Product
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerOrdersController : ControllerBase
    {
        private readonly ICreateUseCase _createUseCase;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerOrdersController(
            ICreateUseCase createUseCase,
            IUserService UserService,
            IHttpContextAccessor httpContextAccessor)
        {
            _createUseCase = createUseCase;
            _userService = UserService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Dictionary<Guid, int> request)
        {
            var user = _userService.GetUser(_httpContextAccessor.HttpContext);
            var customerId = user.CustomerId;

            var input = new CreateInput(customerId, request);

            var orderId = _createUseCase.Execute(input);

            return Ok(orderId);
        }
    }
}