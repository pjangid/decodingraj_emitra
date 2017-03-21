using E_Mitra.Model;
using System;
using System.Web.Http;
using umbraco.NodeFactory;
using Umbraco.Web.WebApi;

namespace E_Mitra.Controller
{
    public class ApplicationController : UmbracoApiController
    {
        [System.Web.Http.HttpPost]
        public string NewApplication([FromBody]UserInfo userinfo)
        {


            Random rnd = new Random();
            int num = rnd.Next(0000000, 9999999);
            var txn = num.ToString().PadLeft(7, '0');
            CreateApplication(userinfo, txn);
            return txn;
        }

        private void CreateApplication(UserInfo userInfo, string txn)
        {
            int userId = 0;
            var cs = Services.ContentService;
            var content = cs.CreateContent(DateTime.Today.ToString("yyyyMMddHHmmss") + "_" + userInfo.FirstName + userInfo.LastName, 1083, "ApplicationItem", userId);
            content.SetValue("UID", userInfo.UID);
            content.SetValue("FirstName", userInfo.FirstName);
            content.SetValue("LastName", userInfo.LastName);
            content.SetValue("Email", userInfo.Email);
            content.SetValue("Mobile", userInfo.Mobile);
            content.SetValue("MarkSheetVerification", true);
            content.SetValue("Status", "Pending");
            content.SetValue("TransectionNumber", txn);
            content.SetValue("MarksheetNumber", userInfo.MarksheetNumber);
            cs.SaveAndPublishWithStatus(content);
        }
        [System.Web.Http.HttpPost]
        public string GetApplication([FromBody]UserInfo userinfo)
        {
            var uid = userinfo.UID;
            var userinfoItems = Umbraco.Content(1083).Children.Where("UID==userinfo.UID");            
            var info= userinfoItems == null ? "" : userinfoItems[0];
            return Json(info);
        }
    }
}