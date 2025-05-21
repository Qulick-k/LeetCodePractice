#
# @lc app=leetcode id=198 lang=python3
#
# [198] House Robber
#

# @lc code=start
from typing import List


class Solution:
    def rob(self, nums: List[int]) -> int:
        #Use DP,  Create a dp array and the array's length set it to 0 with len(nums) + 1
        #now we have a dp array like [0, 1 ,0 ,0 ,0], next use a "for loop" Start form dp[2], End to dp[len(nums)]
        #to determine current money and last money, which is bigger
        #Finally return the max(dp[n], dp[n-1])
        dp = [0] * (len(nums) + 1)
        dp[1] = nums[0]

        for i in range(2, len(nums) + 1):
            dp[i] = max(dp[i - 2] + nums[i - 1], dp[i - 1])
        
        return max(dp[len(nums)], dp[len(nums) - 1])
#ref https://youtu.be/k-JYXpHXOcU?si=iOGTLX4pfx4Ywhv6
# @lc code=end

