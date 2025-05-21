#
# @lc app=leetcode id=152 lang=python3
#
# [152] Maximum Product Subarray
#

# @lc code=start
from typing import List


class Solution:
    def maxProduct(self, nums: List[int]) -> int:
        #練習動態規劃
        cur_max = 1
        cur_min = 1
        res = nums[0]

        for i in nums:
            temp = cur_max * i
            cur_max = max( i * cur_max, i * cur_min, i)
            cur_min = min( temp, i * cur_min, i)
            res = max(res, cur_max)
        return res
'''
贾考博 https://youtu.be/0Kpz-ChuQIE?si=I3kpND2-y5tWoWIW
NEETCODE https://youtu.be/lXVy6YWFcRM?si=G3-BNGCQuPAkXejz
'''
# @lc code=end

