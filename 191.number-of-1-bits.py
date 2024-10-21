#
# @lc app=leetcode id=191 lang=python3
#
# [191] Number of 1 Bits
#

# @lc code=start
class Solution:
    def hammingWeight(self, n: int) -> int:
        #練習位元運算嗎? 注意餘數和除數的語法，小心踩坑python的/和//差別
        res = 0        
        while n != 0:
            temp = n
            temp = temp % 2
            if (temp == 1):
                res += 1
            n = n // 2
        return res
# @lc code=end

