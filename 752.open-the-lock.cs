/*
 * @lc app=leetcode id=752 lang=csharp
 *
 * [752] Open the Lock

 You have a lock in front of you with 4 circular wheels. Each wheel has 10 slots: '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'. The wheels can rotate freely and wrap around: for example we can turn '9' to be '0', or '0' to be '9'. Each move consists of turning one wheel one slot.

The lock initially starts at '0000', a string representing the state of the 4 wheels.

You are given a list of deadends dead ends, meaning if the lock displays any of these codes, the wheels of the lock will stop turning and you will be unable to open it.

Given a target representing the value of the wheels that will unlock the lock, return the minimum total number of turns required to open the lock, or -1 if it is impossible.

Example 1:
Input: deadends = ["0201","0101","0102","1212","2002"], target = "0202"
Output: 6
Explanation:
A sequence of valid moves would be "0000" -> "1000" -> "1100" -> "1200" -> "1201" -> "1202" -> "0202".
Note that a sequence like "0000" -> "0001" -> "0002" -> "0102" -> "0202" would be invalid,
because the wheels of the lock become stuck after the display becomes the dead end "0102".
Example 2:
Input: deadends = ["8888"], target = "0009"
Output: 1
Explanation:
We can turn the last wheel in reverse to move from "0000" -> "0009".
Example 3:
Input: deadends = ["8887","8889","8878","8898","8788","8988","7888","9888"], target = "8888"
Output: -1
Explanation:
We can't reach the target without getting stuck.
Example 4:
Input: deadends = ["0000"], target = "8888"
Output: -1
Note:
The length of deadends will be in the range [1, 500].
target will not be in the list deadends.
Every string in deadends and the string target will be a string of 4 digits from the 10,000 possibilities '0000' to '9999'.
 */
public class Solution {
    public int OpenLock(string[] deadends, string target)
        {
            //搜索次数
            int step = 0;
            var deadEndsList = deadends.Distinct().ToDictionary(q => q, q => q);
            if (deadEndsList.ContainsKey("0000")) return -1;
            //队列
            var queue = new Queue<string>();
            //已尝试组合
            var usedList = new Dictionary<string, string>();
            queue.Enqueue("0000");
            usedList.Add("0000", "0000");
            while (queue.Any())
            {
                int size = queue.Count();
                for (int i = 0; i < size; i++)
                {
                    //当前尝试密码
                    var current = queue.Peek();
                    if (current == target) return step;
                    var neighbor = GetNeighbor(current);
                    foreach (var n in neighbor)
                    {
                        if (!usedList.ContainsKey(n) && !deadEndsList.ContainsKey(n))
                        {
                            queue.Enqueue(n);
                            usedList.Add(n, n);
                        }
                    }
                    queue.Dequeue();
                }
                step += 1;
            }
            return -1;
        }

        //获取相邻的8个密码
        private List<string> GetNeighbor(string current)
        {
            var result = new List<string>();
            var value = new Dictionary<int, int>();
            for (int i = 0; i < current.Length; i++)
            {
                value.Add(i, Convert.ToInt32(current.Substring(i, 1)));
            }
            for (int i = 0; i < current.Length; i++)
            {
                var temp = GetAddSub(value[i]);
                result.Add(current.Substring(0, i) + temp[0] + current.Substring(i + 1, current.Length - i - 1));
                result.Add(current.Substring(0, i) + temp[1] + current.Substring(i + 1, current.Length - i - 1));
            }
            return result;
        }

        //获取当前数字加减后的数字
        private int[] GetAddSub(int value)
        {
            var add = value + 1;
            var sub = value - 1;
            if (add == 10) add = 0;
            if (sub == -1) sub = 9;
            return new int[] { add, sub };
        }



    public int OpenLock_timeout(string[] deadends, string target) {
        List<string> visited = new List<string>(deadends);
        if (visited.Contains("0000"))
            return -1;
        int res = 0;
        visited.Add("0000");
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("0000");

        int[] way = { -1, 1 };
        int sum = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                string now = queue.Dequeue();
                if (now.Equals(target))
                    return sum;

                for (int j = 0; j < 4; j++)
                for (int k = 0; k < 2; k++)
                {
                    char[] c = now.ToCharArray();
                    int digit = (c[j] - '0' + way[k] + 10) % 10;
                    c[j] = (char)('0' + digit);
                    String nxt = new String(c);
                    if (!visited.Contains(nxt))
                    {
                        visited.Add(nxt);
                        queue.Enqueue(nxt);
                    }
                }
            }
            sum++;
        }
        return -1;
    }
}


// √ Accepted
//   √ 43/43 cases passed (792 ms)
//   √ Your runtime beats 26.28 % of csharp submissions
//   √ Your memory usage beats 16.67 % of csharp submissions (42.1 MB)
