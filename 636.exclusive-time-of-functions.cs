/*
 * @lc app=leetcode id=636 lang=csharp
 *
 * [636] Exclusive Time of Functions

 On a single threaded CPU, we execute some functions.  Each function has a unique id between 0 and N-1.

We store logs in timestamp order that describe when a function is entered or exited.

Each log is a string with this format: "{function_id}:{"start" | "end"}:{timestamp}".  For example, "0:start:3" means the function with id 0 started at the beginning of timestamp 3.  "1:end:2" means the function with id 1 ended at the end of timestamp 2.

A function's exclusive time is the number of units of time spent in this function.  Note that this does not include any recursive calls to child functions.

Return the exclusive time of each function, sorted by their function id.

 

Example 1:



Input:
n = 2
logs = ["0:start:0","1:start:2","1:end:5","0:end:6"]
Output: [3, 4]
Explanation:
Function 0 starts at the beginning of time 0, then it executes 2 units of time and reaches the end of time 1.
Now function 1 starts at the beginning of time 2, executes 4 units of time and ends at time 5.
Function 0 is running again at the beginning of time 6, and also ends at the end of time 6, thus executing for 1 unit of time. 
So function 0 spends 2 + 1 = 3 units of total time executing, and function 1 spends 4 units of total time executing.
 

Note:

1 <= n <= 100
Two functions won't start or end at the same time.
Functions will always log when they exit.
 */
public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        if(n <= 0)
            return new int[0];
        
        Stack<int> stack = new Stack<int>();
        int[] time = new int[n];
        int cur = 0;

        foreach (var log in logs)
        {
            string[] ps = log.Split(':');
            int idx = int.Parse(ps[0]);
            int t = int.Parse(ps[2]);
            
            while (stack.Count > 0 && cur < t)
            {
                time[stack.Peek()]++;
                cur++;
            }

            if (ps[1] == "start")
            {
                stack.Push(idx);
            }
            else
            {
                stack.Pop();
                time[idx]++;
                cur++;
            }
        }

        return time;
    }
}

// √ Accepted
//   √ 120/120 cases passed (1792 ms)
//   √ Your runtime beats 5.64 % of csharp submissions
//   √ Your memory usage beats 25 % of csharp submissions (31.1 MB)

