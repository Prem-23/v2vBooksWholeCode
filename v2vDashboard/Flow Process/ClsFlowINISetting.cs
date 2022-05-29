using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace v2vDashboard.Flow_Process
{
    public class ClsFlowINISetting
    {
        private ClsFlowINISetting()
        {

        }

        private readonly static Lazy<ClsFlowINISetting> objClsFlowINISetting = new Lazy<ClsFlowINISetting>(() => new ClsFlowINISetting());

        public static ClsFlowINISetting GetobjClsFlowINISetting
        {
            get
            {
                return objClsFlowINISetting.Value;
            }
        }
    }
}