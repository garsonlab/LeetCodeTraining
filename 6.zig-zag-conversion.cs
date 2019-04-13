/*
 * @lc app=leetcode id=6 lang=csharp
 *
 * [6] ZigZag Conversion
 *
 * https://leetcode.com/problems/zigzag-conversion/description/
 *
 * algorithms
 * Medium (31.26%)
 * Total Accepted:    303.5K
 * Total Submissions: 970.7K
 * Testcase Example:  '"PAYPALISHIRING"\n3'
 *
 * The string "PAYPALISHIRING" is written in a zigzag pattern on a given number
 * of rows like this: (you may want to display this pattern in a fixed font for
 * better legibility)
 * 
 * 
 * P   A   H   N
 * A P L S I I G
 * Y   I   R
 * 
 * 
 * And then read line by line: "PAHNAPLSIIGYIR"
 * 
 * Write the code that will take a string and make this conversion given a
 * number of rows:
 * 
 * 
 * string convert(string s, int numRows);
 * 
 * Example 1:
 * 
 * 
 * Input: s = "PAYPALISHIRING", numRows = 3
 * Output: "PAHNAPLSIIGYIR"
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "PAYPALISHIRING", numRows = 4
 * Output: "PINALSIGYAHRPI"
 * Explanation:
 * 
 * P     I    N
 * A   L S  I G
 * Y A   H R
 * P     I
 * 
 */
public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows <= 1 || s.Length <= 2)
            return s;

        string[] str = new string[numRows];
        for (int i = 0; i < numRows; i++)
        {
            str[i] = "";
        }

        int row = 0;
        bool add = true;
        for (int i = 0; i < s.Length; i++)
        {
            str[row] += s[i];

            if (add)
            {
                row++;
                if (row >= numRows)
                {
                    row -= 2;
                    add = false;
                }
            }
            else
            {
                row--;
                if (row < 0)
                {
                    row = 1;
                    add = true;
                }
            }
        }

        string ret = "";
        for (int i = 0; i < numRows; i++)
        {
            ret += str[i];
        }

        return ret;
    }
}

// √ Accepted
//   √ 1158/1158 cases passed (112 ms)
//   √ Your runtime beats 75.33 % of csharp submissions
//   √ Your memory usage beats 20.24 % of csharp submissions (24.5 MB)

