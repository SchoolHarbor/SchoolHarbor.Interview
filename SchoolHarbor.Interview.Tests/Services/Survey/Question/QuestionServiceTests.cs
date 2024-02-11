using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using SchoolHarbor.Interview.Data.EntityResolvers.Question;
using SchoolHarbor.Interview.Data.Repositories.Instance;
using SchoolHarbor.Interview.Services.Survey.Question;

namespace SchoolHarbor.Interview.Tests.Services.Survey.Question;

public sealed class QuestionServiceTests
{
    [Theory, AutoMoqData]
    public async Task GetForSurvey(
        [Frozen] Mock<IQuestionEntityResolver> mockQuestionEntityResolver,
        [Frozen] Mock<IInstanceRepository> mockInstanceRepository,
        QuestionService sut)
    {
        var surveyId = MockData.MockDataReferenceId();

        var result = await sut.GetForSurvey(surveyId);

        result.Should().NotBeNullOrEmpty();
    }
}