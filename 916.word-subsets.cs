/*
 * @lc app=leetcode id=916 lang=csharp
 *
 * [916] Word Subsets

 We are given two arrays A and B of words.  Each word is a string of lowercase letters.

Now, say that word b is a subset of word a if every letter in b occurs in a, including multiplicity.  For example, "wrr" is a subset of "warrior", but is not a subset of "world".

Now say a word a from A is universal if for every b in B, b is a subset of a. 

Return a list of all universal words in A.  You can return the words in any order.

 

Example 1:

Input: A = ["amazon","apple","facebook","google","leetcode"], B = ["e","o"]
Output: ["facebook","google","leetcode"]
Example 2:

Input: A = ["amazon","apple","facebook","google","leetcode"], B = ["l","e"]
Output: ["apple","google","leetcode"]
Example 3:

Input: A = ["amazon","apple","facebook","google","leetcode"], B = ["e","oo"]
Output: ["facebook","google"]
Example 4:

Input: A = ["amazon","apple","facebook","google","leetcode"], B = ["lo","eo"]
Output: ["google","leetcode"]
Example 5:

Input: A = ["amazon","apple","facebook","google","leetcode"], B = ["ec","oc","ceo"]
Output: ["facebook","leetcode"]
 

Note:

1 <= A.length, B.length <= 10000
1 <= A[i].length, B[i].length <= 10
A[i] and B[i] consist only of lowercase letters.
All words in A[i] are unique: there isn't i != j with A[i] == A[j].
 */
public class Solution {
    public IList<string> WordSubsets(string[] A, string[] B) {
        List<string> res = new List<string>();

        if (A == null || B == null || A.Length == 0 || B.Length == 0)
            return res;

        int n = A.Length;
        int m = B.Length;

        // map中的key：A[i]中某个字符，value为A[i]中某个字符出现的次数
        Dictionary<char, int>[] AMap = new Dictionary<char, int>[n];
        Dictionary<char, int> BMap = new Dictionary<char, int>();

        for (int i = 0; i < n; i++)
        {
            AMap[i] = new Dictionary<char, int>();
            for (int j = 0; j < A[i].Length; j++)
            {
                char key = A[i][j];

                if (AMap[i].ContainsKey(key))
                    AMap[i][key]++;
                else
                    AMap[i][key] = 1;
            }
        }

        for (int i = 0; i < m; i++)
        {
            Dictionary<char, int> temp = new Dictionary<char, int>();
            for (int j = 0; j < B[i].Length; j++)
            {
                char key = B[i][j];
                if (temp.ContainsKey(key))
                    temp[key]++;
                else
                    temp[key] = 1;
            }
            foreach (char key in temp.Keys)
            { // BMap中存储对应某个字符出现次数的最大值即可，因为只要有一个不符合条件，那么A[i]将不是它的父集
                if (BMap.ContainsKey(key))
                    BMap[key] = Math.Max(BMap[key], temp[key]);
                else
                    BMap[key] = temp[key];
            }
        }

        // 判断A[i]是否是B的父集
        for (int i = 0; i < n; i++)
        {
            bool flag = true;
            foreach (char key in BMap.Keys)
            if (!AMap[i].ContainsKey(key) || BMap[key] > AMap[i][key])
                flag = false;
            if (flag)
                res.Add(A[i]);
        }
        return res;
    }
}

// √ Accepted
//   √ 55/55 cases passed (588 ms)
//   √ Your runtime beats 7.69 % of csharp submissions
//   √ Your memory usage beats 7.32 % of csharp submissions (55.3 MB)

