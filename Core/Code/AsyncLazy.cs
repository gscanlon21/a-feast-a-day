using System.Runtime.CompilerServices;

namespace Core.Code;

public class AsyncLazy<T> : Lazy<Task<T>>
{
    public AsyncLazy(Func<T> valueFactory) : base(() => Task.Factory.StartNew(valueFactory)) { }

    public AsyncLazy(Func<Task<T>> taskFactory) : base(() => Task.Factory.StartNew(() => taskFactory()).Unwrap()) { }

    public TaskAwaiter<T> GetAwaiter() => Value.GetAwaiter();
}
