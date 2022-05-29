using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace v2vDashboard.Flow_Process
{
    public class ClsFlowLogin
    {
        private ClsFlowLogin()
        {

        }

        private readonly static Lazy<ClsFlowLogin> objClsFlowLogin = new Lazy<ClsFlowLogin>(() => new ClsFlowLogin());

        public static ClsFlowLogin GetobjClsFlowLogin
        {
            get
            {
                return objClsFlowLogin.Value;
            }
        }
    }
}