/* HomeCell.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.SpiderSolitaire
{
    /// <summary>
    /// A drawing of a home cell. Only the top card will be visible.
    /// </summary>
    public partial class HomeCell : UserControl
    {
        /// <summary>
        /// The vertical offset between cards.
        /// </summary>
        private const int _offset = 1;

        /// <summary>
        /// Gets or sets the stack of cards on this cell.
        /// </summary>
        public Stack<Card> Cards { get; } = new();

        /// <summary>
        /// Initializes the control.
        /// </summary>
        public HomeCell()
        {
            InitializeComponent();
            Width = CardPainter.CardWidth + 1;
            Height = CardPainter.CardHeight + _offset * Card.NumberOfRanks;
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        /// <param name="e">Data about the drawing context.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // This method redefines the OnPaint method defined within the UserControl class,
            // which is the super-type (or parent) of this class. The following line ensures
            // that everything done by the overridden method is done here.
            base.OnPaint(e);

            Graphics g = e.Graphics;
            CardPainter.DrawBox(g);
            CardPainter.DrawCards(Cards, g, 0, _offset);
        }
    }
}
