#
# @lc app=leetcode id=1 lang=python3
#
# [1] Two Sum
#

# @lc code=start
from typing import List
class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        #使用HashMap
        map = {} #key : value
        for i in range(len(nums)):
            #總和的數字，減掉當前的數字，將剩餘的數字放入complement
            complement = target - nums[i]
            if (complement in map):
                return [map[complement], i] #Map有符合的complement，就回傳該complement的索引值和當前的i索引值
            map[nums[i]] = i #如果Map沒有符合的complement，就把當前數字和數字的索引值分別以key和value放進Map內
        return
# @lc code=end

