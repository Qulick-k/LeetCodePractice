/*
 * @lc app=leetcode id=641 lang=csharp
 *
 * [641] Design Circular Deque
 */

// @lc code=start
//此題為雙向鏈結串列題
//設置Node類別
public class Node 
{
    public int val;
    public Node next;
    public Node prev;
    public Node(int v) => val = v;
}
public class MyCircularDeque
{
    //設置串列大小上限、目前數量、頭節點、尾八節點
    int size = 0;
    int count = 0;
    Node head;
    Node tail;

    public MyCircularDeque(int k)
    {
        size = k;    
    }
    
    public bool InsertFirstItem(int value)
    {
        //設置第一個節點，配置雙指標
        Node node = new(value);
        head = node;
        tail = node;
        count++;
        return true;
    }

    public bool InsertFront(int value)
    {
        if (count >= size) return false;
        if (count == 0) return InsertFirstItem(value);

        Node node = new(value);
        node.next = head;
        head.prev = node;
        head = node;
        count++;
        return true;
    }
    
    public bool InsertLast(int value)
    {
        if (count >= size) return false;
        if (count == 0) return InsertFirstItem(value);

        Node node = new(value);
        tail.next = node;
        node.prev = tail;        
        tail = node;
        count++;
        return true;
    }
    
    public bool DeleteLastItem()
    {
        tail = null;
        head = null;
        count--;
        return true;
    }

    public bool DeleteFront()
    {
        if (count == 0) return false;
        if (count == 1) return DeleteLastItem();

        head = head.next;
        head.prev = null;
        count--;
        return true;
    }
    
    public bool DeleteLast()
    {
        if (count == 0) return false;
        if (count == 1) return DeleteLastItem();

        tail = tail.prev;
        tail.next = null;
        count--;
        return true;
    }
    
    public int GetFront() => head == null ? -1 : head.val;
    
    public int GetRear() => tail == null ? -1 : tail.val;
    
    public bool IsEmpty() => count == 0;
    
    public bool IsFull() => count == size;
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */
// @lc code=end

