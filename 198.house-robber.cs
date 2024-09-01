/*
 * @lc app=leetcode id=198 lang=csharp
 *
 * [198] House Robber
 */

// @lc code=start
public class Solution {
    public int Rob(int[] nums)
    {
        //使用一維動態規劃 
        int n = nums.Length;
        int[] dp = new int [n+1];

        dp[0] = 0;
        dp[1] = nums[0];

        for(int i = 2; i <= n; i++)
        {
            dp[i] = Math.Max((dp[i-2]+nums[i-1]), dp[i-1]);
        }
        Console.WriteLine("有跑到這裡");
        return Math.Max(dp[n], dp[n - 1]);    
    }
}
// @lc code=end

