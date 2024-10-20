#
# @lc app=leetcode id=371 lang=python3
#
# [371] Sum of Two Integers
#

# @lc code=start
class Solution:
    def getSum(self, a: int, b: int) -> int:
        mask = 0xffffffff
        while ((b & mask) != 0):
            temp = (a & b) << 1
            a = a ^ b
            b = temp
        return (a & mask) if b > 0 else a
'''使用內建函數smu()
        res = sum([a, b])

        return res
'''
# @lc code=end

