/*
 * @lc app=leetcode id=380 lang=csharp
 *
 * [380] Insert Delete GetRandom O(1)

 Design a data structure that supports all following operations in average O(1) time.

insert(val): Inserts an item val to the set if not already present.
remove(val): Removes an item val from the set if present.
getRandom: Returns a random element from current set of elements. Each element must have the same probability of being returned.
Example:

// Init an empty set.
RandomizedSet randomSet = new RandomizedSet();

// Inserts 1 to the set. Returns true as 1 was inserted successfully.
randomSet.insert(1);

// Returns false as 2 does not exist in the set.
randomSet.remove(2);

// Inserts 2 to the set, returns true. Set now contains [1,2].
randomSet.insert(2);

// getRandom should return either 1 or 2 randomly.
randomSet.getRandom();

// Removes 1 from the set, returns true. Set now contains [2].
randomSet.remove(1);

// 2 was already in the set, so return false.
randomSet.insert(2);

// Since 2 is the only number in the set, getRandom always return 2.
randomSet.getRandom();
 */
public class RandomizedSet {

    Dictionary<int, int> dic;
    List<int> list;
    Random random;

    /** Initialize your data structure here. */
    public RandomizedSet() {
        dic = new Dictionary<int, int>();
        list = new List<int>();
        random = new Random();
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if(dic.ContainsKey(val))
            return false;
        list.Add(val);
        dic[val] = list.Count-1;
        return true;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if(!dic.ContainsKey(val))
            return false;

        int tem = list[list.Count-1];
        dic[tem] = dic[val];
        list[dic[val]] = tem;
        list.RemoveAt(list.Count-1);
        dic.Remove(val);
        return true;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        return list[random.Next(0, list.Count)];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */

//  √ Accepted
//   √ 18/18 cases passed (184 ms)
//   √ Your runtime beats 52.92 % of csharp submissions
//   √ Your memory usage beats 42.86 % of csharp submissions (38.6 MB)

