using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shop.Model.Models
{
    [DataContract]
    public class User : IdentityUser
    {
        [DataMember]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [DataMember]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [DataMember]
        [Display(Name = "Telefon domowy")]
        public string HomeNumber { get; set; }

        [DataMember]
        [Display(Name = "Numer mieszkania")]
        public string FlatNumber { get; set; }

        [DataMember]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [DataMember]
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }
        
        [DataMember]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}