﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableIO
{
    public interface IPropertyMapper
    {
        PropertyMap[] CreatePropertyMaps(Type type, IList<string> header);
    }
}