/*
 * @lc app=leetcode id=621 lang=csharp
 *
 * [621] Task Scheduler

 Given a char array representing tasks CPU need to do. It contains capital letters A to Z where different letters represent different tasks. Tasks could be done without original order. Each task could be done in one interval. For each interval, CPU could finish one task or just be idle.

However, there is a non-negative cooling interval n that means between two same tasks, there must be at least n intervals that CPU are doing different tasks or just be idle.

You need to return the least number of intervals the CPU will take to finish all the given tasks.

 

Example:

Input: tasks = ["A","A","A","B","B","B"], n = 2
Output: 8
Explanation: A -> B -> idle -> A -> B -> idle -> A -> B.
 

Note:

The number of tasks is in the range [1, 10000].
The integer n is in the range [0, 100].
 */
public class Solution {
    public int LeastInterval(char[] tasks, int n)
    {
        int len = tasks.Length;
        if (len < 1 || n < 0)
        {
            return 0;
        }
        int[] nums = new int[26];
        int i = 0;
        //得到每个字符的数量后再排序
        while (i < len)
        {
            nums[tasks[i++] - 65]++;
        }
        Array.Sort(nums);
        //res的最小值
        int res = (nums[25] - 1) * (n + 1);
        i = 25;
        while (i >= 0 && nums[i] == nums[25])
        {
            //若最多数量的字符有多个 则res相应地+1
            res++;
            i--;
        }
        //得到的结果为res与数组长度len之间最大值
        return res > len ? res : len;
    }


    public int LeastInterval_ERR(char[] tasks, int n) {
        int len = tasks.Length;
        if (len == 0)
            return 0;

        int[] task = new int[26];
        int[] time = new int[26];
        foreach (var t1 in tasks)
        {
            int i = t1 - 'A';
            task[i]++;
            time[i] = -n-1;
        }

        int total = 0;
        while (len-- > 0)
        {
            int idx = -1;
            int midx = -1, min = Int32.MaxValue;
            for (int i = 0; i < 26; i++)
            {
                if(task[i] <= 0)
                    continue;

                if (total+1 - time[i] > n)
                {
                    idx = i;
                    break;
                }
                else
                {
                    if (time[i] < min)
                    {
                        midx = i;
                        min = time[i];
                    }
                }
            }

            if (idx >= 0)
            {
                total++;
                task[idx]--;
                time[idx] = total;
            }
            else
            {
                total = min + n + 1;
                task[midx]--;
                time[midx] = total;
            }
        }

        return total;
    }
}

// √ Accepted
//   √ 64/64 cases passed (180 ms)
//   √ Your runtime beats 65.85 % of csharp submissions
//   √ Your memory usage beats 37.5 % of csharp submissions (32.8 MB)

