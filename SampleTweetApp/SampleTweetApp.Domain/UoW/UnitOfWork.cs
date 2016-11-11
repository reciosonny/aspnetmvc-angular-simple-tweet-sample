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
            if (Tweets.Query.Count() == 0) {
                Seed();
            }
        }

        /// <summary>
        /// Populates database automatically if it's empty
        /// </summary>
        public void Seed() {
            var data = new List<Tweet>();

            for (int i = 0; i < 10; i++) {
                data.Add(new Tweet() {
                    FullName = "Sonny Recio",
                    Message = "Hello World!"
                });
            }

            Tweets.AddRange(data);
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
