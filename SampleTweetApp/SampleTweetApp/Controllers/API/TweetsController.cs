using SampleTweetApp.Domain.Services;
using SampleTweetApp.Domain.UoW;
using SampleTweetApp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleTweetApp.Controllers.API {
    [RoutePrefix("api/tweets")]
    public class TweetsController : ApiController {
        // GET api/<controller>
        //public IEnumerable<string> Get() {
        //    return new string[] { "value1", "value2" };
        //}

        private TweetService tweetService;
        public TweetsController() {
            tweetService = new TweetService();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTweets() {
            return Ok(tweetService.GetTweets());
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddTweet(TweetViewModel model) {
            tweetService.AddNewTweet(model);

            return Ok("Success!");
        }

        // DELETE api/<controller>/5
        public void Delete(int id) {
        }
    }
}