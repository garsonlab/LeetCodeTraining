/*
 * @lc app=leetcode id=551 lang=csharp
 *
 * [551] Student Attendance Record I
 *
 * https://leetcode.com/problems/student-attendance-record-i/description/
 *
 * algorithms
 * Easy (45.15%)
 * Total Accepted:    48.8K
 * Total Submissions: 108.1K
 * Testcase Example:  '"PPALLP"'
 *
 * You are given a string representing an attendance record for a student. The
 * record only contains the following three characters:
 * 
 * 
 * 
 * 'A' : Absent. 
 * 'L' : Late.
 * ⁠'P' : Present. 
 * 
 * 
 * 
 * 
 * A student could be rewarded if his attendance record doesn't contain more
 * than one 'A' (absent) or more than two continuous 'L' (late).    
 * 
 * You need to return whether the student could be rewarded according to his
 * attendance record.
 * 
 * Example 1:
 * 
 * Input: "PPALLP"
 * Output: True
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: "PPALLL"
 * Output: False
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public bool CheckRecord(string s) {
        int an = 0;
        int ln = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'A')
            {
                ln = 0;
                if (++an > 1)
                    return false;
            }
            else if (s[i] == 'L')
            {
                if (++ln > 2)
                    return false;
            }
            else
            {
                ln = 0;
            }
        }

        return true;
    }
}

// √ Accepted
//   √ 113/113 cases passed (72 ms)
//   √ Your runtime beats 97.75 % of csharp submissions
//   √ Your memory usage beats 40 % of csharp submissions (20.1 MB)

