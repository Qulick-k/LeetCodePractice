/*
 * @lc app=leetcode id=700 lang=csharp
 *
 * [700] Search in a Binary Search Tree
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode SearchBST(TreeNode root, int val)
    {
        /*
        10% 74%
        二元搜尋樹，root的左方節點.val必定比root.val還小，同樣地，root的右方節點.val必定比root.val大
        因此如果root為null或是root.val等於val，就回傳root
        如果都沒有，那就看看root有沒有比目標數值大，大的話，就往小的地方也就是左方節點遞迴；小的話，就往大的地方也就是右方節點遞迴
        */
        if (root == null)
        {
            return root;
        }

        if (root.val == val)
        {
            return root;
        }
        
        if(root.val > val)  //當root節點大於target數值的話，進入遞迴往左方節點看
        {
            return SearchBST(root.left, val);
        }
        else                //當root節點小於target數值的話，進入遞迴往右方節點看
        {
            return SearchBST(root.right, val);
        }
    }
}
// @lc code=end

