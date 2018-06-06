using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.Enum
{
    /// <summary>
    /// States represented Char (Ascii) Value
    /// </summary>
    public enum ApplicationState
    {
        Pending=80,
        Reject=82,
        Unconditional=85,
        Conditional=67
    }
}
