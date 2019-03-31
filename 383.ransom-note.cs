/*
 * @lc app=leetcode id=383 lang=csharp
 *
 * [383] Ransom Note
 *
 * https://leetcode.com/problems/ransom-note/description/
 *
 * algorithms
 * Easy (49.41%)
 * Total Accepted:    106.4K
 * Total Submissions: 215.1K
 * Testcase Example:  '"a"\n"b"'
 *
 * 
 * Given an arbitrary ransom note string and another string containing letters
 * from all the magazines, write a function that will return true if the
 * ransom 
 * note can be constructed from the magazines ; otherwise, it will return
 * false. 
 * 
 * 
 * Each letter in the magazine string can only be used once in your ransom
 * note.
 * 
 * 
 * Note:
 * You may assume that both strings contain only lowercase letters.
 * 
 * 
 * 
 * canConstruct("a", "b") -> false
 * canConstruct("aa", "ab") -> false
 * canConstruct("aa", "aab") -> true
 * 
 * 
 */
public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        Dictionary<char, int> dic = new Dictionary<char, int>();
        for (int i = 0; i < magazine.Length; i++)
        {
            int n;
            if(!dic.TryGetValue(magazine[i], out n)){
                n = 0;
            }
            dic[magazine[i]] = n+1;
        }

        for (int i = 0; i < ransomNote.Length; i++)
        {
            int n;
            if(!dic.TryGetValue(ransomNote[i], out n)){
                return false;
            }
            
            if(n<=1)
                dic.Remove(ransomNote[i]);
            else
                dic[ransomNote[i]] = n-1;

        }

        return true;
    }
}


// √ Accepted
//   √ 126/126 cases passed (96 ms)
//   √ Your runtime beats 79.71 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (25.4 MB)

