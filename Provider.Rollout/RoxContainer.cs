using Io.Rollout.Rox.Core.Entities;
using Io.Rollout.Rox.Server.Flags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Rollout
{
    public class RoxContainer: IRoxContainer
    {
        //False default value
        public RoxFlag Costings = new RoxFlag(false);
    }
}
