/*
 * @lc app=leetcode id=435 lang=csharp
 *
 * [435] Non-overlapping Intervals
 */

// @lc code=start
public class Solution {
    public int EraseOverlapIntervals(int[][] intervals)
    {
        //使用Interval，演算法使用貪婪法
        
        //對Interval排序，使用二維升冪
        Array.Sort(intervals, (x, y) => x[0] - y[0]);
        //如果Input: intervals = [[1,2],[1,3],[2,3],[3,4]]
        //temp = 2
        int temp = intervals[0][1];
        int result = 0;
        for (int i = 1; i < intervals.Length; i++)
        {
            ///當temp <= intervals[i][0]
            ///2 <= 1 不符合
            ///2 <= 2 符合
            ///3 <= 3 符合
            if (temp <= intervals[i][0])
            {
                ///temp = 3
                ///temp = 4
                temp = intervals[i][1];
            }
            else
            {
                result++;
                ///temp = 抓最小值(2, 3) == 2
                temp = Math.Min(temp, intervals[i][1]);
            }
        }
        return result;
    }
}
// @lc code=end

/*C#的二維陣列排序寫法
https://blog.csdn.net/qq_22626987/article/details/115469546

https://youtu.be/r7sYCw-3Kdw?si=v_ElewEa_DfMdirv
https://youtu.be/nONCGxWoUfM?si=--1z9YaXxPU80sz8
*/