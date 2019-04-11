/*
 * @lc app=leetcode id=896 lang=csharp
 *
 * [896] Monotonic Array
 *
 * https://leetcode.com/problems/monotonic-array/description/
 *
 * algorithms
 * Easy (54.73%)
 * Total Accepted:    37.3K
 * Total Submissions: 68.1K
 * Testcase Example:  '[1,2,2,3]'
 *
 * An array is monotonic if it is either monotone increasing or monotone
 * decreasing.
 * 
 * An array A is monotone increasing if for all i <= j, A[i] <= A[j].  An array
 * A is monotone decreasing if for all i <= j, A[i] >= A[j].
 * 
 * Return true if and only if the given array A is monotonic.
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [1,2,2,3]
 * Output: true
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [6,5,4,4]
 * Output: true
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: [1,3,2]
 * Output: false
 * 
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: [1,2,4,5]
 * Output: true
 * 
 * 
 * 
 * Example 5:
 * 
 * 
 * Input: [1,1,1]
 * Output: true
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= A.length <= 50000
 * -100000 <= A[i] <= 100000
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public bool IsMonotonic(int[] A) {
        if (A.Length <= 1)
            return true;

        bool isUp = A[A.Length - 1] - A[0] >= 0;

        for (int i = 1; i < A.Length; i++)
        {
            if (isUp && A[i] < A[i - 1])
                return false;

            if (!isUp && A[i] > A[i - 1])
                return false;
        }

        return true;
    }
}

// √ Accepted
//   √ 366/366 cases passed (176 ms)
//   √ Your runtime beats 55.56 % of csharp submissions
//   √ Your memory usage beats 83.33 % of csharp submissions (37.6 MB)

