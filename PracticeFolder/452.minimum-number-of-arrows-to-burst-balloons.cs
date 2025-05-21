/*
 * @lc app=leetcode id=452 lang=csharp
 *
 * [452] Minimum Number of Arrows to Burst Balloons
 */

// @lc code=start
public class Solution {
    public int FindMinArrowShots(int[][] points)
    {
        //使用Interval
        //先排序二維陣列
        Array.Sort(points, (x, y) => x[0].CompareTo(y[0]));        
        int Arrow = points[0][1];
        int count = 1;
        for (int i = 1; i < points.Length; i++)
        {
            if ( Arrow >= points[i][0])
            {
                Arrow = Math.Min( Arrow, points[i][1]);
            }
            else
            {
                count++;
                Arrow = points[i][1] ;
            }
        }
        return count;
    }
}
// @lc code=end

