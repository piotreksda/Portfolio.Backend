using System.Collections;
using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;

namespace Portfolio.Architecture.Tests;

public class GlobalArchitectureTests
{
    private static readonly List<string> ProjectNames = new()
    {
        "Portfolio.Authorization.Service",
        "Portfolio.Dictionary.Service",
        "Portfolio.Domain.Core"
    };

    // private static readonly List<KeyValuePair<string, string>> CleanArchitectureNameSpaces = new()
    // {
    //     new KeyValuePair<string, string>("Application", "Application"),
    //     new KeyValuePair<string, string>("Domain","Domain"),
    //     new KeyValuePair<string, string>("Infrastructure", "Infrastructure")
    // };

    private static readonly List<Assembly?> MicroservicesAssemblies = ProjectNames.Select(x => Type.GetType($"{x}.Infrastructure.Architecture.GetAssembly, {x}")?.Assembly).ToList();
    
    public static IEnumerable<object[]?> MicroservicesAssemblyData()
    {
        return MicroservicesAssemblies.Select(a => new object[] { (a ?? null)! });
    }
    
    [Theory]
    [MemberData(nameof(MicroservicesAssemblyData))]
    public void Infrastructure_Should_FindAssembly(Assembly? assembly)
    {
        bool foundAssembly = assembly is not null;
        foundAssembly.Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(MicroservicesAssemblyData))]
    public void Domain_Should_Not_HaveDependencyOnOtherNameSpaces(Assembly assembly)
    {
        // Arrange

        var otherNameSpaces = new List<string>
        {
            $"{assembly.GetName().Name}.Application",
            $"{assembly.GetName().Name}.Infrastructure"
        };

        // Act
        
        foreach (var ns in otherNameSpaces)
        {
            var result = Types.InAssembly(assembly)
                .That()
                .ResideInNamespace($"{assembly.GetName().Name}.Domain")
                .Should()
                .NotHaveDependencyOnAny(ns) 
                .GetResult();

            result.IsSuccessful.Should().BeTrue($"Types in the domain namespace should not have dependencies on the namespace '{ns}'. Failing types: {string.Join(", ", result?.FailingTypeNames ?? new List<string?>() )}");

        }
        
    }
}