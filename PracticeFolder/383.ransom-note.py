#
# @lc app=leetcode id=383 lang=python3
#
# [383] Ransom Note
#

# @lc code=start
class Solution:
    def canConstruct(self, ransomNote: str, magazine: str) -> bool:
        #可以使用HASHMAP，不過用陣列的話，也不是不行，+1+1+1-1-1，如果是>=0就回傳true，+1+1-1-1-1，如果是<0就回傳false
        _Note = [0] * 26

        for c in magazine:
            _Note[ord(c) - ord('a')] += 1
        for c in ransomNote:
            _Note[ord(c) - ord('a')] -= 1
        for count in _Note:
            if count < 0:
                return False
        '''
        for i in range(26):
            if (_Note[i] < 0):
                return False
        '''
        return True
# @lc code=end

