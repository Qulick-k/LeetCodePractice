/*
 * @lc app=leetcode id=2130 lang=csharp
 *
 * [2130] Maximum Twin Sum of a Linked List
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
    public int PairSum(ListNode head)
    {
        //透過slow，找到鏈結的中間值
        ListNode Fast = head;
        ListNode Slow = head;
        while (Fast != null && Fast.next != null && Fast.next.next != null)
        {
            Slow = Slow.next;
            Fast = Fast.next.next;
        }
        
        //slow下一個節點的value賦予給next_list，之後把next_list鏈結反轉，呼叫Reverse()方法
        ListNode next_list = Slow.next; 
        Slow.next = null;
        ListNode temp_list = Reverse(next_list);

        //後半部翻轉過的鏈結temp_list，賦予給another_temp_for_templist
        //設置int result放目前相加的最大值
        //接著前半部的鏈結和後半部的鏈結相加，互相比較大小，大的數值做為result的值
        ListNode another_temp_for_templist = temp_list;
        int result = 0;
        while (another_temp_for_templist != null && head != null)
        {
            result = Math.Max((head.val + another_temp_for_templist.val), result);
            head = head.next;
            another_temp_for_templist = another_temp_for_templist.next;
        }

        //跑完回傳結果
        return result;  
    }

    public ListNode Reverse(ListNode head)
    {
        ListNode Prev = null;
        while (head != null)
        {
            ListNode nextNode = head.next;
            head.next = Prev;
            Prev = head;
            head = nextNode;
        }
        return Prev;
    }
}
// @lc code=end

