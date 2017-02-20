using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Common.Share
{
    /// <summary>
    /// Type of alerts.
    /// </summary>
    public enum AlertType
    {
        Danger,
        Warning,
        Info,
        Success
    }

    /// <summary>
    /// Is used to create a html view with different alert types.
    /// </summary>
    public class AlertView
    {
        private static string convertTypeToString(AlertType a)
        {
            switch (a)
            {
                case AlertType.Danger:
                    return "danger";
                case AlertType.Warning:
                    return "warning";
                case AlertType.Info:
                    return "info";
                case AlertType.Success:
                    return "success";
            }

            return "";
        }

        private static string buildInDiv(string message, AlertType a)
        {
            return "<div class=\"alert alert-" + convertTypeToString(a) + "\">" + message + "</div>";
        }

        public static string BuildErrors(ViewDataDictionary errorViewData)
        {
            string errorBuild = "";
            int x = 0;
            foreach (ModelState modelState in errorViewData.ModelState.Values)
            {
                if (modelState.Errors.Count > 0)
                {
                    if (x != 0)
                        errorBuild += "<br/>";

                    int y = 0;
                    foreach (ModelError error in modelState.Errors)
                        if (y == 0)
                        {
                            errorBuild += error.ErrorMessage;
                            y = 1;
                        }
                        else
                            errorBuild += ", " + error.ErrorMessage;

                    x = 1;
                }
            }

            return buildInDiv(errorBuild, AlertType.Danger);
        }

        public static string Build(string message, AlertType a)
        {
            return buildInDiv(message, a);
        }
    }
}