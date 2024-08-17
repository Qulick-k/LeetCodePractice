/*
 * @lc app=leetcode id=2095 lang=csharp
 *
 * [2095] Delete the Middle Node of a Linked List
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
    public ListNode DeleteMiddle(ListNode head)
    {
        /* 88% 56%
        如果想在鏈結串列刪除一個節點，就必須找到這個節點的前一個節點。
        target's.next = target's.next.next
        [1,2,3,4,5,6,7]，target's的node是1，target's = 1，target's.next = target's.next.next == 2.next == [1,3,4,5,6,7]。所以target's.next的指標目標更新為3，2這個節點就刪掉了

        input = [1,3,4,7,1,2,6]
        1. 如果Head為null，直接回傳null。
        2. 設置prev節點，賦予0這個值，並且把指標指向head，使prev比head還前面。現在input變成[0,1,3,4,7,1,2,6]
        3. 設置slow和fast節點，各賦予prev和head。進迴圈，直到fast的指標指向null之前或是自身變為null之前，slow每次動1個節點，fast每次動2個節點，這樣slow的節點等於1/2的fast節點
        4. 當跳出迴圈後就把slow的下個節點，更新為下下一個節點，這時候中間的節點被刪掉了。slow.next變為[1,2,6]
        5.最後回傳prev.next也就是[1,3,4,1,2,6]
        */

        if(head == null)return null;
        ListNode prev = new ListNode(0);
        prev.next = head;
        ListNode slow = prev;
        ListNode fast = head;
        while(fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        slow.next = slow.next.next; //刪掉
        return prev.next;
    }
}
// @lc code=end

