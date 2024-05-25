using BuildingManagerILogic;
using BuildingManagerModels.Inner;
using BuildingManagerModels.Outer;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagerApi.Controllers
{
    [ApiController]
    [Route("api/construction-company")]
    public class ConstructionCompanyController: ControllerBase
    {
        private readonly IConstructionCompanyLogic _constructionCompanyLogic;

        public ConstructionCompanyController(IConstructionCompanyLogic constructionCompanyLogic)
        {
            _constructionCompanyLogic = constructionCompanyLogic;
        }

        [HttpPost]
        public IActionResult CreateConstructionCompany([FromBody] CreateConstructionCompanyRequest constructionCompanyRequest)
        {
            CreateConstructionCompanyResponse createConstructionCompanyResponse = new(_constructionCompanyLogic.CreateConstructionCompany(constructionCompanyRequest.ToEntity()));
            return CreatedAtAction(nameof(CreateConstructionCompany), createConstructionCompanyResponse);
        }
    }
}