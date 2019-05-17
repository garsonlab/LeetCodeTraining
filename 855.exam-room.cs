/*
 * @lc app=leetcode id=855 lang=csharp
 *
 * [855] Exam Room

 In an exam room, there are N seats in a single row, numbered 0, 1, 2, ..., N-1.

When a student enters the room, they must sit in the seat that maximizes the distance to the closest person.  If there are multiple such seats, they sit in the seat with the lowest number.  (Also, if no one is in the room, then the student sits at seat number 0.)

Return a class ExamRoom(int N) that exposes two functions: ExamRoom.seat() returning an int representing what seat the student sat in, and ExamRoom.leave(int p) representing that the student in seat number p now leaves the room.  It is guaranteed that any calls to ExamRoom.leave(p) have a student sitting in seat p.

 

Example 1:

Input: ["ExamRoom","seat","seat","seat","seat","leave","seat"], [[10],[],[],[],[],[4],[]]
Output: [null,0,9,4,2,null,5]
Explanation:
ExamRoom(10) -> null
seat() -> 0, no one is in the room, then the student sits at seat number 0.
seat() -> 9, the student sits at the last seat number 9.
seat() -> 4, the student sits at the last seat number 4.
seat() -> 2, the student sits at the last seat number 2.
leave(4) -> null
seat() -> 5, the student sits at the last seat number 5.
​​​​​​​

Note:

1 <= N <= 10^9
ExamRoom.seat() and ExamRoom.leave() will be called at most 10^4 times across all test cases.
Calls to ExamRoom.leave(p) are guaranteed to have a student currently sitting in seat number p.
 */
public class ExamRoom {

    private List<int> list;
    private int size;
    public ExamRoom(int N)
    {
        list = new List<int>();
        size = N;
    }

    public int Seat()
    {
        if (list.Count == 0)
        {
            list.Add(0);
            return 0;
        }

        int result = 0, maxLen = list[0];
        //计算相邻两位考生之间的距离，且若距离大于当前的maxLen，应该更新maxLen
        for (int i = 0; i < list.Count - 1; i++)
        {
            int a = list[i], b = list[i + 1];
            if ((b - a) / 2 > maxLen)
            {
                result = (a + b) / 2;
                maxLen = (b - a) / 2;
            }
        }
        if (size - 1 - list[list.Count - 1] > maxLen)
        {
            result = size - 1;
        }
        list.Add(result);
        list.Sort();
        return result;
    }

    public void Leave(int p)
    {
        list.Remove(p);
    }
}

/**
 * Your ExamRoom object will be instantiated and called as such:
 * ExamRoom obj = new ExamRoom(N);
 * int param_1 = obj.Seat();
 * obj.Leave(p);
 */

//  √ Accepted
//   √ 128/128 cases passed (240 ms)
//   √ Your runtime beats 21.15 % of csharp submissions
//   √ Your memory usage beats 10.72 % of csharp submissions (29 MB)

