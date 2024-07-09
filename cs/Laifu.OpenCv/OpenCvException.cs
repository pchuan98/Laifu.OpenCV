using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

    [Obsolete("Obsolete")]
    protected OpenCvException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}