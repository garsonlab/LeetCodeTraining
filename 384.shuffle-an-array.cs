/*
 * @lc app=leetcode id=384 lang=csharp
 *
 * [384] Shuffle an Array

 Shuffle a set of numbers without duplicates.

Example:

// Init an array with set 1, 2, and 3.
int[] nums = {1,2,3};
Solution solution = new Solution(nums);

// Shuffle the array [1,2,3] and return its result. Any permutation of [1,2,3] must equally likely to be returned.
solution.shuffle();

// Resets the array back to its original configuration [1,2,3].
solution.reset();

// Returns the random shuffling of array [1,2,3].
solution.shuffle();
 */
public class Solution {

    int[] ori;
    int[] shuffle;
    Random random;

    public Solution(int[] nums) {
        ori = new int[nums.Length];
        Array.Copy(nums, ori, nums.Length);
        shuffle = nums;
        random = new Random();
    }
    
    /** Resets the array to its original configuration and return it. */
    public int[] Reset() {
        return ori;
    }
    
    /** Returns a random shuffling of the array. */
    public int[] Shuffle() {
        int len = shuffle.Length;
        for (int i = 0; i < len/2; i++)
        {
            int tem = random.Next(len);
            swap(i, tem);
        }
        return shuffle;
    }

    private void swap(int i, int j) {
        int tem = shuffle[i];
        shuffle[i] = shuffle[j];
        shuffle[j] = tem;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */

//  √ Accepted
//   √ 10/10 cases passed (356 ms)
//   √ Your runtime beats 95.65 % of csharp submissions
//   √ Your memory usage beats 85.71 % of csharp submissions (49.9 MB)

