/* CardPainter.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.SpiderSolitaire
{
    /// <summary>
    /// Contains constants and static methods/properties for drawing cards.
    /// </summary>
    public static class CardPainter
    {
        /// <summary>
        /// The height of a single card image from the input files.
        /// </summary>
        private const int _cardImageHeight = 333;

        /// <summary>
        /// The width of a single card image from the input files.
        /// </summary>
        private const int _cardImageWidth = 234;

        /// <summary>
        /// The pen used to draw the box where the stock will be placed.
        /// </summary>
        public static readonly Pen BoxPen = new(Color.White);

        /// <summary>
        /// The pen used to highlight selected cards.
        /// </summary>
        private static readonly Pen _highlightPen = new(Color.Magenta, 2);

        /// <summary>
        /// The scale factor for drawing the cards.
        /// </summary>
        private const float _scale = 0.4f;

        /// <summary>
        /// The height of a displayed card drawing.
        /// </summary>
        public static readonly int CardHeight = (int)(_cardImageHeight * _scale);

        /// <summary>
        /// The width of a displayed card drawing.
        /// </summary>
        public static readonly int CardWidth = (int)(_cardImageWidth * _scale);

        /// <summary>
        /// Draws the given stack of cards on the given graphics context at the given y-coordinate.
        /// </summary>
        /// <param name="c">The cards to draw.</param>
        /// <param name="g">The graphics context on which to draw.</param>
        /// <param name="y">The y-coordinate of the upper-left corner.</param>
        /// <param name="offset">The vertical offset between cards.</param>
        public static void DrawCards(Stack<Card> c, Graphics g, int y, int offset)
        {
            Card[] cards = c.ToArray();
            for (int i = cards.Length - 1; i >= 0; i--)
            {
                g.DrawImage(cards[i].Picture, 0, y, CardWidth, CardHeight);
                y += offset;
            }
        }

        /// <summary>
        /// Draws a box the size of a card at the top of the given graphics context.
        /// </summary>
        /// <param name="g">The graphics context on which to draw.</param>
        public static void DrawBox(Graphics g)
        {
            g.DrawRectangle(BoxPen, 0, 0, CardWidth - 1, CardHeight - 1);
        }

        /// <summary>
        /// Draws a sequence of backs of cards on the given graphics context.
        /// </summary>
        /// <param name="g">The graphics context on which to draw.</param>
        /// <param name="n">The number of backs to draw.</param>
        /// <param name="x">The horizontal position to begin drawing.</param>
        /// <param name="xOff">The horizontal offset for each card.</param>
        /// <param name="yOff">The vertical offset for each card.</param>
        public static void DrawBacks(Graphics g, int n, float x, float xOff, float yOff)
        {
            float y = 0;
            for (int i = 0; i < n; i++)
            {
                g.DrawImage(Card.CardBack, x, y, CardWidth, CardHeight);
                x += xOff;
                y += yOff;
            }
        }

        /// <summary>
        /// Draws a highlight box of the given height at the given y-coordinate of the given
        /// graphics context.
        /// </summary>
        /// <param name="g">The graphics context on which to draw.</param>
        /// <param name="y">The y-coordinate of the upper-left corner.</param>
        /// <param name="height">The height of the box.</param>
        public static void DrawHighlight(Graphics g, int y, int height)
        {
            g.DrawRectangle(_highlightPen, 0, y, CardWidth - 1, height - 1);
        }
    }
}
