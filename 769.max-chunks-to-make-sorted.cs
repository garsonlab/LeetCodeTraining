/*
 * @lc app=leetcode id=769 lang=csharp
 *
 * [769] Max Chunks To Make Sorted

 Given an array arr that is a permutation of [0, 1, ..., arr.length - 1], we split the array into some number of "chunks" (partitions), and individually sort each chunk.  After concatenating them, the result equals the sorted array.

What is the most number of chunks we could have made?

Example 1:

Input: arr = [4,3,2,1,0]
Output: 1
Explanation:
Splitting into two or more chunks will not return the required result.
For example, splitting into [4, 3], [2, 1, 0] will result in [3, 4, 0, 1, 2], which isn't sorted.
Example 2:

Input: arr = [1,0,2,3,4]
Output: 4
Explanation:
We can split into two chunks, such as [1, 0], [2, 3, 4].
However, splitting into [1, 0], [2], [3], [4] is the highest number of chunks possible.
Note:

arr will have length in range [1, 10].
arr[i] will be a permutation of [0, 1, ..., arr.length - 1].
 */
public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        int arrLen = arr.Length;
        int maxIndex = 0, result = 1;
        for (int i = 0; i < arrLen; ++i)
        {
            if (maxIndex < i)
            {
                ++result;
            }
            if (arr[i] > maxIndex)
            {
                maxIndex = arr[i];
            }
        }

        return result;
    }
}

// √ Accepted
//   √ 52/52 cases passed (88 ms)
//   √ Your runtime beats 95.24 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (21.8 MB)

