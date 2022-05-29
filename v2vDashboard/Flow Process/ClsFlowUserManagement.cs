using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace v2vDashboard.Flow_Process
{
    public class ClsFlowUserManagement
    {
        private ClsFlowUserManagement()
        {

        }

        private readonly static Lazy<ClsFlowUserManagement> objClsFlowUserManagement = new Lazy<ClsFlowUserManagement>(() => new ClsFlowUserManagement());

        public static ClsFlowUserManagement GetClsFlowUserManagement
        {
            get
            {
                return objClsFlowUserManagement.Value;
            }
        }
    }
}