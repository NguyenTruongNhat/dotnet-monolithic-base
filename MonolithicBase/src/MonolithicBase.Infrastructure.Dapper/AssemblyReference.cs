using System.Reflection;

namespace MonolithicBase.Infrastructure.Dapper;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}

