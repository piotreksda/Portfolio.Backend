using System.Collections;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions;
using NetArchTest.Rules;

namespace Portfolio.Architecture.Tests;

public class GlobalArchitectureTests
{
    private static readonly List<string> ProjectNames = new()
    {
        "Portfolio.Authorization.Service",
        "Portfolio.Dictionary.Service"
    };

    private static readonly Assembly? DomainCoreAssembly = Type.GetType($"Portfolio.Domain.Core.Infrastructure.Architecture.GetAssembly, Portfolio.Domain.Core")?.Assembly;
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
    
    [Theory]
    [MemberData(nameof(MicroservicesWithDomainCoreAssemblyData))]
    public void Microservice_Should_FindAssembly(Assembly? assembly)
    {
        bool foundAssembly = assembly is not null;
        foundAssembly.Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(MicroservicesWithDomainCoreAssemblyData))]
    public void Domain_Should_Not_HaveDependencyOnOtherNameSpaces(Assembly assembly)
    {
        // Arrange
        List<string> otherNameSpaces;
        
        if (assembly.Equals(DomainCoreAssembly))
        {
            otherNameSpaces = new List<string>()
            {
                $"{assembly.GetName().Name}.Application",
                $"{assembly.GetName().Name}.Infrastructure",
                $"{assembly.GetName().Name}.Presentation"
            };
        }
        else
        {
            otherNameSpaces = new List<string>()
            {
                $"{assembly.GetName().Name}.Application",
                $"{assembly.GetName().Name}.Infrastructure",
                $"{assembly.GetName().Name}.Presentation",
                "Portfolio.Domain.Core.Application",
                "Portfolio.Domain.Core.Infrastructure",
                "Portfolio.Domain.Core.Presentation"
            };
        }

        // Act
        var result = Types.InAssembly(assembly)
            .That()
            .ResideInNamespace($"{assembly.GetName().Name}.Domain")
            .Should()
            .NotHaveDependencyOnAny(otherNameSpaces.ToArray()) 
            .GetResult();

        result.IsSuccessful.Should().BeTrue($"Types in the 'Domain' namespace should not have dependencies on the namespace 'Application', 'Infrastructure' or 'Presentation'. Failing types: {string.Join(", ", result?.FailingTypeNames ?? new List<string?>() )}");
    }
    
    [Theory]
    [MemberData(nameof(MicroservicesWithDomainCoreAssemblyData))]
    public void Infrastructure_Should_Not_HaveDependencyOnApplicationOrPresentation(Assembly assembly)
    {
        // Arrange
        List<string> otherNameSpaces;
        
        if (assembly.Equals(DomainCoreAssembly))
        {
            otherNameSpaces = new List<string>()
            {
                $"{assembly.GetName().Name}.Application",
                $"{assembly.GetName().Name}.Presentation"
            };
        }
        else
        {
            otherNameSpaces = new List<string>()
            {
                $"{assembly.GetName().Name}.Application",
                $"{assembly.GetName().Name}.Presentation",
                "Portfolio.Domain.Core.Application",
                "Portfolio.Domain.Core.Presentation"
            };
        }
        
        // Act
        var result = Types.InAssembly(assembly)
            .That()
            .ResideInNamespace($"{assembly.GetName().Name}.Infrastructure")
            .Should()
            .NotHaveDependencyOnAny(otherNameSpaces.ToArray()) 
            .GetResult();
        
        // Assert
        result.IsSuccessful.Should().BeTrue($"Types in the 'Infrastructure' namespace should not have dependencies on the namespace 'Application' or 'Presentation'. Failing types: {string.Join(", ", result?.FailingTypeNames ?? new List<string?>() )}");
    }
    
    [Theory]
    [MemberData(nameof(MicroservicesWithDomainCoreAssemblyData))]
    public void Application_Should_Not_HaveDependencyOnInfrastructureOrPresentation(Assembly assembly)
    {
        // Arrange
        List<string> otherNameSpaces;
        
        if (assembly.Equals(DomainCoreAssembly))
        {
            otherNameSpaces = new List<string>()
            {
                $"{assembly.GetName().Name}.Infrastructure",
                $"{assembly.GetName().Name}.Presentation"
            };
        }
        else
        {
            otherNameSpaces = new List<string>()
            {
                $"{assembly.GetName().Name}.Infrastructure",
                $"{assembly.GetName().Name}.Presentation",
                "Portfolio.Domain.Core.Infrastructure",
                "Portfolio.Domain.Core.Presentation"
            };
        }
        
        // Act
        var result = Types.InAssembly(assembly)
            .That()
            .ResideInNamespace($"{assembly.GetName().Name}.Application")
            .Should()
            .NotHaveDependencyOnAny(otherNameSpaces.ToArray()) 
            .GetResult();
        
        // Assert
        result.IsSuccessful.Should().BeTrue($"Types in the 'Application' namespace should not have dependencies on the namespace 'Infrastructure' or 'Presentation'. Failing types: {string.Join(", ", result?.FailingTypeNames ?? new List<string?>() )}");
    }
}