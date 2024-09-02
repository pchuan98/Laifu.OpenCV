namespace Laifu.OpenCv;

public abstract class DisposableObject : IDisposable
{
    /// <summary>
    /// Gets a value indicating whether this instance has been disposed.
    /// </summary>
    public bool IsDisposed { get; protected set; }

    /// <summary>
    /// 
    /// </summary>
    protected GCHandle DataHandle { get; set; }

    /// <summary>
    /// Determine whether to dispose signal.
    ///
    /// 0 - not disposed, 1 - disposing or disposed.
    /// </summary>
    private volatile int _signal;

    public virtual void Dispose()
    {
        if (Interlocked.Exchange(ref _signal, 1) != 0) return;

        if (DataHandle.IsAllocated) DataHandle.Free();
    }
}