/*
 * @lc app=leetcode id=721 lang=csharp
 *
 * [721] Accounts Merge

 Given a list accounts, each element accounts[i] is a list of strings, where the first element accounts[i][0] is a name, and the rest of the elements are emails representing emails of the account.

Now, we would like to merge these accounts. Two accounts definitely belong to the same person if there is some email that is common to both accounts. Note that even if two accounts have the same name, they may belong to different people as people could have the same name. A person can have any number of accounts initially, but all of their accounts definitely have the same name.

After merging the accounts, return the accounts in the following format: the first element of each account is the name, and the rest of the elements are emails in sorted order. The accounts themselves can be returned in any order.

Example 1:
Input: 
accounts = [["John", "johnsmith@mail.com", "john00@mail.com"], ["John", "johnnybravo@mail.com"], ["John", "johnsmith@mail.com", "john_newyork@mail.com"], ["Mary", "mary@mail.com"]]
Output: [["John", 'john00@mail.com', 'john_newyork@mail.com', 'johnsmith@mail.com'],  ["John", "johnnybravo@mail.com"], ["Mary", "mary@mail.com"]]
Explanation: 
The first and third John's are the same person as they have the common email "johnsmith@mail.com".
The second John and Mary are different people as none of their email addresses are used by other accounts.
We could return these lists in any order, for example the answer [['Mary', 'mary@mail.com'], ['John', 'johnnybravo@mail.com'], 
['John', 'john00@mail.com', 'john_newyork@mail.com', 'johnsmith@mail.com']] would still be accepted.
Note:

The length of accounts will be in the range [1, 1000].
The length of accounts[i] will be in the range [1, 10].
The length of accounts[i][j] will be in the range [1, 30].
 */
public class Solution {
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        var result = new List<IList<string>>();
        
        if (accounts == null || accounts.Count == 0) return result;
        
        // email address to list of accounts
        var dict = new Dictionary<string, HashSet<int>>();
        
        // build the graph
        for (int j = 0; j < accounts.Count; j++)
        {
            var account = accounts[j];
            for (int i = 1; i < account.Count; i++)
            {
                if (!dict.ContainsKey(account[i]))
                {
                    dict[account[i]] = new HashSet<int>();
                }
                
                dict[account[i]].Add(j);
            }
        }
        
        var visited = new HashSet<string>();
        
        foreach (var email in dict.Keys)
        {
            if (visited.Contains(email)) continue;
            visited.Add(email);
            
            var list = new List<string>();
            list.Add(email);
            
            var name = "";
            var queue = new Queue<string>();
            
            queue.Enqueue(email);
            
            while (queue.Count > 0)
            {
                var e = queue.Dequeue();
                
                foreach (var aId in dict[e])
                {
                    var account = accounts[aId];
                    name = account[0];
                    
                    for (int i = 1; i < account.Count; i++)
                    {
                        if (!visited.Contains(account[i]))
                        {
                            queue.Enqueue(account[i]);
                            list.Add(account[i]);
                            visited.Add(account[i]);
                        }
                    }
                }
            }
            
            list.Insert(0, name);
            
            // c# string comparer has different behavior than Java
            list.Sort((Comparison<String>) (
                (String left, String right) => {
                    return String.CompareOrdinal(left, right);
                }
            ));
            
            result.Add(list);
        }
        
        return result;
    }



    public IList<IList<string>> AccountsMerge_noRap(IList<IList<string>> accounts) {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        IList<IList<string>> res = new List<IList<string>>();

        foreach (var list in accounts)
        {
            int idx = -1;
            for (int i = 1; i < list.Count; i++)
            {
                if (dic.TryGetValue(list[i], out idx))
                {
                    break;
                }
                else
                    idx = -1;
            }

            if (idx < 0)
            {
                res.Add(new List<string>(){list[0]});
                idx = res.Count - 1;
            }

            for (int i = 1; i < list.Count; i++)
            {
                if(!res[idx].Contains(list[i]))
                    res[idx].Add(list[i]);
                    // res[idx].Insert(1, list[i]);
                dic[list[i]] = idx;
            }
        }

        foreach (List<string> list in res)
        {
            string name = list[0];
            list.Sort((a, b) =>
            {
                if (a == name)
                    return -1;
                if (b == name)
                    return 1;
                return string.CompareOrdinal(a, b);
            });
        }

        return res;
    }
}


// √ Accepted
//   √ 49/49 cases passed (516 ms)
//   √ Your runtime beats 38.46 % of csharp submissions
//   √ Your memory usage beats 60 % of csharp submissions (47.8 MB)

