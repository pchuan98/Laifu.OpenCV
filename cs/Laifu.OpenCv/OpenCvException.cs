namespace Laifu.OpenCv;

/// <summary>
/// All Exception from Laifu.OpenCv will be of this type
/// </summary>
[Serializable]
public class OpenCvException : Exception
{
    public OpenCvException() { }

    public OpenCvException(string message) : base(message) { }

    public OpenCvException(string message, Exception innerException) : base(message, innerException) { }
}