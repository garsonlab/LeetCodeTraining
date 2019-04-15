/*
 * @lc app=leetcode id=49 lang=csharp
 *
 * [49] Group Anagrams
 *
 * https://leetcode.com/problems/group-anagrams/description/
 *
 * algorithms
 * Medium (45.78%)
 * Total Accepted:    317.5K
 * Total Submissions: 692.8K
 * Testcase Example:  '["eat","tea","tan","ate","nat","bat"]'
 *
 * Given an array of strings, group anagrams together.
 * 
 * Example:
 * 
 * 
 * Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
 * Output:
 * [
 * ⁠ ["ate","eat","tea"],
 * ⁠ ["nat","tan"],
 * ⁠ ["bat"]
 * ]
 * 
 * Note:
 * 
 * 
 * All inputs will be in lowercase.
 * The order of your output does not matter.
 * 
 * 
 */
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        foreach (var str in strs)
        {
            char[] chars = str.ToCharArray();
            Array.Sort(chars);

            string r = new string(chars);

            List<string> list;
            if (!dic.TryGetValue(r, out list))
            {
                list = new List<string>();
                dic[r] = list;
            }
            list.Add(str);
        }
        IList<IList<string>> ret = new List<IList<string>>();
        foreach (var dicValue in dic.Values)
        {
            ret.Add(dicValue);
        }

        return ret;
    }
}

//参考学习了一种方法，26个字母用质数表示，比较乘积是否相等
// √ Accepted
//   √ 101/101 cases passed (296 ms)
//   √ Your runtime beats 96.51 % of csharp submissions
//   √ Your memory usage beats 49.23 % of csharp submissions (37.3 MB)

