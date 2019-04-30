/*
 * @lc app=leetcode id=332 lang=csharp
 *
 * [332] Reconstruct Itinerary

 Given a list of airline tickets represented by pairs of departure and arrival airports [from, to], reconstruct the itinerary in order. All of the tickets belong to a man who departs from JFK. Thus, the itinerary must begin with JFK.

Note:

If there are multiple valid itineraries, you should return the itinerary that has the smallest lexical order when read as a single string. For example, the itinerary ["JFK", "LGA"] has a smaller lexical order than ["JFK", "LGB"].
All airports are represented by three capital letters (IATA code).
You may assume all tickets form at least one valid itinerary.
Example 1:

Input: [["MUC", "LHR"], ["JFK", "MUC"], ["SFO", "SJC"], ["LHR", "SFO"]]
Output: ["JFK", "MUC", "LHR", "SFO", "SJC"]
Example 2:

Input: [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
Output: ["JFK","ATL","JFK","SFO","ATL","SFO"]
Explanation: Another possible reconstruction is ["JFK","SFO","ATL","JFK","ATL","SFO"].
             But it is larger in lexical order.
 */
public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        List<string> list = new List<string>(){ "JFK" };
        foreach (var ticket in tickets)
        {
            List<string> t;
            if (!dic.TryGetValue(ticket[0], out t))
            {
                t = new List<string>();
                dic[ticket[0]] = t;
            }
            t.Add(ticket[1]);
        }

        foreach (var dicValue in dic.Values)
        {
            dicValue.Sort();
        }

        SerPath(dic, list, "JFK");

        return list;
    }

    private bool SerPath(Dictionary<string, List<string>> dic, List<string> list, string from)
    {
        if (!dic.ContainsKey(from) || dic[from].Count <= 0)
        {
            foreach (var value in dic.Values)
            {
                if (value.Count > 0)
                    return false;
            }

            return true;
        }

        List<string> tem = dic[from];

        for (int i = 0; i < tem.Count; i++)
        {
            string name = tem[i];
            tem.RemoveAt(i);
            list.Add(name);

            bool ret = SerPath(dic, list, name);
            if (!ret)
            {
                tem.Insert(i, name);
                list.RemoveAt(list.Count - 1);
            }
            else
                return true;
        }

        return false;
    }

}

// √ Accepted
//   √ 80/80 cases passed (300 ms)
//   √ Your runtime beats 95.6 % of csharp submissions
//   √ Your memory usage beats 14.29 % of csharp submissions (31.9 MB)

