/*
 * @lc app=leetcode id=705 lang=csharp
 *
 * [705] Design HashSet
 *
 * https://leetcode.com/problems/design-hashset/description/
 *
 * algorithms
 * Easy (51.36%)
 * Total Accepted:    17.2K
 * Total Submissions: 33.2K
 * Testcase Example:  '["MyHashSet","add","add","contains","contains","add","contains","remove","contains"]\n[[],[1],[2],[1],[3],[2],[2],[2],[2]]'
 *
 * Design a HashSet without using any built-in hash table libraries.
 * 
 * To be specific, your design should include these functions:
 * 
 * 
 * add(value): Insert a value into the HashSet. 
 * contains(value) : Return whether the value exists in the HashSet or not.
 * remove(value): Remove a value in the HashSet. If the value does not exist in
 * the HashSet, do nothing.
 * 
 * 
 * 
 * Example:
 * 
 * 
 * MyHashSet hashSet = new MyHashSet();
 * hashSet.add(1);         
 * hashSet.add(2);         
 * hashSet.contains(1);    // returns true
 * hashSet.contains(3);    // returns false (not found)
 * hashSet.add(2);          
 * hashSet.contains(2);    // returns true
 * hashSet.remove(2);          
 * hashSet.contains(2);    // returns false (already removed)
 * 
 * 
 * 
 * Note:
 * 
 * 
 * All values will be in the range of [0, 1000000].
 * The number of operations will be in the range of [1, 10000].
 * Please do not use the built-in HashSet library.
 * 
 * 
 */
public class MyHashSet
{
    int[] nums = new int[1000001];

    /** Initialize your data structure here. */
    public MyHashSet()
    {
    }

    public void Add(int key)
    {
        nums[key] = 1;
    }

    public void Remove(int key)
    {
        nums[key] = 0;
    }

    /** Returns true if this set contains the specified element */
    public bool Contains(int key)
    {
        return nums[key] > 0;
    }
}
// √ Accepted
//   √ 28/28 cases passed (244 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (41.8 MB)


//理解错误，以为Add两次2 Remove1次后还有，当List了
public class MyHashSet2 {
    // int[] list = new int[10001];
    node root;
    node cur;
    int[] nums = new int[1000001];

    /** Initialize your data structure here. */
    public MyHashSet2() {
        root = new node(0);
        cur = root;
    }
    
    public void Add(int key) {
        var n = new node(key);
        cur.next = n;
        cur = n;
        nums[key]++;
    }
    
    public void Remove(int key) {
        var tem = root;
        var pre = root;
        while (tem != null)
        {
            if(tem.val == key)
            {
                pre.next = tem.next;
                nums[key]--;

                if(tem == cur)
                    cur = pre;
                break;
            }
            pre = tem;
            tem = tem.next;
        }
    }
    
    /** Returns true if this set contains the specified element */
    public bool Contains(int key) {
        //return nums[key] > 0;
        var tem = root;
        while (tem != null)
        {
            if(tem.val == key)
                return true;
            tem = tem.next;
        }
        return false;
    }

    class node {
        public int val;
        public node next;

        public node(int v) {
            val = v;
            next = null;
        }
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */

