#
# @lc app=leetcode id=238 lang=python3
#
# [238] Product of Array Except Self
#

# @lc code=start
from typing import List
class Solution:
    def productExceptSelf(self, nums: List[int]) -> List[int]:
        #複習two pointer
        #分成abc三個部分，left代表c，right代表a
        left_sum = 1
        right_sum = 1
        res = [0] * len(nums)
        for i in range(len(nums)):
            res[i] = left_sum 
            left_sum *= nums[i]
        
        for i in range(len(nums)-1, -1, -1):
            res [i] *= right_sum
            right_sum *= nums[i]
        return res
# @lc code=end

