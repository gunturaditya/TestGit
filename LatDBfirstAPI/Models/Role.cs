﻿using System;
using System.Collections.Generic;

namespace LatDBfirstAPI.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AccountRole> TbTrAccountRoles { get; set; } = new List<AccountRole>();
}
