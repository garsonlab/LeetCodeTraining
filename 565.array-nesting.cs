/*
 * @lc app=leetcode id=565 lang=csharp
 *
 * [565] Array Nesting

 A zero-indexed array A of length N contains all integers from 0 to N-1. Find and return the longest length of set S, where S[i] = {A[i], A[A[i]], A[A[A[i]]], ... } subjected to the rule below.

Suppose the first element in S starts with the selection of element A[i] of index = i, the next element in S should be A[A[i]], and then A[A[A[i]]]… By that analogy, we stop adding right before a duplicate element occurs in S.

 

Example 1:

Input: A = [5,4,0,3,1,6,2]
Output: 4
Explanation: 
A[0] = 5, A[1] = 4, A[2] = 0, A[3] = 3, A[4] = 1, A[5] = 6, A[6] = 2.

One of the longest S[K]:
S[0] = {A[0], A[5], A[6], A[2]} = {5, 6, 2, 0}
 

Note:

N is an integer within the range [1, 20,000].
The elements of A are all distinct.
Each element of A is an integer within the range [0, N-1].
 */
public class Solution {
    public int ArrayNesting(int[] nums) {
        int len = nums.Length;
        if (len <= 1)
            return len;

        int max = 0;
        for (int i = 0; i < len; i++)
        {
            if(nums[i] < 0)
                continue;

            int count = 0;
            int tem = i;
            while (nums[tem] >= 0)
            {
                count++;
                int t = nums[tem];
                nums[tem] = -1;
                tem = t;
            }

            max = Math.Max(max, count);
        }

        return max;
    }
}


// √ Accepted
//   √ 856/856 cases passed (112 ms)
//   √ Your runtime beats 71.43 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (27.9 MB)
