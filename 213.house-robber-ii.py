#
# @lc app=leetcode id=213 lang=python3
#
# [213] House Robber II
#

# @lc code=start
from typing import List


class Solution:
    def rob(self, nums: List[int]) -> int:
        #Use DP, Although the house are arranged in circle, the first house and last house are adjacent
        #Here is second solution, so we create a new function name it robber, use nums for paramater
        #Set two variable rob1, rob2 = 0, 0. Then dive into "nums" for loop, 
        #give a local variable "newRob" to check  whether is current rob (rob1 + n) or last rob (rob2) which is bigger
        #next rob2  give value to rob1, and newRob give value to rob2
        #After all return rob2
        #Back to the main function rob(), Finally we can just return max(nums[0], self.robber(nums[:-1]), self.robber(nums[1:]))
        #p.s If nums=[2,3,2], nums[:-1] == [2,3], nums[1:] == [3,2]
        return max(nums[0], self.robber(nums[:-1]), self.robber(nums[1:]))
    
    def robber(self, nums):
        rob1 = 0
        rob2 = 0
        for n in nums:
            newRob = max(rob1 + n, rob2)
            rob1 = rob2
            rob2 = newRob
        return rob2
#Second solution ref https://youtu.be/rWAJCfYYOvM?si=yri8NGcPbyNSC95Y
        '''
        #Use DP, Although the house are arranged in circle, the first house and last house are adjacent
        #Assume there are 4 houese, the first solution is to separetly consider houses 1 ~ 3 And housee 2 ~ 4
        def robber(start, end):
            dp = [0] * (end - start + 1)
            print(start)
            dp[0] = nums[start]
            dp[1] = max(nums[start], nums[start + 1])

            for i in range(2, len(dp)):
                dp[i] = max(dp[i - 2] + nums[start + i], dp[i - 1])
            
            return max(dp[len(dp) - 2], dp[len(dp) - 1])
        
        if len(nums) == 1: return nums[0]
        if len(nums) == 2: return max(nums[0], nums[1])
        res1 = robber(0, len(nums) - 2)
        res2 = robber(1, len(nums) - 1)
        return max(res1, res2)
        #First solution ref https://youtu.be/rWAJCfYYOvM?si=hcRYGdrcWA-Rd-1l
        '''
# @lc code=end

