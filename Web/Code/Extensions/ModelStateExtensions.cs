using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace Web.Code.Extensions;

public static class ModelStateExtensions
{
    public static string GetHtmlListOfErrors(this ModelStateDictionary modelState)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("<ul class='mb-0'>");

        foreach (var error in modelState.Values.SelectMany(v => v.Errors))
        {
            stringBuilder.Append("<li>");
            stringBuilder.Append(error.ErrorMessage);
            stringBuilder.Append("</li>");
        }

        stringBuilder.Append("</ul>");
        return stringBuilder.ToString();
    }
}
