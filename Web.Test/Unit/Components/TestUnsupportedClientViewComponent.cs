using Data.Entities.Users;
using Web.Components.User;
using Web.Views.Shared.Components.UnsupportedClient;

namespace Web.Test.Unit.Components;

[TestClass]
public class TestUnsupportedClientViewComponent
{
    [TestMethod]
    public async Task GetUnsupportedClientStatus_WhenUserIsGmail_ReturnsUnsupportedClientStatus()
    {
        var user = new User("test@gmail.com", acceptedTerms: true);
        var status = UnsupportedClientViewComponent.GetUnsupportedClient(user);
        Assert.AreEqual(UnsupportedClientViewModel.UnsupportedClient.Gmail, status);
    }

    [TestMethod]
    public async Task GetUnsupportedClientStatus_WhenUserIsFastmail_ReturnsSupportedClientStatus()
    {
        var user = new User("test@fastmail.com", acceptedTerms: true);
        var status = UnsupportedClientViewComponent.GetUnsupportedClient(user);
        Assert.AreEqual(UnsupportedClientViewModel.UnsupportedClient.None, status);
    }
}
