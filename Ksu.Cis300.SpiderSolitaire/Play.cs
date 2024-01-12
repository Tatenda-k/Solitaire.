/* Play.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.SpiderSolitaire
{
    /// <summary>
    /// Instances describe a single play.
    /// </summary>
    public class Play
    {
        /// <summary>
        /// Gets the number of cards moved.
        /// </summary>
        public int NumberOfCards { get; }

        /// <summary>
        /// Gets the column from which the cards were moved. If the play is a deal, this value is null.
        /// </summary>
        public TableauColumn? From { get; }

        /// <summary>
        /// Gets the column to which the cards were moved. If the play is a deal, this value is null.
        /// </summary>
        public TableauColumn? To { get; }

        /// <summary>
        /// Gets a stack containing the TableauColumns on which a face-down card was flipped.
        /// </summary>
        public Stack<TableauColumn> CardsFlipped { get; }

        /// <summary>
        /// Gets a stack containing the TableauColumns from which a suit was moved to a home cell.
        /// </summary>
        public Stack<TableauColumn> SuitsCleared { get; }

        /// <summary>
        /// Constructs a play from the given information.
        /// </summary>
        /// <param name="n">The number of cards moved.</param>
        /// <param name="from">The column from which cards were moved.</param>
        /// <param name="to">The column to which cards were moved.</param>
        /// <param name="flipped">Columns on which a card was flipped.</param>
        /// <param name="cleared">Columns on which the play cleared a suit.</param>
        public Play(int n, TableauColumn? from, TableauColumn? to, Stack<TableauColumn> flipped, Stack<TableauColumn> cleared)
        {
            NumberOfCards = n;
            From = from;
            To = to;
            CardsFlipped = flipped;
            SuitsCleared = cleared;
        }
    }
}
