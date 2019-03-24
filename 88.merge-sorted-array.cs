/*
 * @lc app=leetcode id=88 lang=csharp
 *
 * [88] Merge Sorted Array
 *
 * https://leetcode.com/problems/merge-sorted-array/description/
 *
 * algorithms
 * Easy (35.06%)
 * Total Accepted:    339.6K
 * Total Submissions: 967.7K
 * Testcase Example:  '[1,2,3,0,0,0]\n3\n[2,5,6]\n3'
 *
 * Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as
 * one sorted array.
 * 
 * Note:
 * 
 * 
 * The number of elements initialized in nums1 and nums2 are m and n
 * respectively.
 * You may assume that nums1 has enough space (size that is greater or equal to
 * m + n) to hold additional elements from nums2.
 * 
 * 
 * Example:
 * 
 * 
 * Input:
 * nums1 = [1,2,3,0,0,0], m = 3
 * nums2 = [2,5,6],       n = 3
 * 
 * Output: [1,2,2,3,5,6]
 * 
 * 
 */
public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int idx = m+n-1;
        while (m > 0 || n > 0)
        {
            int a = m>0?nums1[m-1]:int.MinValue;
            int b = n>0?nums2[n-1]:int.MinValue;

            if (a >= b)
            {
                nums1[idx] = a;
                m--;
            }
            else
            {
                nums1[idx] = b;
                n--;
            }
            idx--;
        }
    }
}

// √ Accepted
//   √ 59/59 cases passed (272 ms)
//   √ Your runtime beats 63.45 % of csharp submissions
//   √ Your memory usage beats 72.13 % of csharp submissions (28.6 MB)

