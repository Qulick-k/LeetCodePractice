#
# @lc app=leetcode id=121 lang=python3
#
# [121] Best Time to Buy and Sell Stock
#

# @lc code=start
from typing import List
class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        #練習two pointer DP
        left = 0
        right = 1
        res = 0

        while right < len(prices):
            if (prices[left] >= prices[right]):
                left = right
            else:
                res = max(res, (prices[right] - prices[left]))
                print(right)
            right += 1

        return res
# @lc code=end

