/*
 * @lc app=leetcode id=216 lang=csharp
 *
 * [216] Combination Sum III
 */

// @lc code=start
public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        //使用BackTrack
        //設置兩個串列，泛型為IList<int>的Answer串列，還有泛型為<int>的Temp
        List<IList<int>> Answer = new List<IList<int>>();
        List<int> Temp = new List<int>();

        //呼叫遞迴backtrack()
        backtrack(k, n, 1, Temp);

        //回傳Answer串列
        return Answer;

        //backtrack()的參數設為整數的k、n、start，以及串列temp
        void backtrack(int k, int n, int start, List<int> temp)
        {   
            //當k減到剩下0
            if (k == 0 ) 
            {   
                //且n減到剩下0
                if (n == 0)
                {   
                    //Answer新增目前的temp串列
                    Answer.Add(new List<int>(temp));
                }                
                return; //回傳上一層遞迴
            }
            
            //如果k或是n都被減到剩下0，直接回傳上一層遞迴
            if ( k == 0 || n == 0 ) return;
            
            //從start為起始點，訪問到9為止 (1~9)
            for (int i = start; i <= 9; i++)
            {
                //目前串列新增i
                temp.Add(i);

                //呼叫遞迴backtrack()，參數為k - 1, n - i, i + 1, temp
                backtrack(k - 1, n - i, i + 1, temp);
                //遞迴結束後，把目前的temp串列最後數值刪除
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
// @lc code=end

