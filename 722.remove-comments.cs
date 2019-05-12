/*
 * @lc app=leetcode id=722 lang=csharp
 *
 * [722] Remove Comments
Given a C++ program, remove comments from it. The program source is an array where source[i] is the i-th line of the source code. This represents the result of splitting the original source code string by the newline character \n.

In C++, there are two types of comments, line comments, and block comments.

The string // denotes a line comment, which represents that it and rest of the characters to the right of it in the same line should be ignored.

The string /* denotes a block comment, which represents that all characters until the next (non-overlapping) occurrence of */ /* should be ignored. (Here, occurrences happen in reading order: line by line from left to right.) To be clear, the string*/ /*/ does not yet end the block comment, as the ending would be overlapping the beginning.

The first effective comment takes precedence over others: if the string // occurs in a block comment, it is ignored. Similarly, if the string /* occurs in a line or block comment, it is also ignored.

If a certain line of code is empty after removing comments, you must not output that line: each string in the answer list will be non-empty.

There will be no control characters, single quote, or double quote characters. For example, source = "string s = "/* Not a comment. *//*";" will not be a test case. (Also, nothing else such as defines or macros will interfere with the comments.)*/

// It is guaranteed that every open block comment will eventually be closed, so /* outside of a line or block comment always starts a new comment.

// Finally, implicit newline characters can be deleted by block comments. Please see the examples below for details.

// After removing the comments from the source code, return the source code in the same format.

// Example 1:
// Input: 
// source = ["/*Test program */", "int main()", "{ ", "  // variable declaration ", "int a, b, c;", "/* This is a test", "   multiline  ", "   comment for ", "   testing */", "a = b + c;", "}"]

// The line by line code is visualized as below:
// /*Test program */
// int main()
// { 
//   // variable declaration 
// int a, b, c;
// /* This is a test
//    multiline  
//    comment for 
//    testing */
// a = b + c;
// }

// Output: ["int main()","{ ","  ","int a, b, c;","a = b + c;","}"]

// The line by line code is visualized as below:
// int main()
// { 
  
// int a, b, c;
// a = b + c;
// }

// Explanation: 
// The string /* denotes a block comment, including line 1 and lines 6-9. The string // denotes line 4 as comments.
// Example 2:
// Input: 
// source = ["a/*comment", "line", "more_comment*/b"]
// Output: ["ab"]
// Explanation: The original source string is "a/*comment\nline\nmore_comment*/b", where we have bolded the newline characters.  After deletion, the implicit newline characters are deleted, leaving the string "ab", which when delimited by newline characters becomes ["ab"].
// Note:

// The length of source is in the range [1, 100].
// The length of source[i] is in the range [0, 80].
// Every open block comment is eventually closed.
// There are no single-quote, double-quote, or control characters in the source code.
 
public class Solution {
    public IList<string> RemoveComments(string[] source) {
        List<string> res = new List<string>();
        if (source == null || source.Length == 0)
        {
            return res;
        }
        int tag = 0;
        StringBuilder buffer = new StringBuilder();
        for (int i = 0; i < source.Length; i++)
        {
            string line = source[i];
            int len = line.Length;
            int j = 0;
            while (j < len)
            {
                char c1 = line[j];
                char c2 = j < len - 1 ? line[j + 1] : ' '; //防止数组越界
                if (tag == 0 && c1 == '/' && c2 == '/')
                {
                    break;
                }
                else if (tag == 0 && c1 == '/' && c2 == '*')
                {
                    tag = 1;
                    j += 2;
                }
                else if (tag == 1 && c1 == '*' && c2 == '/')
                {
                    tag = 0;
                    j += 2;
                }
                else
                {
                    j++;
                    if (tag == 0)
                    {
                        buffer.Append(c1);
                    }
                }
            }
            if (tag == 0 && buffer.Length > 0)
            {
                res.Add(buffer.ToString());
                buffer = new StringBuilder();
            }
        }
        return res;
    }


    public IList<string> RemoveComments_Err(string[] source) {
        List<string> res = new List<string>();
        StringBuilder builder = new StringBuilder();
        bool inCom = false;

        foreach (var row in source)
        {
            builder.Length = 0;
            int start = 0;
            bool insertLast = inCom;

            if(inCom)
            {
                int idx = row.IndexOf("*/");
                if(idx >= 0)
                {
                    start = idx+2;
                    inCom = false;
                }
                else
                    continue;
            }

            for (int i = start; i < row.Length; i++)
            {
                if(row[i] == '*' && i < row.Length-1 && row[i+1] == '/' && inCom)
                {
                    i++;
                    inCom = false;
                }
                else if(row[i] == '/' && i<row.Length-1 &&
                    (row[i+1] == '/' || row[i+1] == '*')){
                    if(row[i+1] == '/')
                        break;
                    else if(row[i+1] == '*')
                    {
                        i++;
                        inCom = true;
                    }
                }
                else if(!inCom)
                    builder.Append(row[i]);
            }

            if(builder.Length > 0) {
                if(insertLast)
                    res[res.Count-1] += builder.ToString();
                else
                    res.Add(builder.ToString());
            }
        }
        return res;
    }
}


// √ Accepted
//   √ 53/53 cases passed (268 ms)
//   √ Your runtime beats 26.51 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (29.1 MB)
