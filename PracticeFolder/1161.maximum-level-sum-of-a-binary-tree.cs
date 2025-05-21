/*
 * @lc app=leetcode id=1161 lang=csharp
 *
 * [1161] Maximum Level Sum of a Binary Tree
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
    public int MaxLevelSum(TreeNode root)
    {
        //網友的扣 48% 22%
        Queue<TreeNode> node_queue = new Queue<TreeNode>();

        if (root == null)
        {
            return 0;
        }     
        if(root.left == null && root.right == null)
        {
            return 1;
        }   
        int MaxSum = int.MinValue; //最大總和，先設最小值，以方便比對大小
        int current_Level = 0; //當前層級
        int MaxLevel = 0; //有最大總和的層級
        
        node_queue.Enqueue(root);
        
        while (node_queue.Count > 0)
        {
            current_Level++;
            int queue_Count = node_queue.Count;
            int temp_Max = 0; //當前層次的總和。每進入一層，就先把暫存歸零 

            for (int i = 0; i < queue_Count; i++)
            {
                TreeNode temp_node = node_queue.Dequeue();
                temp_Max = temp_Max + temp_node.val;

                if (temp_node.left != null)
                {
                    node_queue.Enqueue(temp_node.left);
                }
                if (temp_node.right != null)
                {
                    node_queue.Enqueue(temp_node.right);
                }
            }
            if (temp_Max > MaxSum)
            {                
                MaxSum = temp_Max;
                MaxLevel = current_Level;
            }
        }
        return MaxLevel;
    }
}
// @lc code=end

/*
        //自幹的爛扣 81% 34%
        //使用BFS      
        //1. 先設置queue。  
        //2. 如果root是null，回傳0。接著，如果root左方和右方都沒節點，回傳1。
        //3. 把root放進queue內。設置最大總和為root.val，還有當前層級設為2，以及有最大總和的層級為1
        //4. 當queue長度大於0時，進入while迴圈。設置queue的長度變數、設置暫存當前層次的數值總和變數temp_Max
        //5. 進入for迴圈，拜訪queue內的元素。
        //6. 在迴圈內設置區域變數TreeNode存放被Dequeue出來的節點
        //7. 當此節點左方有節點，temp_Max += temp_node.left.val;。 並且把左方節點放進queue內
        //8. 當此節點右方有節點，temp_Max += temp_node.right.val;。 並且把右方節點放進queue內
        //9. 當temp_Max大於MaxSum，就更新MaxSum
        //10. 接著利用current_Level把MaxLevel更新，代表當前節點的下一層級數值總和，比現在這一層級的節點們數值總和還高
        //11. *Edge Case*如果queue長度為0，代表當前層級的下一層級數值總和，比現在這一層級的節點們數值總和還高，但其實下一層級已經沒有節點了，全部是null，因此把current_Level-1，退回當前層級，並且直接回傳MaxLevel
        //12. 沒跑進Edge Case的話，就繼續把current_Level++
        //13. 跑完while迴圈，把MaxLevel回傳
        Queue<TreeNode> node_queue = new Queue<TreeNode>();
        if (root == null)
        {
            return 0;
        }    
        if(root.left == null && root.right == null)
        {
            return 1;
        }    
        node_queue.Enqueue(root);
        int MaxSum = root.val; //最大總和
        int current_Level = 2; //當前層級        
        int MaxLevel = 1; //有最大總和的層級
        while (node_queue.Count > 0)
        {
            int queue_Count = node_queue.Count;
            int temp_Max = 0; //當前層次的總和。每進入一層，就先把暫存歸零 
            for (int i = 0; i < queue_Count; i++)
            {
                TreeNode temp_node = node_queue.Dequeue();
                if (temp_node.left != null)
                {
                    temp_Max = temp_Max + temp_node.left.val;
                    node_queue.Enqueue(temp_node.left);
                }
                if (temp_node.right != null)
                {
                    temp_Max = temp_Max + temp_node.right.val;
                    node_queue.Enqueue(temp_node.right);
                }
            }
            if (temp_Max > MaxSum)
            {                
                MaxSum = temp_Max;
                MaxLevel = current_Level;
                if(node_queue.Count == 0)  //以防出現edge case [-100,-200,-300,-20,-5,-10,null]中必定會多算一次層級，因此要把-1減回去
                {
                    return MaxLevel-1;
                }
            }
            current_Level++;
        }
        return MaxLevel;
*/