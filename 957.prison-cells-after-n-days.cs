/*
 * @lc app=leetcode id=957 lang=csharp
 *
 * [957] Prison Cells After N Days
 There are 8 prison cells in a row, and each cell is either occupied or vacant.

Each day, whether the cell is occupied or vacant changes according to the following rules:

If a cell has two adjacent neighbors that are both occupied or both vacant, then the cell becomes occupied.
Otherwise, it becomes vacant.
(Note that because the prison is a row, the first and the last cells in the row can't have two adjacent neighbors.)

We describe the current state of the prison in the following way: cells[i] == 1 if the i-th cell is occupied, else cells[i] == 0.

Given the initial state of the prison, return the state of the prison after N days (and N such changes described above.)

 

Example 1:

Input: cells = [0,1,0,1,1,0,0,1], N = 7
Output: [0,0,1,1,0,0,0,0]
Explanation: 
The following table summarizes the state of the prison on each day:
Day 0: [0, 1, 0, 1, 1, 0, 0, 1]
Day 1: [0, 1, 1, 0, 0, 0, 0, 0]
Day 2: [0, 0, 0, 0, 1, 1, 1, 0]
Day 3: [0, 1, 1, 0, 0, 1, 0, 0]
Day 4: [0, 0, 0, 0, 0, 1, 0, 0]
Day 5: [0, 1, 1, 1, 0, 1, 0, 0]
Day 6: [0, 0, 1, 0, 1, 1, 0, 0]
Day 7: [0, 0, 1, 1, 0, 0, 0, 0]
Example 2:

Input: cells = [1,0,0,1,0,0,1,0], N = 1000000000
Output: [0,0,1,1,1,1,1,0]
 

Note:

cells.length == 8
cells[i] is in {0, 1}
1 <= N <= 10^9
 */
public class Solution {
    public int[] PrisonAfterNDays(int[] cells, int N) {
        int d = 0;
        for (int i = 0; i < 8; i++)
        {
            d = (d << 1) + cells[i];
        }

        List<int[]> cellList = new List<int[]>();
        List<int> valList = new List<int>();

        for (int i = 1; i <= N; i++)
        {
            cells = ChangeCells(cells);
            int v = List2Num(cells);

            if (i == N)
                return cells;
            if (!valList.Contains(v))
            {
                cellList.Add(cells);
                valList.Add(v);
            }
            else
            {
                return cellList[(N - 1) % valList.Count];
            }
        }

        return null;
    }

    private int List2Num(int[] cells)
    {
        int res = 0;
        for (int i = 0; i < 8; i++)
        {
            res = (res << 1) + cells[i];
        }

        return res;
    }

    private int[] ChangeCells(int[] cells)
    {
        int[] tem = new int[8];
        for (int i = 1; i < 7; i++)
        {
            tem[i] = cells[i - 1] == cells[i + 1] ? 1 : 0;
        }

        return tem;
    }

}

// √ Accepted
//   √ 258/258 cases passed (284 ms)
//   √ Your runtime beats 9.2 % of csharp submissions
//   √ Your memory usage beats 38.33 % of csharp submissions (29.3 MB)

