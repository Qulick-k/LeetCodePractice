#
# @lc app=leetcode id=190 lang=python3
#
# [190] Reverse Bits
#

# @lc code=start
class Solution:
    def reverseBits(self, n: int) -> int:
        '''        
        使用format函數轉換數字成32bts 尺寸
        翻轉二進位數字
        使用int函數，把二進位數字轉回十進位數字
        '''
        t = format(n, "032b")
        reverse = t[::-1] 
        return int(reverse, 2)
'''
        #使用位元運算
        
        res = 0

        for i in range(32):
            res = res << 1
            #bit = n % 2
            res += (n % 2)
            n = n >> 1
        return res
'''
# @lc code=end

