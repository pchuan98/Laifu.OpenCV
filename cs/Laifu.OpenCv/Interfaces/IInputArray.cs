namespace Laifu.OpenCv.Interfaces;

public interface IInputArray
{
    public bool IsDisposed { get; }

    /// <summary>
    /// converter to InputArray
    /// </summary>
    /// <returns></returns>
    InputArrayHandle GetInputArrayHandle();
}