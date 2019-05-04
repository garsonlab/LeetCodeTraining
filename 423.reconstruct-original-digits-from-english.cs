/*
 * @lc app=leetcode id=423 lang=csharp
 *
 * [423] Reconstruct Original Digits from English

 Given a non-empty string containing an out-of-order English representation of digits 0-9, output the digits in ascending order.

Note:
Input contains only lowercase English letters.
Input is guaranteed to be valid and can be transformed to its original digits. That means invalid inputs such as "abc" or "zerone" are not permitted.
Input length is less than 50,000.
Example 1:
Input: "owoztneoer"

Output: "012"
Example 2:
Input: "fviefuro"

Output: "45"
 */
public class Solution {
    public string OriginalDigits(string s) {
        List<string> str = new List<string>(){
            "geiht", "zero", "xis", "wto", "ufor",
            "five", "vseen", "one", "three", "nine"
        };
        List<int> nums = new List<int>() {
            8, 0, 6, 2,4,5,7,1,3,9
        };
        // List<string> sn = new List<string>() {
        //     "zero", "one", "two", "three", "four",
        //     "five", "six", "seven","eight",  "nine"
        // };
        StringBuilder builder = new StringBuilder();

        int[] map = new int[26];

        foreach (var c in s)
        {
            map[c-'a']++;
        }

        List<int> list = new List<int>();
        for (int i = 0; i < str.Count; i++)
        {
            var item = str[i];
            if (map[item[0]-'a'] > 0)
            {
                int n = map[item[0]-'a'];
                foreach (var c in item)
                {
                    n = Math.Min(n, map[c-'a']);
                }
                foreach (var c in item)
                {
                    map[c-'a'] -= n;
                }

                for (int j = 0; j < n; j++)
                {
                    list.Add(nums[i]);
                }
            }
        }

        list.Sort();
        foreach (var i in list)
        {
            // builder.Append(sn[i]);
            builder.Append(i);
        }
        return builder.ToString();
    }
}



        
        // nine
        
        // three  r 
        // one    o
        // seven  v
        // five  f  
         
        // four  u  
        // two   w 
        // six     x
        // zero    z
        // eight  g

// √ Accepted
//   √ 24/24 cases passed (112 ms)
//   √ Your runtime beats 68 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (30.2 MB)
