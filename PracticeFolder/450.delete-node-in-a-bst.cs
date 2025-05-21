/*
 * @lc app=leetcode id=450 lang=csharp
 *
 * [450] Delete Node in a BST
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
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        //11% 86%
        /*
        二元樹的左方節點必定小於右方節點
        左方節點 < 根節點 < 右方節點

        當root為空，回傳root
        當key小於root.val，往左找
        又當key大於root.val，往右找
        最後當key等於root.val，有三種情況
            如果root.left為空
                回傳root.right
            又如果root.right為空
                回傳root.left
            最後如果左右皆不為空，由於題目優先把右方節點補上
            因此我們以root.right的最小值為目標，作為root的數值替換
                設置區域min_node，放置root.right
                當min_node的左方節點不為空時，進while迴圈
                    更新min_node為min_node的左方節點
                跳出while迴圈後，root.val更新為min.val
                接著刪掉min節點，也就是去右方節點遞迴找到min節點
        流程到最後再回傳root
        */
        if (root == null)
            {return root;}
        
        if (key < root.val)  //如果key比root小，往左找
        {
            root.left = DeleteNode(root.left, key);
        }
        else if (key > root.val)  //如果key比root大，往右找
        {            
            root.right = DeleteNode(root.right, key);
        }
        else  // 這個else 代表 (root.val == key)
        {
            if (root.left == null)
                {return root.right;}
            else if (root.right == null)
                {return root.left;}
            else
            {
                TreeNode min = root.right;
                while (min.left != null)
                {
                    min = min.left;
                }
                root.val = min.val;
                root.right = DeleteNode(root.right, min.val);
            }
        }
        return root;

    }
}
// @lc code=end

/*
https://youtu.be/W_3jGD2AXOE?si=QdC1IenezC4vVIpc
*/