/*
 * @lc app=leetcode id=820 lang=csharp
 *
 * [820] Short Encoding of Words
 Given a list of words, we may encode it by writing a reference string S and a list of indexes A.

For example, if the list of words is ["time", "me", "bell"], we can write it as S = "time#bell#" and indexes = [0, 2, 5].

Then for each index, we will recover the word by reading from the reference string from that index until we reach a "#" character.

What is the length of the shortest reference string S possible that encodes the given words?

Example:

Input: words = ["time", "me", "bell"]
Output: 10
Explanation: S = "time#bell#" and indexes = [0, 2, 5].
 

Note:

1 <= words.length <= 2000.
1 <= words[i].length <= 7.
Each word has only lowercase letters.
 */
public class Solution {
    public int MinimumLengthEncoding(string[] words)
    {
        if (words.Length <= 0)
            return 1;

        Array.Sort(words, (a, b) => { return b.Length - a.Length; });        
        StringBuilder sb = new StringBuilder();
        foreach(string i in words) {
            if(sb.ToString().Contains(i+"#"))
                continue;
            else
                sb.Append(i+"#");
        }
        return sb.Length;
    }


    public int MinimumLengthEncoding_timeout(string[] words) {
        if (words == null || words.Length == 0)
        {
            return 1;
        }
        // 使用set对字符串去重
        List<string> strings = new List<string>();
        foreach (var word in words)
        {
            if(!strings.Contains(word))
                strings.Add(word);
        }

        int size = strings.Count;
        int result = 0, add;
        for (int i = 0; i < size; i++)
        {
            // 表示本字符串可以给最终字符串增加的长度
            add = strings[i].Length + 1;
            for (int j = 0; j < size; j++)
            {
                // 如果这个字符串是别的字符串的后缀，那么这个字符串就可以用其表示
                // 而不需要在主串后再加一段
                if (i != j && strings[j].EndsWith(words[i]))
                {
                    add = 0;
                    break;
                }
            }

            result += add;
        }

        return result;
    }
}
//最合适的是字典树
// √ Accepted
//   √ 30/30 cases passed (740 ms)
//   √ Your runtime beats 10.53 % of csharp submissions
//   √ Your memory usage beats 29.41 % of csharp submissions (43.2 MB)

