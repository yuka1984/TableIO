﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableIO
{
    public interface ITypeConverter
    {
        object ConvertToField(object propertyValue);
        object ConvertFromField(object fieldValue);
    }
}