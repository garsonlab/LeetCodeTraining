/*
 * @lc app=leetcode id=870 lang=csharp
 *
 * [870] Advantage Shuffle

 Given two arrays A and B of equal size, the advantage of A with respect to B is the number of indices i for which A[i] > B[i].

Return any permutation of A that maximizes its advantage with respect to B.

 

Example 1:

Input: A = [2,7,11,15], B = [1,10,4,11]
Output: [2,11,7,15]
Example 2:

Input: A = [12,24,8,32], B = [13,25,32,11]
Output: [24,32,8,12]
 

Note:

1 <= A.length = B.length <= 10000
0 <= A[i] <= 10^9
0 <= B[i] <= 10^9
 */
public class Solution {
    public int[] AdvantageCount(int[] A, int[] B) {
        Array.Sort(A);

        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        for (int i = 0; i < B.Length; i++)
        {
            List<int> list;
            if(!map.TryGetValue(B[i], out list)) {
                list = new List<int>();
                map[B[i]] = list;
            }
            list.Add(i);
        }
        Array.Sort(B);

        int[] res = new int[A.Length];

        int l = 0, r = B.Length-1;
        for (int i = 0; i < A.Length; i++)
        {
            int val = 0;

            if(A[i] > B[l])
                val = B[l++];
            else
                val = B[r--];

            List<int> list = map[val];
            int tem = list[0];
            list.RemoveAt(0);
            res[tem] = A[i];
        }
        return res;
    }
}

// 田忌赛马
// 如果A的最小比B的最小小，则A的最小对B的最大
// 如果A的最小比B的最小大，则A的最小对B的最小
// √ Accepted
//   √ 67/67 cases passed (388 ms)
//   √ Your runtime beats 58.82 % of csharp submissions
//   √ Your memory usage beats 7.14 % of csharp submissions (47.9 MB)

