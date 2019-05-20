/*
 * @lc app=leetcode id=904 lang=csharp
 *
 * [904] Fruit Into Baskets

 In a row of trees, the i-th tree produces fruit with type tree[i].

You start at any tree of your choice, then repeatedly perform the following steps:

Add one piece of fruit from this tree to your baskets.  If you cannot, stop.
Move to the next tree to the right of the current tree.  If there is no tree to the right, stop.
Note that you do not have any choice after the initial choice of starting tree: you must perform step 1, then step 2, then back to step 1, then step 2, and so on until you stop.

You have two baskets, and each basket can carry any quantity of fruit, but you want each basket to only carry one type of fruit each.

What is the total amount of fruit you can collect with this procedure?

 

Example 1:

Input: [1,2,1]
Output: 3
Explanation: We can collect [1,2,1].
Example 2:

Input: [0,1,2,2]
Output: 3
Explanation: We can collect [1,2,2].
If we started at the first tree, we would only collect [0, 1].
Example 3:

Input: [1,2,3,2,2]
Output: 4
Explanation: We can collect [2,3,2,2].
If we started at the first tree, we would only collect [1, 2].
Example 4:

Input: [3,3,3,1,2,1,1,2,3,3,4]
Output: 5
Explanation: We can collect [1,2,1,1,2].
If we started at the first tree or the eighth tree, we would only collect 4 fruits.
 

Note:

1 <= tree.length <= 40000
0 <= tree[i] < tree.length
 */
public class Solution {
    public int TotalFruit(int[] tree) {
        int max = 0;
        int s1 = 0, s2 = -1;

        for (int i = 1; i < tree.Length; i++)
        {
            if(tree[i] == tree[s1])
                continue;

            if (s2 == -1)
            {
                s2 = i;
                continue;
            }

            if(tree[i] == tree[s2])
                continue;

            max = Math.Max(max, i - s1);

            s1 = i-1;
            while (s1 > 0 && tree[s1-1] == tree[s1])
            {
                s1--;
            }

            s2 = i;
        }
        max = Math.Max(max, tree.Length - s1);
        return max;
    }
}

// √ Accepted
//   √ 90/90 cases passed (244 ms)
//   √ Your runtime beats 48.18 % of csharp submissions
//   √ Your memory usage beats 6.71 % of csharp submissions (42.1 MB)

