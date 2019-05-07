/*
 * @lc app=leetcode id=519 lang=csharp
 *
 * [519] Random Flip Matrix

 You are given the number of rows n_rows and number of columns n_cols of a 2D binary matrix where all values are initially 0. Write a function flip which chooses a 0 value uniformly at random, changes it to 1, and then returns the position [row.id, col.id] of that value. Also, write a function reset which sets all values back to 0. Try to minimize the number of calls to system's Math.random() and optimize the time and space complexity.

Note:

1 <= n_rows, n_cols <= 10000
0 <= row.id < n_rows and 0 <= col.id < n_cols
flip will not be called when the matrix has no 0 values left.
the total number of calls to flip and reset will not exceed 1000.
Example 1:

Input: 
["Solution","flip","flip","flip","flip"]
[[2,3],[],[],[],[]]
Output: [null,[0,1],[1,2],[1,0],[1,1]]
Example 2:

Input: 
["Solution","flip","flip","reset","flip"]
[[1,2],[],[],[],[]]
Output: [null,[0,0],[0,1],null,[0,0]]
Explanation of Input Syntax:

The input is two lists: the subroutines called and their arguments. Solution's constructor has two arguments, n_rows and n_cols. flip and reset have no arguments. Arguments are always wrapped with a list, even if there aren't any.
 */
public class Solution {

    private Random random;
        private List<int> list;
        private int total;
        private int col;

        public Solution(int n_rows, int n_cols)
        {
            random = new Random();
            list = new List<int>();
            total = n_rows * n_cols;
            col = n_cols;
        }

        public int[] Flip()
        {
            if(total <= 0 || list.Count == total)
                return new int[0];

            int idx = random.Next(total);
            for (int i = 0; i < total; i++)
            {
                int v = (idx + i) % total;
                if (!list.Contains(v))
                {
                    idx = v;
                    break;
                }
            }
            list.Add(idx);
            return new[] {idx / col, idx % col};
        }

        public void Reset()
        {
            list.Clear();
        }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(n_rows, n_cols);
 * int[] param_1 = obj.Flip();
 * obj.Reset();
 */


//  √ Accepted
//   √ 19/19 cases passed (288 ms)
//   √ Your runtime beats 61.54 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (32.7 MB)

