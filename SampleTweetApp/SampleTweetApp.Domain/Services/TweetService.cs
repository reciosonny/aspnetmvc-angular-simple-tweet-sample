using SampleTweetApp.Domain.Data;
using SampleTweetApp.Domain.UoW;
using SampleTweetApp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTweetApp.Domain.Services {
    public class TweetService {

        IUnitOfWork uo;
        /// <summary>
        /// Supposedly, if we apply dependency constructor injection here, we don't need to instantiate this manually on our own.
        /// </summary>
        public TweetService() {
            uo = new UnitOfWork();
        }

        public void AddNewTweet(TweetViewModel model) {
            uo.Tweets.Add(new Tweet() {
                FullName = model.FullName,
                Message = model.TweetMessage
            });
            uo.SaveChanges();
        }

        public void UpdateTweet(TweetViewModel model) {
            uo.Tweets.Update(new Tweet() {
                Id = model.Id,
                FullName = model.FullName,
                Message = model.TweetMessage
            });
            uo.SaveChanges();
        }

        public void DeleteTweet(int id) {
            var tweet = uo.Tweets.GetItem(id);

            uo.Tweets.Remove(tweet);
            uo.SaveChanges();
        }

        public TweetViewModel GetTweet(int id) {
            var result = uo.Tweets.GetItem(id);
            var model = new TweetViewModel() {
                FullName = result.FullName,
                TweetMessage = result.Message,
                Id = result.Id
            };
            return model;
        }

        public IEnumerable<TweetViewModel> GetTweets() {
            return uo.Tweets.GetAll().Select(x => new TweetViewModel() {
                FullName = x.FullName,
                TweetMessage = x.Message,
                Id = x.Id
            }).OrderByDescending(x => x.Id);
        }



    }
}
