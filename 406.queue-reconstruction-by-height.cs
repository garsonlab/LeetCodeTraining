/*
 * @lc app=leetcode id=406 lang=csharp
 *
 * [406] Queue Reconstruction by Height

 Suppose you have a random list of people standing in a queue. Each person is described by a pair of integers (h, k), where h is the height of the person and k is the number of people in front of this person who have a height greater than or equal to h. Write an algorithm to reconstruct the queue.

Note:
The number of people is less than 1,100.


Example

Input:
[[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]

Output:
[[5,0], [7,0], [5,2], [6,1], [4,4], [7,1]]
 */
public class Solution {
    public int[][] ReconstructQueue(int[][] people) {
        if (people.Length <= 1)
            return people;

        Array.Sort(people, (a, b) =>//按照从高到低，序号从小到大排列
        {
            if (a[0] == b[0])
                return a[1] - b[1];
            return b[0] - a[0];
        });

        List<int[]> res = new List<int[]>();
        foreach (var p in people)
        {
            if(p[1] >= res.Count)
                res.Add(p);
            else
                res.Insert(p[1], p);
        }

        return res.ToArray();
    }
}

// √ Accepted
//   √ 37/37 cases passed (312 ms)
//   √ Your runtime beats 12.61 % of csharp submissions
//   √ Your memory usage beats 10 % of csharp submissions (32.4 MB)
