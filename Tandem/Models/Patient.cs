using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Transactions;
using FluentValidation;

namespace Tandem.Models
{
	public class Patient
	{
		[JsonPropertyName("firstName")]
		public string FirstName { get; set; }

		[JsonPropertyName("lastName")]
		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public string EmailAddress { get; set; }
 

		public string PhoneNumber { get; set; }

		public string id { get; set; }

	}

	



	public class PatientValidator : AbstractValidator<Patient>
	{
		public PatientValidator()
		{

			RuleFor(p => p.LastName).NotNull();
			RuleFor(p => p.EmailAddress).EmailAddress();

		}
	}

}
