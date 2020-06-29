using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tandem.Controllers
{

	[ApiController]
	public class PatientController : ControllerBase
	{
		[HttpGet]
		[Route("api/v1/patient/{emailAddress}")]
		public Task<IActionResult> GetUserNotes(string emailAddress)
		{



			return null;
		
		}


		[HttpPost]
		[Route("api/v1/patient")]

		public Task<bool> CreatePatient()
		{



			return null;
		}

	}
}
