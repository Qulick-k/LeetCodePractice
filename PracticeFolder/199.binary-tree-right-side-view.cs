/*
 * @lc app=leetcode id=199 lang=csharp
 *
 * [199] Binary Tree Right Side View
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
    // 42% 7%
    /*
    使用BFS，接收到右方側風的node都記錄在List內，並且要由上而下的紀錄
    1. 利用BFS一層一層拜訪，在queue長度不為0時，運行while迴圈，在迴圈內設置變數存放當層queue長度，接著for迴圈訪問，每一次迴圈都需要Dequeue()給暫存node
    2. 最右邊的node都是當前層的最後一個node
        ex 1: input[1]，跑for迴圈時，第一層是1，而當前queue長度為1，而1的索引值為0，因此queue長度-1 == 0索引值
    3. 找到後，把之前Dequeue的值存在List
    4. 之前Dequeue的值，如果左方有節點，Enqueue進queue
    5. 之前Dequeue的值，如果右方有節點，Enqueue進queue
    6. while跑完，回傳List
    */
    Queue<TreeNode> node_queue = new Queue<TreeNode>();
    public IList<int> RightSideView(TreeNode root)
    {
        List<int>  temp_List = new List<int>();
        if (root == null)
        {
            return temp_List;
        }
        //使用BFS
        node_queue.Enqueue(root);
        

        while (node_queue.Count > 0)
        {       
            int queue_Count = node_queue.Count;     
            for(int i = 0; i < queue_Count; i++)
            {
                TreeNode node = node_queue.Dequeue(); //把第一層的節點排掉
                
                if (i == queue_Count-1)
                {
                    temp_List.Add(node.val);
                }

                if(node.left != null)
                    node_queue.Enqueue(node.left);
                if(node.right != null)
                    node_queue.Enqueue(node.right);
            }
        }
        return temp_List;
    }
}
// @lc code=end

