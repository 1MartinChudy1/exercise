﻿using System.Collections.Generic;

namespace IO
{
    public interface IInput
    {
        IEnumerable<Argument> Read(string[] args);
    }
}