/*
 * @lc app=leetcode id=477 lang=csharp
 *
 * [477] Total Hamming Distance

 The Hamming distance between two integers is the number of positions at which the corresponding bits are different.

Now your job is to find the total Hamming distance between all pairs of the given numbers.

Example:
Input: 4, 14, 2

Output: 6

Explanation: In binary representation, the 4 is 0100, 14 is 1110, and 2 is 0010 (just
showing the four bits relevant in this case). So the answer will be:
HammingDistance(4, 14) + HammingDistance(4, 2) + HammingDistance(14, 2) = 2 + 2 + 2 = 6.
Note:
Elements of the given array are in the range of 0 to 10^9
Length of the array will not exceed 10^4.
 */
public class Solution {
    public int TotalHammingDistance(int[] nums)
        {
            int res = 0, c0 = 0, c1 = 0;
            for (int i = 0; i < 32; i++)
            {
                c0 = 0;
                c1 = 0;
                foreach (var num in nums)
                {
                    if (((num >> i) & 1) > 0)
                        c1++;
                    else
                        c0++;
                }

                res += c0 * c1;
            }

            return res;
        }


    public int TotalHammingDistance_timeOut(int[] nums) {
        int res = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i+1; j < nums.Length; j++)
            {
                res += GetDis(nums[i], nums[j]);
            }
        }
        return res;
    }

    private int GetDis(int a, int b) {
        int v = a^b;
        int count = 0;
        for (int i = 0; i < 32; i++)
        {
            int tem = 1 << i;
            if(tem > v)
                break;
            
            if((tem&v) > 0)
                count++;
        }
        return count;
    }
}



// √ Accepted
//   √ 47/47 cases passed (140 ms)
//   √ Your runtime beats 67.86 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (31.1 MB)
