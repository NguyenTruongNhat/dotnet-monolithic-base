﻿using System.Reflection;

namespace MonolithicBase.Contract;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}


