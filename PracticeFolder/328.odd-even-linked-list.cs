/*
 * @lc app=leetcode id=328 lang=csharp
 *
 * [328] Odd Even Linked List
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
    public ListNode OddEvenList(ListNode head) {
        //80% 98%

        //如果Head是空值，或是head的下一個節點是空值，直接回傳
        if (head == null || head.next == null)
        {
            return head;
        }
        /*
        鏈結總共兩個，一個是原本的head，第二個是EvenHead
        設置兩個變數OddNode和EvenNode
        OddNode 改成指向 原本下個節點 的下一個節點 OddNode.next.next或是EvenNode.next
        EvenNode 改成指向 原本下個節點 的下一個節點 EvenNode.next.next或是OddNode.next
        每次幫oddNode跟evenNode指向正確的節點後, 我們將會繼續同樣的動作直到oddNode或evenNode的下個節點已是空值
        */
        ListNode EvenHead = head.next;
        ListNode EvenNode = EvenHead;
        ListNode OddNode = head;
        while (OddNode.next != null && EvenNode.next != null)
        {
            //[1,2,3,4,5]
            
            OddNode.next = OddNode.next.next;
            OddNode = OddNode.next;
            EvenNode.next = EvenNode.next.next;
            EvenNode = EvenNode.next;
            
        }
        //假設input是[1,2,3,4,5]
        //那麼計算完後，目前的head是[1,3,5]，而EvenHead是[2,4]
        //最後把OddNode的next接在EvenHead頭上
        OddNode.next = EvenHead;
        return head;
    }
}
// @lc code=end

