using System.CodeDom;

namespace SimpleApp.Ultilities
{
    /// <summary>
    /// Contains all of the constants strings to be used through out SimpleApp project.
    /// </summary>
    public static class Constant
    {
        #region Controllers

        /// <summary>
        /// Controllers constants
        /// </summary>
        public static class Controllers
        {
            public const string Dashboard = "Dashboard";
            public const string Donors = "Donors";
            public const string Patients = "Patients";
            public const string Account = "Account";
            public const string Manage = "Manage";
            public const string Home = "Home";
        }
        
        #endregion

        #region Actions

        /// <summary>
        /// Actions constants
        /// </summary>
        public static class Actions
        {
            public const string Index = "Index";
            public const string Login = "Login";
            public const string LogOff = "LogOff";
            public const string Register = "Register";
            public const string ResetPassword = "ResetPassword";
            public const string ResetPasswordConfirmation = "ResetPasswordConfirmation";
            public const string ExternalLoginCallback = "ExternalLoginCallback";
            public const string SendCode = "SendCode";
            public const string VerifyCode = "VerifyCode";
            public const string Edit = "Edit";
            public const string Delete = "Delete";
            public const string Details = "Details";
            public const string ManageLogins = "ManageLogins";
            public const string AddPhoneNumber = "AddPhoneNumber";
            public const string ChangePassword = "ChangePassword";
            public const string SetPassword = "SetPassword";
            public const string VerifyPhoneNumber = "VerifyPhoneNumber";
            public const string LinkLoginCallback = "LinkLoginCallback";
            public const string RemoveLogin = "RemoveLogin";
            public const string LinkLogin = "LinkLogin";
            public const string Transplant = "Transplant";
            public const string Create = "Create";
        }
        #endregion

        #region Views

        /// <summary>
        /// Views constants
        /// </summary>
        public static class Views
        {
            public const string Lockout = "Lockout";
            public const string Error = "Error";
            public const string ConfirmEmail = "ConfirmEmail";
            public const string ForgotPassword = "ForgotPassword";
            public const string ForgotPasswordConfirmation = "ForgotPasswordConfirmation";
            public const string Login = "Login";
            public const string ExternalLoginConfirmation = "ExternalLoginConfirmation";
            public const string ExternalLoginFailure = "ExternalLoginFailure";
            public const string ExternalLogin = "ExternalLogin";
        }
        #endregion

        #region Other

        #endregion


    }
}