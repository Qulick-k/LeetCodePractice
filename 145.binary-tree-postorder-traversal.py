#
# @lc app=leetcode id=145 lang=python3
#
# [145] Binary Tree Postorder Traversal
#

# @lc code=start
# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
from typing import List


class Solution:
    def postorderTraversal(self, root: Optional[TreeNode]) -> List[int]:
        #Use binary search, just traversal all of the node left first and then right. the last we just append root itself value into the result'array. Then return the result.
        def postorder(root):
            if root:
                postorder(root.left)
                postorder(root.right)
                res.append(root.val)
        
        res = []
        postorder(root)
        return res

        
# @lc code=end

