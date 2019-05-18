/*
 * @lc app=leetcode id=881 lang=csharp
 *
 * [881] Boats to Save People

 The i-th person has weight people[i], and each boat can carry a maximum weight of limit.

Each boat carries at most 2 people at the same time, provided the sum of the weight of those people is at most limit.

Return the minimum number of boats to carry every given person.  (It is guaranteed each person can be carried by a boat.)

 

Example 1:

Input: people = [1,2], limit = 3
Output: 1
Explanation: 1 boat (1, 2)
Example 2:

Input: people = [3,2,2,1], limit = 3
Output: 3
Explanation: 3 boats (1, 2), (2) and (3)
Example 3:

Input: people = [3,5,3,4], limit = 5
Output: 4
Explanation: 4 boats (3), (3), (4), (5)
Note:

1 <= people.length <= 50000
1 <= people[i] <= limit <= 30000
 */
public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        Array.Sort(people);
        int i = 0, j = people.Length-1, res = 0;
        while (i <= j)
        {
            var reserve = limit-people[j];
            if(reserve >= people[i])
                i++;
            j--;
            res++;
        }
        return res;
    }
}


// √ Accepted
//   √ 77/77 cases passed (224 ms)
//   √ Your runtime beats 41.59 % of csharp submissions
//   √ Your memory usage beats 62.2 % of csharp submissions (36.3 MB)
