/*
 * @lc app=leetcode id=1456 lang=csharp
 *
 * [1456] Maximum Number of Vowels in a Substring of Given Length
 */

// @lc code=start
public class Solution {
    public int MaxVowels(string s, int k)
    {
        //使用Slide Window
        int num = 0;   //計數器
        for (int i = 0; i < k; i++) //先算第一個基準值
        {
            if (IsVowel(s[i]))  //如果方法回傳true，代表s[i]是母音
            {
                num++; //計數器增加
            }
        }
        int Max_num = num;
        for (int i = k; i < s.Length; i++) //index從k開始算起
        {              
            if(IsVowel(s[i-k]))   //把基準值移除掉s[i-k]，換句話說就是s[i-k]如果是母音的話，num要-1
            {
                num--;
            }
            if(IsVowel(s[i]))   //再把基準值加上s[i]，換句話說就是s[i]如果是母音的畫，num要+1
            {
                num++;
            }
            Max_num = Math.Max(Max_num, num);//比較Max_num跟num哪一個數字比較大，比較大的就重新賦予給Max_num
        }        
        //算完後Return Max_num;
        return Max_num;
        bool IsVowel(char charName)       //設一個母音判斷是不是母音的方法
        {
            return (charName == 'a') || (charName == 'e') || (charName == 'i') || (charName == 'o') || (charName == 'u');
        } 
    }
}
// @lc code=end

/*  第二種解法，比較吃空間，但跟最一開始的想法是最接近的解法
        // For control
        int left = 1;
        int right = k;
        int size = s.Length;
        int answer = 0;
        int count = 0;

        // Get the first count
        for( int i=0; i < k; i++ ){
            if( "aeiouAEIOU".Contains( s[i] ) ){
                count++;
            }
        }
        // Set as answer, to start
        answer = count;

        // Traverse the string
        while( right < size ){
            
            // If char removed at left was vowel
            if( "aeiouAEIOU".Contains( s[left-1] ) ){
                count--;
            }
            // If char added at right is a vowel
            if( "aeiouAEIOU".Contains(s[right]) ){
                count++;
            }
            // If answer is < than count, higher number of vowels
            if( answer < count ){
                answer = count;
            }
            // Move pointers
            right++;
            left++;
        }

        return answer;
*/
