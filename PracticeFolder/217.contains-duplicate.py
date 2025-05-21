#
# @lc app=leetcode id=217 lang=python3
#
# [217] Contains Duplicate
#

# @lc code=start
from typing import List

class Solution:
    def containsDuplicate(self, nums: List[int]) -> bool:
        # 使用set，如果長度相同，代表沒重複
        # 等同於C#中List<int> nums = new List<int>{1,2,3,1};
        # HashSet<int> _set = new HashSet<int>(nums);
        _set = set(nums)

        if len(nums) == len(_set):
            return False
        else:
            return True
'''
        使用dict的get()函數，等同於C#的ContainsKey()
        hash_map = {}
        for i in nums:
            if hash_map.get(i):
                return True
            else:
                hash_map[i] = 1
        return False
'''
'''
        #使用HASH TABLE 哈希表
        table = {}
        for i in range(len(nums)):
            if nums[i] in table:
                return True
            else:
                table[nums[i]] = 1
        return False
'''
# @lc code=end

