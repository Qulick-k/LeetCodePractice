#
# @lc app=leetcode id=53 lang=python3
#
# [53] Maximum Subarray
#

# @lc code=start
from typing import List


class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        #使用sliding window、prefix sum
        res = nums[0]
        cur_sum = 0

        for i in nums:
            if (cur_sum < 0): #如果目前總和小於0，把目前總和歸零，代表丟掉會導致負數的數值
                cur_sum = 0
            cur_sum += i
            res = max(res, cur_sum)
        return res
#參考https://youtu.be/5WZl3MMT0Eg?si=I_nZaUAjeIKR5hiN
# @lc code=end

