﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMS.Core.Entities;
using FMS.Core.Service;
using FMS.Core.Service.Interfaces;
using FMS.Infrastructure;

namespace ATP2.FMS.Controllers
{
    public class UserController : Controller
    {
 
        private IUserInfoService _service;

        public UserController(IUserInfoService service)
        {
            _service = service;
        }
        public ActionResult RegisterForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterForm(UserInfo userInfo)
        {


            try
            {
                var result = _service.Save(userInfo);
                if (result.HasError)
                {
                    ViewBag.Message = result.Message;
                    return View("RegisterForm", userInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //var jasonUserInfo = JsonConvert.SerializeObject(userInfo);
            ////FormsAuthentication.SignOut();
            //FormsAuthentication.SetAuthCookie(jasonUserInfo, false);

            //CurrentUser.User = userInfo;
            if (userInfo.UserType.Equals("Owner"))
                return RedirectToAction("RegisterForm", "User");

            else
            {
                return RedirectToAction("LogInForm");

            }


        }
    }
}