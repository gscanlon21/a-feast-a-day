using System.Collections;
using System.Text;

namespace Core.Code.Exceptions;

[Serializable]
public class MissingMeasureException : NotSupportedException
{
    public MissingMeasureException() { }

    public MissingMeasureException(string message) : base(message) { }

    public MissingMeasureException(string message, Exception innerException) : base(message, innerException) { }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(base.ToString());

        Exception? exception = this;
        do
        {
            foreach (DictionaryEntry kvp in exception.Data)
            {
                stringBuilder.AppendLine($"[{kvp.Key}, {kvp.Value}]");
            }
        }
        while ((exception = exception.InnerException) != null);

        return stringBuilder.ToString();
    }
}
