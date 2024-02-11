using System.Data;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using SchoolHarbor.Interview.Data.Entities;
using SchoolHarbor.Interview.Data.Repositories.Survey;
using SchoolHarbor.Interview.Services.Survey;

namespace SchoolHarbor.Interview.Tests.Services.Survey;

public sealed class SurveyServiceTests
{
    [Theory, AutoMoqData]
    public async Task GetAll(
        [Frozen] Mock<ISurveyRepository> mockSurveyRepository,
        SurveyService sut)
    {
        var surveyEntity = MockData.MockSurveyEntity();

        mockSurveyRepository.Setup(x => x.GetAll())
            .ReturnsAsync(new List<SurveyEntity>(){ surveyEntity });
        
        var result = await sut.GetAll();

        result.Should().NotBeNullOrEmpty();
    }
    
    [Theory, AutoMoqData]
    public async Task GetAll_NoneFound_Throws(
        [Frozen] Mock<ISurveyRepository> mockSurveyRepository,
        SurveyService sut)
    {
        mockSurveyRepository.Setup(x => x.GetAll())
            .ReturnsAsync(new List<SurveyEntity>());
        
        await Assert.ThrowsAnyAsync<DataException>( async Task () => await sut.GetAll());
    }
}