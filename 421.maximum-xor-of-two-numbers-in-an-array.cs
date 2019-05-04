/*
 * @lc app=leetcode id=421 lang=csharp
 *
 * [421] Maximum XOR of Two Numbers in an Array

 Given a non-empty array of numbers, a0, a1, a2, … , an-1, where 0 ≤ ai < 231.

Find the maximum result of ai XOR aj, where 0 ≤ i, j < n.

Could you do this in O(n) runtime?

Example:

Input: [3, 10, 5, 25, 2, 8]

Output: 28

Explanation: The maximum result is 5 ^ 25 = 28.
 */
public class Solution {
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public int FindMaximumXOR(int[] nums) {
        TreeNode root = new TreeNode(-1);

        foreach (var num in nums)
        {
            TreeNode node = root;

            for (int i = 31; i >= 0; i--)
            {
                if((num & (1 << i)) == 0) {
                    if(node.left == null)
                        node.left = new TreeNode(0);
                    node = node.left;
                } else {
                    if(node.right == null)
                        node.right = new TreeNode(1);
                    node = node.right;
                }
            }
            node.left = new TreeNode(num);
        }

        int max = 0;
        foreach (var num in nums)
        {
            TreeNode node = root;

            for (int i = 31; i >= 0; i--)
            {
                if ((num & (1 << i)) == 0) {
                    if(node.right != null)
                        node = node.right;
                    else
                        node = node.left;
                } else {
                    if(node.left != null)
                        node = node.left;
                    else
                        node = node.right;
                }
            }

            int val = node.left.val;
            max = Math.Max(max, num^val);
        }
        return max;
    }





    public int FindMaximumXOR_timeout(int[] nums) {
        int max = 0, mask = 0;
        List<int> list = new List<int>();

        for (int i = 31; i >= 0; i--)
        {
            list.Clear();
            mask = mask | (1 << i);
            foreach (var num in nums)
            {
                list.Add(num&mask);
            }
            int tem = max | (1 << i);
            foreach (var item in list)
            {
                if(list.Contains(tem ^ item)) {
                    max = tem;
                    break;
                }
            }
        }

        return max;
    }
}

//a ^ b = c，而a ^ b ^ b = a, 则 c ^ b = a.

// √ Accepted
//   √ 29/29 cases passed (136 ms)
//   √ Your runtime beats 81.82 % of csharp submissions
//   √ Your memory usage beats 57.14 % of csharp submissions (40.9 MB)

