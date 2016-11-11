using SampleTweetApp.Domain.Services;
using SampleTweetApp.Domain.ViewModels;
using SampleTweetApp.PureMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleTweetApp.PureMVC.Controllers {
    public class TweetsController : Controller {



        private TweetService tweetService;
        public TweetsController() {
            tweetService = new TweetService();
        }

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection) {
            var username = collection["Username"];

            Session["Username"] = username;

            return RedirectToAction("Index");
        }

        // GET: /Tweets/
        public ActionResult Index() {

            if (Session["Username"] == null) {
                return RedirectToAction("Login");
            }

            var model = new TweetFormViewModel();
            model.Tweets = tweetService.GetTweets();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "TweetMessage")] TweetFormViewModel model) {

            if (Session["Username"] == null) {
                return RedirectToAction("Login");
            }


            var tweetModel = new TweetViewModel();
            tweetModel.TweetMessage = model.TweetMessage;
            tweetModel.FullName = Session["Username"].ToString();

            tweetService.AddNewTweet(tweetModel);

            return RedirectToAction("Index"); //we need to do this to avoid the postback of the page
        }


        //
        // GET: /Tweets/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        //
        // GET: /Tweets/Create
        public ActionResult Create() {
            return View();
        }

        //
        // POST: /Tweets/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        //
        // GET: /Tweets/Edit/5
        public ActionResult Edit(int id) {

            if (Session["Username"] == null) {
                return RedirectToAction("Login");
            }

            var model = tweetService.GetTweet(id);
            model.FullName = Session["Username"].ToString();
            return View(model);
        }

        //
        // POST: /Tweets/Edit/5
        [HttpPost]
        public ActionResult Edit(TweetViewModel model) {
            try {
                // TODO: Add update logic here
                tweetService.UpdateTweet(model);

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        //
        // GET: /Tweets/Delete/5
        public ActionResult Delete(int id) {
            var model = tweetService.GetTweet(id);
            return View(model);
        }

        //
        // POST: /Tweets/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id")] TweetViewModel model) {
            try {
                // TODO: Add delete logic here
                tweetService.DeleteTweet(model.Id);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
