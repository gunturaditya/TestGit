using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FinalProjectS2_Guntur.Eba.Models;

public partial class Account
{
    public string EmployeeNik { get; set; } = null!;

    public string Password { get; set; } = null!;
    [JsonIgnore]
    public virtual Employee? EmployeeNikNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<AccountRole>? TbTrAccountRoles { get; set; } = new List<AccountRole>();
}
