using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HelperMethods.Models.Metadata;

namespace HelperMethods.Models
{
    [MetadataType(typeof(PersonMetadata))]
    public partial class Person
    {
        //[HiddenInput(DisplayValue = false)]
        //[ScaffoldColumn(false)]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address HomeAddress { get; set; }
        public bool IsApproved { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin,
        User,
        Guest
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
