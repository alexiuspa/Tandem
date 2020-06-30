using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tandem.Models;
using Tandem.DAL;
using System.Runtime.InteropServices.WindowsRuntime;
using AutoMapper;
using Tandem.ModelsDTO;


namespace Tandem.Controllers
{

	[ApiController]
	public class PatientController : ControllerBase
	{
		IRepository<Patient> _repo;

		readonly IMapper _mapper;


		public PatientController(IRepository<Patient> repo  ,  IMapper mapper)
		{
			_repo = repo;

			_mapper = mapper;

		}


		[HttpGet]
		[Route("api/v1/patient/{emailAddress}")]
		public async  Task< IActionResult > GetUserNotes(string emailAddress)
		{

			Patient pat =  await _repo.GetAll(emailAddress);

			if (pat == null)
				return NotFound();


			var  patDTO = _mapper.Map<PatientDTO>(pat);

			return  Ok( patDTO);
		
		}


		[HttpPost]
		[Route("api/v1/patient")]

		public IActionResult CreatePatient( [FromBody] NewPatientDTO patient)
		{


			if (!ModelState.IsValid)
				return BadRequest();

			var opatient = _mapper.Map<Patient>(patient);

			opatient.id = Guid.NewGuid().ToString();

			_repo.Add(opatient);


			return Ok(opatient);
		}

	}
}
