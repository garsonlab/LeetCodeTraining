/*
 * @lc app=leetcode id=898 lang=csharp
 *
 * [898] Bitwise ORs of Subarrays

 We have an array A of non-negative integers.

For every (contiguous) subarray B = [A[i], A[i+1], ..., A[j]] (with i <= j), we take the bitwise OR of all the elements in B, obtaining a result A[i] | A[i+1] | ... | A[j].

Return the number of possible results.  (Results that occur more than once are only counted once in the final answer.)

 

Example 1:

Input: [0]
Output: 1
Explanation: 
There is only one possible result: 0.
Example 2:

Input: [1,1,2]
Output: 3
Explanation: 
The possible subarrays are [1], [1], [2], [1, 1], [1, 2], [1, 1, 2].
These yield the results 1, 1, 2, 1, 3, 3.
There are 3 unique values, so the answer is 3.
Example 3:

Input: [1,2,4]
Output: 6
Explanation: 
The possible results are 1, 2, 3, 4, 6, and 7.
 

Note:

1 <= A.length <= 50000
0 <= A[i] <= 10^9
 */
public class Solution {
    public int SubarrayBitwiseORs(int[] A) {
        int len = A.Length;
        if(len == 0) return 0;
        int[] dp = new int[len];
        Dictionary<int,int> vis = new Dictionary<int, int>();

        int ans=1;
        vis[A[0]] = 1;
        dp[0] = A[0];
        for(int i=1;i<len;i++){
            dp[i] = A[i];
            if(!vis.ContainsKey(dp[i])) {
                vis[dp[i]] = 1;
                ans++;
            }
            for(int j=i-1;j>=0;j--){
                int temp = A[i] | dp[j];
                if(temp == dp[j]) break;
                if(!vis.ContainsKey(temp)){
                    vis[temp] = 1;
                    ans++;
                }
                dp[j] = temp;
            }
        }
        return ans;
    }

    public int SubarrayBitwiseORs_timeout(int[] A) {
        List<int> list = new List<int>();
        int max = 0;
        foreach (var num in A)
        {
            max |= num;
            if(!list.Contains(max))
                list.Add(max);
        }

        for(int i=1; i<A.Length; i++){
            for(int j=i, n=0; j<A.Length&&n!=max;j++){
                n |= A[j];
                if(!list.Contains(n))
                    list.Add(n);
            }
        }
        return list.Count;
    }
}


// √ Accepted
//   √ 83/83 cases passed (308 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 95.65 % of csharp submissions (44.7 MB)
