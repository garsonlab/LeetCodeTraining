/*
 * @lc app=leetcode id=401 lang=csharp
 *
 * [401] Binary Watch
 *
 * https://leetcode.com/problems/binary-watch/description/
 *
 * algorithms
 * Easy (45.10%)
 * Total Accepted:    61.2K
 * Total Submissions: 135.6K
 * Testcase Example:  '0'
 *
 * A binary watch has 4 LEDs on the top which represent the hours (0-11), and
 * the 6 LEDs on the bottom represent the minutes (0-59).
 * Each LED represents a zero or one, with the least significant bit on the
 * right.
 * 
 * For example, the above binary watch reads "3:25".
 * 
 * Given a non-negative integer n which represents the number of LEDs that are
 * currently on, return all possible times the watch could represent.
 * 
 * Example:
 * Input: n = 1Return: ["1:00", "2:00", "4:00", "8:00", "0:01", "0:02", "0:04",
 * "0:08", "0:16", "0:32"]
 * 
 * 
 * Note:
 * 
 * The order of output does not matter.
 * The hour must not contain a leading zero, for example "01:00" is not valid,
 * it should be "1:00".
 * The minute must be consist of two digits and may contain a leading zero, for
 * example "10:2" is not valid, it should be "10:02".
 * 
 * 
 */
public class Solution {
    public IList<string> ReadBinaryWatch(int num) {
        IList<string> list = new List<string>(){};
        if (num <= 0)
        {
            list.Add("0:00");
            return list;
        }

        for (int i = 0; i < 12; i++)
        {
            string h = Convert.ToString(i, 2);
            int n = 0;
            for (int j = 0; j < h.Length; j++)
            {
                if (h[j] == '1')
                    n++;
            }

            if (n == num)
            {
                list.Add(i+":00");
                continue;
            }
            else if(n > num)
                continue;
            
            for (int j = 0; j < 60; j++)
            {
                string m = Convert.ToString(j, 2);
                int n2 = 0;
                for (int k = 0; k < m.Length; k++)
                {
                    if (m[k] == '1')
                        n2++;
                }

                if (n + n2 == num)
                {
                    list.Add(string.Format("{0}:{1:D2}", i, j));
                }
            }
        }

        return list;
    }
}


// √ Accepted
//   √ 10/10 cases passed (244 ms)
//   √ Your runtime beats 83.58 % of csharp submissions
//   √ Your memory usage beats 66.67 % of csharp submissions (29.1 MB)

