/*
 * @lc app=leetcode id=605 lang=csharp
 *
 * [605] Can Place Flowers
 */

// @lc code=start
public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) 
    {
        //另外一個更直觀的作法，並且使用ElementAtOrDefault來避免超出array的index範圍
        for(int i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 0
                && flowerbed.ElementAtOrDefault(i - 1) == 0
                && flowerbed.ElementAtOrDefault(i + 1) == 0)
            {
                flowerbed[i] = 1;
                n--;
            }
        }

        return n <= 0;
    }
}
// @lc code=end

/*  自己想的
        bool temp_bool = true;
        bool temp_While = true;
        int temp_Num = 0;        

        while(temp_While)
        {
            if(temp_Num < (flowerbed.Length-1))
            {
                if(flowerbed[temp_Num] == 1)
                {
                    temp_Num = temp_Num + 2;
                }
                else
                {
                    if(flowerbed[temp_Num + 1] == 1 && flowerbed[temp_Num + 1] != null)
                    {
                        temp_Num = temp_Num + 3;
                    }
                    else
                    {
                        if(flowerbed[temp_Num] == 0)
                        {
                            n--;
                            temp_Num = temp_Num + 2;
                            Console.WriteLine(temp_Num);
                            Console.WriteLine(n);
                        }
                    }
                }
                
            }
            else
            {
                if(temp_Num == (flowerbed.Length-1))
                {
                    if(flowerbed[temp_Num] == 1)
                    {
                    }
                    else
                    {
                        n--;                                                             
                    }
                }

                if(n <= 0)
                {
                    temp_bool = true;                    
                }
                if(n > 0)
                {
                    temp_bool = false;
                }

                temp_While = false;
            }
        }
        
        return temp_bool;
*/