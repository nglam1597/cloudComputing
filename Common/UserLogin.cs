﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamekWebPes.Common
{
    [Serializable]
    public class UserLogin
    {
        public string UserName { get; set; }
        public long UserID { get; set; }
    }
}