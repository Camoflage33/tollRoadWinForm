namespace tollRoadWinForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vehicleWeight = new System.Windows.Forms.Label();
            this.tollCost = new System.Windows.Forms.Label();
            this.roadCap = new System.Windows.Forms.Label();
            this.txtVehicleWeights = new System.Windows.Forms.TextBox();
            this.txtVehicleValues = new System.Windows.Forms.TextBox();
            this.txtRoadCapacity = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // vehicleWeight
            // 
            this.vehicleWeight.AutoSize = true;
            this.vehicleWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehicleWeight.Location = new System.Drawing.Point(62, 47);
            this.vehicleWeight.Name = "vehicleWeight";
            this.vehicleWeight.Size = new System.Drawing.Size(138, 24);
            this.vehicleWeight.TabIndex = 0;
            this.vehicleWeight.Text = "Vehicle Weight";
            // 
            // tollCost
            // 
            this.tollCost.AutoSize = true;
            this.tollCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tollCost.Location = new System.Drawing.Point(62, 101);
            this.tollCost.Name = "tollCost";
            this.tollCost.Size = new System.Drawing.Size(83, 24);
            this.tollCost.TabIndex = 0;
            this.tollCost.Text = "Toll Cost";
            // 
            // roadCap
            // 
            this.roadCap.AutoSize = true;
            this.roadCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roadCap.Location = new System.Drawing.Point(62, 162);
            this.roadCap.Name = "roadCap";
            this.roadCap.Size = new System.Drawing.Size(131, 24);
            this.roadCap.TabIndex = 0;
            this.roadCap.Text = "Road Capacity";
            // 
            // txtVehicleWeights
            // 
            this.txtVehicleWeights.Location = new System.Drawing.Point(252, 47);
            this.txtVehicleWeights.Name = "txtVehicleWeights";
            this.txtVehicleWeights.Size = new System.Drawing.Size(100, 20);
            this.txtVehicleWeights.TabIndex = 1;
            // 
            // txtVehicleValues
            // 
            this.txtVehicleValues.Location = new System.Drawing.Point(252, 101);
            this.txtVehicleValues.Name = "txtVehicleValues";
            this.txtVehicleValues.Size = new System.Drawing.Size(100, 20);
            this.txtVehicleValues.TabIndex = 1;
            // 
            // txtRoadCapacity
            // 
            this.txtRoadCapacity.Location = new System.Drawing.Point(252, 162);
            this.txtRoadCapacity.Name = "txtRoadCapacity";
            this.txtRoadCapacity.Size = new System.Drawing.Size(100, 20);
            this.txtRoadCapacity.TabIndex = 1;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(66, 225);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(94, 30);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // lstResult
            // 
            this.lstResult.FormattingEnabled = true;
            this.lstResult.Location = new System.Drawing.Point(437, 48);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(296, 238);
            this.lstResult.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 334);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtRoadCapacity);
            this.Controls.Add(this.txtVehicleValues);
            this.Controls.Add(this.txtVehicleWeights);
            this.Controls.Add(this.roadCap);
            this.Controls.Add(this.tollCost);
            this.Controls.Add(this.vehicleWeight);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label vehicleWeight;
        private System.Windows.Forms.Label tollCost;
        private System.Windows.Forms.Label roadCap;
        private System.Windows.Forms.TextBox txtVehicleWeights;
        private System.Windows.Forms.TextBox txtVehicleValues;
        private System.Windows.Forms.TextBox txtRoadCapacity;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.ListBox lstResult;
    }
}

