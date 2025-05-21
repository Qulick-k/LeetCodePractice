#
# @lc app=leetcode id=206 lang=python3
#
# [206] Reverse Linked List
#

# @lc code=start
# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution:
    def reverseList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        #練習鏈結串列
        '''
        設置一個new_list節點，設置一個當前節點並給他head節點
        每循環一次，就設置一次nextnode節點，並給他current.next節點
        current.next節點，瞄準到new_list上
        new_list節點，被賦予到current節點
        current節點，被賦予nextNode節點
        以上while迴圈結束，return new_list即可獲得"反轉鏈結串列"
        '''
        new_list = None
        current = head
        if (head is None or head.next is None):
            return head

        while(current is not None):
            nextNode = current.next
            current.next = new_list
            new_list = current
            current = nextNode
        
        return new_list
        
# @lc code=end

