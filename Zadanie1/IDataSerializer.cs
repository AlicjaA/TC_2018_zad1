﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public interface IDataSerializer
    {
        void Serialize(DataContext context);
        void Deserialize(ref DataContext context);
    }
}
