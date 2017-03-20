using System.Web.Http;
using E_Mitra.Model;
using Umbraco.Web.WebApi;
using Umbraco.Core.Models;

namespace E_Mitra.Controller
{
    public class AuthenticateController : UmbracoApiController
    {
        [HttpPost]
        public bool Login([FromBody]UserInfo userInfo)
        {
            var memberService = Services.MemberService;
            //create umbraco member and set the password as a random Guid

            if (memberService.Exists(userInfo.UserName))
            {
                if (this.Members.Login(userInfo.UserName, userInfo.Password))
                {
                    return true;
                }
            }
            
            return true;

        }


        //private bool MemberExists(string emailAddress)
        //{            
        //    return (ApplicationContext.Current.Services.MemberService.GetByEmail(emailAddress) != null);
        //}

        //[System.Web.Http.HttpPost]
        //public bool Register([FromBody]UserInfo userInfo)
        //{
        //    int umbracoMemberId = -1;

        //    if (!MemberExists(userInfo.Email))
        //    {
        //        IMember newMember = ApplicationContext.Current.Services.MemberService.CreateMember(emailAddress, emailAddress, memberName, memberTypeAlias);

        //        try
        //        {
        //            ApplicationContext.Current.Services.MemberService.Save(newMember);
        //            ApplicationContext.Current.Services.MemberService.SavePassword(newMember, memberPassword);
        //            ApplicationContext.Current.Services.MemberService.AssignRole(newMember.Id, memberGroupName);
        //            umbracoMemberId = newMember.Id;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Unable to create new member " + ex.Message);
        //        }
        //    }

        //    return umbracoMemberId;

        //}

        //private static bool SendMail(string toMail, string mailSubject, string msgBody)
        //{
        //    try
        //    {
        //        //Get default email settings from web.config for sending mails
        //        Configuration configurationFile = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
        //        MailSettingsSectionGroup mailSettings = (MailSettingsSectionGroup)configurationFile.GetSectionGroup("system.net/mailSettings");

        //        // "To" address for mails from global item
        //        string to = toMail;
        //        string subjectPrefix = mailSubject;
        //        string smtpHost = mailSettings.Smtp.Network.Host;
        //        string smtpUserName = mailSettings.Smtp.Network.UserName;
        //        string smtpPassword = mailSettings.Smtp.Network.Password;

        //        NetworkCredential loginInfo = new NetworkCredential(smtpUserName, smtpPassword);
        //        MailMessage msg = new MailMessage();
        //        //msg.From = new MailAddress(contactInfo.Email);
        //        msg.From = new MailAddress("inquiry@bhagwativilas.com");
        //        msg.To.Add(new MailAddress(to));
        //        msg.Subject = subjectPrefix;
        //        msg.Body = msgBody;
        //        msg.IsBodyHtml = true;

        //        SmtpClient client = new SmtpClient(smtpHost)
        //        {
        //            Port = mailSettings.Smtp.Network.Port,
        //            UseDefaultCredentials = false,
        //            Credentials = loginInfo
        //        };
        //        client.Send(msg);

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}
    }

}
