/*
 * @lc app=leetcode id=677 lang=csharp
 *
 * [677] Map Sum Pairs

 Implement a MapSum class with insert, and sum methods.

For the method insert, you'll be given a pair of (string, integer). The string represents the key and the integer represents the value. If the key already existed, then the original key-value pair will be overridden to the new one.

For the method sum, you'll be given a string representing the prefix, and you need to return the sum of all the pairs' value whose key starts with the prefix.

Example 1:
Input: insert("apple", 3), Output: Null
Input: sum("ap"), Output: 3
Input: insert("app", 2), Output: Null
Input: sum("ap"), Output: 5
 */
public class MapSum {

    private Dictionary<string, int> dic;
    /** Initialize your data structure here. */
    public MapSum()
    {
        dic = new Dictionary<string, int>();
    }

    public void Insert(string key, int val)
    {
        dic[key] = val;
    }

    public int Sum(string prefix)
    {
        int res = 0;
        foreach (var i in dic)
        {
            if (i.Key.StartsWith(prefix))
                res += i.Value;
        }

        return res;
    }
}

/**
 * Your MapSum object will be instantiated and called as such:
 * MapSum obj = new MapSum();
 * obj.Insert(key,val);
 * int param_2 = obj.Sum(prefix);
 */

//  √ Accepted
//   √ 30/30 cases passed (128 ms)
//   √ Your runtime beats 37.21 % of csharp submissions
//   √ Your memory usage beats 62.5 % of csharp submissions (24.8 MB)

