/*
 * @lc app=leetcode id=1466 lang=csharp
 *
 * [1466] Reorder Routes to Make All Paths Lead to the City Zero
 */

// @lc code=start
public class Solution {
    public int MinReorder(int n, int[][] connections)
    {
        // 86% 76%
        //leetcode75說此題主題是DFS，所以就試著用DFS
        /*
        題目給的邊的權重都是 1，我們加的反向的邊，權重都是 0 。這樣的目的是：我們從節點0 出發，如果沿著題目給出的邊走，權值為1，即最終需要反向該邊；如果沿著我們新添加的邊走，權值為0，即最終不需要反向該邊
        以[[0,1],[1,3],[2,3],[4,0],[4,5]]為例
        直線是題目原本給定的邊，權值為 1；曲線是自己加的邊，權值為 0。如果從節點 0 出發，需要沿著紅色的路徑，把所有的節點遍歷一遍。累加次紅色路徑上所有的權值為 3，也就是如果讓所有的點都能到達節點 0 ，則需要翻轉 3 條邊
        */
        //graph以adjust_List的形式定義，其中包含標誌表示原始道路（1）或假道路（0）
        //以及連接表示該道路通往哪個城市。

        //宣告二維串列，第二維串列固定放(真偽sign和 前往的點connects)
        // sign == 1 等於真正的路線，sign == 0 等於偽造的路線
        List<List<(int sign, int connects)>> adjust_List = new(); 
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            //把一維串列的各個索引值，放入泛型<(int sign, int connects)>的串列
            //以初始化二維串列
            //假設有n座城市，就代表adjust_List有n個索引值，
            //索引值可以放置List<(int sign, int connects)>
            adjust_List.Add(new List<(int sign, int connects)>()); 
        }

        foreach(int[] road in connections) 
        {
            //假設當前road是[0,1]
            //adjust_List[road[0]] == adjust_List[0號城市]
            //adjust_List[0號城市]加入(真實標誌 1, 目標城市 1號城市)
            adjust_List[road[0]].Add((1, road[1])); 

            //adjust_List[road[1]] == adjust_List[1號城市]
            //adjust_List[1號城市]加入(偽造標誌 0, 目標城市 0號城市)
            adjust_List[road[1]].Add((0, road[0])); 
        }
        
        //呼叫DSF方法，從0號城市開始出發，並且輸入不存在的-1號城市作為0號城市的前一個城市
        DFS_FindAWay(0, -1);

        //跑完DFS遞迴後，回傳偽造過的次數
        return count;

        //設置DFS找哪些是翻轉過的假路，例如(0, -1)
        void DFS_FindAWay(int current, int parent)
        {
            //拜訪adjust_List[當前城市]內的所有鄰近城市，
            foreach((int sign, int connects) neighbor in adjust_List[current])
            {
                //如果鄰近城市(neighbor)的目標城市(connects)等於parent城市的話，代表不用翻轉方向
                //例如adjust_List[0號城市]內有(sign=1, connects=0)，connects(0) != parent(-1)
                if(neighbor.connects == parent)
                {
                    //代表
                    continue;
                }
                //如果不等於的話，代表需要翻轉，增加
                count += neighbor.sign;

                //繼續DFS進去找
                DFS_FindAWay(neighbor.connects, current);
            }
        }

    }
    /*python DFS寫法
    def minReorder(self, n: int, connection: List[List[int]]) -> int:
        graph = collections.defaultdict(dict)  //設置
        for con in connections:
            graph[con[0]][con[1]] = 1
            graph[con[1]][con[0]] = 0
        visited = set()
        return self.dfs(graph, 0, visited)
    
    def dfs(self, graph, cur, visited):
        result = 0
        visited.add(cur)
        for next, value in graph[cur].items():
            if next not in visited:
                result += value
                result += self.dfs(graph, next, visited)
        return res
    */
}
// @lc code=end

/*蓋牌重寫
        List<List<(int sign, int destination)>> adjust_List = new(n);
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            adjust_List.Add(new List<(int sign, int destination)>());
        }

        foreach(int[] road  in connections)
        {
            adjust_List[road[0]].Add((1, road[1]));
            adjust_List[road[1]].Add((0, road[0]));
        }

        DFS_FindSign(0,-1);
        return count;

        void DFS_FindSign(int current, int parent)
        {
            foreach((int sign, int destination) neighbor in adjust_List[current])
            {
                if(neighbor.destination == parent)
                {
                    continue;
                }
                
                count += neighbor.sign;
                DFS_FindSign(neighbor.destination, current);
            }
        }
*/

/*C# DFS解法
        List<List<(int sign, int connects)>> adjust_List = new(); 
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            //把一維串列的各個索引值，放入泛型<(int sign, int connects)>的串列
            //以初始化二維串列
            //假設有n座城市，就代表adjust_List有n個索引值，
            //索引值可以放置List<(int sign, int connects)>
            adjust_List.Add(new List<(int sign, int connects)>()); 
        }

        foreach(int[] road in connections) 
        {
            //假設當前road是[0,1]
            //adjust_List[road[0]] == adjust_List[0號城市]
            //adjust_List[0號城市]加入(真實標誌 1, 目標城市 1號城市)
            adjust_List[road[0]].Add((1, road[1])); 

            //adjust_List[road[1]] == adjust_List[1號城市]
            //adjust_List[1號城市]加入(偽造標誌 0, 目標城市 0號城市)
            adjust_List[road[1]].Add((0, road[0])); 
        }
        
        //呼叫DSF方法，從0號城市開始出發，並且輸入不存在的-1號城市作為0號城市的前一個城市
        DFS_FindAWay(0, -1);

        //跑完DFS遞迴後，回傳偽造過的次數
        return count;

        //設置DFS找哪些是翻轉過的假路，例如(0, -1)
        void DFS_FindAWay(int current, int parent)
        {
            //拜訪adjust_List[當前城市]內的所有鄰近城市，
            foreach((int sign, int connects) neighbor in adjust_List[current])
            {
                //如果鄰近城市(neighbor)的目標城市(connects)等於parent城市的話，代表不用翻轉方向
                //例如adjust_List[0號城市]內有(sign=1, connects=0)，connects(0) != parent(-1)
                if(neighbor.connects == parent)
                {
                    //代表
                    continue;
                }
                //如果不等於的話，代表需要翻轉，增加
                count += neighbor.sign;

                //繼續DFS進去找
                DFS_FindAWay(neighbor.connects, current);
            }
        }
*/

/*自己寫的爛扣，跑不動
        //自己寫的爛扣，跑不動
    public int MinReorder(int n, int[][] connections)
    {
        //
        int result = 0;
        for (int i = 0; i <connections.Length; i++)
        {
            if (connections[i][1] == 0)
            {
                FindAWayTo_zero(connections, connections[i][0], result);
            }            
            else if (connections[i][0] == 0)
            {
                result++;
                FindAWayTo_zero(connections, connections[i][1], result);
            }
        }
        return result;
    }

    public void FindAWayTo_zero(int[][] connections,  int temp_zero, int result)
    {
        for (int j = 0; j < connections.Length; j++)
        {
            
            //if (connections[curremtLoop][1] == temp_zero)
            //{
            //    FindAWayTo_zero(connections, j, connections[curremtLoop][0], result);
            //}
            //else
            
            if (connections[j][0] == temp_zero)
            {
                result++;
                FindAWayTo_zero(connections, connections[j][1], result);
            }
        }
    }
*/