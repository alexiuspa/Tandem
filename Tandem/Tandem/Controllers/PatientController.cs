using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tandem.Models;
using Tandem.DAL;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Tandem.Controllers
{

	[ApiController]
	public class PatientController : ControllerBase
	{
		IRepository<Patient> _repo;


		public PatientController(IRepository<Patient> repo )
		{
			_repo = repo; 

		}


		[HttpGet]
		[Route("api/v1/patient/{emailAddress}")]
		public Task<Patient> GetUserNotes(string emailAddress)
		{



			return null;
		
		}


		[HttpPost]
		[Route("api/v1/patient")]

		public IActionResult CreatePatient( [FromBody] Patient patient)
		{


			if (!ModelState.IsValid)
				return BadRequest();


			return Ok();
		}

	}
}
