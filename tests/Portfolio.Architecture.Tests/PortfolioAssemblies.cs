using System.Reflection;

namespace Portfolio.Architecture.Tests;

public static class PortfolioAssemblies
{
    private static readonly List<string> ProjectNames = new()
    {
        "Portfolio.Authorization.Service",
        "Portfolio.Dictionary.Service"
    };

    public static readonly Assembly? DomainCoreAssembly = Type.GetType($"Portfolio.Shared.Kernel.Infrastructure.Architecture.GetAssembly, Portfolio.Shared.Kernel")?.Assembly;
    private static readonly List<Assembly?> MicroservicesAssemblies = ProjectNames.Select(x => Type.GetType($"{x}.Infrastructure.Architecture.GetAssembly, {x}")?.Assembly).ToList();
    
    public static IEnumerable<object[]?> MicroservicesAssemblyData()
    {
        return MicroservicesAssemblies.Select(a => new object[] { (a ?? null)! });
    }

    public static IEnumerable<object[]?> MicroservicesWithDomainCoreAssemblyData()
    {
        List<object[]?> tempList = new() { new object[] {(Object)DomainCoreAssembly } };
        return MicroservicesAssemblyData().Concat(tempList);
    }
}