/*
 * @lc app=leetcode id=729 lang=csharp
 *
 * [729] My Calendar I
 */

// @lc code=start
public class MyCalendar {
    //使用二元搜尋樹(Binary Search Tree)

    private class Node
    {
        public int start;
        public int end;
        public Node left;
        public Node right;

        public Node(int start, int end)
        {
            this.start = start;
            this.end = end;
            left = null;
            right = null;
        }
    }

    private Node root;

    public MyCalendar()
    {
        root = null;        
    }
    
    public bool Book(int start, int end)
    {
        //如果還沒有root節點，就設置root節點，並回傳可以訂房
        if (root == null)
        {
            root = new Node(start, end);
            return true;
        }
        return Insert(root, start, end);
    }

    private bool Insert(Node node, int start, int end)
    {
        //往二元樹的左方看 (end對照root的左側start)
        if (end <= node.start)
        {
            if (node.left == null) //如果沒有其他訂房了，就訂下目前的日期
            {
                node.left = new Node(start, end);
                return true;
            }
            else //如果還有其他訂房，那就遞迴進去看有沒有跟其他訂房日期重疊
            {
                return Insert(node.left, start, end);
            }
        }
        //往二元樹的右方看 (start對照root的右側end)
        else if (start >= node.end)
        {
            if (node.right == null) //如果沒有其他訂房了，就訂下目前的日期
            {
                node.right = new Node(start, end);
                return true;
            }
            else //如果還有其他訂房，那就遞迴進去看有沒有跟其他訂房日期重疊
            {
                return Insert(node.right, start, end);
            }
        }
        else //start 跟 end被root的左側start跟end包起來的話，代表重疊了，無法訂房
        {
            return false;
        }

    }
}
///參考解法 https://leetcode.com/problems/my-calendar-i/solutions/5834399/c-solution-for-my-calendar-i-problem/?envType=daily-question&envId=2024-09-26
///參考解法 https://youtu.be/fIxck3tlId4?si=-G6fYHQvrV7FrptW
/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */
// @lc code=end

