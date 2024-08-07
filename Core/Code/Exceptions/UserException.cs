﻿using System.Collections;
using System.Text;

namespace Core.Code.Exceptions;

[Serializable]
public class UserException : ArgumentException
{
    public UserException() { }

    public UserException(string message) : base(message) { }

    public UserException(string message, Exception innerException) : base(message, innerException) { }

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
