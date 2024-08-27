using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laifu.OpenCv.Constants.Features2d.Akaze;

public enum DescriptorType
{
    /// <summary>
    /// Upright descriptors, not invariant to rotation
    /// </summary>
    DESCRIPTOR_KAZE_UPRIGHT = 2,

    /// <summary>
    /// 
    /// </summary>
    DESCRIPTOR_KAZE = 3,

    /// <summary>
    /// descriptors, not invariant to rotation
    /// </summary>
    DESCRIPTOR_MLDB_UPRIGHT = 4,

    /// <summary>
    /// 
    /// </summary>
    DESCRIPTOR_MLDB = 5
};