/*
 * @lc app=leetcode id=911 lang=csharp
 *
 * [911] Online Election

 In an election, the i-th vote was cast for persons[i] at time times[i].

Now, we would like to implement the following query function: TopVotedCandidate.q(int t) will return the number of the person that was leading the election at time t.  

Votes cast at time t will count towards our query.  In the case of a tie, the most recent vote (among tied candidates) wins.

 

Example 1:

Input: ["TopVotedCandidate","q","q","q","q","q","q"], [[[0,1,1,0,0,1,0],[0,5,10,15,20,25,30]],[3],[12],[25],[15],[24],[8]]
Output: [null,0,1,1,0,0,1]
Explanation: 
At time 3, the votes are [0], and 0 is leading.
At time 12, the votes are [0,1,1], and 1 is leading.
At time 25, the votes are [0,1,1,0,0,1], and 1 is leading (as ties go to the most recent vote.)
This continues for 3 more queries at time 15, 24, and 8.
 

Note:

1 <= persons.length = times.length <= 5000
0 <= persons[i] <= persons.length
times is a strictly increasing array with all elements in [0, 10^9].
TopVotedCandidate.q is called at most 10000 times per test case.
TopVotedCandidate.q(int t) is always called with t >= times[0].
 */

    public class TopVotedCandidate
    {
        int n;
        int[] vote;
        int[] ti;
        public TopVotedCandidate(int[] persons, int[] times)
        {
            n = persons.Length;
            int[] sum = new int[n+1];
            vote = new int[n];

            sum[persons[0]]++;
            vote[0] = persons[0];

            for (int i = 1; i < n; i++)
            {
                sum[persons[i]]++;
                if (sum[persons[i]] >= sum[vote[i - 1]])
                    vote[i] = persons[i];
                else
                    vote[i] = vote[i - 1];
            }

            ti = times;
        }

        public int Q(int t)
        {
            int l = 0, r = n - 1;
            while (l < r)
            {
                int mid = (l + r) >> 1;
                if (t < ti[mid + 1])
                    r = mid;
                else
                    l = mid + 1;
            }
            return vote[l];
        }
    }


public class TopVotedCandidate_ERR {

    private List<int[]> list;

        public TopVotedCandidate_ERR(int[] persons, int[] times)
        {
            list = new List<int[]>();
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int max = 0, person = 0;

            for (int i = 0; i < persons.Length; i++)
            {
                int n;
                if (!dic.TryGetValue(persons[i], out n))
                    n = 0;
                dic[persons[i]] = n + 1;

                if (n + 1 >= max)
                {
                    max = n + 1;
                    person = persons[i];
                }
                list.Add(new []{times[i], person});
            }
        }

        public int Q(int t)
        {
            int l = 0, r = list.Count - 1;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (list[mid][0] >= t)
                    r = mid;
                else
                    l = mid + 1;
            }

            return list[l][1];
        }
}

/**
 * Your TopVotedCandidate object will be instantiated and called as such:
 * TopVotedCandidate obj = new TopVotedCandidate(persons, times);
 * int param_1 = obj.Q(t);
 */

//  √ Accepted
//   √ 97/97 cases passed (596 ms)
//   √ Your runtime beats 69.81 % of csharp submissions
//   √ Your memory usage beats 82.61 % of csharp submissions (52.1 MB)

