using System;
using System.Collections.Generic;
using System.Text;

namespace Merchandising.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
    }
}
