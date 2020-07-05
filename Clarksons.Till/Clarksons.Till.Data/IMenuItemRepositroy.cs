using System;
using System.Collections.Generic;
using System.Text;
using Clarksons.Till.Core.Models;

namespace Clarksons.Till.Data
{
    public interface IMenuItemRepository
    {
        MenuItem Get(int id);
    }
}
