﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    public interface ISource
    {
        public string Display { get; }
        public string Path { get; }

        (int line, int column) GetLineColumn(int offset);

        string GetText(ILocation location);
    }
}
