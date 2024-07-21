
namespace Core.Code.Exceptions;

[Serializable]
public class MissingMeasureException : NotSupportedException
{
    public MissingMeasureException() { }

    public MissingMeasureException(string message) : base(message) { }

    public MissingMeasureException(string message, Exception innerException) : base(message, innerException) { }
}
