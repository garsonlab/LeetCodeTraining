/*
 * @lc app=leetcode id=11 lang=csharp
 *
 * [11] Container With Most Water
 *
 * https://leetcode.com/problems/container-with-most-water/description/
 *
 * algorithms
 * Medium (43.62%)
 * Total Accepted:    345.7K
 * Total Submissions: 792.5K
 * Testcase Example:  '[1,8,6,2,5,4,8,3,7]'
 *
 * Given n non-negative integers a1, a2, ..., an , where each represents a
 * point at coordinate (i, ai). n vertical lines are drawn such that the two
 * endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together
 * with x-axis forms a container, such that the container contains the most
 * water.
 * 
 * Note: You may not slant the container and n is at least 2.
 * 
 * 
 * 
 * 
 * 
 * The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In
 * this case, the max area of water (blue section) the container can contain is
 * 49. 
 * 
 * 
 * 
 * Example:
 * 
 * 
 * Input: [1,8,6,2,5,4,8,3,7]
 * Output: 49
 * 
 */
public class Solution {
    public int MaxArea(int[] height) {
        if(height.Length <= 1)
            return 0;
        int maxArea = 0;
        for (int i = 0, j = height.Length-1; i < j;)
        {
            maxArea = Math.Max(maxArea, Math.Min(height[i], height[j])*(j-i));
            if (height[i] <= height[j])
            {
                i++;
            }
            else 
                j--;
        }
        return maxArea;
    }
}

//从两边往中间找最高的柱子，与面积进行比较
// √ Accepted
//   √ 50/50 cases passed (104 ms)
//   √ Your runtime beats 92.91 % of csharp submissions
//   √ Your memory usage beats 35.88 % of csharp submissions (25.6 MB)

