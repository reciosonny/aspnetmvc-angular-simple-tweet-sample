using SampleTweetApp.Domain.Data;
using SampleTweetApp.Domain.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTweetApp.Domain.UoW {
    public interface IUnitOfWork {
        GenericRepository<Tweet> Tweets {
            get;
        }
        void SaveChanges();

    }
}
