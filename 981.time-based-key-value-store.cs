/*
 * @lc app=leetcode id=981 lang=csharp
 *
 * [981] Time Based Key-Value Store

 Create a timebased key-value store class TimeMap, that supports two operations.

1. set(string key, string value, int timestamp)

Stores the key and value, along with the given timestamp.
2. get(string key, int timestamp)

Returns a value such that set(key, value, timestamp_prev) was called previously, with timestamp_prev <= timestamp.
If there are multiple such values, it returns the one with the largest timestamp_prev.
If there are no values, it returns the empty string ("").
 

Example 1:

Input: inputs = ["TimeMap","set","get","get","set","get","get"], inputs = [[],["foo","bar",1],["foo",1],["foo",3],["foo","bar2",4],["foo",4],["foo",5]]
Output: [null,null,"bar","bar",null,"bar2","bar2"]
Explanation:   
TimeMap kv;   
kv.set("foo", "bar", 1); // store the key "foo" and value "bar" along with timestamp = 1   
kv.get("foo", 1);  // output "bar"   
kv.get("foo", 3); // output "bar" since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 ie "bar"   
kv.set("foo", "bar2", 4);   
kv.get("foo", 4); // output "bar2"   
kv.get("foo", 5); //output "bar2"   
Example 2:

Input: inputs = ["TimeMap","set","set","get","get","get","get","get"], inputs = [[],["love","high",10],["love","low",20],["love",5],["love",10],["love",15],["love",20],["love",25]]
Output: [null,null,null,"","high","high","low","low"]
 

Note:

All key/value strings are lowercase.
All key/value strings have length in the range [1, 100]
The timestamps for all TimeMap.set operations are strictly increasing.
1 <= timestamp <= 10^7
TimeMap.set and TimeMap.get functions will be called a total of 120000 times (combined) per test case.
 */
public class TimeMap {

        private Dictionary<string, List<int[]>> map;
        private List<string> vals;

        /** Initialize your data structure here. */
        public TimeMap()
        {
            map = new Dictionary<string, List<int[]>>();
            vals = new List<string>();
        }

        public void Set(string key, string value, int timestamp)
        {
            List<int[]> list;
            if (!map.TryGetValue(key, out list))
            {
                list = new List<int[]>();
                map[key] = list;
            }

            list.Add(new int[]{timestamp, vals.Count});
            vals.Add(value);
        }

        public string Get(string key, int timestamp)
        {
            List<int[]> list;
            if (!map.TryGetValue(key, out list))
                return string.Empty;

                // Console.WriteLine(timestamp +", " + list[0][0] +", " + list[list.Count - 1][0]);
            if (timestamp < list[0][0])// || timestamp > list[list.Count - 1][0])
                return string.Empty;

            int l = 0, r = list.Count - 1;
            while (l < r)
            {
                int mid = (l + r) / 2 + 1;

                if (list[mid][0] == timestamp)
                {
                    l = mid;
                    break;
                }
                if (list[mid][0] > timestamp)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid;
                }
            }

            int idx = list[l][1];
            return vals[idx];
        }
        
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */

//  √ Accepted
//   √ 45/45 cases passed (1008 ms)
//   √ Your runtime beats 33.77 % of csharp submissions
//   √ Your memory usage beats 11.11 % of csharp submissions (107.7 MB)

