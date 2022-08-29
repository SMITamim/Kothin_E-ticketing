﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IAuthRepo<CLASS>
    {
        CLASS Validate(string username, string password);
    }
}
