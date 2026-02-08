using Xunit;

[CollectionDefinition("Integration", DisableParallelization = true)]
public class IntegrationCollection : ICollectionFixture<IntegrationFixture>
{
    
}