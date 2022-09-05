using System;
using System.Collections.Generic;

#nullable disable

namespace RemoteBankServices.Context
{
    public partial class PotentialClient
    {
        public int PotentialClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public DateTime? DateBirth { get; set; }
        public string PlaceBirth { get; set; }
        public string TaxId { get; set; }
        public string Email { get; set; }
        public string PhoneFirst { get; set; }
        public string PhoneSecond { get; set; }
        public int? AdvertismentTypeId { get; set; }
        public string ReferralKey { get; set; }
        public int? CountryLanguageId { get; set; }
        public int? CountryId { get; set; }
        public string FormCountryKey { get; set; }
        public int? OriginalCountryId { get; set; }
        public string FormCountryBirthKey { get; set; }
        public int? ResidenceCountryId { get; set; }
        public string CitizenshipKey { get; set; }
        public int? GenderId { get; set; }
        public string GenderKey { get; set; }
        public int? MaritalStatusId { get; set; }
        public string MaritalStatusKey { get; set; }
        public int? ResidenceStatusId { get; set; }
        public string ResidenceStatusKey { get; set; }
        public int? EmploymentStatusId { get; set; }
        public string SourceIncomeKey { get; set; }
        public long? ClientId { get; set; }
        public DateTime Created { get; set; }
        public int CreatorId { get; set; }
        public int? FormId { get; set; }
        public string Xmldata { get; set; }
    }
}
