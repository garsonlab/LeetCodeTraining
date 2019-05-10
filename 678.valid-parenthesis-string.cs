/*
 * @lc app=leetcode id=678 lang=csharp
 *
 * [678] Valid Parenthesis String

 Given a string containing only three types of characters: '(', ')' and '*', write a function to check whether this string is valid. We define the validity of a string by these rules:

Any left parenthesis '(' must have a corresponding right parenthesis ')'.
Any right parenthesis ')' must have a corresponding left parenthesis '('.
Left parenthesis '(' must go before the corresponding right parenthesis ')'.
'*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string.
An empty string is also valid.
Example 1:
Input: "()"
Output: True
Example 2:
Input: "(*)"
Output: True
Example 3:
Input: "(*))"
Output: True
Note:
The string size will be in the range [1, 100].
 */
public class Solution {
    public bool CheckValidString(string s) {
        int low = 0;//( count, but * is )
        int high = 0;//( count, and * is (

        foreach (var c in s)
        {
            if (c == '(')
            {
                low++;
                high++;
            }
            else if(c == ')')
            {
                if (low > 0)//如果low不为空，说明左括号比较多，则low--
                    low--;
                high--;
            }
            else
            {
                if (low > 0)
                    low--;
                high++;
            }

            if (high < 0)//说明将*当做左括号也不够
                return false;
        }

        return low == 0;
    }
}

//https://blog.csdn.net/zsjwish/article/details/80091175
// √ Accepted
//   √ 58/58 cases passed (92 ms)
//   √ Your runtime beats 36.79 % of csharp submissions
//   √ Your memory usage beats 28.57 % of csharp submissions (19.9 MB)

