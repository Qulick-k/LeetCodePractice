/*
 * @lc app=leetcode id=2326 lang=csharp
 *
 * [2326] Spiral Matrix IV
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
    public int[][] SpiralMatrix(int m, int n, ListNode head)
    {
        //使用Linked List

        //先把不規則陣列賦予-1
        int[][] result = new int[m][];        
        
        for (int i = 0; i < m; i++)    
        {
            result[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                result[i][j] = -1;
            }
        }

        //設置一個目前節點
        ListNode current = head;
        //設置該往哪個方向
        bool right = true;
        bool down = false;
        bool left = false;
        bool up = false;

        //設置起點是現在的節點，並且指標指向下一個節點
        result[0][0] = current.val;
        current = current.next;

        //如果二維陣列就只有1，直接回傳
        if (m == 1 && n == 1)
        {
            return result;
        }

        //如果橫列只有1，方向改成下
        if (n == 1 )
        {
            right = false;
            down = true;
        }

        //設置直行橫列數
        int row = 0;
        int col = 0;

        //如果目前節點不為null
        while (current != null)
        {
            //當目前該往右邊看
            if (right == true)
            {                
                //就看col+1後會不會超過陣列長度，OK的話，再看往右看的陣列是不是-1，是-1的話才可以放
                if( col +1 != n && result[row][col+1] == -1 )
                {
                    result[row][col+1] = current.val;
                    col++;
                    current = current.next;
                    continue;
                }
                else
                {
                    right = false;
                    down = true;
                }
            }

            if (down == true)
            {
                if( row +1 != m && result[row+1][col] == -1)
                {
                    result[row+1][col] = current.val;
                    row++;
                    current = current.next;
                    continue;
                }
                else
                {
                    down = false;
                    left = true;
                }
            }

            if (left == true)
            {
                if ( col -1 >= 0 && result[row][col-1] == -1)
                {
                    result[row][col-1] = current.val;
                    col--;
                    current = current.next;
                    continue;
                }
                else
                {
                    left = false;
                    up = true;
                }
            }

            if (up == true)
            {
                if ( row -1 >= 0 && result[row-1][col] == -1)
                {
                    result[row-1][col] = current.val;
                    row--;
                    current = current.next;
                    continue;
                }
                else
                {
                    up = false;
                    right = true;
                }
            }
        }

        return result;
    }
}
// @lc code=end

