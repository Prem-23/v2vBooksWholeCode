using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace v2vDashboard.Flow_Process
{
    public class ClsFlowViewandEdit
    {
        private ClsFlowViewandEdit()
        {

        }

        private readonly static Lazy<ClsFlowViewandEdit> objClsFlowViewandEdit = new Lazy<ClsFlowViewandEdit>(() => new ClsFlowViewandEdit());

        public static ClsFlowViewandEdit GetobjClsFlowViewandEdit
        {
            get
            {
                return objClsFlowViewandEdit.Value;
            }
        }
    }
}