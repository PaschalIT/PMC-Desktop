﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace PMC_Desktop {
    static class ADS {
        public static DirectorySearcher searcher = new DirectorySearcher (new DirectoryEntry ("LDAP://OU=Users, OU=Springdale, DC=US, DC=PaschalCorp, DC=com")) {
            Filter = "(objectClass=user)"
        };
        public static DirectorySearcher termSearcher = new DirectorySearcher (new DirectoryEntry ("LDAP://OU=Terminated, OU=Springdale, DC=US, DC=PaschalCorp, DC=com")) {
            Filter = "(objectClass=user)"
        };

        public static SearchResultCollection userList = searcher.FindAll ();
        public static List<string> UsernameList { get; set; }
        public static SearchResultCollection userListTerm = termSearcher.FindAll ();
        public static List<string> UsernameListTerm { get; set; }
        public static void UpdateUsernameLists () {
            searcher = new DirectorySearcher (new DirectoryEntry ("LDAP://OU=Users, OU=Springdale, DC=US, DC=PaschalCorp, DC=com")) {
                Filter = "(objectClass=user)"
            };
            termSearcher = new DirectorySearcher (new DirectoryEntry ("LDAP://OU=Terminated, OU=Springdale, DC=US, DC=PaschalCorp, DC=com")) {
            Filter = "(objectClass=user)"
            };

            UsernameList = new List<string> ();
            foreach (SearchResult res in userList) {
                UsernameList.Add ((string)res.GetDirectoryEntry ().Properties["samaccountname"].Value);
            }
            UsernameList.Sort ();
            UsernameListTerm = new List<string> ();
            foreach (SearchResult res in userListTerm) {
                UsernameListTerm.Add ((string)res.GetDirectoryEntry ().Properties["samaccountname"].Value);
            }
            UsernameListTerm.Sort ();
        }

        public static List<string> PopulateUserList (bool term) {
            List<string> temp = new List<string> ();
            temp.AddRange (UsernameList);
            if (term) {
                temp.AddRange (UsernameListTerm);
            }
            temp.Sort ();
            return temp;
        }

        public static SearchResult GetSingleUser (string input) {
            if (Regex.IsMatch (input, "CN=")) {
                searcher.Filter = $"(&(objectClass=user)(distinguishedname={input}))";
                SearchResult temp = searcher.FindOne ();
                searcher.Filter = "(objectClass=user)";
                return temp;
            } else {
                searcher.Filter = $"(&(objectClass=user)(samaccountname={input}))";
                SearchResult temp = searcher.FindOne ();
                searcher.Filter = "(objectClass=user)";
                return temp;
            }
        }

        public static SearchResult GetTerminatedUser (string input) {
            if (Regex.IsMatch (input, "CN=")) {
                termSearcher.Filter = $"(&(objectClass=user)(distinguishedname={input}))";
                SearchResult temp = termSearcher.FindOne ();
                termSearcher.Filter = "(objectClass=user)";
                return temp;
            } else {
                termSearcher.Filter = $"(&(objectClass=user)(samaccountname={input}))";
                SearchResult temp = termSearcher.FindOne ();
                termSearcher.Filter = "(objectClass=user)";
                return temp;
            }
        }
    }

    public class User {
        public void SetUser (string input, bool term) {
            //CurrentUser = ADS.searcher.FindOne ();
            if (input != null) {
                CurrentUser = ADS.GetSingleUser (input);

                if (term && CurrentUser == null) {
                    CurrentUser = ADS.GetTerminatedUser (input);
                }
            }
        }

        private List<string> GetUserDirectReports (SearchResult user) {
            List<string> temp = new List<string> ();
            foreach (var item in user.Properties["directreports"]) {
                try {
                    temp.Add ((string)ADS.GetSingleUser (item.ToString ()).Properties["displayname"][0]);
                } catch {
                    try {
                        temp.Add ($"Term - {(string)ADS.GetTerminatedUser (item.ToString ()).Properties["displayname"][0]}");
                    } catch {
                        temp.Add ($"Not found - {item.ToString ().Split (',')[0].Substring (3)}");
                    }
                }
            }
            return temp;
        }

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

        private SearchResult CurrentUser;
        public string Name
            => CurrentUser != null && CurrentUser.Properties["displayname"].Count > 0
            ? CurrentUser.Properties["displayname"][0].ToString ()
            : "N/A";
        public string Username
            => CurrentUser != null && CurrentUser.Properties["samaccountname"].Count > 0
            ? CurrentUser.Properties["samaccountname"][0].ToString ()
            : "N/A";
        public string Email
            => CurrentUser != null && CurrentUser.Properties["mail"].Count > 0
            ? CurrentUser.Properties["mail"][0].ToString ()
            : "N/A";
        public string Department
            => CurrentUser != null && CurrentUser.Properties["department"].Count > 0
            ? CurrentUser.Properties["department"][0].ToString ()
            : "N/A";
        public string Title
            => CurrentUser != null && CurrentUser.Properties["title"].Count > 0
            ? CurrentUser.Properties["title"][0].ToString ()
            : "N/A";
        public string Manager
            => CurrentUser != null && CurrentUser.Properties["manager"].Count > 0
            ? GetUserManager (CurrentUser)
            : "N/A";
        public string Enabled
            => CurrentUser != null && !Convert.ToBoolean ((int)CurrentUser.Properties["useraccountcontrol"][0] & 2)
            ? "True"
            : "False";
        public string LastLogon
            => CurrentUser != null && CurrentUser.Properties["lastlogon"].Count > 0
            ? DateTime.FromFileTime ((long)CurrentUser.Properties["lastlogon"][0]).ToString ()
            : "N/A";
        public string EmployeeID
            => CurrentUser != null && CurrentUser.Properties["employeeid"].Count > 0
            ? CurrentUser.Properties["employeeid"][0].ToString ()
            : "N/A";
        public string EmployeeNumber
            => CurrentUser != null && CurrentUser.Properties["employeenumber"].Count > 0
            ? CurrentUser.Properties["employeenumber"][0].ToString ()
            : "RESTRICTED";
        public string PassLastChanged
            => CurrentUser != null && CurrentUser.Properties["pwdlastset"].Count > 0
            ? DateTime.FromFileTime ((long)CurrentUser.Properties["pwdlastset"][0]).ToString ()
            : "N/A";
        public string PassExpiration
            => CurrentUser == null || (CurrentUser.Properties["pwdlastset"].Count > 0 && Convert.ToBoolean ((int)CurrentUser.Properties["useraccountcontrol"][0] & 65536))
            ? "N/A" 
            : DateTime.FromFileTime ((long)CurrentUser.Properties["pwdlastset"][0]).AddDays (120).ToString ();
        public string FailedLogonNum
            => CurrentUser != null && CurrentUser.Properties["badpwdcount"].Count > 0
            ? CurrentUser.Properties["badpwdcount"][0].ToString ()
            : "N/A";
        public string FailedLogonTime
            => CurrentUser != null && CurrentUser.Properties["badpasswordtime"].Count > 0
            ? DateTime.FromFileTime ((long)CurrentUser.Properties["badpasswordtime"][0]).ToString ()
            : "N/A";
        public string DateOfHire
            => CurrentUser != null && Regex.IsMatch (CurrentUser.Properties["description"][0].ToString (), "DoH -")
            ? DateTime.Parse (CurrentUser.Properties["description"][0].ToString ().Split (' ')[2]).ToShortDateString ()
            : "N/A";
        public string DateOfTermination
            => CurrentUser != null && Regex.IsMatch (CurrentUser.Properties["description"][0].ToString (), @"DoT - \d{2}")
            ? DateTime.Parse (CurrentUser.Properties["description"][0].ToString ().Split (' ')[6].ToString ()).ToShortDateString ()
            : "N/A";
        public string LastModified
            => CurrentUser != null && CurrentUser.Properties["whenchanged"].Count > 0
            ? CurrentUser.Properties["whenchanged"][0].ToString () // DateTime.FromFileTime ((long)CurrentUser.Properties["whenchanged"][0]).ToString ()
            : "N/A";
        public List<string> DirectReports
            => CurrentUser != null && CurrentUser.Properties["directreports"].Count > 0
            ? GetUserDirectReports (CurrentUser)
            : new List<string> () {
                "N/A"
            };
    }
}
