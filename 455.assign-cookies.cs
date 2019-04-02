/*
 * @lc app=leetcode id=455 lang=csharp
 *
 * [455] Assign Cookies
 *
 * https://leetcode.com/problems/assign-cookies/description/
 *
 * algorithms
 * Easy (48.12%)
 * Total Accepted:    60.1K
 * Total Submissions: 124.8K
 * Testcase Example:  '[1,2,3]\n[1,1]'
 *
 * 
 * Assume you are an awesome parent and want to give your children some
 * cookies. But, you should give each child at most one cookie. Each child i
 * has a greed factor gi, which is the minimum size of a cookie that the child
 * will be content with; and each cookie j has a size sj. If sj >= gi, we can
 * assign the cookie j to the child i, and the child i will be content. Your
 * goal is to maximize the number of your content children and output the
 * maximum number.
 * 
 * 
 * Note:
 * You may assume the greed factor is always positive. 
 * You cannot assign more than one cookie to one child.
 * 
 * 
 * Example 1:
 * 
 * Input: [1,2,3], [1,1]
 * 
 * Output: 1
 * 
 * Explanation: You have 3 children and 2 cookies. The greed factors of 3
 * children are 1, 2, 3. 
 * And even though you have 2 cookies, since their size is both 1, you could
 * only make the child whose greed factor is 1 content.
 * You need to output 1.
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: [1,2], [1,2,3]
 * 
 * Output: 2
 * 
 * Explanation: You have 2 children and 3 cookies. The greed factors of 2
 * children are 1, 2. 
 * You have 3 cookies and their sizes are big enough to gratify all of the
 * children, 
 * You need to output 2.
 * 
 * 
 */
public class Solution {
    public int FindContentChildren(int[] g, int[] s) {
        List<int> children = new List<int>(g);
        List<int> cookie = new List<int>(s);

        children.Sort();
        cookie.Sort();

        int num = 0;
        for (int i = children.Count-1, j = cookie.Count-1; i >= 0 && j >= 0; i--, j--)
        {
            if (cookie[j] >= children[i])
                num++;
            else
            {
                j++;
            }
        }

        return num;
    }
}
//从大到小排序，饼干值大于等于孩子需要即+1
// √ Accepted
//   √ 21/21 cases passed (124 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 8.33 % of csharp submissions (28.7 MB)

