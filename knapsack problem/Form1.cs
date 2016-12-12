using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace knapsack_problem
{
    public partial class Form1 : Form
    {
        int N = 4;
        int cap = 5;
        int[] weight = new int[100];

        int[] cost = new int[100];
        int[,] dp = new int[7, 7];
        int weightOfItem;
        int benifitOfItem;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            weight[1] = 2;
            weight[2] = 3;
            weight[3] = 4;
            weight[4] = 5;
            cost[1] = 3;
            cost[2] = 7;
            cost[3] = 2;
            cost[4] = 9;
            for (int i = 0; i < 7; i++)
            {
                for (int w = 0; w < 7; w++)
                {
                    dp[i, w] = 0;
                }
            }
            int MaxProfit = knapsack();
            MessageBox.Show(MaxProfit.ToString());
        }

        public int knapsack()
        {
            int ii=0,ww=0;
            for (ii = 1; ii <= cap; ii++)
            {
                for (ww = 1; ww <= N; ww++)
                {
                    weightOfItem = weight[ii];
                    benifitOfItem = cost[ii];
                    if (weightOfItem <= ww)
                    {
                        if (benifitOfItem + dp[ii - 1, ww - weightOfItem] > dp[ii - 1, ww])
                        {
                            dp[ii, ww] = benifitOfItem + dp[ii - 1, ww - weightOfItem];
                        }
                        else
                        {
                            dp[ii, ww] = dp[ii - 1, ww];
                        }
                    }
                    else
                    {
                        dp[ii, ww] = dp[ii - 1, ww];
                    }
                }
            }
            return dp[ii, ww];

            //if (i == N + 1) // all item have been taken
            //    return 0;

            //if (dp[i,w] != -1)
            //    return dp[i,w];

            //int profit1 = 0, profit2 = 0;

            //if (w + weight[i] <= cap)
            //{
            //    profit1 = cost[i] + knapsack(i + 1, w + weight[i]);  // we take the i'th item and so capacity will reduce
            //}
            //else
            //    profit1 = 0;  // we cannot take the i'th item, because we have not enough capacity to take it

            //profit2 = knapsack(i + 1, w);    // we ignore the i'th item and so capacity will be same

            //dp[i,w] = Math.Max(profit1, profit2);  // here we take the maximum profit between profit1, profit2 and memorizing it

            //return dp[i,w];
        }
    }
}
