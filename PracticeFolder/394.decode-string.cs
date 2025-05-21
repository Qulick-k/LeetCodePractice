/*
 * @lc app=leetcode id=394 lang=csharp
 *
 * [394] Decode String
 */

// @lc code=start
public class Solution {
    public string DecodeString(string s)
    {
        //設置stack，以及空字串
        Stack<string> stack = new Stack<string>();
        string result = "";

        for (int i = 0; i < s.Length; i++)//訪問字串s
        {
            if (s[i] != ']')
            {
                //遇到非']'的字元，就push到Stack
                stack.Push(s[i].ToString());
            }
            else
            {
                //當遇到']'，開始解碼
                string str = ""; //設置空字串
                string stackValue = stack.Pop().ToString(); //pop最頂端的值給暫存字串

                //當Stack的頂端不等於"["字串時，就持續pop出來給stackValue，再賦予給str字串
                while(stackValue != "[")
                {
                    str = stackValue + str; //把只有字母的stackValue加進str字串
                    stackValue = stack.Pop().ToString();
                }
                //設置放數字的字串
                string digitstr = "";
                /*
                當stack長度大於0，並且
                從stack.Peek出字元，丟進char[]內，如果stack = "211"
                用ToCharArray()然後指定[0]索引上
                判斷是否為數字，是的話true，不是的話false跳出迴圈
                char[] = ''                         
                char[] = '1'                        stack = "21"
                char[] = '11'                       stack = "2"
                char[] = '211'                      stack = ""
                */
                while(stack.Count > 0 && char.IsDigit(stack.Peek().ToCharArray()[0]))
                {
                    digitstr = stack.Pop() + digitstr;
                    /*
                    如果211[
                    digitstr = stack.Pop() + digitstr 同時Stack = 211
                    digitstr = 1 + "" == 1     
                    digitstr = 1 + 1  == 11
                    digitstr = 2 + 11 == 211
                    */
                }
                //使用TryParse查看digitstr內的字串是否能轉成數字
                //是的話，回傳true，並且傳回數字，不能的話，回傳false
                if (int.TryParse(digitstr, out var multiplier))
                {
                    //Enumerable.Repeat()可以把str重複multiplier次
                    //string.Concat()可以把Enumerable的參數轉為串連字串
                    //最後把重複的字串，賦予給str
                    //再把str push給stack
                    str = string.Concat(Enumerable.Repeat(str, multiplier));
                    stack.Push(str);
                }
            }
        }
        //當Stack長度大於0，就把Stack的字串轉成result。
        while (stack.Count > 0)
        {            
            result = stack.Pop().ToString() + result;
            /*
            假設stack是aab
            result = ""
            result = "b" + "" == "b"
            result = "a" + "b" == "ab"
            result = "a" + "ab" == "abb"
            */
        }

        return result;
    }
}
// @lc code=end

/*
Char.IsDigit()
https://learn.microsoft.com/en-us/dotnet/api/system.char.isdigit?view=net-8.0
String.ToCharArray()
https://learn.microsoft.com/zh-tw/dotnet/api/system.string.tochararray?view=net-8.0
int.TryParse()
https://learn.microsoft.com/zh-tw/dotnet/api/system.int32.tryparse?view=net-8.0
String.Concat()
https://learn.microsoft.com/zh-tw/dotnet/api/system.string.concat?view=net-8.0#system-string-concat(system-collections-generic-ienumerable((system-string)))
Enumerable.Repeat()
https://learn.microsoft.com/zh-tw/dotnet/api/system.linq.enumerable.repeat?view=net-8.0
*/
