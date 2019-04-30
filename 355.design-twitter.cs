/*
 * @lc app=leetcode id=355 lang=csharp
 *
 * [355] Design Twitter

 Design a simplified version of Twitter where users can post tweets, follow/unfollow another user and is able to see the 10 most recent tweets in the user's news feed. Your design should support the following methods:

postTweet(userId, tweetId): Compose a new tweet.
getNewsFeed(userId): Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent.
follow(followerId, followeeId): Follower follows a followee.
unfollow(followerId, followeeId): Follower unfollows a followee.
Example:

Twitter twitter = new Twitter();

// User 1 posts a new tweet (id = 5).
twitter.postTweet(1, 5);

// User 1's news feed should return a list with 1 tweet id -> [5].
twitter.getNewsFeed(1);

// User 1 follows user 2.
twitter.follow(1, 2);

// User 2 posts a new tweet (id = 6).
twitter.postTweet(2, 6);

// User 1's news feed should return a list with 2 tweet ids -> [6, 5].
// Tweet id 6 should precede tweet id 5 because it is posted after tweet id 5.
twitter.getNewsFeed(1);

// User 1 unfollows user 2.
twitter.unfollow(1, 2);

// User 1's news feed should return a list with 1 tweet id -> [5],
// since user 1 is no longer following user 2.
twitter.getNewsFeed(1);
 */
public class Twitter {

    Dictionary<int, int> news;
        Dictionary<int, List<int>> fans;
        List<int> ids;
        /** Initialize your data structure here. */
        public Twitter()
        {
            news = new Dictionary<int, int>();
            fans = new Dictionary<int, List<int>>();
            ids = new List<int>();
        }

        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            news[tweetId] = userId;
            ids.Add(tweetId);
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId)
        {
            List<int> fan;
            if (!fans.TryGetValue(userId, out fan))
            {
                fan = new List<int>();
                fans[userId] = fan;
            }

            List<int> ret = new List<int>();
            for (int i = ids.Count-1; i >= 0; i--)
            {
                int u = news[ids[i]];
                if (u == userId || fan.Contains(u))
                {
                    ret.Add(ids[i]);
                    if(ret.Count >= 10)
                        break;
                }
            }

            return ret;
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {
            if(!fans.ContainsKey(followerId))
                fans[followerId] = new List<int>();

            fans[followerId].Add(followeeId);
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            if(!fans.ContainsKey(followerId))
                return;
            fans[followerId].Remove(followeeId);
        }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */

//  √ Accepted
//   √ 23/23 cases passed (360 ms)
//   √ Your runtime beats 57.14 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (41.1 MB)

