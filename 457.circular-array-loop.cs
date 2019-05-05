/*
 * @lc app=leetcode id=457 lang=csharp
 *
 * [457] Circular Array Loop

 You are given a circular array nums of positive and negative integers. If a number k at an index is positive, then move forward k steps. Conversely, if it's negative (-k), move backward k steps. Since the array is circular, you may assume that the last element's next element is the first element, and the first element's previous element is the last element.

Determine if there is a loop (or a cycle) in nums. A cycle must start and end at the same index and the cycle's length > 1. Furthermore, movements in a cycle must all follow a single direction. In other words, a cycle must not consist of both forward and backward movements.

 

Example 1:

Input: [2,-1,1,2,2]
Output: true
Explanation: There is a cycle, from index 0 -> 2 -> 3 -> 0. The cycle's length is 3.
Example 2:

Input: [-1,2]
Output: false
Explanation: The movement from index 1 -> 1 -> 1 ... is not a cycle, because the cycle's length is 1. By definition the cycle's length must be greater than 1.
Example 3:

Input: [-2,1,-1,-2,-2]
Output: false
Explanation: The movement from index 1 -> 2 -> 1 -> ... is not a cycle, because movement from index 1 -> 2 is a forward movement, but movement from index 2 -> 1 is a backward movement. All movements in a cycle must follow a single direction.
 

Note:

-1000 ≤ nums[i] ≤ 1000
nums[i] ≠ 0
1 ≤ nums.length ≤ 5000
 

Follow up:

Could you solve it in O(n) time complexity and O(1) extra space complexity?
 */
public class Solution {

    public bool CircularArrayLoop(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            //time  记录循环中元素的个数，用来判断是否满足提议。
            //count 记录一共走了多少步，用来及时跳出循环。
            int count = 0, time = 0;

            if (nums[i] < 0)//向后走
                for (int j = i; count < nums.Length;)
                {
                    if (nums[j] > 0)
                        break;
                    else
                    {
                        int temp = j;
                        j = j + nums[j];
                        count++;
                        while (j < 0)
                            j += nums.Length;
                        if (temp != j)
                            time++;
                    }

                    if (j == i && time > 1)
                        return true;
                }
            else if (nums[i] > 0)
                for (int j = i; count < nums.Length;)
                {
                    if (nums[j] < 0)
                        break;
                    else
                    {
                        int temp = j;
                        j = j + nums[j];
                        count++;

                        while (j >= nums.Length)
                            j -= nums.Length;

                        if (temp != j)
                            time++;
                    }

                    if (j == i && time > 1)
                        return true;
                }
        }
        return false;
    }


    public bool CircularArrayLoop_t1(int[] nums) {
        int len = nums.Length;
        if (len <= 1)
            return false;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                continue;

            int tem = i, count = 0;
            while (nums[tem] != 0)
            {
                if (nums[tem] * nums[i] < 0)//panduan fuhao 
                    break;

                int t = (tem + nums[tem]) % len;
                if(tem != i)
                    nums[tem] = 0;

                tem = (t + len) % len;
                if (tem == i)
                {
                    if(count > 0)
                        return true;
                    else
                        break;
                }

                count++;
            }
            nums[i] = 0;
        }

        return false;
    }
}

// √ Accepted
//   √ 42/42 cases passed (96 ms)
//   √ Your runtime beats 84.62 % of csharp submissions
//   √ Your memory usage beats 25 % of csharp submissions (21.7 MB)

