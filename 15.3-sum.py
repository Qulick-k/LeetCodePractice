#
# @lc app=leetcode id=15 lang=python3
#
# [15] 3Sum
#

# @lc code=start
from typing import List


class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        #使用two pointer、升階sort
        res = []
        nums.sort()
        #先取一個start，剩下的差值，再多設置左索引跟右索引去判斷，start + [左索引] + [右索引]是不是等於3sum
        #因為題目要求重複的子陣列要去除，所以排序過後的nums陣列，在下一個索引處，遇到已經使用過且與上一個索引處相同的數值，必須把該數值跳過
        for i in range(len(nums)):
            start = nums[i]
            if (i > 0 and start == nums[i - 1]):
                continue
            left = i + 1
            right = len(nums) - 1

            while (left < right):
                three_sum = start + nums[left] + nums[right]

                if (three_sum == 0):
                    res.append([start, nums[left], nums[right]])
                    left += 1
                    #誠如題目要求，重複的子陣列要去除，所以在下一個左索引處遇到已經使用過且與上一個左索引處相同的數值時，必須把該數值跳過
                    while (nums[left] == nums[left - 1] and left < right):
                        left += 1
                elif (three_sum > 0):
                    right -= 1
                else:
                    left += 1
        return res
'''45/313 cases passed 卡在無法把重複數值挑出來
        res = []

        for i in range(len(nums)):
            start = nums[i]
            left = i + 1
            right = left + 1

            while (left < len(nums) - 1):
                if (start + nums[left] + nums[right]) == 0:
                    res.append([start, nums[left], nums[right]])
                        
                right += 1
                
                if (right == len(nums)):
                        left += 1
                        right = left + 1        
        return res
Testcase
[-1,0,1,2,-1,-4]
Answer
[[-1,0,1],[-1,2,-1],[0,1,-1]]
Expected Answer
[[-1,-1,2],[-1,0,1]]
'''
# @lc code=end

