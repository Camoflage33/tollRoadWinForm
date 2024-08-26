using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tollRoadWinForm
{
    public partial class Form1 : Form
    {
        private object lstResult;

        public Form1()
        {
            InitializeComponent();
        }

        private void calculate_Click(object sender, EventArgs e)
        {          

            // Knapsack algorithm adapted from previous code
           int MaximizeVehicleFlow(int[] vehicleWeights, int[] vehicleValues, int roadCapacity)
            {
                int n = vehicleWeights.Length;
                int[,] dp = new int[n + 1, roadCapacity + 1];

                for (int i = 0; i <= n; i++)
                {
                    for (int w = 0; w <= roadCapacity; w++)
                    {
                        if (i == 0 || w == 0)
                            dp[i, w] = 0;
                        else if (vehicleWeights[i - 1] <= w)
                            dp[i, w] = Math.Max(vehicleValues[i - 1] + dp[i - 1, w - vehicleWeights[i - 1]], dp[i - 1, w]);
                        else
                            dp[i, w] = dp[i - 1, w];
                    }
                }

                return dp[n, roadCapacity];
            }

           void DisplayResult(int[] vehicleWeights, int[] vehicleValues, int roadCapacity)
            {
                int n = vehicleWeights.Length;
                bool[,] keep = new bool[n + 1, roadCapacity + 1];
                int[,] dp = new int[n + 1, roadCapacity + 1];

                for (int i = 1; i <= n; i++)
                {
                    for (int w = 0; w <= roadCapacity; w++)
                    {
                        if (vehicleWeights[i - 1] <= w && vehicleValues[i - 1] + dp[i - 1, w - vehicleWeights[i - 1]] > dp[i - 1, w])
                        {
                            dp[i, w] = vehicleValues[i - 1] + dp[i - 1, w - vehicleWeights[i - 1]];
                            keep[i, w] = true;
                        }
                        else
                        {
                            dp[i, w] = dp[i - 1, w];
                        }
                    }
                }

                int K = roadCapacity;
                lstResult.Items.Clear();
                lstResult.Items.Add("Selected vehicles for optimal flow:");
                for (int i = n; i > 0; i--)
                {
                    if (keep[i, K])
                    {
                        lstResult.Items.Add($"Vehicle Type {i} (Weight: {vehicleWeights[i - 1]}, Value: {vehicleValues[i - 1]})");
                        K -= vehicleWeights[i - 1];
                    }
                }
            }

            private void btnCalculate_Click(object sender, EventArgs e)
            {
                try
                {
                    int[] vehicleWeights = Array.ConvertAll(txtVehicleWeights.Text.Split(','), int.Parse);
                    int[] vehicleValues = Array.ConvertAll(txtVehicleValues.Text.Split(','), int.Parse);
                    int roadCapacity = int.Parse(txtRoadCapacity.Text);

                    int maxFlowValue = MaximizeVehicleFlow(vehicleWeights, vehicleValues, roadCapacity);
                    lstResult.Items.Add($"Maximum Value of Vehicle Flow: {maxFlowValue}");
                    lstResult.Items.Add("");

                    DisplayResult(vehicleWeights, vehicleValues, roadCapacity);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}
    

