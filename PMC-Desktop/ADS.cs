using CircularProgressBar;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PMC_Desktop {

    /// <summary>
    /// Active Directory Services.  Contains functions and properties pertaining to Active Directory access, viewing, and editing.
    /// </summary>
    static class ADS {
        /// <summary>
        /// DirectorySearcher preset to locate users in the "OU=Users" directory.  Filter must be edited in order to specify finer results.
        /// </summary>
        public static DirectorySearcher searcher = new DirectorySearcher (new DirectoryEntry ("LDAP://OU=Users, OU=Springdale, DC=US, DC=PaschalCorp, DC=com")) {
            Filter = "(objectClass=user)"
        };

        /// <summary>
        /// DirectorySearcher preset to locate users in the "OU=Terminated" directory.  Filter must be edited in order to specify finer results.
        /// </summary>
        public static DirectorySearcher termSearcher = new DirectorySearcher (new DirectoryEntry ("LDAP://OU=Terminated, OU=Springdale, DC=US, DC=PaschalCorp, DC=com")) {
            Filter = "(objectClass=user)"
        };

        /// <summary>
        /// DirectoyrSearcher preset to locate all users in the Springdale OU.
        /// </summary>
        public static DirectorySearcher exSearcher = new DirectorySearcher (new DirectoryEntry ("LDAP://OU=Springdale, DC=US, DC=PaschalCorp, DC=com")) {
            Filter = "(objectClass=user)"
        };

        /// <summary>
        /// NetworkCredential for global credential permenence.  Defaults to null until set by ChangeLogon () function.
        /// </summary>
        public static NetworkCredential cred = null;
        /// <summary>
        /// PrincipalContext for global usage.  Used as reference for UserPrincipal and GroupPrincipal searches.
        /// </summary>
        public static PrincipalContext context = new PrincipalContext (ContextType.Domain);
        /// <summary>
        /// Global user list containing all possible returns from "OU=Users" directory.  Primarily used for populating comboUMUserSelect.
        /// </summary>
        public static SearchResultCollection userList = searcher.FindAll ();
        /// <summary>
        /// Refined global list specifically containing usernames from global userList.
        /// </summary>
        public static List<string> UsernameList { get; set; }
        /// <summary>
        /// Global user list containing all possible returns from "OU=Terminated" directory.  Primarily used for populating comboUMUserSelect when checkUMTerminatedUsers is toggled.
        /// </summary>
        public static SearchResultCollection userListTerm = termSearcher.FindAll ();
        /// <summary>
        /// Refined global list specifically containing usernames from global userListTerm.
        /// </summary>
        public static List<string> UsernameListTerm { get; set; }

        /// <summary>
        /// Performs full refresh of both userList and userListTerm by pulling new results from LDAP.  Requires parameter of cover form to be passed in to function.
        /// </summary>
        /// <param name="cover">Cover form generated to display progress of user list update.</param>
        public static void UpdateUsernameLists (formProgress cover) {
            cover.ProgressMaximum = userList.Count + userListTerm.Count;
            cover.ProgressText = "Creating searcher objects...";
            cover.Refresh ();
            cover.ProgressRefresh ();
            searcher.SearchRoot.Path = "LDAP://OU=Users, OU=Springdale, DC=US, DC=PaschalCorp, DC=com";
            searcher.Filter = "(objectClass=user)";
            termSearcher.SearchRoot.Path = "LDAP://OU=Terminated, OU=Springdale, DC=US, DC=PaschalCorp, DC=com";
            termSearcher.Filter = "(objectClass=user)";

            cover.ProgressText = "Retrieving\r\nActive Users...";
            UsernameList = new List<string> ();
            foreach (SearchResult res in userList) {
                UsernameList.Add ((string)res.GetDirectoryEntry ().Properties["samaccountname"].Value);
                cover.ProgressStep ();
            }
            //cover.ProgressText = "Sorting...";
            UsernameList.Sort ();

            cover.ProgressText = "Retrieving\r\nTerminated users...";
            //cover.ProgressMaximum = userListTerm.Count;
            UsernameListTerm = new List<string> ();
            foreach (SearchResult res in userListTerm) {
                UsernameListTerm.Add ((string)res.GetDirectoryEntry ().Properties["samaccountname"].Value);
                cover.ProgressStep ();
            }
            //cover.ProgressText = "Sorting...";
            UsernameListTerm.Sort ();
        }

        /// <summary>
        /// Builds List of usernames and sorts before returning values.
        /// </summary>
        /// <param name="term">Boolean value determining whether to include terminated users in list.  Typically provided by checkUMTerminatedUsers.Checked value.</param>
        /// <returns>List containing string usernames of all Active users, as well as Terminated users if term is true.</returns>
        public static List<string> PopulateUserList (bool term) {
            List<string> temp = new List<string> {
                ""
            };
            temp.AddRange (UsernameList);
            if (term) {
                temp.AddRange (UsernameListTerm);
            }
            temp.Sort ();
            return temp;
        }

        /// <summary>
        /// Searches for a single user in "OU=Users" directory based on input.  Checks first if input is DistinguishedName, then SamAccountName, then uses ANR if both fail.
        /// </summary>
        /// <param name="input">String input of unique identifier for user to return.  DistinguishedName or SamAccountName are preferred, otherwise uses ANR.</param>
        /// <returns>SearchResult object of located user information.</returns>
        public static SearchResult GetSingleUser (string input) {
            if (Regex.IsMatch (input, "CN=")) {
                searcher.Filter = $"(&(objectClass=user)(distinguishedname={input}))";
                SearchResult temp = searcher.FindOne ();
                searcher.Filter = "(objectClass=user)";
                return temp;
            } else if (IsLower (input)) {
                searcher.Filter = $"(&(objectClass=user)(samaccountname={input}))";
                SearchResult temp = searcher.FindOne ();
                searcher.Filter = "(objectClass=user)";
                return temp;
            } else {
                searcher.Filter = $"(&(objectClass=user)(anr={input}))";
                SearchResult temp = searcher.FindOne ();
                searcher.Filter = "(objectClass=user)";
                return temp;
            }
        }

        /// <summary>
        /// Searches for a single user in "OU=Terminated" directory based on input.  Checks first if input is DistinguishedName, then SamAccountName, then uses ANR if both fail.
        /// </summary>
        /// <param name="input">String input of unique identifier for user to return.  DistinguishedName or SamAccountName are preferred, otherwise uses ANR.</param>
        /// <returns>SearchResult object of located user information.</returns>
        public static SearchResult GetTerminatedUser (string input) {
            if (Regex.IsMatch (input, "CN=")) {
                termSearcher.Filter = $"(&(objectClass=user)(distinguishedname={input}))";
                SearchResult temp = termSearcher.FindOne ();
                termSearcher.Filter = "(objectClass=user)";
                return temp;
            } else if (IsLower (input)) {
                termSearcher.Filter = $"(&(objectClass=user)(samaccountname={input}))";
                SearchResult temp = termSearcher.FindOne ();
                termSearcher.Filter = "(objectClass=user)";
                return temp;
            } else {
                termSearcher.Filter = $"(&(objectClass=user)(anr={input}))";
                SearchResult temp = termSearcher.FindOne ();
                termSearcher.Filter = "(objectClass=user)";
                return temp;
            }
        }

        public static SearchResult GetEXUser (string input) {
            if (Regex.IsMatch (input, "CN=")) {
                exSearcher.Filter = $"(&(objectClass=user)(distinguishedname={input}))";
                SearchResult temp = exSearcher.FindOne ();
                exSearcher.Filter = "(objectClass=user)";
                return temp;
            } else if (IsLower (input)) {
                exSearcher.Filter = $"(&(objectClass=user)(samaccountname={input}))";
                SearchResult temp = exSearcher.FindOne ();
                exSearcher.Filter = "(objectClass=user)";
                return temp;
            } else {
                exSearcher.Filter = $"(&(objectClass=user)(anr={input}))";
                SearchResult temp = exSearcher.FindOne ();
                exSearcher.Filter = "(objectClass=user)";
                return temp;
            }
        }

        /// <summary>
        /// Returns true if all char values contained in input string are lowercase.  If any are uppercase, returns false.
        /// </summary>
        /// <param name="input">String value to be checked.</param>
        /// <returns>Returns true if all char are lowercase.  Else returns false.</returns>
        public static bool IsLower (string input) {
            for (int i = 0; i < input.Length; i++) {
                if (!char.IsLower (input[i])) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Prompts user to provide new credentials for logon.  Returns true if credentials successfully validate to ActiveDirectory server.
        /// </summary>
        /// <returns>Returns true if credentials validate with ActiveDirectory.  If validation fails, returns false.</returns>
        public static bool ChangeLogon () {
            using (CredentialDialog dialog = new CredentialDialog () {
                Target = "us.paschalcorp.com",
                MainInstruction = "Please supply logon credentials."
            }) {
                if (dialog.ShowDialog () == DialogResult.OK) {
                    if (context.ValidateCredentials (dialog.UserName, dialog.Password)) {
                        cred = new NetworkCredential (dialog.UserName, dialog.Password);
                        searcher = new DirectorySearcher (new DirectoryEntry (searcher.SearchRoot.Path, cred.UserName, cred.Password));
                        termSearcher = new DirectorySearcher (new DirectoryEntry (termSearcher.SearchRoot.Path, cred.UserName, cred.Password));
                        context = new PrincipalContext (ContextType.Domain, "us.paschalcorp.com", cred.UserName, cred.Password);
                        return true;
                    } else {
                        MessageBox.Show ("Credentials failed to validate.  Current logon has not changed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return false;
        }
    }

    /// <summary>
    /// Class contains all necessary properties of ActiveDirectory users for usage in PMC processes.
    /// </summary>
    public class User {

        /// <summary>
        /// Sets CurrentUser object with values necessary for usage in PMC processes.
        /// </summary>
        /// <param name="input">String input for passing into ADS.GetSingleUser and/or ADS.GetTerminatedUser.  Must be unique identifier or process will fail.</param>
        /// <param name="term">Boolean value determining whether or not to include Terminated users in search.</param>
        public void SetUser (string input, bool term) {
            //CurrentUser = ADS.searcher.FindOne ();
            if (input != null) {
                CurrentUser = ADS.GetSingleUser (input);

                if (term && CurrentUser == null) {
                    CurrentUser = ADS.GetTerminatedUser (input);
                }
                if (CurrentUser == null) {
                    CurrentUser = ADS.GetEXUser (input);
                }

                if (CurrentUser != null) {
                    userTools = UserPrincipal.FindByIdentity (ADS.context, Username);
                }
            }
        }

        /// <summary>
        /// Parses user's Direct Reports into a string of Display Names.
        /// </summary>
        /// <param name="user">SearchResult value of user with Direct Reports to parse.</param>
        /// <returns>List of string values containing Display Names of all Direct Reports under provided user.</returns>
        private List<User> GetUserDirectReports (SearchResult user) {
            List<User> temp = new List<User> ();
            foreach (var item in user.Properties["directreports"]) {
                User newuser = new User ();
                newuser.SetUser (item.ToString (), true);
                if (newuser == null) {
                    newuser.Name = $"Not found - {item.ToString ().Split (',')[0].Substring (3)}";
                }
                temp.Add (newuser);
            }
            return temp;
        }

        /// <summary>
        /// Parses user's Manager value (DistinguishedName) into Manager's Display Name.
        /// </summary>
        /// <param name="user">SearchResult of user with Manager to parse.</param>
        /// <returns>String value of Manager's Display Name.</returns>
        private string GetUserManager (SearchResult user) {
            string managername;
            try {
                managername = (string)ADS.GetSingleUser ((string)user.Properties["manager"][0]).Properties["displayname"][0];
            } catch {
                try {
                    managername = $"Term - {(string)ADS.GetTerminatedUser ((string)user.Properties["manager"][0]).Properties["displayname"][0]}";
                } catch {
                    try {
                        managername = $"Not found - {user.Properties["manager"][0].ToString ().Split (',')[0].Substring (3)}";
                    } catch {
                        managername = "Not Listed";
                    }
                }
            }
            return managername;
        }

        /// <summary>
        /// SearchResult value for internal usage.
        /// </summary>
        private SearchResult CurrentUser;
        /// <summary>
        /// UserPrincipal value for usage in complex processes.  Ex. Reset Password, Enable/Disable Account.
        /// </summary>
        public UserPrincipal userTools;
        /// <summary>
        /// Display Name of user.
        /// </summary>
        public string Name {
            get => CurrentUser != null && CurrentUser.Properties["displayname"].Count > 0
            ? CurrentUser.Properties["displayname"][0].ToString ()
            : "N/A";
            set {
                userTools.Name = value;
                userTools.Save ();
                SetUser (CurrentUser.Properties["samaccountname"][0].ToString (), true);
            }
        }
        /// <summary>
        /// SamAccountName of user.
        /// </summary>
        public string Username
            => CurrentUser != null && CurrentUser.Properties["samaccountname"].Count > 0
            ? CurrentUser.Properties["samaccountname"][0].ToString ()
            : "N/A";
        /// <summary>
        /// DistinguishedName of user.
        /// </summary>
        public string DistinguishedName {
            get => CurrentUser != null && CurrentUser.Properties["distinguishedname"].Count > 0
                ? CurrentUser.Properties["distinguishedname"][0].ToString ()
                : "N/A";
        }
        /// <summary>
        /// Primary email address of user.
        /// </summary>
        public string Email
            => CurrentUser != null && CurrentUser.Properties["mail"].Count > 0
            ? CurrentUser.Properties["mail"][0].ToString ()
            : "N/A";
        /// <summary>
        /// Department of user.
        /// </summary>
        public string Department
            => CurrentUser != null && CurrentUser.Properties["department"].Count > 0
            ? CurrentUser.Properties["department"][0].ToString ()
            : "N/A";
        /// <summary>
        /// Job title of user.
        /// </summary>
        public string Title
            => CurrentUser != null && CurrentUser.Properties["title"].Count > 0
            ? CurrentUser.Properties["title"][0].ToString ()
            : "N/A";
        /// <summary>
        /// Manager of user.
        /// </summary>
        public string Manager
            => CurrentUser != null && CurrentUser.Properties["manager"].Count > 0
            ? GetUserManager (CurrentUser)
            : "N/A";
        /// <summary>
        /// Enabled status of user.
        /// </summary>
        public string Enabled
            => CurrentUser != null && CurrentUser.Properties["useraccountcontrol"].Count > 0 && !Convert.ToBoolean ((int)CurrentUser.Properties["useraccountcontrol"][0] & 2)
            ? "True"
            : "False";
        /// <summary>
        /// String date/time of user's most recent valid logon.
        /// </summary>
        public string LastLogon
            => CurrentUser != null && CurrentUser.Properties["lastlogon"].Count > 0
            ? DateTime.FromFileTime ((long)CurrentUser.Properties["lastlogon"][0]).ToString ()
            : "N/A";
        /// <summary>
        /// Employee ID of user.
        /// </summary>
        public string EmployeeID
            => CurrentUser != null && CurrentUser.Properties["employeeid"].Count > 0
            ? CurrentUser.Properties["employeeid"][0].ToString ()
            : "N/A";
        /// <summary>
        /// Employee Number of user.  Only visible if logged in viewer has admin privileges.
        /// </summary>
        public string EmployeeNumber
            => CurrentUser != null && CurrentUser.Properties["employeenumber"].Count > 0
            ? CurrentUser.Properties["employeenumber"][0].ToString ()
            : "RESTRICTED";
        /// <summary>
        /// String date/time of the most recent time the user's password was changed.
        /// </summary>
        public string PassLastChanged
            => CurrentUser != null && CurrentUser.Properties["pwdlastset"].Count > 0
            ? DateTime.FromFileTime ((long)CurrentUser.Properties["pwdlastset"][0]).ToString ()
            : "N/A";
        /// <summary>
        /// String date/time of when the user's password will expire, if at all.
        /// </summary>
        public string PassExpiration
            => CurrentUser == null || (CurrentUser.Properties["pwdlastset"].Count > 0 && Convert.ToBoolean ((int)CurrentUser.Properties["useraccountcontrol"][0] & 65536))
            ? "N/A" 
            : DateTime.FromFileTime ((long)CurrentUser.Properties["pwdlastset"][0]).AddDays (120).ToString ();
        /// <summary>
        /// Integer of the number of times the user has failed logon validation.
        /// </summary>
        public string FailedLogonNum
            => CurrentUser != null && CurrentUser.Properties["badpwdcount"].Count > 0
            ? CurrentUser.Properties["badpwdcount"][0].ToString ()
            : "N/A";
        /// <summary>
        /// String date/time of the most recent time the user failed logon validation.
        /// </summary>
        public string FailedLogonTime
            => CurrentUser != null && CurrentUser.Properties["badpasswordtime"].Count > 0
            ? DateTime.FromFileTime ((long)CurrentUser.Properties["badpasswordtime"][0]).ToString ()
            : "N/A";
        /// <summary>
        /// String date of when the user was hired.
        /// </summary>
        public string DateOfHire
            => CurrentUser != null && Regex.IsMatch (CurrentUser.Properties["description"][0].ToString (), "DoH -")
            ? DateTime.Parse (CurrentUser.Properties["description"][0].ToString ().Split (' ')[2]).ToShortDateString ()
            : "N/A";
        /// <summary>
        /// String date of when the user was terminated, if at all.
        /// </summary>
        public string DateOfTermination
            => CurrentUser != null && Regex.IsMatch (CurrentUser.Properties["description"][0].ToString (), @"DoT - \d{2}")
            ? DateTime.Parse (CurrentUser.Properties["description"][0].ToString ().Split (' ')[6].ToString ()).ToShortDateString ()
            : "N/A";
        /// <summary>
        /// String date/time of the most recent time the user's ActiveDirectory information was modified, if at all.
        /// </summary>
        public string LastModified
            => CurrentUser != null && CurrentUser.Properties["whenchanged"].Count > 0
            ? CurrentUser.Properties["whenchanged"][0].ToString () // DateTime.FromFileTime ((long)CurrentUser.Properties["whenchanged"][0]).ToString ()
            : "N/A";
        /// <summary>
        /// String list showing the Display Names of all Direct Reports under the user, if any.
        /// </summary>
        public List<User> DirectReports
            => CurrentUser != null && CurrentUser.Properties["directreports"].Count > 0
            ? GetUserDirectReports (CurrentUser)
            : new List<User> ();
        /// <summary>
        /// Boolean value indicating whether the user's account is locked.
        /// </summary>
        public bool IsLocked
            => CurrentUser != null && userTools.IsAccountLockedOut ();
    }
}
