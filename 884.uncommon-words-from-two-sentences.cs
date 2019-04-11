/*
 * @lc app=leetcode id=884 lang=csharp
 *
 * [884] Uncommon Words from Two Sentences
 *
 * https://leetcode.com/problems/uncommon-words-from-two-sentences/description/
 *
 * algorithms
 * Easy (60.54%)
 * Total Accepted:    26.8K
 * Total Submissions: 44.2K
 * Testcase Example:  '"this apple is sweet"\n"this apple is sour"'
 *
 * We are given two sentences A and B.  (A sentence is a string of space
 * separated words.  Each word consists only of lowercase letters.)
 * 
 * A word is uncommon if it appears exactly once in one of the sentences, and
 * does not appear in the other sentence.
 * 
 * Return a list of all uncommon words. 
 * 
 * You may return the list in any order.
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: A = "this apple is sweet", B = "this apple is sour"
 * Output: ["sweet","sour"]
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: A = "apple apple", B = "banana"
 * Output: ["banana"]
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 0 <= A.length <= 200
 * 0 <= B.length <= 200
 * A and B both contain only spaces and lowercase letters.
 * 
 * 
 * 
 * 
 */
public class Solution {
    public string[] UncommonFromSentences(string A, string B) {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        string[] ps = A.Split(' ');
        foreach (var s in ps)
        {
            int n;
            if (!dic.TryGetValue(s, out n))
                n = 0;
            dic[s] = n + 1;
        }
        ps = B.Split(' ');
        foreach (var s in ps)
        {
            int n;
            if (!dic.TryGetValue(s, out n))
                n = 0;
            dic[s] = n + 1;
        }

        List<string> list = new List<string>();
        foreach (var i in dic)
        {
            if(i.Value == 1)
                list.Add(i.Key);
        }

        return list.ToArray();
    }
}

// √ Accepted
//   √ 53/53 cases passed (248 ms)
//   √ Your runtime beats 93.33 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (29.1 MB)

