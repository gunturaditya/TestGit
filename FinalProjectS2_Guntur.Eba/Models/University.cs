using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FinalProjectS2_Guntur.Eba.Models;

public partial class University
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Education>? TbMEducations { get; set; } = new List<Education>();
}
