/*
 * @lc app=leetcode id=394 lang=csharp
 *
 * [394] Decode String.

 Given an encoded string, return it's decoded string.

The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note that k is guaranteed to be a positive integer.

You may assume that the input string is always valid; No extra white spaces, square brackets are well-formed, etc.

Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k. For example, there won't be input like 3a or 2[4].

Examples:

s = "3[a]2[bc]", return "aaabcbc".
s = "3[a2[c]]", return "accaccacc".
s = "2[abc]3[cd]ef", return "abcabccdcdcdef".
 */
public class Solution {
    public string DecodeString(string s) {
        StringBuilder tem = new StringBuilder();

        Stack<string> stack = new Stack<string>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '[')
            {
                int len = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (s[j] >= '0' && s[j] <= '9')
                        len++;
                    else
                        break;
                }

                tem.Remove(tem.Length - len, len);
                if (tem.Length > 0)
                {
                    stack.Push(tem.ToString());
                    tem.Length = 0;
                }
                stack.Push(s.Substring(i - len, len));
            }
            else if (s[i] == ']')
            {
                int num = int.Parse(stack.Pop());
                int l = tem.Length;
                for (int j = 0; j < num-1; j++)
                {
                    for (int k = 0; k < l; k++)
                    {
                        tem.Append(tem[k]);
                    }
                }

                if (stack.Count > 0)
                {
                    int n;
                    if (!int.TryParse(stack.Peek(), out n))
                    {
                        var pre = stack.Pop();
                        //stack.Push(pre + tem);
                        tem.Insert(0, pre);
                    }
                }
                //else
                //{
                //    stack.Push(tem.ToString());
                //}

                //tem.Length = 0;
            }
            else
            {
                tem.Append(s[i]);
            }
        }

        if (stack.Count > 0)
            return stack.Pop() + tem;
        else
            return tem.ToString();
    }
}

// √ Accepted
//   √ 29/29 cases passed (88 ms)
//   √ Your runtime beats 51.87 % of csharp submissions
//   √ Your memory usage beats 70.59 % of csharp submissions (20.8 MB)

