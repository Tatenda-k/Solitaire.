/* Shuffler.cs
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
    /// Contains methods for obtaining a shuffled deck of cards.
    /// </summary>
    public static class Shuffler
    {
        /// <summary>
        /// Gets a new unshuffled stock.
        /// </summary>
        /// <param name="suits">The number of suits to use.</param>
        /// <returns>The stock.</returns>
        private static Card[] GetStock(int suits)
        {
            int numberOfDecks = 2 * Card.NumberOfSuits / suits;
            Card[] stock = new Card[2 * Card.NumberOfRanks * Card.NumberOfSuits];
            int i = 0;
            for (int deck = 0; deck < numberOfDecks; deck++)
            {
                for (Suit suit = 0; (int)suit < suits; suit++)
                {
                    for (int rank = Card.MinumumRank; rank <= Card.MaximumRank; rank++)
                    {
                        stock[i] = new Card(rank, suit);
                        i++;
                    }
                }
            }
            return stock;
        }

        /// <summary>
        /// Replaces the contents of the given stack with a stock of cards in a random order determined
        /// by the given seed. 
        /// </summary>
        /// <param name="seed">The seed for random numbers.</param>
        /// <param name="stock">The stack in which to place the stock.</param>
        /// <param name="suits">The number of suits to use.</param>
        public static void GetShuffledStock(int seed, Stack<Card> stock, int suits)
        {
            Random r = new(seed);
            Card[] a = GetStock(suits);
            stock.Clear();
            for (int i = a.Length - 1; i >= 0; i--)
            {
                int j = r.Next(i + 1);
                stock.Push(a[j]);
                a[j] = a[i];
            }
        }

    }
}
