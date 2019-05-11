/*
 * @lc app=leetcode id=692 lang=csharp
 *
 * [692] Top K Frequent Words

 Given a non-empty list of words, return the k most frequent elements.

Your answer should be sorted by frequency from highest to lowest. If two words have the same frequency, then the word with the lower alphabetical order comes first.

Example 1:
Input: ["i", "love", "leetcode", "i", "love", "coding"], k = 2
Output: ["i", "love"]
Explanation: "i" and "love" are the two most frequent words.
    Note that "i" comes before "love" due to a lower alphabetical order.
Example 2:
Input: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], k = 4
Output: ["the", "is", "sunny", "day"]
Explanation: "the", "is", "sunny" and "day" are the four most frequent words,
    with the number of occurrence being 4, 3, 2 and 1 respectively.
Note:
You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
Input words contain only lowercase letters.
Follow up:
Try to solve it in O(n log k) time and O(n) extra space.
 */
public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        List<string> res = new List<string>();
        Dictionary<string, int> dic = new Dictionary<string, int>();

        foreach (var word in words)
        {
            int n;
            if (!dic.TryGetValue(word, out n))
                n = 0;
            dic[word] = n + 1;
        }

        res.AddRange(dic.Keys);
        res.Sort((a, b) =>
        {
            if (dic[a] == dic[b])
                return a.CompareTo(b);
            return dic[b] - dic[a];
        });

        for (int i = res.Count-1; i >= k; i--)
        {
            res.RemoveAt(i);
        }

        return res;
    }
}

// √ Accepted
//   √ 110/110 cases passed (320 ms)
//   √ Your runtime beats 27.41 % of csharp submissions
//   √ Your memory usage beats 5.55 % of csharp submissions (31.6 MB)

