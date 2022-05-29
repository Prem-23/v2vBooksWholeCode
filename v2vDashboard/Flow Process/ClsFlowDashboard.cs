using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace v2vDashboard.Flow_Process
{
    public class ClsFlowDashboard
    {
        private ClsFlowDashboard()
        {

        }

        private readonly static Lazy<ClsFlowDashboard> objClsFlowDashboard = new Lazy<ClsFlowDashboard>(() => new ClsFlowDashboard());

        public static ClsFlowDashboard GetobjClsFlowDashboard
        {
            get
            {
                return objClsFlowDashboard.Value;
            }
        }
    }
}