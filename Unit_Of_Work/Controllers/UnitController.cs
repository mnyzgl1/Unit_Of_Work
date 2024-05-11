using Microsoft.AspNetCore.Mvc;

namespace Unit_Of_Work.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UnitController : ControllerBase
	{
		UnitOfWork.UnitOfWork _unitOfWork;
        public UnitController(UnitOfWork.UnitOfWork unitOfWorks)
        {
            _unitOfWork = unitOfWorks;
        }

		[HttpGet]
		public IActionResult Save()
		{

		var authen=	_unitOfWork._authRepository.Add(new DMO.Authentication()
			{
				Username = "Derya",
				Password = "2020"
			});

	     _unitOfWork._authRepository.Add(new DMO.Autorization()
			{
				Controller="Home",
				Action = "Index",
				

			});



            // unit of work üzerinden repository'e erişip, modelimizi verdikç
            // yine unit of work üzerinden save metodunu çağırarak verinin kaydedilmesini sağlayalım


            _unitOfWork.Save();
			return Ok();
		}

	}
}
