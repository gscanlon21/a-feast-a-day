﻿using System.Collections.Concurrent;

namespace Core.Code;

public class FixedSizeQueue<T>(int size) : ConcurrentQueue<T>
{
    public int Size { get; private set; } = size;

    public new void Enqueue(T obj)
    {
        base.Enqueue(obj);
        while (base.Count > Size)
        {
            TryDequeue(out _);
        }
    }
}