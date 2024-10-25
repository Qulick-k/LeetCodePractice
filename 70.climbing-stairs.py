#
# @lc app=leetcode id=70 lang=python3
#
# [70] Climbing Stairs
#

# @lc code=start
class Solution:
    def climbStairs(self, n: int) -> int:
        #練習基礎DP還有Memorization
        two = 2
        three = 3
        remainder = 0

        if n == 2:
            return 2
        elif n == 3:
            return 3
        elif n == 1:
            return 1

        for i in range(4,n+1):
            remainder = three + two
            two = three
            three = remainder
            
        return remainder
# @lc code=end

