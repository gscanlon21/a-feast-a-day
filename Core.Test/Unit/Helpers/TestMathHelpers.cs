using Core.Code.Helpers;

namespace Core.Test.Unit.Helpers;

[TestClass]
public class TestMathHelpers
{
    #region RoundDownUnder

    [TestMethod]
    public async Task RoundDownUnder_WhenLower_ReturnsLower()
    {
        Assert.AreEqual(4, MathHelpers.RoundDownUnder(4.19, 0.2));
    }

    [TestMethod]
    public async Task RoundDownUnder_WhenEven_ReturnsUpper()
    {
        Assert.AreEqual(5, MathHelpers.RoundDownUnder(4.2, 0.2));
    }

    [TestMethod]
    public async Task RoundDownUnder_WhenUpper_ReturnsUpper()
    {
        Assert.AreEqual(5, MathHelpers.RoundDownUnder(4.21, 0.2));
    }

    [TestMethod]
    public async Task RoundDownUnder_WhenLower_ReturnsLower2()
    {
        Assert.AreEqual(4, MathHelpers.RoundDownUnder(4.79, 0.8));
    }

    [TestMethod]
    public async Task RoundDownUnder_WhenEven_ReturnsUpper2()
    {
        Assert.AreEqual(5, MathHelpers.RoundDownUnder(4.8, 0.8));
    }

    [TestMethod]
    public async Task RoundDownUnder_WhenUpper_ReturnsUpper2()
    {
        Assert.AreEqual(5, MathHelpers.RoundDownUnder(4.81, 0.8));
    }

    [TestMethod]
    public async Task RoundDownUnder_WhenCutoffTooLow_Throws()
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => MathHelpers.RoundDownUnder(4.2, 0));
    }

    [TestMethod]
    public async Task RoundDownUnder_WhenCutoffTooHigh_Throws()
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => MathHelpers.RoundDownUnder(4.2, 1));
    }

    #endregion
    #region RoundUpAbove

    [TestMethod]
    public async Task RoundUpAbove_WhenLower_ReturnsLower()
    {
        Assert.AreEqual(4, MathHelpers.RoundUpAbove(4.19, 0.2));
    }

    [TestMethod]
    public async Task RoundUpAbove_WhenEven_ReturnsUpper()
    {
        Assert.AreEqual(4, MathHelpers.RoundUpAbove(4.2, 0.2));
    }

    [TestMethod]
    public async Task RoundUpAbove_WhenUpper_ReturnsUpper()
    {
        Assert.AreEqual(5, MathHelpers.RoundUpAbove(4.21, 0.2));
    }

    [TestMethod]
    public async Task RoundUpAbove_WhenLower_ReturnsLower2()
    {
        Assert.AreEqual(4, MathHelpers.RoundUpAbove(4.79, 0.8));
    }

    [TestMethod]
    public async Task RoundUpAbove_WhenEven_ReturnsUpper2()
    {
        Assert.AreEqual(4, MathHelpers.RoundUpAbove(4.8, 0.8));
    }

    [TestMethod]
    public async Task RoundUpAbove_WhenUpper_ReturnsUpper2()
    {
        Assert.AreEqual(5, MathHelpers.RoundUpAbove(4.81, 0.8));
    }

    [TestMethod]
    public async Task RoundUpAbove_WhenCutoffTooLow_Throws()
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => MathHelpers.RoundUpAbove(4.2, 0));
    }

    [TestMethod]
    public async Task RoundUpAbove_WhenCutoffTooHigh_Throws()
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => MathHelpers.RoundUpAbove(4.2, 1));
    }

    #endregion
    #region Diff

    [TestMethod]
    public async Task Diff_WhenOffByOne_ReturnsOne()
    {
        Assert.AreEqual(1, MathHelpers.Diff(4, 5));
    }

    #endregion
}
