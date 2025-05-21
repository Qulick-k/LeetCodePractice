/*
 * @lc app=leetcode id=1381 lang=csharp
 *
 * [1381] Design a Stack With Increment Operation
 */

// @lc code=start
public class CustomStack
{
    //練習stack的實作
    int[] stack_arr;
    int maxSize;
    int top;
    int size;
    public CustomStack(int maxSize)
    {
        stack_arr = new int[maxSize];
        this.maxSize = maxSize;
        top = -1;
        size = 0;
    }
    
    public void Push(int x)
    {
        //如果stack滿了
        if (size == maxSize) return;

        stack_arr[++top] = x;
        size++;
    }
    
    public int Pop()
    {
        //如果stack沒東西
        if (size == 0) return -1;

        size--;
        return stack_arr[top--];
    }
    
    public void Increment(int k, int val)
    {
        //如果stack剛初始化
        if (top == -1) return;
        
        //如果要增加的k數，超過stack尺寸
        if (k > size)
        {
            for (int i = 0; i < size; i++)
            {
                stack_arr[i] += val;
            }
        }
        else //如果要增加的k數，沒超過stack尺寸
        {
            for (int i = 0; i < k; i++)
            {
                stack_arr[i] += val;
            }
        }
    }
}

/**
 * Your CustomStack object will be instantiated and called as such:
 * CustomStack obj = new CustomStack(maxSize);
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * obj.Increment(k,val);
 */
// @lc code=end

