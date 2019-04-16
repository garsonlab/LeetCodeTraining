/*
 * @lc app=leetcode id=71 lang=csharp
 *
 * [71] Simplify Path
 *
 * https://leetcode.com/problems/simplify-path/description/
 *
 * algorithms
 * Medium (28.45%)
 * Total Accepted:    146.1K
 * Total Submissions: 513.4K
 * Testcase Example:  '"/home/"'
 *
 * Given an absolute path for a file (Unix-style), simplify it. Or in other
 * words, convert it to the canonical path.
 * 
 * In a UNIX-style file system, a period . refers to the current directory.
 * Furthermore, a double period .. moves the directory up a level. For more
 * information, see: Absolute path vs relative path in Linux/Unix
 * 
 * Note that the returned canonical path must always begin with a slash /, and
 * there must be only a single slash / between two directory names. The last
 * directory name (if it exists) must not end with a trailing /. Also, the
 * canonical path must be the shortest string representing the absolute
 * path.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: "/home/"
 * Output: "/home"
 * Explanation: Note that there is no trailing slash after the last directory
 * name.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "/../"
 * Output: "/"
 * Explanation: Going one level up from the root directory is a no-op, as the
 * root level is the highest level you can go.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: "/home//foo/"
 * Output: "/home/foo"
 * Explanation: In the canonical path, multiple consecutive slashes are
 * replaced by a single one.
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: "/a/./b/../../c/"
 * Output: "/c"
 * 
 * 
 * Example 5:
 * 
 * 
 * Input: "/a/../../b/../c//.//"
 * Output: "/c"
 * 
 * 
 * Example 6:
 * 
 * 
 * Input: "/a//b////c/d//././/.."
 * Output: "/a/b/c"
 * 
 * 
 */
public class Solution {
    public string SimplifyPath(string path) {
        List<string> list = new List<string>();
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < path.Length; i++)
        {
            if (path[i] == '/')
            {
                if (builder.Length > 0)
                {
                    list.Add(builder.ToString());
                    builder.Length = 0;
                }
            }
            else
            {
                builder.Append(path[i]);
            }
        }
        if (builder.Length > 0)
            list.Add(builder.ToString());

        List<string> tem = new List<string>();
        foreach (var s in list)
        {
            if(s == ".")
                continue;
            if (s == "..")
            {
                if (tem.Count > 0)
                {
                    tem.RemoveAt(tem.Count-1);
                }
                continue;
            }
            tem.Add(s);
        }

        string ret = "/";
        for (int i = 0; i < tem.Count; i++)
        {
            if (i > 0)
                ret += "/";
            ret += tem[i];
        }

        return ret;
    }
}

// √ Accepted
//   √ 254/254 cases passed (104 ms)
//   √ Your runtime beats 59.41 % of csharp submissions
//   √ Your memory usage beats 13.79 % of csharp submissions (24.2 MB)

