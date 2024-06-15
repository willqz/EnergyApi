using Energy.API.ViewModel.Requests;
using Energy.Application.Interface;
using Energy.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Energy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorController : ControllerBase
    {
        private readonly IAppDistributor _IAppDistributor;
        private readonly ILogger<DistributorController> _logger;

        public DistributorController(IAppDistributor IAppDistributor, ILogger<DistributorController> logger)
        {
            _IAppDistributor = IAppDistributor;
            _logger = logger;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        [Route("GetAllDistributors")]
        public IActionResult GetAllDistributors()
        {
            try
            {
                var listDistutors = _IAppDistributor.GetAll();

                return Ok(listDistutors.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in method GetAllDistributors.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        [Route("GetDistributor")]
        public IActionResult GetDistributor(int Id)
        {
            try
            {
                if (Id <= 0)
                    return StatusCode(StatusCodes.Status400BadRequest, "Codigo inválido");

                var distributor = _IAppDistributor.GetById(Id);

                return Ok(distributor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in method GetDistributor.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        [Route("CreateDistributor")]
        public IActionResult CreateDistributor([Bind] RequestCreateDistributor request)
        {
            try
            {
                Distributor distributor = new Distributor(0, request.Description, request.Code, request.Active, DateTime.Now);
                _IAppDistributor.Add(distributor);
                return Ok(distributor);
            }
            catch (ArgumentException ar)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ar.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in method CreateDistributor.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        [EnableCors("AllowOrigin")]
        [Route("EditDistributor")]
        public IActionResult EditDistributor([Bind] RequestEditDistributor request)
        {
            try
            {
                var distributor = _IAppDistributor.GetById(request.Id);
                if (distributor == null)
                    return StatusCode(StatusCodes.Status400BadRequest, "Registro não encontrado.");

                distributor.Description = request.Description;
                distributor.Active = request.Active;
                distributor.Code = request.Code;
                distributor.IsValid();
                
                _IAppDistributor.Update(distributor);

                return Ok();
            }
            catch (ArgumentException ar)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ar.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete]
        [EnableCors("AllowOrigin")]
        [Route("DeleteDistributor")]
        public IActionResult DeleteDistributor(int Id)
        {
            try
            {
                if (Id <= 0)
                    return StatusCode(StatusCodes.Status400BadRequest, "Codigo inválido");

                var distributor = _IAppDistributor.GetById(Id);
                if (distributor == null)
                    return StatusCode(StatusCodes.Status400BadRequest, "Registro não encontrado.");

                _IAppDistributor.Delete(Id);

                return Ok();
            }
            catch (ArgumentException ar)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ar.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in method DeleteDistributor.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
