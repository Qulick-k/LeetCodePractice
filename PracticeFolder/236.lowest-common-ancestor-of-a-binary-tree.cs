/*
 * @lc app=leetcode id=236 lang=csharp
 *
 * [236] Lowest Common Ancestor of a Binary Tree
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        //90% 68%
        /*
        node.val不會重複、p 必定不同於 q、p和q必定存在於樹

        使用DFS，進行遞迴，拜訪二元樹的左邊和右邊

        1. root為null，直接回傳null
        2. root與p或是q相同，直接回傳root
        3. 設置left，再呼叫自己去跑遞迴root的左邊，找後代。再把node交付給left
        4. 設置right，再呼叫自己去跑遞迴root的右邊，找後代。再把node交付給right
        5. 如果左邊跟右邊都不為null，代表兩邊都有後代，回傳root
        6. 又如果左邊不為null，但是右邊為Null，代表後代都在左邊，回傳left
        7. 再如果左邊為null，但是右邊不為null，代表後代都在右邊，回傳right
        8. 其他，也就是左邊跟右邊都是null，回傳null
        */
        if (root == null)
        {
            return null;
        }

        if (root == p || root == q)
        {
            return root;
        }

        TreeNode temp_left = LowestCommonAncestor(root.left, p, q);
        TreeNode temp_right = LowestCommonAncestor(root.right, p, q);
        
        if (temp_left != null && temp_right != null)
        {
            return root;
        }
        else if (temp_left != null && temp_right == null)
        {
            return temp_left;
        }
        else if (temp_left == null && temp_right != null)
        {
            return temp_right;
        }
        else
        {
            return null;
        }
    }
}
// @lc code=end

