using Api.Jobs.Create;
using Core.Code.Helpers;
using Core.Models.Options;
using Data;
using Data.Entities.Users;
using Data.Repos;
using Data.Test.Code;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace Api.Test.Unit.Jobs.Create;

[TestClass]
public class TestCreateFeasts : FakeDatabase
{
    private CreateFeasts NewsletterJob { get; set; } = null!;

    [TestInitialize]
    public void Init()
    {
        var mockSp = new Mock<IServiceProvider>();
        mockSp.Setup(m => m.GetService(typeof(CoreContext))).Returns(Context);
        var mockSs = new Mock<IServiceScope>();
        mockSs.Setup(m => m.ServiceProvider).Returns(mockSp.Object);
        var mockSsf = new Mock<IServiceScopeFactory>();
        mockSsf.Setup(m => m.CreateScope()).Returns(mockSs.Object);

        var mockHttpClient = new Mock<HttpClient>();
        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        mockHttpClientFactory.Setup(m => m.CreateClient(It.IsAny<string>())).Returns(mockHttpClient.Object);

        var mockLoggerNewsletterJob = new Mock<ILogger<CreateFeasts>>();
        var userRepo = new UserRepo(Context, mockSsf.Object);

        NewsletterJob = new CreateFeasts(
            mockLoggerNewsletterJob.Object,
            userRepo,
            mockHttpClientFactory.Object,
            Services.GetService<IOptions<SiteSettings>>()!,
            Context
        );
    }

    [TestMethod]
    public async Task GetUsers_WhenNewsletterIsDisabled_ReturnsOne()
    {
        Context.Users.Add(new User(string.Empty, true)
        {
            LastActive = DateHelpers.Today,
            NewsletterDisabledReason = "testing",
            SendDay = DateHelpers.Today.DayOfWeek,
            SendHour = int.Parse(DateTime.UtcNow.ToString("HH"))
        });
        await Context.SaveChangesAsync();

        var users = await NewsletterJob.GetUsers().ToListAsync();
        Assert.HasCount(1, users);
    }

    [TestMethod]
    public async Task GetUsers_WhenSendDaysIsNone_ReturnsNone()
    {
        Context.Users.Add(new User(string.Empty, true)
        {
            SendDay = DateHelpers.Today.DayOfWeek,
        });
        await Context.SaveChangesAsync();

        var users = await NewsletterJob.GetUsers().ToListAsync();
        Assert.IsEmpty(users);
    }

    [TestMethod]
    public async Task GetUsers_WhenLastActiveIsNull_ReturnsNone()
    {
        Context.Users.Add(new User(string.Empty, true)
        {
            SendDay = DateHelpers.Today.DayOfWeek,
        });
        await Context.SaveChangesAsync();

        var users = await NewsletterJob.GetUsers().ToListAsync();
        Assert.IsEmpty(users);
    }

    [TestMethod]
    public async Task GetUsers_WhenActive_ReturnsNone()
    {
        Context.Users.Add(new User(string.Empty, true)
        {
            LastActive = DateHelpers.Today,
            SendDay = DateHelpers.Today.DayOfWeek,
            SendHour = int.Parse(DateTime.UtcNow.ToString("HH"))
        });
        await Context.SaveChangesAsync();

        var users = await NewsletterJob.GetUsers().ToListAsync();
        Assert.IsEmpty(users);
    }
}
