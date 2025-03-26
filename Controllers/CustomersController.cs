using AFI.Dtos;
using AFI.Models;
using AFI.UoW;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AFI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CustomerForCreationDtoValidator _creationValidator;


        public CustomersController(
            ILogger<CustomersController> logger,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CustomerForCreationDtoValidator creationValidator)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _creationValidator = creationValidator;
        }

        // POST: api/Customers/CreateNew
        [HttpPost("CreateNew")]
        public async Task<IActionResult> CreateNew([FromBody] CustomerForCreationDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid customer data.");
            }

            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var validationResult = await _creationValidator.ValidateAsync(dto);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var customer = _mapper.Map<Customer>(dto);
                var createdCustomer = await _unitOfWork.Customers.CreateAsync(customer);

                await _unitOfWork.SaveAllAsync();
                await transaction.CommitAsync();

                return CreatedAtAction(nameof(GetById), new { id = createdCustomer.Id }, createdCustomer);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Error creating customer.");
                return StatusCode(500, "An error occurred while creating the customer.");
            }
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
            return Ok(customer);
        }
    }
}
