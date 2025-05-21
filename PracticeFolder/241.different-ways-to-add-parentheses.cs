/*
 * @lc app=leetcode id=241 lang=csharp
 *
 * [241] Different Ways to Add Parentheses
 */

// @lc code=start
public class Solution {
    public IList<int> DiffWaysToCompute(string expression)
    {
        //DP+遞迴
        //把字串當成一個Tree，以運算子作為一個節點，將字串分成兩邊個別進行遞迴。而字串中的運算子可能有很多個，所以在拜訪過程中，會將各個運算子，作為節點再進行遞迴判斷
        
        //首先在第一層方法設置新的串列res
        //接著拜訪目前方法expression字串內的所有字元
            //把第i個字元提出來，放在char oper內
            //接著判斷oper是不是指定的運算子'+'、'-'、'*'。如果是的話
                //設置新的串列Left來放，從下一層遞迴回傳上來的res串列，而下一層遞迴的參數為"包含運算子以及運算子左側的字串"
                //設置新的串列Right來放，從下一層遞迴回傳上來的res串列，而下一層遞迴的參數為"運算子右側的字串"

                //接著拜訪Left串列
                    //繼續拜訪Right串列
                        //判斷oper是哪一種運算子
                            //如果是'+'的話，就將左側數值 + 右側數值
                            //如果是'-'的話，就將左側數值 - 右側數值
                            //如果是'*'的話，就將左側數值 * 右側數值

        //如果遇到有一些遞迴的字串，沒有運算子，代表字串內只有數字。因此跑完迴圈後，res串列不會新增數字。
            //把字串內的數字字元，轉成整數，新增至res串列內。
        
        //回傳 res串列回去題目或是回傳給上一層遞迴。
        IList<int> res = new List<int>();
        for (int i = 0; i < expression.Length; i++)
        {
            char oper = expression[i];
            if (oper == '+' || oper == '-' || oper == '*' ) 
            {
                IList<int> left = DiffWaysToCompute(expression.Substring(0,i));
                IList<int> right = DiffWaysToCompute(expression.Substring(i + 1));

                foreach (int L in left)
                {
                    foreach (int R in right)
                    {
                        switch(oper)
                        {
                            case '+':
                                res.Add(L + R);
                                break;
                            case '-':
                                res.Add(L - R);
                                break;
                            case '*':
                                res.Add(L * R);
                                break;
                        }
                    }
                }
            }
        }
       //如果當前遞迴，沒有運算子，代表字串內只有數字。因此res串列不會新增數字
        if(res.Count == 0)
        {
            res.Add(Int32.Parse(expression));
        }
        return res;
    }
}
// @lc code=end

