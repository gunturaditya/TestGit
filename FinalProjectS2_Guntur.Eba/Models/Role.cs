using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FinalProjectS2_Guntur.Eba.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<AccountRole>? TbTrAccountRoles { get; set; } = new List<AccountRole>();
}
