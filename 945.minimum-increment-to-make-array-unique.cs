/*
 * @lc app=leetcode id=945 lang=csharp
 *
 * [945] Minimum Increment to Make Array Unique

 Given an array of integers A, a move consists of choosing any A[i], and incrementing it by 1.

Return the least number of moves to make every value in A unique.

 

Example 1:

Input: [1,2,2]
Output: 1
Explanation:  After 1 move, the array could be [1, 2, 3].
Example 2:

Input: [3,2,1,2,1,7]
Output: 6
Explanation:  After 6 moves, the array could be [3, 4, 1, 2, 5, 7].
It can be shown with 5 or less moves that it is impossible for the array to have all unique values.
 

Note:

0 <= A.length <= 40000
0 <= A[i] < 40000
 */
public class Solution {
    public int MinIncrementForUnique(int[] A) {
        if(A.Length == 0)
            return 0;
        int sum = 0;          //计数
        Array.Sort(A);    //排序
        for(int i = 1; i<A.Length;i++)
        {
            if(A[i] <= A[i-1])  //直到后一个刚好大于前一个，保证最小增量
            {
                sum+=A[i-1]+1-A[i];
                A[i]=A[i-1]+1;   
            }
        }
        return sum;
    }


    public int MinIncrementForUnique_timeout(int[] A) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        foreach (var i in A)
        {
            int n;
            if (!dic.TryGetValue(i, out n))
                n = 0;

            dic[i] = n + 1;
        }

        List<int> list = new List<int>(dic.Keys);
        int res = 0;
        foreach (var i in list)
        {
            int left = dic[i] - 1;
            if(left == 0)
                continue;

            int j = i + 1;
            while (left > 0)
            {
                for (; j < int.MaxValue; j++)
                {
                    if (!dic.ContainsKey(j))
                    {
                        dic[j] = 1;
                        res += j - i;
                        left--;
                        break;
                    }
                }
            }
        }

        return res;
    }
}


// √ Accepted
//   √ 59/59 cases passed (180 ms)
//   √ Your runtime beats 61.19 % of csharp submissions
//   √ Your memory usage beats 31.91 % of csharp submissions (33.4 MB)