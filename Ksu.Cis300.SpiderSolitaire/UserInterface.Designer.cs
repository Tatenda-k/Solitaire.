namespace Ksu.Cis300.SpiderSolitaire
{
    partial class UserInterface
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uxMenuBar = new MenuStrip();
            uxGameMenu = new ToolStripMenuItem();
            uxUndo = new ToolStripMenuItem();
            uxNew = new ToolStripMenuItem();
            uxGameNumberLabel = new ToolStripMenuItem();
            uxScore = new ToolStripTextBox();
            uxScoreLabel = new ToolStripMenuItem();
            uxGameNumber = new ToolStripTextBox();
            uxSuitsLabel = new ToolStripTextBox();
            uxMainContainer = new SplitContainer();
            uxTopPanel = new FlowLayoutPanel();
            uxTableauPanel = new FlowLayoutPanel();
            uxSuits = new ToolStripTextBox();
            uxMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uxMainContainer).BeginInit();
            uxMainContainer.Panel1.SuspendLayout();
            uxMainContainer.Panel2.SuspendLayout();
            uxMainContainer.SuspendLayout();
            SuspendLayout();
            // 
            // uxMenuBar
            // 
            uxMenuBar.ImageScalingSize = new Size(24, 24);
            uxMenuBar.Items.AddRange(new ToolStripItem[] { uxGameMenu, uxGameNumberLabel, uxScore, uxScoreLabel, uxGameNumber, uxSuitsLabel, uxSuits });
            uxMenuBar.Location = new Point(0, 0);
            uxMenuBar.Name = "uxMenuBar";
            uxMenuBar.Size = new Size(895, 35);
            uxMenuBar.TabIndex = 0;
            uxMenuBar.Text = "menuStrip1";
            // 
            // uxGameMenu
            // 
            uxGameMenu.DropDownItems.AddRange(new ToolStripItem[] { uxUndo, uxNew });
            uxGameMenu.Name = "uxGameMenu";
            uxGameMenu.Size = new Size(74, 31);
            uxGameMenu.Text = "Game";
            // 
            // uxUndo
            // 
            uxUndo.Enabled = false;
            uxUndo.Name = "uxUndo";
            uxUndo.ShortcutKeys = Keys.Control | Keys.Z;
            uxUndo.Size = new Size(264, 34);
            uxUndo.Text = "Undo";
            uxUndo.Click += UndoClick;
            // 
            // uxNew
            // 
            uxNew.Name = "uxNew";
            uxNew.ShortcutKeys = Keys.Control | Keys.N;
            uxNew.Size = new Size(264, 34);
            uxNew.Text = "New Game";
            uxNew.Click += NewClick;
            // 
            // uxGameNumberLabel
            // 
            uxGameNumberLabel.Name = "uxGameNumberLabel";
            uxGameNumberLabel.Size = new Size(148, 31);
            uxGameNumberLabel.Text = "Game Number:";
            uxGameNumberLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uxScore
            // 
            uxScore.Alignment = ToolStripItemAlignment.Right;
            uxScore.Name = "uxScore";
            uxScore.ReadOnly = true;
            uxScore.Size = new Size(100, 31);
            uxScore.Text = "0";
            // 
            // uxScoreLabel
            // 
            uxScoreLabel.Alignment = ToolStripItemAlignment.Right;
            uxScoreLabel.Name = "uxScoreLabel";
            uxScoreLabel.Size = new Size(76, 31);
            uxScoreLabel.Text = "Score:";
            uxScoreLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uxGameNumber
            // 
            uxGameNumber.Name = "uxGameNumber";
            uxGameNumber.ReadOnly = true;
            uxGameNumber.Size = new Size(100, 31);
            // 
            // uxSuitsLabel
            // 
            uxSuitsLabel.Name = "uxSuitsLabel";
            uxSuitsLabel.ReadOnly = true;
            uxSuitsLabel.Size = new Size(100, 31);
            uxSuitsLabel.Text = "Suits:";
            uxSuitsLabel.TextBoxTextAlign = HorizontalAlignment.Right;
            // 
            // uxMainContainer
            // 
            uxMainContainer.Dock = DockStyle.Fill;
            uxMainContainer.Location = new Point(0, 35);
            uxMainContainer.Name = "uxMainContainer";
            uxMainContainer.Orientation = Orientation.Horizontal;
            // 
            // uxMainContainer.Panel1
            // 
            uxMainContainer.Panel1.Controls.Add(uxTopPanel);
            // 
            // uxMainContainer.Panel2
            // 
            uxMainContainer.Panel2.Controls.Add(uxTableauPanel);
            uxMainContainer.Size = new Size(895, 469);
            uxMainContainer.SplitterDistance = 161;
            uxMainContainer.TabIndex = 1;
            // 
            // uxTopPanel
            // 
            uxTopPanel.AutoSize = true;
            uxTopPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uxTopPanel.Location = new Point(0, 0);
            uxTopPanel.MinimumSize = new Size(50, 50);
            uxTopPanel.Name = "uxTopPanel";
            uxTopPanel.Size = new Size(50, 50);
            uxTopPanel.TabIndex = 0;
            uxTopPanel.WrapContents = false;
            // 
            // uxTableauPanel
            // 
            uxTableauPanel.Dock = DockStyle.Fill;
            uxTableauPanel.Location = new Point(0, 0);
            uxTableauPanel.Name = "uxTableauPanel";
            uxTableauPanel.Size = new Size(895, 304);
            uxTableauPanel.TabIndex = 0;
            uxTableauPanel.WrapContents = false;
            uxTableauPanel.SizeChanged += TableauPanelSizeChanged;
            // 
            // uxSuits
            // 
            uxSuits.Name = "uxSuits";
            uxSuits.ReadOnly = true;
            uxSuits.Size = new Size(100, 31);
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(895, 504);
            Controls.Add(uxMainContainer);
            Controls.Add(uxMenuBar);
            MainMenuStrip = uxMenuBar;
            Name = "UserInterface";
            Text = "Spider Solitaire";
            uxMenuBar.ResumeLayout(false);
            uxMenuBar.PerformLayout();
            uxMainContainer.Panel1.ResumeLayout(false);
            uxMainContainer.Panel1.PerformLayout();
            uxMainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)uxMainContainer).EndInit();
            uxMainContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip uxMenuBar;
        private ToolStripMenuItem uxGameMenu;
        private ToolStripMenuItem uxUndo;
        private ToolStripMenuItem uxNew;
        private ToolStripMenuItem uxGameNumberLabel;
        private ToolStripMenuItem uxScoreLabel;
        private ToolStripTextBox uxScore;
        private ToolStripTextBox uxGameNumber;
        private SplitContainer uxMainContainer;
        private FlowLayoutPanel uxTopPanel;
        private FlowLayoutPanel uxTableauPanel;
        private ToolStripTextBox uxSuitsLabel;
        private ToolStripTextBox uxSuits;
    }
}