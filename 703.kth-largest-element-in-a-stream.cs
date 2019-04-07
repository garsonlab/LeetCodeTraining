/*
 * @lc app=leetcode id=703 lang=csharp
 *
 * [703] Kth Largest Element in a Stream
 *
 * https://leetcode.com/problems/kth-largest-element-in-a-stream/description/
 *
 * algorithms
 * Easy (45.49%)
 * Total Accepted:    27.7K
 * Total Submissions: 60.2K
 * Testcase Example:  '["KthLargest","add","add","add","add","add"]\n[[3,[4,5,8,2]],[3],[5],[10],[9],[4]]'
 *
 * Design a class to find the kth largest element in a stream. Note that it is
 * the kth largest element in the sorted order, not the kth distinct element.
 * 
 * Your KthLargest class will have a constructor which accepts an integer k and
 * an integer array nums, which contains initial elements from the stream. For
 * each call to the method KthLargest.add, return the element representing the
 * kth largest element in the stream.
 * 
 * Example:
 * 
 * 
 * int k = 3;
 * int[] arr = [4,5,8,2];
 * KthLargest kthLargest = new KthLargest(3, arr);
 * kthLargest.add(3);   // returns 4
 * kthLargest.add(5);   // returns 5
 * kthLargest.add(10);  // returns 5
 * kthLargest.add(9);   // returns 8
 * kthLargest.add(4);   // returns 8
 * 
 * 
 * Note: 
 * You may assume that nums' length ≥ k-1 and k ≥ 1.
 * 
 */
public class KthLargest {

    List<int> list;
    int k;

    public KthLargest(int k, int[] nums) {
        this.k = k;
        this.list = new List<int>(k);

        Array.Sort(nums);
        int e = nums.Length - Math.Min(nums.Length, k);
        for (int i = nums.Length-1; i >= e; i--)
        {
            list.Add(nums[i]);
        }
    }
    
    public int Add(int val) {
        bool insert = false;
        for (int i = 0; i < list.Count; i++)
        {
            if (val >= list[i])
            {
                if (list.Count >= k)
                    list.RemoveAt(list.Count - 1);
                list.Insert(i, val);
                insert = true;
                break;
            }
        }
        if(!insert && list.Count < k)
            list.Add(val);


        if (list.Count < k)
            return 0;

        return list[k - 1];
    }


}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */


// √ Accepted
//   √ 10/10 cases passed (456 ms)
//   √ Your runtime beats 48.2 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (38.1 MB)
