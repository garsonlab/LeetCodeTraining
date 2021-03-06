/*
 * @lc app=leetcode id=599 lang=csharp
 *
 * [599] Minimum Index Sum of Two Lists
 *
 * https://leetcode.com/problems/minimum-index-sum-of-two-lists/description/
 *
 * algorithms
 * Easy (47.41%)
 * Total Accepted:    52.9K
 * Total Submissions: 111.3K
 * Testcase Example:  '["Shogun","Tapioca Express","Burger King","KFC"]\n["Piatti","The Grill at Torrey Pines","Hungry Hunter Steakhouse","Shogun"]'
 *
 * 
 * Suppose Andy and Doris want to choose a restaurant for dinner, and they both
 * have a list of favorite restaurants represented by strings. 
 * 
 * 
 * You need to help them find out their common interest with the least list
 * index sum. If there is a choice tie between answers, output all of them with
 * no order requirement. You could assume there always exists an answer.
 * 
 * 
 * 
 * Example 1:
 * 
 * Input:
 * ["Shogun", "Tapioca Express", "Burger King", "KFC"]
 * ["Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse",
 * "Shogun"]
 * Output: ["Shogun"]
 * Explanation: The only restaurant they both like is "Shogun".
 * 
 * 
 * 
 * Example 2:
 * 
 * Input:
 * ["Shogun", "Tapioca Express", "Burger King", "KFC"]
 * ["KFC", "Shogun", "Burger King"]
 * Output: ["Shogun"]
 * Explanation: The restaurant they both like and have the least index sum is
 * "Shogun" with index sum 1 (0+1).
 * 
 * 
 * 
 * 
 * Note:
 * 
 * The length of both lists will be in the range of [1, 1000].
 * The length of strings in both lists will be in the range of [1, 30].
 * The index is starting from 0 to the list length minus 1.
 * No duplicates in both lists.
 * 
 * 
 */
public class Solution {
    public string[] FindRestaurant(string[] list1, string[] list2) {
        List<string> list = new List<string>();
        Dictionary<string, int> dic = new Dictionary<string, int>();
        for (int i = 0; i < list1.Length; i++)
        {
            dic.Add(list1[i], i);
        }

        int min = int.MaxValue;
        for (int i = 0; i < list2.Length; i++)
        {
            int idx;
            if (dic.TryGetValue(list2[i], out idx))
            {
                if (idx + i < min)
                {
                    list.Clear();
                    list.Add(list2[i]);
                    min = idx + i;
                }
                else if(idx+i == min)
                {
                    list.Add(list2[i]);
                }
            }
        }

        return list.ToArray();
    }
}


// √ Accepted
//   √ 133/133 cases passed (312 ms)
//   √ Your runtime beats 96.69 % of csharp submissions
//   √ Your memory usage beats 21.43 % of csharp submissions (41.2 MB)
