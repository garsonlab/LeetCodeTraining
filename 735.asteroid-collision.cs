/*
 * @lc app=leetcode id=735 lang=csharp
 *
 * [735] Asteroid Collision

 We are given an array asteroids of integers representing asteroids in a row.

For each asteroid, the absolute value represents its size, and the sign represents its direction (positive meaning right, negative meaning left). Each asteroid moves at the same speed.

Find out the state of the asteroids after all collisions. If two asteroids meet, the smaller one will explode. If both are the same size, both will explode. Two asteroids moving in the same direction will never meet.

Example 1:
Input: 
asteroids = [5, 10, -5]
Output: [5, 10]
Explanation: 
The 10 and -5 collide resulting in 10.  The 5 and 10 never collide.
Example 2:
Input: 
asteroids = [8, -8]
Output: []
Explanation: 
The 8 and -8 collide exploding each other.
Example 3:
Input: 
asteroids = [10, 2, -5]
Output: [10]
Explanation: 
The 2 and -5 collide resulting in -5.  The 10 and -5 collide resulting in 10.
Example 4:
Input: 
asteroids = [-2, -1, 1, 2]
Output: [-2, -1, 1, 2]
Explanation: 
The -2 and -1 are moving left, while the 1 and 2 are moving right.
Asteroids moving the same direction never meet, so no asteroids will meet each other.
Note:

The length of asteroids will be at most 10000.
Each asteroid will be a non-zero integer in the range [-1000, 1000]..
 */
public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        List<int> nums = new List<int>(asteroids);
        List<int> idxs = new List<int>();
        bool changed = true;
        while (changed && nums.Count > 0)
        {
            changed = false;
            for (int i = 1; i < nums.Count; i++)
            {
                if(nums[i] < 0 && nums[i-1] > 0)
                {
                    int o = Math.Abs(nums[i]) - Math.Abs(nums[i-1]);

                    if(o > 0)
                        idxs.Add(i-1);
                    else if(o < 0)
                        idxs.Add(i);
                    else
                    {
                        idxs.Add(i-1);
                        idxs.Add(i);
                    }
                }
            }

            for (int i = idxs.Count-1; i >= 0; i--)
            {
                nums.RemoveAt(idxs[i]);
                changed = true;
            }
            idxs.Clear();
        }
        return nums.ToArray();
    }
}

// √ Accepted
//   √ 275/275 cases passed (276 ms)
//   √ Your runtime beats 47.22 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (32 MB)

