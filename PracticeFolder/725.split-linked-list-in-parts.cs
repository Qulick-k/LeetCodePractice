/*
 * @lc app=leetcode id=725 lang=csharp
 *
 * [725] Split Linked List in Parts
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
    public ListNode[] SplitListToParts(ListNode head, int k)
    {
        //使用Linked List   

        //設置ListNode串列
        List<ListNode> result = new List<ListNode>();
        //設置目前的節點
        ListNode current = head;
        //設置節點長度
        int length = 0;

        //只要節點不為NULL，長度+1，並且往下一個節點移動
        while (current != null)
        {
            length++;
            current = current.next;
        }
        
        //要分幾群
        int parted = length / k;   
        //看"餘"多少，代表有多少群要多+1個節點
        int extence = length % k;
        //重置目前節點為head
        current = head;

        //訪問k次
        for (int i = 0; i < k; i++)
        {        
            //每一輪都把根節點放進串列    
            result.Add(current);
            //設置number查看之後的J迴圈要移動幾次節點
            //i小於餘數，number就1+parted
            int number = parted + (i < extence ? 1 : 0);

            //移動節點number-1次，並且需要在current不為null時進行。
            for (int j = 0; (j < number - 1) && (current != null); j++)
            {
                current = current.next;
            }

            //如果current不為空，則將目前節點與下一個節點斷開，但必須把下一個節點放回進current
            if (current != null)
            {
                //把目前節點的下一個節點交給temp。
                //current等於A -> B -> C ，B交給temp，temp等於B -> C
                ListNode temp = current.next;
                //在把目前節點的下一個節點設為null
                //current等於 A -> null
                current.next = null;
                //把current重新賦予temp
                //current 等於 B -> C
                current = temp;           
            }     
        }

        return result.ToArray();
    }
}
// @lc code=end

