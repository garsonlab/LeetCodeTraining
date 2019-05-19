/*
 * @lc app=leetcode id=885 lang=csharp
 *
 * [885] Spiral Matrix III

 On a 2 dimensional grid with R rows and C columns, we start at (r0, c0) facing east.

Here, the north-west corner of the grid is at the first row and column, and the south-east corner of the grid is at the last row and column.

Now, we walk in a clockwise spiral shape to visit every position in this grid. 

Whenever we would move outside the boundary of the grid, we continue our walk outside the grid (but may return to the grid boundary later.) 

Eventually, we reach all R * C spaces of the grid.

Return a list of coordinates representing the positions of the grid in the order they were visited.

 

Example 1:

Input: R = 1, C = 4, r0 = 0, c0 = 0
Output: [[0,0],[0,1],[0,2],[0,3]]


 

Example 2:

Input: R = 5, C = 6, r0 = 1, c0 = 4
Output: [[1,4],[1,5],[2,5],[2,4],[2,3],[1,3],[0,3],[0,4],[0,5],[3,5],[3,4],[3,3],[3,2],[2,2],[1,2],[0,2],[4,5],[4,4],[4,3],[4,2],[4,1],[3,1],[2,1],[1,1],[0,1],[4,0],[3,0],[2,0],[1,0],[0,0]]


 

Note:

1 <= R <= 100
1 <= C <= 100
0 <= r0 < R
0 <= c0 < C
 */
public class Solution {
    public int[][] SpiralMatrixIII(int R, int C, int r0, int c0) {
        List<int[]> res = new List<int[]>();
        
        int count = 1, time = 2;
        int east = 1, south = 0, western = 0, north = 0 ;
        int sum = 0;
        while( sum < R * C) {
            
            while( time-- > 0){
                int temp = count;
                while( temp-- > 0){
                    
                    if( r0 > -1 && r0 < R && c0 > -1 && c0 < C) {
                        res.Add(new []{r0, c0});
                        sum++;
                    }

                    if( east > 0 ) {
                        r0 = r0;
                        c0 = c0 + 1;
                    }
                    else if( south > 0 ) {
                        r0 = r0 +1;
                        c0 = c0;
                    }
                    else if( western > 0 ) {
                        r0 = r0;
                        c0 = c0 - 1;
                    }
                    else if( north > 0 ) {
                        r0 = r0 - 1;
                        c0 = c0;
                    }
                }
                
                if( east > 0 ) {
                    east = 0;
                    south = 1;
                }
                else if( south > 0 ) {
                    south = 0;
                    western = 1;
                }
                else if( western > 0 ) {
                    western = 0;
                    north = 1;
                }
                else if( north > 0 ) {
                    north = 0;
                    east = 1;
                }
            }
            time = 2;
            count++;
        }
        return res.ToArray();
    }
}

// √ Accepted
//   √ 73/73 cases passed (252 ms)
//   √ Your runtime beats 46.94 % of csharp submissions
//   √ Your memory usage beats 6.9 % of csharp submissions (30.1 MB)

