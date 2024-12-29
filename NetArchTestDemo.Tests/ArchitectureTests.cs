using NetArchTest.Rules;
using Xunit;

namespace NetArchTestDemo.Tests;

public class ArchitectureTests
{
    [Fact]
    public void Controllers_ShouldOnlyDependOnServices()
    {
        var result = Types.InAssembly(typeof(NetArchTestDemo.Controllers.ExampleController).Assembly)
                          .That()
                          .ResideInNamespace("NetArchTestDemo.Controllers")
                          .Should()
                          .NotHaveDependencyOnAny("NetArchTestDemo.Repositories")
                          .GetResult();

        Assert.True(result.IsSuccessful, "Controllers têm dependências não permitidas.");
    }

    [Fact]
    public void Services_ShouldOnlyDependOnRepositories()
    {
        var result = Types.InAssembly(typeof(NetArchTestDemo.Services.ExampleService).Assembly)
                      .That()
                      .ResideInNamespace("NetArchTestDemo.Services")
                      .ShouldNot()
                      .HaveDependencyOnAny("NetArchTestDemo.Controllers")
                      .GetResult();

        Assert.True(result.IsSuccessful, "Services têm dependências não permitidas.");
    }
}
