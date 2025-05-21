#
# @lc app=leetcode id=567 lang=python3
#
# [567] Permutation in String
#

# @lc code=start
class Solution:
    def checkInclusion(self, s1: str, s2: str) -> bool:
        #練習sliding window和簡易hash table
        #如果字串1長度，比字串2長，代表不可能當字串2的子陣列
        if len(s1)> len(s2):
            return False
        
        #設置兩個陣列，作為簡易的哈希表，長度為a~z aka 0 ~ 25
        s1count = [0] * 26
        s2count = [0] * 26

        #紀錄字串內字母的出現次數
        for i in range(len(s1)):
            s1count[ord(s1[i])-ord('a')] +=1

        #//s1="ab",s2="eidbaooo"
        for i in range(len(s2)):
            if (i >= len(s1)):
                #當i等於2，則s2count[ord(s2[2 - 2]) - ord('a')] == s2count[ord(s2[0]) - ord('a')] == s2count[ord('e') - ord('a')] == {e : 1}
                #因此s2count[ord(s2[2 - 2]) - ord('a')] -= 1 
                #就等於 {e : 1 - 1} == {e : 0}，使得左方索引值歸零
                s2count[ord(s2[i - len(s1)]) - ord('a')] -= 1
            #新增右方索引的value + 1，讓windows滑起來
            #像是當i = 2，s2[ord(s2[i]) - ord('a')] == s2[ord('d') - ord('a')] == {d : 0}
            #則s2[ord(s2[i]) - ord('a')] += 1，等於 {d : 0 + 1} == {d : 1}
            s2count[ord(s2[i]) - ord('a')] += 1
            if s1count == s2count:
                return True 
        return False
#參考https://youtu.be/wpq03MmEHIM?si=1VJ8g6ZKijEbxOWW
# @lc code=end

        """
                if len(s1)> len(s2):
            return False
        
        #設置兩個陣列，作為簡易的哈希表，長度為a~z aka 0 ~ 25
        s1count = [0] * 26
        s2count = [0] * 26

        #紀錄字串內字母的出現次數
        for i in range(len(s1)):
            s1count[ord(s1[i])-ord('a')] +=1
            s2count[ord(s2[i])-ord('a')] +=1

        #//
        """
        """
        for i in range(len(s2) - len(s1)):
            if s1count ==s2count:
                return True 
            s2count[ord(s2[i])-ord('a')] -=1
            s2count[ord(s2[i + len(s1)]) -ord('a')] +=1
        return s1count ==s2count
        """