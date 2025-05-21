/*
 * @lc app=leetcode id=206 lang=csharp
 *
 * [206] Reverse Linked List
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head)
    {
        ListNode new_list = null;
        ListNode current = head;        
        if(head == null || head.next == null)    
        {
            return head;
        }
        
        while(current != null)
        {
            /*
            [1,2,3,4] head = 1，current = null
            設置區域變數
            NextNode = current.next;
            current.next = new_list
            new_list = current
            current = NextNode
            */
            ListNode NextNode = current.next;
            current.next = new_list;
            new_list = current;
            current = NextNode;
        }
        return new_list;
    }
}
// @lc code=end

