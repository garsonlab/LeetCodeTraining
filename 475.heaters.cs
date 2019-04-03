/*
 * @lc app=leetcode id=475 lang=csharp
 *
 * [475] Heaters
 *
 * https://leetcode.com/problems/heaters/description/
 *
 * algorithms
 * Easy (31.32%)
 * Total Accepted:    45.3K
 * Total Submissions: 144.2K
 * Testcase Example:  '[1,2,3]\n[2]'
 *
 * Winter is coming! Your first job during the contest is to design a standard
 * heater with fixed warm radius to warm all the houses.
 * 
 * Now, you are given positions of houses and heaters on a horizontal line,
 * find out minimum radius of heaters so that all houses could be covered by
 * those heaters.
 * 
 * So, your input will be the positions of houses and heaters seperately, and
 * your expected output will be the minimum radius standard of heaters.
 * 
 * Note:
 * 
 * 
 * Numbers of houses and heaters you are given are non-negative and will not
 * exceed 25000.
 * Positions of houses and heaters you are given are non-negative and will not
 * exceed 10^9.
 * As long as a house is in the heaters' warm radius range, it can be
 * warmed.
 * All the heaters follow your radius standard and the warm radius will the
 * same.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [1,2,3],[2]
 * Output: 1
 * Explanation: The only heater was placed in the position 2, and if we use the
 * radius 1 standard, then all the houses can be warmed.
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [1,2,3,4],[1,4]
 * Output: 1
 * Explanation: The two heater was placed in the position 1 and 4. We need to
 * use radius 1 standard, then all the houses can be warmed.
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int FindRadius(int[] houses, int[] heaters)
    {
        List<int> list = new List<int>(heaters);
        list.Sort();
        int radius = 0;
        for (int i = 0; i < houses.Length; i++)
        {
            int cur = GetMinRadius(list, 0, heaters.Length - 1, houses[i]);
            if (cur > radius)
                radius = cur;
        }

        return radius;
    }

    private int GetMinRadius(List<int> heaters, int start, int end, int house)
    {
        if (end - start <= 2)
        {
            int min = int.MaxValue;
            for (int i = start; i <= end; i++)
            {
                if (Math.Abs(heaters[i] - house) < min)
                    min = Math.Abs(heaters[i] - house);
            }

            return min;
        }

        int mid = (start + 1) / 2 + end / 2;
        if (heaters[mid] == house)
            return 0;
        else if (heaters[mid] > house)
            return GetMinRadius(heaters, start, mid, house);
        else
            return GetMinRadius(heaters, mid, end, house);
    }

    //超时
    public int FindRadius3(int[] houses, int[] heaters)
    {
        int radius = 0;
        for (int i = 0; i < houses.Length; i++)
        {
            int cur = int.MaxValue;
            for (int j = 0; j < heaters.Length; j++)
            {
                int dis = Math.Abs(heaters[j] - houses[i]);
                if (dis < cur)
                    cur = dis;
            }

            if (cur > radius)
                radius = cur;
        }

        return radius;
    }

    //理解有问题，以为是房间号乱序且相邻
    public int FindRadius2(int[] houses, int[] heaters) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < heaters.Length; i++)
        {
            dic[heaters[i]] = 0;
        }

        int radius = 0;
        int preH = -1;
        for (int i = 0; i < houses.Length; i++)
        {
            if (dic.ContainsKey(houses[i]))
            {
                if (preH < 0)
                {
                    preH = i;
                    radius = i > 0 ? i - 1 : 0;
                }
                else
                {
                    int r = (i - preH) / 2;
                    if (r > radius)
                        radius = r;
                    preH = i;
                }
            }
        }

        int last = houses.Length - preH - 1;
        if (last > radius)
            radius = last;

        return radius;
    }
}

// √ Accepted
//   √ 30/30 cases passed (156 ms)
//   √ Your runtime beats 63.08 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (33.4 MB)

