namespace Ksu.Cis300.SpiderSolitaire
{
    partial class NewGameDialog
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
            uxMainPanel = new FlowLayoutPanel();
            uxLabelsPanel = new FlowLayoutPanel();
            uxGameNumberLabel = new Label();
            uxGameNumber = new NumericUpDown();
            uxControlsPanel = new FlowLayoutPanel();
            uxSuitsLabel = new Label();
            uxSuits = new ComboBox();
            uxOK = new Button();
            uxMainPanel.SuspendLayout();
            uxLabelsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uxGameNumber).BeginInit();
            uxControlsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // uxMainPanel
            // 
            uxMainPanel.AutoSize = true;
            uxMainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uxMainPanel.Controls.Add(uxLabelsPanel);
            uxMainPanel.Controls.Add(uxControlsPanel);
            uxMainPanel.Controls.Add(uxOK);
            uxMainPanel.FlowDirection = FlowDirection.TopDown;
            uxMainPanel.Location = new Point(0, 0);
            uxMainPanel.Name = "uxMainPanel";
            uxMainPanel.Size = new Size(330, 128);
            uxMainPanel.TabIndex = 0;
            uxMainPanel.WrapContents = false;
            // 
            // uxLabelsPanel
            // 
            uxLabelsPanel.AutoSize = true;
            uxLabelsPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uxLabelsPanel.Controls.Add(uxGameNumberLabel);
            uxLabelsPanel.Controls.Add(uxGameNumber);
            uxLabelsPanel.Location = new Point(3, 3);
            uxLabelsPanel.Name = "uxLabelsPanel";
            uxLabelsPanel.Size = new Size(324, 37);
            uxLabelsPanel.TabIndex = 0;
            uxLabelsPanel.WrapContents = false;
            // 
            // uxGameNumberLabel
            // 
            uxGameNumberLabel.AutoSize = true;
            uxGameNumberLabel.Location = new Point(3, 0);
            uxGameNumberLabel.Name = "uxGameNumberLabel";
            uxGameNumberLabel.Padding = new Padding(0, 5, 0, 0);
            uxGameNumberLabel.Size = new Size(132, 30);
            uxGameNumberLabel.TabIndex = 0;
            uxGameNumberLabel.Text = "Game Number:";
            uxGameNumberLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uxGameNumber
            // 
            uxGameNumber.Location = new Point(141, 3);
            uxGameNumber.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            uxGameNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            uxGameNumber.Name = "uxGameNumber";
            uxGameNumber.Size = new Size(180, 31);
            uxGameNumber.TabIndex = 1;
            uxGameNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // uxControlsPanel
            // 
            uxControlsPanel.AutoSize = true;
            uxControlsPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uxControlsPanel.Controls.Add(uxSuitsLabel);
            uxControlsPanel.Controls.Add(uxSuits);
            uxControlsPanel.Location = new Point(3, 46);
            uxControlsPanel.Name = "uxControlsPanel";
            uxControlsPanel.Size = new Size(324, 39);
            uxControlsPanel.TabIndex = 1;
            uxControlsPanel.WrapContents = false;
            // 
            // uxSuitsLabel
            // 
            uxSuitsLabel.AutoSize = true;
            uxSuitsLabel.Location = new Point(3, 0);
            uxSuitsLabel.Name = "uxSuitsLabel";
            uxSuitsLabel.Padding = new Padding(0, 5, 0, 0);
            uxSuitsLabel.Size = new Size(146, 30);
            uxSuitsLabel.TabIndex = 1;
            uxSuitsLabel.Text = "Number of Suits:";
            uxSuitsLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uxSuits
            // 
            uxSuits.DropDownStyle = ComboBoxStyle.DropDownList;
            uxSuits.FormattingEnabled = true;
            uxSuits.Items.AddRange(new object[] { "1", "2", "4" });
            uxSuits.Location = new Point(155, 3);
            uxSuits.Name = "uxSuits";
            uxSuits.Size = new Size(166, 33);
            uxSuits.TabIndex = 1;
            // 
            // uxOK
            // 
            uxOK.DialogResult = DialogResult.OK;
            uxOK.Location = new Point(3, 91);
            uxOK.Name = "uxOK";
            uxOK.Size = new Size(324, 34);
            uxOK.TabIndex = 2;
            uxOK.Text = "OK";
            uxOK.UseVisualStyleBackColor = true;
            // 
            // NewGameDialog
            // 
            AcceptButton = uxOK;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 450);
            Controls.Add(uxMainPanel);
            Name = "NewGameDialog";
            uxMainPanel.ResumeLayout(false);
            uxMainPanel.PerformLayout();
            uxLabelsPanel.ResumeLayout(false);
            uxLabelsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)uxGameNumber).EndInit();
            uxControlsPanel.ResumeLayout(false);
            uxControlsPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel uxMainPanel;
        private FlowLayoutPanel uxLabelsPanel;
        private Label uxGameNumberLabel;
        private FlowLayoutPanel uxControlsPanel;
        private ComboBox uxSuits;
        private NumericUpDown uxGameNumber;
        private Label uxSuitsLabel;
        private Button uxOK;
    }
}