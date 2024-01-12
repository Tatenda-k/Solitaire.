/* TableauColumn.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.SpiderSolitaire
{
    /// <summary>
    /// A control implementing a column on the tableau.
    /// </summary>
    public partial class TableauColumn : UserControl
    {
        /// <summary>
        /// The vertical offset between face down cards.
        /// </summary>
        private const int _faceDownOffset = 5;

        /// <summary>
        /// The maximum vertical offset between face up cards.
        /// </summary>
        private readonly int _maxFaceUpOffset = CardPainter.CardHeight / 5;

        /// <summary>
        /// The vertical offset of the first face-up card.
        /// </summary>
        private int _faceUpStart;

        /// <summary>
        /// The vertical offset between face-up cards.
        /// </summary>
        private int _faceUpOffset;

        /// <summary>
        /// Gets the stack of face down cards on the column.
        /// </summary>
        public Stack<Card> FaceDownCards { get; } = new();

        /// <summary>
        /// Gets the stack of face up cards on the column.
        /// </summary>
        public Stack<Card> FaceUpCards { get; } = new();

        /// <summary>
        /// The number of cards selected on this column.
        /// </summary>
        private int _numberSelected;

        /// <summary>
        /// Gets or sets the number of cards selected on this column.
        /// </summary>
        public int NumberSelected
        {
            get => _numberSelected;
            set
            {
                if (value < 0 || value > FaceUpCards.Count)
                {
                    throw new InvalidOperationException(
                        "The number selected must be at least 0 and at most the number of face-up cards.");
                }
                _numberSelected = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Constructs the control.
        /// </summary>
        public TableauColumn()
        {
            InitializeComponent();
            Width = CardPainter.CardWidth + 1;
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        /// <param name="e">Data concerning the graphics environment.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // This method redefines the OnPaint method defined within the UserControl class,
            // which is the super-type (or parent) of this class. The following line ensures
            // that everything done by the overridden method is done here.
            base.OnPaint(e);

            Graphics g = e.Graphics;
            CardPainter.DrawBox(g);
            CardPainter.DrawBacks(g, FaceDownCards.Count, 0, 0, _faceDownOffset);
            _faceUpStart = FaceDownCards.Count * _faceDownOffset;
            _faceUpOffset = 0;
            if (FaceUpCards.Count > 1)
            {
                _faceUpOffset = Math.Min(_maxFaceUpOffset,
                    (Height - _faceUpStart - CardPainter.CardHeight) / (FaceUpCards.Count - 1));
            }
            CardPainter.DrawCards(FaceUpCards, g, _faceUpStart, _faceUpOffset);
            if (_numberSelected > 0)
            {
                int boxHeight = CardPainter.CardHeight + (_numberSelected - 1) * _faceUpOffset;
                int boxStart = _faceUpStart + (FaceUpCards.Count - _numberSelected) * _faceUpOffset;
                CardPainter.DrawHighlight(g, boxStart, boxHeight);
            }
        }

        /// <summary>
        /// Finds the number of cards on top of the given y-coordinate, provided this
        /// coordinate is on a face-up card..
        /// </summary>
        /// <param name="y">The y-coordinate.</param>
        /// <returns>The number of cards on top of y. If there are no face-up cards and y is 
        /// on the box indicating the empty column, returns 0. Otherwise, returns -1</returns>
        public int NumberAbove(int y)
        {
            y -= _faceUpStart;
            if (FaceUpCards.Count == 0)
            {
                if (y <= CardPainter.CardHeight)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            if (y < 0 || y > (FaceUpCards.Count - 1) * _faceUpOffset + CardPainter.CardHeight)
            {
                return -1;
            }
            if (y >= FaceUpCards.Count * _faceUpOffset)
            {
                return 1;
            }
            return FaceUpCards.Count - y / _faceUpOffset;
        }

    }
}
