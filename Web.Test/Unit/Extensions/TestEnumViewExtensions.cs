using System.ComponentModel.DataAnnotations;
using Web.Code.Extensions;

namespace Web.Test.Unit.Extensions;

[TestClass]
public class TestEnumViewExtensions
{
    private enum ScrambledEnum
    {
        [Display(Name = "A")] A = 9,
        [Display(Name = "C")] C = 1,
        [Display(Name = "B")] B = 2,
        [Display(Name = "D")] D = 3,
        [Display(Name = "E")] E = 0,
    }

    [TestMethod]
    public async Task AsSelectListItems32_OrderByText_ReturnsCorrectOrder()
    {
        var values = new List<ScrambledEnum>() { ScrambledEnum.C, ScrambledEnum.B, ScrambledEnum.E, ScrambledEnum.A, ScrambledEnum.D };
        var items = values.AsSelectListItems(EnumViewExtensions.EnumOrdering.Text);
        // Yes, the default value should always come first.
        Assert.IsTrue(items.Select(i => i.Text).SequenceEqual(["E", "A", "B", "C", "D"]));
    }

    [TestMethod]
    public async Task AsSelectListItems32_OrderByValue_ReturnsCorrectOrder()
    {
        var values = new List<ScrambledEnum>() { ScrambledEnum.C, ScrambledEnum.B, ScrambledEnum.E, ScrambledEnum.A, ScrambledEnum.D };
        var items = values.AsSelectListItems(EnumViewExtensions.EnumOrdering.Value);
        Assert.IsTrue(items.Select(i => i.Value).SequenceEqual(["0", "1", "2", "3", "9"]));
    }
}