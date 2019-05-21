/*
 * @lc app=leetcode id=955 lang=csharp
 *
 * [955] Delete Columns to Make Sorted II

 We are given an array A of N lowercase letter strings, all of the same length.

Now, we may choose any set of deletion indices, and for each string, we delete all the characters in those indices.

For example, if we have an array A = ["abcdef","uvwxyz"] and deletion indices {0, 2, 3}, then the final array after deletions is ["bef","vyz"].

Suppose we chose a set of deletion indices D such that after deletions, the final array has its elements in lexicographic order (A[0] <= A[1] <= A[2] ... <= A[A.length - 1]).

Return the minimum possible value of D.length.

 

Example 1:

Input: ["ca","bb","ac"]
Output: 1
Explanation: 
After deleting the first column, A = ["a", "b", "c"].
Now A is in lexicographic order (ie. A[0] <= A[1] <= A[2]).
We require at least 1 deletion since initially A was not in lexicographic order, so the answer is 1.
Example 2:

Input: ["xc","yb","za"]
Output: 0
Explanation: 
A is already in lexicographic order, so we don't need to delete anything.
Note that the rows of A are not necessarily in lexicographic order:
ie. it is NOT necessarily true that (A[0][0] <= A[0][1] <= ...)
Example 3:

Input: ["zyx","wvu","tsr"]
Output: 3
Explanation: 
We have to delete every column.
 

Note:

1 <= A.length <= 100
1 <= A[i].length <= 100
 */
public class Solution {
    public int MinDeletionSize(string[] A) {
        if (A.Length <= 1)
            return 0;
        int startLen = A[0].Length;
        if (startLen <= 0)
            return 0;

        int arrLen = A.Length;
        int strLen = A[0].Length;
        // 如果cuts[i] = true， 那么我们不需要再检查 strs[i][j] > strs[i+1][j]
        bool[] cuts = new bool[arrLen];
        int ans = 0;
        bool delete;

        for (int j = 0; j < strLen; j++)
        {
            delete = false;
            for (int i = 0; i < arrLen - 1; i++)
            {
                if (!cuts[i] && A[i][j] > A[i + 1][j])
                {
                    ans++;
                    delete = true;
                    break;
                }
            }
            if (!delete)
            {
                // 更新cuts
                for (int i = 0; i < arrLen - 1; i++)
                {
                    if (A[i][j] < A[i + 1][j])
                    {
                        cuts[i] = true;
                    }
                }
            }
        }
        return ans;
    }
}

// √ Accepted
//   √ 145/145 cases passed (120 ms)
//   √ Your runtime beats 15 % of csharp submissions
//   √ Your memory usage beats 28.57 % of csharp submissions (23 MB)

