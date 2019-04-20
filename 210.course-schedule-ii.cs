/*
 * @lc app=leetcode id=210 lang=csharp
 *
 * [210] Course Schedule II
 *
 * https://leetcode.com/problems/course-schedule-ii/description/
 *
 * algorithms
 * Medium (34.26%)
 * Total Accepted:    140.5K
 * Total Submissions: 409K
 * Testcase Example:  '2\n[[1,0]]'
 *
 * There are a total of n courses you have to take, labeled from 0 to n-1.
 * 
 * Some courses may have prerequisites, for example to take course 0 you have
 * to first take course 1, which is expressed as a pair: [0,1]
 * 
 * Given the total number of courses and a list of prerequisite pairs, return
 * the ordering of courses you should take to finish all courses.
 * 
 * There may be multiple correct orders, you just need to return one of them.
 * If it is impossible to finish all courses, return an empty array.
 * 
 * Example 1:
 * 
 * 
 * Input: 2, [[1,0]] 
 * Output: [0,1]
 * Explanation: There are a total of 2 courses to take. To take course 1 you
 * should have finished   
 * course 0. So the correct course order is [0,1] .
 * 
 * Example 2:
 * 
 * 
 * Input: 4, [[1,0],[2,0],[3,1],[3,2]]
 * Output: [0,1,2,3] or [0,2,1,3]
 * Explanation: There are a total of 4 courses to take. To take course 3 you
 * should have finished both     
 * ⁠            courses 1 and 2. Both courses 1 and 2 should be taken after you
 * finished course 0. 
 * So one correct course order is [0,1,2,3]. Another correct ordering is
 * [0,2,1,3] .
 * 
 * Note:
 * 
 * 
 * The input prerequisites is a graph represented by a list of edges, not
 * adjacency matrices. Read more about how a graph is represented.
 * You may assume that there are no duplicate edges in the input
 * prerequisites.
 * 
 * 
 */
public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        List<int> ret = new List<int>();
        List<int>[] dics = new List<int>[numCourses];
        foreach (var prerequisite in prerequisites)
        {
            if (dics[prerequisite[0]] == null)
                dics[prerequisite[0]] = new List<int>();
            dics[prerequisite[0]].Add(prerequisite[1]);
        }


        int[] course = new int[numCourses];
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < numCourses; i++)
        {
            if (course[i] != 0)
                continue;

            stack.Clear();
            stack.Push(i);

            while (stack.Count > 0)
            {
                var c = stack.Peek();
                if (dics[c] == null)
                {
                    course[c] = 1;
                    stack.Pop();
                    ret.Add(c);
                    continue;
                }

                bool add = false;
                foreach (var n in dics[c])
                {
                    if (course[n] == 1)
                        continue;

                    if (stack.Contains(n))
                        return new int[0];

                    stack.Push(n);
                    add = true;
                }

                if (!add)
                {
                    while (stack.Count > 0)
                    {
                        var a = stack.Pop();
                        ret.Add(a);
                        course[a] = 1;
                    }
                }
            }
        }

        return ret.ToArray();
    }
}

