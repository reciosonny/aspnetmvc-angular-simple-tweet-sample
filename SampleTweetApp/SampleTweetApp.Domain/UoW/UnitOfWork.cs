using SampleTweetApp.Domain.Data;
using SampleTweetApp.Domain.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTweetApp.Domain.UoW {
    public class UnitOfWork : IUnitOfWork {
        private TweetDataContainer tweetContext = new TweetDataContainer();

        public UnitOfWork() {

        }

        public GenericRepository<Tweet> Tweets {
            get {
                return new GenericRepository<Tweet>(tweetContext);
            }
        }

        public void SaveChanges() {
            tweetContext.SaveChanges();
        }

    }
}
