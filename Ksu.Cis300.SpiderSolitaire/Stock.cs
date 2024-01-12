/* Stock.cs
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
    /// A control representing the stock.
    /// </summary>
    public partial class Stock : UserControl
    {
        /// <summary>
        /// The offset to use for single cards.
        /// </summary>
        private const float _cardOffset = 0.5f;

        /// <summary>
        /// The number of cards in a group;
        /// </summary>
        private const int _groupSize = 10;

        /// <summary>
        /// The maximum number of groups expected (not enforced).
        /// </summary>
        private const int _maxGroups = 5;

        /// <summary>
        /// Gets the cards in the stock.
        /// </summary>
        public Stack<Card> Cards { get; } = new();

        /// <summary>
        /// Gets or sets whether the stock should be shown as staggered into groups.
        /// </summary>
        public bool IsStaggered { get; set; }

        /// <summary>
        /// Constructs the control.
        /// </summary>
        public Stock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Signals a Paint event on this control. This method is called whenever the control needs
        /// to be redrawn.
        /// </summary>
        /// <param name="e">Information about the event.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // This method redefines the OnPaint method defined within the UserControl class,
            // which is the super-type (or parent) of this class. The following line ensures
            // that everything done by the overridden method is done here.
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.DrawRectangle(CardPainter.BoxPen, 0, 0, Width - 1, Height - 1);
            float gapOffset = 0;
            if (IsStaggered)
            {
                gapOffset = (Width - _maxGroups * _groupSize * _cardOffset - CardPainter.CardWidth) / (_maxGroups - 1);
            }
            float x = 0;
            int groups = Cards.Count / _groupSize;
            for (int i = 0; i < groups; i++)
            {
                CardPainter.DrawBacks(g, _groupSize, x, _cardOffset, 0);
                x += gapOffset + _groupSize * _cardOffset;
            }
            CardPainter.DrawBacks(g, Cards.Count % _groupSize, x, _cardOffset, 0);
        }
    }
}
