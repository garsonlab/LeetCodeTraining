/*
 * @lc app=leetcode id=496 lang=csharp
 *
 * [496] Next Greater Element I
 *
 * https://leetcode.com/problems/next-greater-element-i/description/
 *
 * algorithms
 * Easy (58.89%)
 * Total Accepted:    90K
 * Total Submissions: 152.4K
 * Testcase Example:  '[4,1,2]\n[1,3,4,2]'
 *
 * 
 * You are given two arrays (without duplicates) nums1 and nums2 where nums1’s
 * elements are subset of nums2. Find all the next greater numbers for nums1's
 * elements in the corresponding places of nums2. 
 * 
 * 
 * 
 * The Next Greater Number of a number x in nums1 is the first greater number
 * to its right in nums2. If it does not exist, output -1 for this number.
 * 
 * 
 * Example 1:
 * 
 * Input: nums1 = [4,1,2], nums2 = [1,3,4,2].
 * Output: [-1,3,-1]
 * Explanation:
 * ⁠   For number 4 in the first array, you cannot find the next greater number
 * for it in the second array, so output -1.
 * ⁠   For number 1 in the first array, the next greater number for it in the
 * second array is 3.
 * ⁠   For number 2 in the first array, there is no next greater number for it
 * in the second array, so output -1.
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: nums1 = [2,4], nums2 = [1,2,3,4].
 * Output: [3,-1]
 * Explanation:
 * ⁠   For number 2 in the first array, the next greater number for it in the
 * second array is 3.
 * ⁠   For number 4 in the first array, there is no next greater number for it
 * in the second array, so output -1.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * All elements in nums1 and nums2 are unique.
 * The length of both nums1 and nums2 would not exceed 1000.
 * 
 * 
 */
public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        int[] greater = new int[nums1.Length];

        for (int i = 0; i < nums1.Length; i++)
        {
            int r = -1;
            bool find = false;
            for (int j = 0; j < nums2.Length; j++)
            {
                if (nums2[j] == nums1[i])
                    find = true;
                else if (find && nums2[j] > nums1[i])
                {
                    r = nums2[j];
                    break;
                }
            }

            greater[i] = r;
        }

        return greater;
    }
}

// √ Accepted
//   √ 17/17 cases passed (256 ms)
//   √ Your runtime beats 65.32 % of csharp submissions
//   √ Your memory usage beats 93.75 % of csharp submissions (29.1 MB)

