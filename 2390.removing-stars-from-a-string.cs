/*
 * @lc app=leetcode id=2390 lang=csharp
 *
 * [2390] Removing Stars From a String
 */

// @lc code=start
public class Solution {
    public string RemoveStars(string s)
    {
        /*
        In the beginning we create an empty Stack.
        In foreach loop we check if the current char ch is equal to * and the Stack is not empty we remove the element we inserted before *, else we add char to the Stack.
        Then create a list filling it with values from Stack.
        In return section we need to return a string so I used string.Join filled with reversed values from the list.
        If you don't know why I reversed values is because stack follows the LIFO (Last In First Out) principle. You can read about it in google:)
        */
        Stack<char> myStack = new Stack<char>();

        foreach(char ch in s)
        {
            if (ch == '*' && myStack.Count > 0) myStack.Pop();
            else myStack.Push(ch);
        }

        List<char> result = new List<char>();
        foreach(char ch in myStack)
        {
            result.Add(ch);
        }

        return string.Join("", result.ToArray().Reverse());
        /*
        string.Join的參考
        https://learn.microsoft.com/zh-tw/dotnet/api/system.string.join?view=net-8.0#system-string-join(system-string-system-string())
        */
    }
}
// @lc code=end

/*
        //自己洗的爛扣，23% 25%
        //設置一個stack
        //設一個迴圈訪問陣列s，沒遇到'*'就把s[i]push到Stack，遇到'*'就pop掉stack
        //設置StringBuilder，放置stack pop出來的字元，Insert(0,Stack.Pop())
        //再回傳StringBuilder.ToString()
        Stack<char> numbers = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != '*')
            {
                numbers.Push(s[i]);
            }
            else
            {
                numbers.Pop();
            }
        }
        StringBuilder sb = new StringBuilder();
        while (numbers.Count > 0)
        {
            sb.Insert(0, numbers.Pop());         
        }
        return sb.ToString();
*/