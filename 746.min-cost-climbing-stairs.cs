/*
 * @lc app=leetcode id=746 lang=csharp
 *
 * [746] Min Cost Climbing Stairs
 */

// @lc code=start
public class Solution {
    public int MinCostClimbingStairs(int[] cost)
    {
        //一維動態規劃
        int[] dp = new int[cost.Length];
        dp[0] = cost[0];
        dp[1] = cost[1];

        for (int i = 2; i < cost.Length; i++)
        {
            dp[i] = Math.Min(dp[i-1], dp[i-2]) + cost[i];
        }
        return Math.Min(dp[cost.Length-1], dp[cost.Length-2]);
    }
}
// @lc code=end

