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
        public Form1()
        {
            InitializeComponent();
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            // Clear previous results
            lstResult.Items.Clear();

            // Input validation
            if (string.IsNullOrWhiteSpace(txtVehicleWeights.Text) || string.IsNullOrWhiteSpace(txtVehicleValues.Text) || string.IsNullOrWhiteSpace(txtRoadCapacity.Text))
            {
                MessageBox.Show("Please enter all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int[] vehicleWeights = Array.ConvertAll(txtVehicleWeights.Text.Split(','), int.Parse);
                int[] vehicleValues = Array.ConvertAll(txtVehicleValues.Text.Split(','), int.Parse);
                int roadCapacity = int.Parse(txtRoadCapacity.Text);

                if (vehicleWeights.Length != vehicleValues.Length)
                {
                    MessageBox.Show("Vehicle Weights and Toll Costs must have the same number of entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (roadCapacity <= 0)
                {
                    MessageBox.Show("Road Capacity must be a positive number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maxFlowValue = MaximizeVehicleFlow(vehicleWeights, vehicleValues, roadCapacity);
                lstResult.Items.Add($"Maximum Value of Vehicle Flow: {maxFlowValue}");
                lstResult.Items.Add("");

                DisplayResult(vehicleWeights, vehicleValues, roadCapacity);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Knapsack algorithm to maximize vehicle flow
        private int MaximizeVehicleFlow(int[] vehicleWeights, int[] vehicleValues, int roadCapacity)
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

        // Method to display the selected vehicles for optimal flow
        private void DisplayResult(int[] vehicleWeights, int[] vehicleValues, int roadCapacity)
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

     
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set placeholder example text
            SetPlaceholders();

            // tooltips for guidance
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtVehicleWeights, "Enter the weight of each vehicle type, separated by commas (e.g., 2,5,8).");
            toolTip.SetToolTip(txtVehicleValues, "Enter the value for each vehicle type in the same order as the weights.");
            toolTip.SetToolTip(txtRoadCapacity, "Enter the total capacity of the road.");
        }

        
        private void SetPlaceholders()
        {
            //Placeholders 
            txtVehicleWeights.Text = "e.g., 2,5,8";  
            txtVehicleValues.Text = "e.g., 10,15,20";  
            txtRoadCapacity.Text = "e.g., 10"; 

            txtVehicleWeights.ForeColor = Color.Gray;  
            txtVehicleValues.ForeColor = Color.Gray;
            txtRoadCapacity.ForeColor = Color.Gray;
        }

        //Event handlers for when to space is presse to turn it back normal and make it empty or if something else is chosen to make it show exmples.
        private void txtVehicleWeights_Enter(object sender, EventArgs e)
        {
            if (txtVehicleWeights.Text == "e.g., 2,5,8")
            {
                txtVehicleWeights.Text = "";  
                txtVehicleWeights.ForeColor = Color.Black;  
            }
        }

       
        private void txtVehicleWeights_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVehicleWeights.Text))
            {
                txtVehicleWeights.Text = "e.g., 2,5,8";  
                txtVehicleWeights.ForeColor = Color.Gray;  
            }
        }

        
        private void txtVehicleValues_Enter(object sender, EventArgs e)
        {
            if (txtVehicleValues.Text == "e.g., 10,15,20")
            {
                txtVehicleValues.Text = "";
                txtVehicleValues.ForeColor = Color.Black;
            }
        }

        private void txtVehicleValues_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVehicleValues.Text))
            {
                txtVehicleValues.Text = "e.g., 10,15,20";
                txtVehicleValues.ForeColor = Color.Gray;
            }
        }

        
        private void txtRoadCapacity_Enter(object sender, EventArgs e)
        {
            if (txtRoadCapacity.Text == "e.g., 10")
            {
                txtRoadCapacity.Text = "";
                txtRoadCapacity.ForeColor = Color.Black;
            }
        }

        private void txtRoadCapacity_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoadCapacity.Text))
            {
                txtRoadCapacity.Text = "e.g., 10";
                txtRoadCapacity.ForeColor = Color.Gray;
            }
        }

        // Reset for all
        private void Reset_Click(object sender, EventArgs e)
        {
           
            lstResult.Items.Clear();

            SetPlaceholders();  
        }


    }
}