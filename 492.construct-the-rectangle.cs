/*
 * @lc app=leetcode id=492 lang=csharp
 *
 * [492] Construct the Rectangle
 *
 * https://leetcode.com/problems/construct-the-rectangle/description/
 *
 * algorithms
 * Easy (48.46%)
 * Total Accepted:    43.5K
 * Total Submissions: 89.8K
 * Testcase Example:  '1'
 *
 * 
 * For a web developer, it is very important to know how to design a web page's
 * size. So, given a specific rectangular web page’s area, your job by now is
 * to design a rectangular web page, whose length L and width W satisfy the
 * following requirements:
 * 1. The area of the rectangular web page you designed must equal to the given
 * target area.
 * 2. The width W should not be larger than the length L, which means L >= W.
 * 3. The difference between length L and width W should be as small as
 * possible.
 * 
 * You need to output the length L and the width W of the web page you designed
 * in sequence.
 * 
 * 
 * 
 * Example:
 * 
 * Input: 4
 * Output: [2, 2]
 * Explanation: The target area is 4, and all the possible ways to construct it
 * are [1,4], [2,2], [4,1]. 
 * But according to requirement 2, [1,4] is illegal; according to requirement
 * 3,  [4,1] is not optimal compared to [2,2]. So the length L is 2, and the
 * width W is 2.
 * 
 * 
 * 
 * Note:
 * 
 * The given area won't exceed 10,000,000 and is a positive integer
 * The web page's width and length you designed must be positive integers.
 * 
 * 
 */
public class Solution {
    public int[] ConstructRectangle(int area) {
        int h = -area, w = (int) Math.Sqrt(area);
        for (int i = w; i > 0; i--)
        {
            if (area % i == 0)
            {
                int x = area / i;
                if (Math.Abs(w-h) > Math.Abs(i-x))
                {
                    w = i;
                    h = x;

                    if(w == h)
                        break;
                }
            }
        }

        return new[] {h >= w ? h : w, h >= w ? w : h};
    }
}


// √ Accepted
//   √ 50/50 cases passed (208 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 87.5 % of csharp submissions (22.8 MB)

