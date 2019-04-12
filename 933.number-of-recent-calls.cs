/*
 * @lc app=leetcode id=933 lang=csharp
 *
 * [933] Number of Recent Calls
 *
 * https://leetcode.com/problems/number-of-recent-calls/description/
 *
 * algorithms
 * Easy (69.06%)
 * Total Accepted:    18.6K
 * Total Submissions: 26.9K
 * Testcase Example:  '["RecentCounter","ping","ping","ping","ping"]\n[[],[1],[100],[3001],[3002]]'
 *
 * Write a class RecentCounter to count recent requests.
 * 
 * It has only one method: ping(int t), where t represents some time in
 * milliseconds.
 * 
 * Return the number of pings that have been made from 3000 milliseconds ago
 * until now.
 * 
 * Any ping with time in [t - 3000, t] will count, including the current ping.
 * 
 * It is guaranteed that every call to ping uses a strictly larger value of t
 * than before.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: inputs = ["RecentCounter","ping","ping","ping","ping"], inputs =
 * [[],[1],[100],[3001],[3002]]
 * Output: [null,1,2,3,3]
 * 
 * 
 * 
 * Note:
 * 
 * 
 * Each test case will have at most 10000 calls to ping.
 * Each test case will call ping with strictly increasing values of t.
 * Each call to ping will have 1 <= t <= 10^9.
 * 
 * 
 * 
 * 
 * 
 */
public class RecentCounter {

    private readonly List<int> list;
    public RecentCounter()
    {
        list = new List<int>();
    }

    public int Ping(int t)
    {
        list.Add(t);

        int removeNum = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (t - list[i] > 3000)
                removeNum++;
            else
                break;
        }

        while (removeNum-- > 0)
        {
            list.RemoveAt(0);
        }

        return list.Count;
    }
}

/**
 * Your RecentCounter object will be instantiated and called as such:
 * RecentCounter obj = new RecentCounter();
 * int param_1 = obj.Ping(t);
 */

//  √ Accepted
//   √ 68/68 cases passed (340 ms)
//   √ Your runtime beats 80.54 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (45.6 MB)

