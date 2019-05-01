/*
 * @lc app=leetcode id=388 lang=csharp
 *
 * [388] Longest Absolute File Path

 Suppose we abstract our file system by a string in the following manner:

The string "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext" represents:

dir
    subdir1
    subdir2
        file.ext
The directory dir contains an empty sub-directory subdir1 and a sub-directory subdir2 containing a file file.ext.

The string "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext" represents:

dir
    subdir1
        file1.ext
        subsubdir1
    subdir2
        subsubdir2
            file2.ext
The directory dir contains two sub-directories subdir1 and subdir2. subdir1 contains a file file1.ext and an empty second-level sub-directory subsubdir1. subdir2 contains a second-level sub-directory subsubdir2 containing a file file2.ext.

We are interested in finding the longest (number of characters) absolute path to a file within our file system. For example, in the second example above, the longest absolute path is "dir/subdir2/subsubdir2/file2.ext", and its length is 32 (not including the double quotes).

Given a string representing the file system in the above format, return the length of the longest absolute path to file in the abstracted file system. If there is no file in the system, return 0.

Note:
The name of a file contains at least a . and an extension.
The name of a directory or sub-directory will not contain a ..
Time complexity required: O(n) where n is the size of the input string.

Notice that a/aa/aaa/file1.txt is not the longest file path, if there is another path aaaaaaaaaaaaaaaaaaaaa/sth.png.
 */
public class Solution {
    public int LengthLongestPath(string input) {
        int res = 0;
        Stack<int> stack = new Stack<int>();
        StringBuilder builder = new StringBuilder();
        stack.Push(0);

        int preTn = 0;
        int tn = 0;
        for (int i = 0; i < input.Length;)
        {
            tn = 0;
            while (input[i] == '\t')
            {
                tn++;
                i++;
            }
            
            while (i < input.Length && input[i] != '\n')
            {
                builder.Append(input[i++]);
            }

            i++;

            if (tn <= preTn)
            {
                for (int j = 0; j <= preTn-tn && stack.Count > 0; j++)
                {
                    stack.Pop();
                }
            }
            stack.Push(builder.Length);

            if(builder.ToString().Contains("."))
            {
                int tem = 0;
                foreach (var i1 in stack)
                {
                    tem += i1;
                }

                tem += stack.Count - 1;
                res = Math.Max(tem, res);
            }

            builder.Length = 0;
            preTn = tn;
        }

        return res;
    }
}


// √ Accepted
//   √ 25/25 cases passed (72 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (20.1 MB)
