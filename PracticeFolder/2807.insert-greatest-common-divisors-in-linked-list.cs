/*
 * @lc app=leetcode id=2807 lang=csharp
 *
 * [2807] Insert Greatest Common Divisors in Linked List
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
    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        //使用Linked List
        
        if (head.next == null) return head;

        ListNode current = head;

        while (current.next != null)      
        {
            //呼叫求最大公因數的方法
            int G_Common = GreatestCommon(current.val, current.next.val);
            //把目前節點的下一個節點數值更新為最大公因數，然後把舊的下一個節點作為新的下一個節點的下一個節點
            //目前節點為18，下一個節點為6，把目前節點的下一個節點改為18 -> 最大公因數6(同時把這個最大公因數的下一個節點設定為原本18的下一個節點 6)
            current.next = new ListNode(G_Common, current.next);
            current = current.next.next;
        }
        //current新增的節點，同時更新在head的指標內了，LinkedList的特性
        return head;
    }

    //求最大公因數
    public int GreatestCommon(int m, int n)
    {
        //其實可以不用分大小
        //int Big = Math.Max(m, n);
        //int Small = Math.Min(m, n);

        /*while (Small != 0)
        {
            int temp = Big % Small;
            Big = Small;
            Small = temp;
        }*/
        while ( n > 0)
        {
            int temp = m % n;
            m = n;
            n = temp;
        }
        return m;
    }
}
            
        
// @lc code=end

/* 自己寫的 75% / 5%
    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        //使用Linked List
        
        if (head.next == null) return head;

        ListNode current = head;
        ListNode result = current;

        while (current.next != null)      
        {
            //呼叫求最大公因數的方法
            int Front = current.val;
            int Back = current.next.val;
            int G_Common = GreatestCommon(Front, Back);
            
            //把目前節點的下一個節點數值更新為最大公因數，然後把舊的下一個節點作為新的下一個節點的下一個節點
            //目前節點為18，下一個節點為6，把目前節點的下一個節點改為18 -> 最大公因數6(同時把這個最大公因數的下一個節點設定為原本18的下一個節點 6)
            current.next = new ListNode(G_Common, current.next);

            current = current.next.next;

        }

        return result;
    }

    //求最大公因數
    public int GreatestCommon(int m, int n)
    {
        //其實可以不用分大小
        int Big = Math.Max(m, n);
        int Small = Math.Min(m, n);

        while (Small != 0)
        {
            int temp = Big % Small;
            Big = Small;
            Small = temp;
        }

        return Big;
    }
*/