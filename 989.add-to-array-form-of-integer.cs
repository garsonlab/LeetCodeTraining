/*
 * @lc app=leetcode id=989 lang=csharp
 *
 * [989] Add to Array-Form of Integer
 *
 * https://leetcode.com/problems/add-to-array-form-of-integer/description/
 *
 * algorithms
 * Easy (45.05%)
 * Total Accepted:    11.4K
 * Total Submissions: 25.5K
 * Testcase Example:  '[1,2,0,0]\n34'
 *
 * For a non-negative integer X, the array-form of X is an array of its digits
 * in left to right order.  For example, if X = 1231, then the array form is
 * [1,2,3,1].
 * 
 * Given the array-form A of a non-negative integer X, return the array-form of
 * the integer X+K.
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
 * Input: A = [1,2,0,0], K = 34
 * Output: [1,2,3,4]
 * Explanation: 1200 + 34 = 1234
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: A = [2,7,4], K = 181
 * Output: [4,5,5]
 * Explanation: 274 + 181 = 455
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: A = [2,1,5], K = 806
 * Output: [1,0,2,1]
 * Explanation: 215 + 806 = 1021
 * 
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: A = [9,9,9,9,9,9,9,9,9,9], K = 1
 * Output: [1,0,0,0,0,0,0,0,0,0,0]
 * Explanation: 9999999999 + 1 = 10000000000
 * 
 * 
 * 
 * 
 * Note：
 * 
 * 
 * 1 <= A.length <= 10000
 * 0 <= A[i] <= 9
 * 0 <= K <= 10000
 * If A.length > 1, then A[0] != 0
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public IList<int> AddToArrayForm(int[] A, int K) {
        List<int> list = new List<int>();
        int add = 0;

        for (int i = A.Length-1; i >= 0; i--)
        {
            int v = A[i] + K % 10 + add;

            list.Add(v%10);
            add = v / 10;
            K = K / 10;
        }

        while (K > 0)
        {
            int v = K % 10 + add;
            list.Add(v%10);
            add = v / 10;
            K = K / 10;
        }
        if(add > 0)
            list.Add(add);
        list.Reverse();
        return list;
    }
}

// √ Accepted
//   √ 156/156 cases passed (332 ms)
//   √ Your runtime beats 68.53 % of csharp submissions
//   √ Your memory usage beats 12.96 % of csharp submissions (37.9 MB)

