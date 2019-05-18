/*
 * @lc app=leetcode id=875 lang=csharp
 *
 * [875] Koko Eating Bananas

 Koko loves to eat bananas.  There are N piles of bananas, the i-th pile has piles[i] bananas.  The guards have gone and will come back in H hours.

Koko can decide her bananas-per-hour eating speed of K.  Each hour, she chooses some pile of bananas, and eats K bananas from that pile.  If the pile has less than K bananas, she eats all of them instead, and won't eat any more bananas during this hour.

Koko likes to eat slowly, but still wants to finish eating all the bananas before the guards come back.

Return the minimum integer K such that she can eat all the bananas within H hours.

 

Example 1:

Input: piles = [3,6,7,11], H = 8
Output: 4
Example 2:

Input: piles = [30,11,23,4,20], H = 5
Output: 30
Example 3:

Input: piles = [30,11,23,4,20], H = 6
Output: 23
 

Note:

1 <= piles.length <= 10^4
piles.length <= H <= 10^9
1 <= piles[i] <= 10^9
 */
public class Solution {
    public int MinEatingSpeed(int[] piles, int H) {
        Array.Sort(piles);
		int left = 1; // 因为 piles[i] 最小为1
		int right = piles[piles.Length - 1]; // piles 中的最大值经升序排序后，末值为最大值
		while(left < right) {
			int mid = (right - left) / 2 + left;
			int time = 0;
			foreach(int num in piles) {
				if(num % mid != 0) // 如果 除以 中间值 有余，则 time + 1, 
					time++;
				time = time + num / mid; // 如果 num >中间值，则time需要额外+1，小于等于不需要额外+1.
			}
			if(time <= H) // 如果为true，说明mid右边（包括他本身）都能满足，接下来需要往左扩展，找到最小能满足条件的数值，本值有可能会是最小满足条件的数值
				right = mid; // 小于H 说明 mid大了，能够满足条件，但不是最小值，需要往左缩小
			else
				left = mid + 1; // 本值及其左边的都不能满足案例，所以要向右扩展，需要+1,舍弃本值
		}
		return left;
    }


    public int MinEatingSpeed_ER(int[] piles, int H) {
        Array.Sort(piles);

        int left = 1, right = piles[piles.Length-1];

        while (left < right)
        {
            int mid = (right+left)/2;
            int time = 0;
            foreach (var num in piles)
            {
                if(num%mid > 0)
                    time++;

                time += num/mid;
                // time += (int)Math.Ceiling(num*1.0/mid);
            }

            if(time == H)
                return mid;
            if(time < H)
                right = mid-1;
            else
                left = mid+1;
        }
        return left;
    }
}


// √ Accepted
//   √ 113/113 cases passed (160 ms)
//   √ Your runtime beats 29.51 % of csharp submissions
//   √ Your memory usage beats 6 % of csharp submissions (30.8 MB)
