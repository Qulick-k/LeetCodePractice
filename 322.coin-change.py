#
# @lc app=leetcode id=322 lang=python3
#
# [322] Coin Change
#

# @lc code=start
from typing import List


class Solution:
    def coinChange(self, coins: List[int], amount: int) -> int:
        #練習DP
        dp = [amount + 10] * (amount + 1)
        dp[0] = 0


        for a in range(amount + 1):
            for c in coins:
                if (a-c) >= 0:
                    dp[a] = min(dp[a - c] + 1, dp[a])
        
        return -1 if dp[amount] == amount + 10 else dp[amount]
# @lc code=end

