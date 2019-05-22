/*
 * @lc app=leetcode id=969 lang=csharp
 *
 * [969] Pancake Sorting
 Given an array A, we can perform a pancake flip: We choose some positive integer k <= A.length, then reverse the order of the first k elements of A.  We want to perform zero or more pancake flips (doing them one after another in succession) to sort the array A.

Return the k-values corresponding to a sequence of pancake flips that sort A.  Any valid answer that sorts the array within 10 * A.length flips will be judged as correct.

 

Example 1:

Input: [3,2,4,1]
Output: [4,2,4,3]
Explanation: 
We perform 4 pancake flips, with k values 4, 2, 4, and 3.
Starting state: A = [3, 2, 4, 1]
After 1st flip (k=4): A = [1, 4, 2, 3]
After 2nd flip (k=2): A = [4, 1, 2, 3]
After 3rd flip (k=4): A = [3, 2, 1, 4]
After 4th flip (k=3): A = [1, 2, 3, 4], which is sorted. 
Example 2:

Input: [1,2,3]
Output: []
Explanation: The input is already sorted, so there is no need to flip anything.
Note that other answers, such as [3, 3], would also be accepted.
 

Note:

1 <= A.length <= 100
A[i] is a permutation of [1, 2, ..., A.length]
 */
public class Solution {
    public IList<int> PancakeSort(int[] A) {
        List<int> res = new List<int>();
        for (int i = A.Length; i > 0; i--)
        {
            if (i == A[i-1])
            {
                continue;
            }
            else
            {
                int index = Array.IndexOf(A, i);//  indexOfAi(A, B[i], i);
                Array.Reverse(A, 0, index+1);
                Array.Reverse(A, 0, i);
                res.Add(index+1);
                res.Add(i);
            }
        }
        return res;
    }
}

// √ Accepted
//   √ 215/215 cases passed (268 ms)
//   √ Your runtime beats 37.08 % of csharp submissions
//   √ Your memory usage beats 18.46 % of csharp submissions (29.2 MB)

