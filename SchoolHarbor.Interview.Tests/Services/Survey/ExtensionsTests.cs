using FluentAssertions;
using SchoolHarbor.Interview.Core.Identifier;
using SchoolHarbor.Interview.Services.Survey;

namespace SchoolHarbor.Interview.Tests.Services.Survey;

public class ExtensionsTests
{
    [Fact]
    public void ToDomain()
    {
        var entity = MockData.MockSurveyEntity();

        var result = entity.ToDomain();

        result.Id.Value.Should().BeEquivalentTo(entity.Id.ToString());
        result.Name.Should().BeEquivalentTo(entity.Name);
        result.Id.Kind.Should().Be(ReferenceIdKind.Database);
        result.Id.SourceKind.Should().Be(ReferenceIdSourceKind.SchoolHarbor);
        result.Name.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public void ToDomain_IdIsZero_Throws()
    {
        var entity = MockData.MockSurveyEntity(id: 0);

        Assert.Throws<InvalidDataException>(() => entity.ToDomain());
    }
    
    [Fact]
    public void ToDomain_NameNull_Throws()
    {
        var entity = MockData.MockInvalidSurveyEntityWithoutName();

        Assert.Throws<InvalidDataException>(() => entity.ToDomain());
    }
}