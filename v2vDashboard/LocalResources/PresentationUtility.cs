using BusinessObjectLayer;
using DataAccessLayer;
using Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace v2vDashboard.LocalResources
{
    public abstract class PresentationCls
    {
        public abstract void fun_GetIniSetting(Page PageObject);
    }
    public sealed class PresentationUtility : PresentationCls
    {
        private PresentationUtility()
        {
            //fun_GetIniSetting();
        }

        private static readonly Lazy<PresentationUtility> objPresentationUtility = new Lazy<PresentationUtility>(() => new PresentationUtility());
        ClsLogWriter objClsLogWriter = ClsLogWriter.GetObjLogger;
        ClsCommanBAL objClsCommanBAL = new ClsCommanBAL();
        Utilites objUtilites = new Utilites();

        public static PresentationUtility GetPresentationUtility
        {
            get
            {
                return objPresentationUtility.Value;
            }
        }

        public override void fun_GetIniSetting(Page PageObject)
        {
            DataTable dtGetINISetting = new DataTable();
            try
            {
                dtGetINISetting = objClsCommanBAL.fun_GetINISetting();
                if (dtGetINISetting.Rows[0][0].ToString() == "0")
                {
                    objClsLogWriter.fun_LogWirter("Have an Error in SP - USP_GETINISETTING");
                    return;
                }
                if (dtGetINISetting.Rows.Count > 0)
                {
                    for (int i = 0; i < dtGetINISetting.Rows.Count; i++)
                    {
                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "expdate")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["ExpDate"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["ExpDate"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "image source path")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["IMAGESOURCEPATH"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["IMAGESOURCEPATH"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "log path")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["LOGPATH"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["LOGPATH"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "log folder name")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["LOGFOLDERPATH"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["LOGFOLDERPATH"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "web host name")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["WEBHOSTNAME"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["WEBHOSTNAME"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "image host name")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["IMAGEHOSTNAME"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["IMAGEHOSTNAME"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToUpper() == "COMMON ERROR")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["WEBSITECOMMONERROR"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["WEBSITECOMMONERROR"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "mail from")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["MAILFROM"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["MAILFROM"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "mail to")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["MAILTO"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["MAILTO"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "mail subject")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["MAILSUBJECT"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["MAILSUBJECT"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "smtp")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["SMTP"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["SMTP"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "smtp port")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["SMTPPORT"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["SMTPPORT"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "mail password")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["MAILPASSWORD"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["MAILPASSWORD"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "whatsapp")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["WA"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["WA"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "mail")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["EMAIL"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["EMAIL"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "whatsapp number")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["WHATSAPPNUMBER"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["WHATSAPPNUMBER"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "mobile")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["MOBORSMS"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["MOBORSMS"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "cc mail")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["CCMail"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["CCMail"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }

                        if (dtGetINISetting.Rows[i]["INI_DESCRIPTION"].ToString().ToLower() == "bcc mail")
                        {
                            if (dtGetINISetting.Rows[i]["INI_VALUE"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == true)
                                    PageObject.Session["BCCMail"] = objUtilites.EDataToData(dtGetINISetting.Rows[i]["INI_VALUE"].ToString());
                                else if (Convert.ToBoolean(dtGetINISetting.Rows[i]["INI_ISENCRYPT"]) == false)
                                    PageObject.Session["BCCMail"] = dtGetINISetting.Rows[i]["INI_VALUE"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "PresentationUtility.cs");
            }
        }

    }
}