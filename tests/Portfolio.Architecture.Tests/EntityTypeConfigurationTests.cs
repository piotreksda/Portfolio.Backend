using System.Reflection;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Architecture.Tests;

public class EntityTypeConfigurationTests
{
    //[Fact]
    public void AllEntityPropertiesShouldBeConfigured()
    {
        Dictionary<Type, Type> configurations = GetEntityTypeConfigurations();
        HashSet<Type> entities = GetEntities();

        List<string> errors = new List<string>();
        
        foreach (Type entity in entities)
        {
            if (configurations.TryGetValue(entity, out var config))
            {
                HashSet<string> entityProperties = GetPropertiesOfEntity(entity);
                HashSet<string> configuredProperties = GetConfiguredPropertiesInConfiguration(config);
    
                foreach (string property in entityProperties)
                {
                    if (!configuredProperties.Contains(property))
                    {
                        errors.Add($"Property {property} of entity {entity.Name} is not configured in {config.Name}");
                    }
                }
            }
            else
            {
                errors.Add($"No configuration found for entity {entity.Name}");
            }
        }
        errors.Count.Should().Be(0, $"But found {errors.Count}, List:\n {String.Join(", \n", errors)}");
    }
    
    
    
    private Dictionary<Type, Type> GetEntityTypeConfigurations()
    {
        var configurationInterface = typeof(IEntityTypeConfiguration<>);
        return PortfolioAssemblies.DomainCoreAssembly
                       .GetTypes()
                       .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == configurationInterface))
                       .ToDictionary(t => t.GetInterfaces().Single(i => i.IsGenericType && i.GetGenericTypeDefinition() == configurationInterface).GetGenericArguments()[0],
                                     t => t);
    }
    
    private HashSet<Type> GetEntities()
    {
        var DbContext = PortfolioAssemblies.DomainCoreAssembly.GetTypes()
            .FirstOrDefault(t => t.IsSubclassOf(typeof(DbContext)));
        return DbContext.GetProperties()
                          .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                          .Select(p => p.PropertyType.GetGenericArguments()[0])
                          .ToHashSet();
    }
    
    private HashSet<string> GetPropertiesOfEntity(Type entityType)
    {
        return entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                         .Select(p => p.Name)
                         .ToHashSet();
    }
    
    //todo: inprogress
    private HashSet<string> GetConfiguredPropertiesInConfiguration(Type configurationType)
    {
        var methodInfo = configurationType.GetMethod("Configure");
        if (methodInfo == null) throw new InvalidOperationException($"Configure method not found in {configurationType.Name}");
        
        var methodBody = methodInfo.GetMethodBody();
        if (methodBody == null) return new HashSet<string>();
    
        var ilAsByteArray = methodBody.GetILAsByteArray();
        // Analyze the IL byte array to identify which properties are being configured
        // This is complex and requires understanding of IL. Alternatively, use a simpler but less accurate method like parsing the method's source code if available
        // For demonstration purposes, returning an empty set
        // todo: someday i will find way to do it :( maybe this link https://github.com/jbevain/cecil/ but its future task
        return new HashSet<string>();
    }
}