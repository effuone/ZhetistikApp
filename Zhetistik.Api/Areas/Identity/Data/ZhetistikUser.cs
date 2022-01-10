using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Zhetistik.Api.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ZhetistikUser class
public class ZhetistikUser : IdentityUser
{
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(40)]
    public string LastName { get; set; }
}

