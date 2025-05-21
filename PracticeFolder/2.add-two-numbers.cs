/*
 * @lc app=leetcode id=2 lang=csharp
 *
 * [2] Add Two Numbers
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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        //Linked List
        //設置dummy鏈結、設置current作為dummy的移動鏈結
        ListNode dummy = new ListNode(-1);
        ListNode current = dummy;

        //需要進位的數字
        int carry = 0;

        //只要其中一個鏈結不為空
        while ( l1 != null || l2 != null )
        {
            //計算目前數字
            int temp1 = l1 == null ? 0 : l1.val;
            int temp2 = l2 == null ? 0 : l2.val;
            //算總和，並且更新carry
            int sum = temp1 + temp2 + carry;
            current.next = new ListNode(sum % 10);
            carry = sum / 10;

            //移動到下一個節點
            current = current.next;

            if ( l1 != null )
            {
                l1 = l1.next;
            }
            if ( l2 != null )
            {
                l2 = l2.next;
            }
        }
        //在最後面時，carry可能不為0，需要記得最後進位
        if (carry != 0)
        {
            current.next = new ListNode(carry);
        }
        //回傳dummy下一個節點之後的鏈結
        return dummy.next;
    }
}
// @lc code=end

