#
# @lc app=leetcode id=268 lang=python3
#
# [268] Missing Number
#

# @lc code=start
from typing import List


class Solution:
    def missingNumber(self, nums: List[int]) -> int:
        #使用XOR
        res = len(nums)
        for i in range(len(nums)):
            res = res ^ (i ^ nums[i])
        return res

'''
        #使用總和的解法
        cur_max = 0
        #找最大
        for i in nums:
            if cur_max < i:
                cur_max = i
        #找最大是不是真的最大，不是的話，代表陣列長才是最大，直接回傳
        if cur_max < len(nums):
            cur_max = len(nums)
            return cur_max
        #找最大總和
        sum_max = 0
        for i in range(cur_max+1):
            sum_max += i
        #找原陣列總和
        sum_nums = 0
        for i in nums:
            sum_nums += i
        #回傳最大總和-原陣列總和的數字，正是解答
        return sum_max - sum_nums
'''
'''
        #使用總和解法的精簡寫法
        res = len(nums)
        for i in range(len(nums)):
            res += (i - nums[i])
        return res
'''
# @lc code=end

