/*
 * @lc app=leetcode id=96 lang=csharp
 *
 * [96] Unique Binary Search Trees
 *
 * https://leetcode.com/problems/unique-binary-search-trees/description/
 *
 * algorithms
 * Medium (45.66%)
 * Total Accepted:    192.9K
 * Total Submissions: 422K
 * Testcase Example:  '3'
 *
 * Given n, how many structurally unique BST's (binary search trees) that store
 * values 1 ... n?
 * 
 * Example:
 * 
 * 
 * Input: 3
 * Output: 5
 * Explanation:
 * Given n = 3, there are a total of 5 unique BST's:
 * 
 * ⁠  1         3     3      2      1
 * ⁠   \       /     /      / \      \
 * ⁠    3     2     1      1   3      2
 * ⁠   /     /       \                 \
 * ⁠  2     1         2                 3
 * 
 * 
 */
public class Solution {
    public int NumTrees(int n) {
        if(n <= 1)
            return n;
        
        int[] nums = new int[n+1];
        nums[0] = 1; nums[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                nums[i] += nums[j]*nums[i-1-j];
            }
        }

        return nums[n];
    }
}


// √ Accepted
//   √ 19/19 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 23.08 % of csharp submissions (12.9 MB)

