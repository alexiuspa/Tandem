using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tandem.Models;

namespace Tandem.ModelsDTO
{
	public class ModelsMapping : Profile
	{

		public ModelsMapping()
		{

			CreateMap<Patient, PatientDTO>().ForMember(dst => dst.UserID, act => act.MapFrom(src => src.id)).ForMember(dst => dst.FullName ,  act => act.MapFrom(src => src.LastName + "," + src.FirstName)) ;

			CreateMap<NewPatientDTO, Patient>();
		}

	}



	public class PatientDTO
		{


		
 

	public string FullName{ get; set; }

	public string EmailAddress { get; set; }


	public string UserID{ get; set; }
 



}


	public class NewPatientDTO
	{
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string middleName { get; set; }
		public string emailAddress { get; set; }
		public string phoneNumber { get; set; }

	}


	public class PatientValidator : AbstractValidator<NewPatientDTO>
	{
		public PatientValidator()
		{

			RuleFor(p => p.lastName).NotNull();
			RuleFor(p => p.emailAddress).EmailAddress();

		}
	}



}
