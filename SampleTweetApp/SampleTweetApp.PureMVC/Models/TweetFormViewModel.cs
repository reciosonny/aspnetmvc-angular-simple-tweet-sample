using SampleTweetApp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTweetApp.PureMVC.Models {
    public class TweetFormViewModel {
        public string TweetMessage { get; set; }
        public IEnumerable<TweetViewModel> Tweets { get; set; }
    }

    public class TweetForm {

    }
}