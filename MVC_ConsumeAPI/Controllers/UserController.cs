﻿using MVC_ConsumeAPI.Models;
using MVC_ConsumeAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC_ConsumeAPI.Controllers
{
    public class UserController : Controller
    {
        public ActionResult GetAllUsers()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("user");
                response.EnsureSuccessStatusCode();
                List<User> users = response.Content.ReadAsAsync<List<User>>().Result;
                ViewBag.Title = "All Users";
                return View(users);
            }catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("user/" + id.ToString());
            response.EnsureSuccessStatusCode();
            User user = response.Content.ReadAsAsync<User>().Result;
            ViewBag.Title = "Selected User";
            return View(user);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("user", user);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllUsers");
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            int id = user.UserId;
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("user/" + id.ToString(), user);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllUsers");
        }

        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("user/" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllUsers");
        }
    }
}