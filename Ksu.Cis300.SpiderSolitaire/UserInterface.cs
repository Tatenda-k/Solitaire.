/* UserInterface.cs
 * Author: Rod Howell
 */
namespace Ksu.Cis300.SpiderSolitaire
{
    /// <summary>
    /// A GUI for a program that plays Spider Solitaire
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The default padding between controls.
        /// </summary>
        private const int _defaultPadding = 3;

        /// <summary>
        /// The minimum height of the GUI.
        /// </summary>
        private readonly int _minHeight = CardPainter.CardHeight * 6;

        /// <summary>
        /// The dialog for obtaining a new game number.
        /// </summary>
        private readonly NewGameDialog _newGameDialog = new();

        /// <summary>
        /// The game representation.
        /// </summary>
        private readonly Game _game = new();

        /// <summary>
        /// Adds the Stock control to the GUI.
        /// </summary>
        private void AddStock()
        {
            Stock stock = _game.Stock;
            stock.Margin = new Padding(_defaultPadding);
            stock.Width =
                (_game.TableauColumns.Length - _game.HomeCells.Length) * (_game.TableauColumns[0].Width + 2 * _defaultPadding) - 2 * _defaultPadding;
            stock.Height = CardPainter.CardHeight;
            stock.Click += StockClick;
            uxTopPanel.Controls.Add(stock);
        }

        /// <summary>
        /// Adds the home cells to the GUI.
        /// </summary>
        private void AddHomeCells()
        {
            foreach (HomeCell cell in _game.HomeCells)
            {
                cell.Margin = new Padding(_defaultPadding);
                uxTopPanel.Controls.Add(cell);
            }
        }

        /// <summary>
        /// Adds the tableau columns to the GUI.
        /// </summary>
        private void AddTableauColumns()
        {
            foreach (TableauColumn col in _game.TableauColumns)
            {
                col.Margin = new Padding(_defaultPadding);
                col.MouseClick += TableauColumnMouseClick;
                uxTableauPanel.Controls.Add(col);
            }
            ResizeColumns();
        }

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            AddStock();
            AddHomeCells();
            AddTableauColumns();
            int diff = Width - uxMainContainer.Width;
            MinimumSize = new Size(uxTopPanel.Width + diff + _defaultPadding, _minHeight);
            uxMainContainer.SplitterDistance = uxTopPanel.Height;
            uxMainContainer.IsSplitterFixed = true;
        }

        /// <summary>
        /// Handles a Click event on the "New Game" menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void NewClick(object sender, EventArgs e)
        {
            if (_newGameDialog.ShowDialog() == DialogResult.OK)
            {
                _game.StartNewGame(_newGameDialog.GameNumber, _newGameDialog.NumberOfSuits);
                uxGameNumber.Text = _newGameDialog.GameNumber.ToString();
                uxSuits.Text = _newGameDialog.NumberOfSuits.ToString();
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Handles a Click event on a tableau column.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void TableauColumnMouseClick(object? sender, MouseEventArgs e)
        {
            // The sender will always be a TableauColumn, and hence will not be null.
            TableauColumn col = (TableauColumn)sender!;
            int n = col.NumberAbove(e.Y);
            if (n >= 0)
            {
                _game.ClickColumn(col, n);
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Updates the display.
        /// </summary>
        private void UpdateDisplay()
        {
            uxScore.Text = _game.Score.ToString();
            uxUndo.Enabled = _game.CanUndo;
            Refresh();
        }

        /// <summary>
        /// Handles a Click event on the stock.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void StockClick(object? sender, EventArgs e)
        {
            // The sender will always be a Stock; hence, it will never be null.
            Stock stock = (Stock)sender!;
            if (stock.Cards.Count > 0)
            {
                _game.ClickStock();
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Resizes the tableau columns to fit the containing panel.
        /// </summary>
        private void ResizeColumns()
        {
            foreach (TableauColumn col in _game.TableauColumns)
            {
                col.Height = uxTableauPanel.Height - 2 * _defaultPadding;
            }
        }

        /// <summary>
        /// Handles a SizeChanged event on the tableau panel
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void TableauPanelSizeChanged(object sender, EventArgs e)
        {
            ResizeColumns();
            Refresh();
        }

        /// <summary>
        /// Handles a Click event on the Undo button.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void UndoClick(object sender, EventArgs e)
        {
            _game.Undo();
            UpdateDisplay();
        }
    }
}