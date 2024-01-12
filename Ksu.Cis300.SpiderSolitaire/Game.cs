/* Game.cs
 * Author: Rod Howell
 * Edited by Tatenda Sekabanja
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.CodeDom.Compiler;
using System.DirectoryServices.ActiveDirectory;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Security.Cryptography.Xml;

namespace Ksu.Cis300.SpiderSolitaire
{
    /// <summary>
    /// Conrols the game logic for a SpiderSolitaire game.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The number of home cells.
        /// </summary>
        private const int _homeCellCount = 8;

        /// <summary>
        /// The number of tableau columns.
        /// </summary>
        private const int _tableauColumnCount = 10;

        /// <summary>
        /// Gets the stock.
        /// </summary>
        public Stock Stock { get; } = new();

        /// <summary>
        /// Gets the home cells.
        /// </summary>
        public HomeCell[] HomeCells { get; } = new HomeCell[_homeCellCount];

        /// <summary>
        /// Gets the tableau columns.
        /// </summary>
        public TableauColumn[] TableauColumns { get; } = new TableauColumn[_tableauColumnCount];

        /// <summary>
        /// Gets the current score.
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Gets whether a play can be undone.
        /// </summary>
        public bool CanUndo
        {
            get
            {
                return _plays.Count() > 0;
            }
        }



        /// <summary>
        /// the initial score the player starts with
        /// </summary>
        private const int _initScore = 500;

        /// <summary>
        /// award for moving sequence to home cell
        /// </summary>
        private const int _award = 100;
        /// <summary>
        /// the number of milliseconds to pause when making an update
        /// </summary>
        private const int _pause = 10;
        /// <summary>
        /// number of cards to deal face down initially
        /// </summary>
        private const int _fdown = 44;
        /// <summary>
        /// keeps track of the tableau column on which cards are sellected
        /// </summary>
        private TableauColumn? _track;
        /// <summary>
        /// how many sequences habe been moved to home cells
        /// </summary>
        private int _homeCount = 0;
        /// <summary>
        /// tracks the plays that have been made
        /// </summary>
        private Stack<Play> _plays = new();

        /// <summary>
        /// Constructs a Game.
        /// </summary>
        /// 

        public Game()
        {
            for (int i = 0; i < HomeCells.Length; i++)
            {
                HomeCells[i] = new HomeCell();
            }
            for (int i = 0; i < TableauColumns.Length; i++)
            {
                TableauColumns[i] = new TableauColumn();
            }
        }

        /// <summary>
        /// Starts a new game using the given seed.
        /// </summary>
        /// <param name="seed">The seed to use to shuffle the cards.</param>
        /// <param name="suits">The number of suits to use.</param>
        public void StartNewGame(int seed, int suits)
        {
            //clear all stacks on the home cellsclear
            // itterrate through all of the home cells
            //call Move from the home cell to the stock if the home cell has a length >0
            //Homecell[i].Refesh();
            //reset no_ of home cel sequences
            //_homeCount=0;
            Score =_initScore ;
            //reset stack play
            _plays.Clear();
            Deselect();
            //clear all stacks on Tableau Columns
            for (int i = 0; i < TableauColumns.Length; i++)
            {
                TableauColumns[i].FaceDownCards.Clear();
                TableauColumns[i].FaceUpCards.Clear();
                TableauColumns[i].Refresh();

            }
            for(int i=0;i< _homeCellCount; i++)
            {
                HomeCells[i].Cards.Clear();
                HomeCells[i].Refresh();
            }
            _homeCount = 0;
            _plays.Clear();
            Shuffler.GetShuffledStock(seed, Stock.Cards, suits);
            //Set stock , so not shown staggered into groups
            Stock.IsStaggered = false;
            Stock.Refresh();
            int start = Deal(_fdown, 0, false);
            Deal(TableauColumns.Length, start, true);
            Stock.IsStaggered = true;
            Stock.Refresh();
            _track = null;
        }

        /// <summary>
        /// Reacts to the user's click on a tableau column.
        /// </summary>
        /// <param name="col">The column clicked.</param>
        /// <param name="n">The number of cards chosen.</param>
        public void ClickColumn(TableauColumn col, int n)
        {
            //click on faceup card
            //prog will attempt to select all cards, and all on top of it
            //if the sequence is moveable, select
            //otherwise ignore
            if (_track == null)
            {
                if ( n==1 ||n>1 && (MovSeq(col.FaceUpCards,n)))
                {

                    col.NumberSelected = n;
                    //MoveOrder(col.FaceUpCards, _plays, n);
                    //record _plays
                    _track = col;
                   // _track.NumberSelected = n;
                }
            }
            else if (_track!= col)
            {
                // make attempt to move selected cards onto clicked card
                //is the sequence moveable
                //bool possible = MovSeq(_track.FaceUpCards, _track.NumberSelected);
            //    if (possible)
                {
                    bool moved; 	

                    if (_track.NumberSelected > 0)
                    {   //is it possible to move it to the clicked card
                        moved = MoveOrder(_track.FaceUpCards, col.FaceUpCards, _track.NumberSelected, true);
                    }
                    else
                    {
                        moved = MoveOrder(_track.FaceUpCards, col.FaceUpCards, _track.NumberSelected, false);
                    }
                    if (moved)
                    {
                        Stack<TableauColumn> flip = new Stack<TableauColumn>();
                        Stack<TableauColumn> clear = new Stack<TableauColumn>();
                        //if th move leaveas a face down card flip
                        //not sure about clear and flip
                        TryFlip(_track, flip);
                        //MessageBox.Show(flip.Count.ToString());
                        //if the move makes a 13 wequence clear
                        TryClear(col, clear);
                        //MessageBox.Show(flip.Count.ToString());
                        //if removoving the 13 sequence leaves a face down card
                        TryFlip(col, flip);
                        //MessageBox.Show(flip.Count.ToString());

                        _plays.Push(new Play(_track.NumberSelected, _track, col, flip, clear));
                //      MessageBox.Show("Pushed to  play");
                  //    MessageBox.Show(_track.NumberSelected.ToString());
                    //  MessageBox.Show(flip.Count.ToString());
                     // MessageBox.Show(clear.Count.ToString());
                        ///update the score for the move that was made
                        Score -= 1;

                    }
                }
                Deselect();
            }
            else
            {
                Deselect();
            }

        }
        //if clicked whle a sequence is selected, make attempt to move selected cards onto clicked card
        //successful move if card is uncoverd, and legal
        //if successful, move cards accordingly, and enable undo item, 
        //if the move leaves a face down card, flip the card
        //if the move is 13 cards long, move to next empty home cell
        //flip if necessary, update scoring. 
        //remove selection
        //record moves on stack plays


        //if empty tableau clicked, while no cards selected, ignore
        //move selected cards to tablesau, remove selection
        //flip if remaining card is facedown, update scoring

        //stock area, first remove all selections. if no empty tableaus, deal 10 cards face up from left to right
        //animate like the initial deal
        //if a valid 13 sequence is found, move the sequences to empty home cell
        //flip if necessary, update scoring



        /// <summary>
        /// Reacts to the user's clicking the stock.
        /// </summary>
        public void ClickStock()
        {
            //if we deal cards
            ////record this on play
            /////need two Stack<tableau Colums>
            //checked whether any seq can be moved to home
            //if any face down card need flip
            //  use any int when constructing the Play, but both TableauColumn
            //  parameters to this constructor should be null to indicated that the play was a deal.
            bool deal = true;
            for (int i = 0; i < _tableauColumnCount; i++)
           {      //first make sure there are no blank tableau columns
                if (TableauColumns[i].FaceUpCards.Count <=0)
                {
                    deal = false;
                }
            }
            if (Stock.Cards.Count < 1)
            {
                deal = false;
            }
            if (deal)
            {   //deal the cards
                Deal(_tableauColumnCount, 0, true);
                //try and see if we found a 13 sequence on any of the tableaus
                Stack<TableauColumn> flip = new Stack<TableauColumn>();
                Stack<TableauColumn> clear = new Stack<TableauColumn>();
                _plays.Push(new Play(0, null, null, flip,clear));
         //     MessageBox.Show("dealing and pushed");

                for (int k = 0; k < _tableauColumnCount; k++)
                {


                    TryClear(TableauColumns[k], clear);
                    TryFlip(TableauColumns[k], flip);
                    if (clear.Count > 0)
                    {
                 //     MessageBox.Show("clearing and pushing");
                        _plays.Push(new Play(_tableauColumnCount, null, null, flip, clear));
                    }
                }

            }
            

        }
        /// <summary>
        /// move the given number of cards from one stack to the other.
        /// </summary>
        /// <param name="from"> the stack from which we are moving</param>
        /// <param name="to">the stack to which we are moving</param>
        /// <param name="no"> the number of cards to move</param>
        private static void MoveCards(Stack<Card> from, Stack<Card> to, int no)
        {
            for (int i = 0; i < no; i++)
            {
                Card popped = from.Pop();
                to.Push(popped);
            }

        }
        /// <summary>
        /// move a sequence of cards from one position to another
        /// </summary>
        /// <param name="from">the cards we want to move</param>
        /// <param name="to"> the stack of cards we want to move to </param>
        /// <param name="no"> the number of cards we want to move</param>
        /// <param name="check"> if we should check that a move would be valid </param>
        /// <returns>whether the move was made</returns>
        private static bool MoveOrder(Stack<Card> from, Stack<Card> to, int no, bool check)
        {
            Stack<Card> temp = new();
            MoveCards(from, temp, no);
            bool valid = false;

            if (check)
            {
                //if (to.Count > 0)
                if (to.Count > 0)
                {
                    Card next = temp.Peek();
                    Card preceed = to.Peek();
                    valid = true;
                    //make sure the  move is valid
                    if (preceed.Rank == next.Rank + 1)
                    {
                        while (temp.Count > 0)
                        {
                            to.Push(temp.Pop());
                        }
                    }
                    else
                    {
                        //transfer back from temp to from
                        while (temp.Count > 0)
                        {
                            from.Push(temp.Pop());
                        }

                        valid = false;
                        // }
                    }
                    return valid;
                }
                else
                {
                    while (temp.Count > 0)
                    {
                        to.Push(temp.Pop());
                    }
                    return true;
                }

            }
            else
            {
                //incase there are no cards on the destination stack, push and return true
                while (temp.Count > 0)
                {
                    to.Push(temp.Pop());
                }
                return true;
            }

        }
        /*
            
            .A card can be flipped if the column has at least one face-down card and no face-up cards.
            Use one of the above methods to move the card from one stack to the other.
            If you flip a card, push the TableauColumn onto the given stack.
         */
        /// <summary>
        /// try to flip the top face-down card on a tableau column
        /// </summary>
        /// <param name="col"> on which the card is to be flipped </param>
        /// <param name="accum">stack where TableauColumns with flip*ped cards are accumulated</param>
        private static void TryFlip(TableauColumn col, Stack<TableauColumn> accum)
        {
            //make sure thta the colum has >=1 face down, and no cards in it are face-up
            //flip the card from col,
            //get the face down cards
            //if we flip, puch col onto accum
            if (col.FaceDownCards.Count > 0 && col.FaceUpCards.Count == 0)
            {
                accum.Push(col);
                Stack<Card> temp = new();

                MoveCards(col.FaceDownCards, temp, 1);
                // add the card to the face up cards
                col.FaceUpCards.Push(temp.Pop());
                //do we need t
            }

        }
        /// <summary>
        /// deals a given number of cards
        /// </summary>
        /// <param name="no">the number of cards to deal.</param>
        /// <param name="ind">the index of the TableauColumn on which to deal the first card.</param>
        /// <param name="up">whether the cards should be dealt face up.</param>
        /// <returns> the index of the next TableauColumn, on which a card should be dealt</returns>

        /////
        private int Deal(int no, int ind, bool up)
        {

            // call the MoveCards( from stock, temp, no)
            //how to access stock
            //transfer each card
            for (int i = 0; i < no; i++)
            {
                if (ind == TableauColumns.Length)
                {
                    ind = 0;
                }
                Card popped = Stock.Cards.Pop();
                if (!up)
                {
                    TableauColumns[ind].FaceDownCards.Push(popped);
                }
                else
                {
                    TableauColumns[ind].FaceUpCards.Push(popped);
                }
                Stock.Refresh();
                TableauColumns[ind].Refresh();
                ind += 1;
                Thread.Sleep(_pause);

            }
            // then we need to pop from temp, and append it to the corresponding tableau index
            // if the cards are face up
            //refresh the stock and tableau calling Refresh()
            //reset to index 0 after we reach the end index
            //return index + 1 if still in bounds
                 
            


                if (ind == TableauColumns.Length)
            {
                return 0;
            }
            else
            {
                return ind ;
            }

        }
        /// <summary>
        /// transfers cards from the tableau back to the stock one at a time
        /// </summary>
        private void UnDeal()
        {
            //transfer a single card from each tableau col from right to left to the stock 
            for (int i = TableauColumns.Length - 1; i >= 0; i--)
            {
                Stack<Card> temp = new();
                MoveCards(TableauColumns[i].FaceUpCards, temp, 1);
                Card popped = temp.Pop();
                Stock.Cards.Push(popped);
                Stock.Refresh();
                TableauColumns[i].Refresh();
            }
            //use one of the above methods to transfer
            // animate as above
            //start from right, tableau 9
            //call Moves(from Tableau 9, temp,1)
            // then pop from temp, and add the popped to the stack
            //decrease the index by 1
            //when the index reaches 0, reset to 9 
            //call Refresh (STock) and column tableau

        }
        /// <summary>
        /// determines whether a given stack contains a moveable sequence of seqLen at its top
        /// </summary>
        /// <param name="check">the stack to check</param>
        /// <param name="seqLen">the length of the sequence we want to check </param>
        /// <returns> if check contains a moveable sequence of seqLen</returns>
        private static bool MovSeq(Stack<Card> check, int seqLen)
        {
            //assum seqLen > 0
            //Get rank and suit of the top card on check
            int cnt = 0;
            Card popped = check.Peek();
            int rank = popped.Rank ;
            Suit suit = popped.Suit;
            int start = rank;
            foreach (Card card in check)
            {
               if(cnt < seqLen)
                {
                    if (card.Rank != rank || card.Suit != suit)
                    {
                        return false;
                    }
                    rank += 1;
                }
                cnt += 1;
            }
            return rank-start==seqLen;
            //use foreach to itterate throught the stack from top to bottom
            //itterate from top to bottom
            //make sure that the next card we pop has the same suit and rank-1
            //if wrong number or wrong suit return fasle
            //at each itteration if start-rank=seqLen+1 return True
            //if we have completed the loop then the stack is moveable, but shorter than given length
            //so retrun false -pause

        }
        /// <summary>
        /// try to clear a complete suit from a tableau column
        /// </summary>
        /// <param name="col"> the tableau col we are trying to clear/ reduce</param>
        /// <param name="stack">on which TableauColumns from which suits have been removed are accumulated</param>
        private void TryClear(TableauColumn col, Stack<TableauColumn> stack)
        {
            // if call MovSeq(stack, col,Card.MaximumRank)
            if (MovSeq(col.FaceUpCards, Card.NumberOfRanks))
            {
                //then  mov sequence to home cell
                //get the sequence, push it to the home cell
                //sequence the top 13 cards in the current tableau
                //so pop from col, 13 times and push to home cell
                //t i = Card.NumberOfRanks;
                //while (i > 0)
                //{
                //Card pop = col.FaceUpCards.Pop();
                //HomeCells[0].Cards.Push(pop);
                //i -= 1;
                //find next available home cell
                MoveOrder(col.FaceUpCards, HomeCells[_homeCount].Cards, Card.NumberOfRanks, false);
              //}
                Score += _award;
                _homeCount += 1;
                stack.Push(col);
            }
            //uncover favce down cards

            //update number of sequences that have been moved to home cells
            //_homeCellCount+=1
            // Score+=?
            //push col onto stack
            //
            //Card.NumberOfRanks
        }
        /// <summary>
        /// deselect any currently selected cards
        /// </summary>
        private void Deselect()
        {
            //First, determine whether there is a column containing selected cards.
            //1.Set the number of selected cards on that column to 0.
            //2.Refresh the column so that the GUI is updated.
            //3.Set the field keeping track of the column containing selected cards to null.
            //is there a column containingselected cards
            // go through all the columns and check if there is one that has selected cards
            for (int i = 0; i < TableauColumns.Length; i++)
            {
                if (TableauColumns[i].NumberSelected > 0)
                {
                    TableauColumns[i].NumberSelected = 0;
                    TableauColumns[i].Refresh();
                    _track = null;
                }
            }
        }

        /// <summary>
        /// Undoes the last play.
        /// </summary>
        public void Undo()
        {
            Deselect();
            //update score
            Score -= 1;
            Play prev = _plays.Pop();
            //  For each TableauColumn in the stack of columns on which cards were flipped, 
            // move the top face-up card to the stack of face-down cards.
            //access the _tableau columns fr flipped cards
            while (prev.CardsFlipped.Count > 0)
            {
                TableauColumn pres = prev.CardsFlipped.Pop();
                //tried to undo, but ther 
                //we have a problem when unflipping cards, we want to  get from the face up cards, and move to face down cards
                //, but then we have no face up cards
                // during the undo, when we undo, some cards remain face down, but they need to be flipped and added to the face up cards
                //so when we try to ctrlz, and access , he face up cards, there's nothing to flip,
                //so make sure to add to th face up cards
                // or maybe, the flip isn't being pushed , 
                Card top = pres.FaceUpCards.Pop();

                pres.FaceDownCards.Push(top);
                //   MessageBox.Show("flipping cards");

            }

            while (prev.SuitsCleared.Count > 0)
            {
                TableauColumn pres = prev.SuitsCleared.Pop();
                Stack<Card> temp = new();
                //move cards from home cell count to temp
                MoveCards(HomeCells[_homeCount-1].Cards, temp, HomeCells[_homeCount - 1].Cards.Count);
                int x = temp.Count;
                for (int i = 0; i < x; i++)
                {
                    pres.FaceUpCards.Push(temp.Pop());

                }
                _homeCount--;
                Score -= _award;


            }
            
             if (prev.From != null)
             {
           //    MessageBox.Show("changing from to ");
                 Stack<Card> temp = new Stack<Card>();
                 //ssageBox.Show(prev.To.FaceUpCards.Count.ToString());
                 //we will only access the To if a move was made / if To is not null
                 MoveCards(prev.To!.FaceUpCards, temp, prev.NumberOfCards);
                 while (temp.Count > 0)
                 {
                     prev.From.FaceUpCards.Push(temp.Pop());
                   //MessageBox.Show("adding");
                 }
             }
            
            //For each TableauColumn in the stack of columns from which complete suits were removed, 
            //move the cards from the last occupied HomeCell to this TableauColumn.
            //Be sure to update the number of sequences that have been moved to home cells
            //the card is not being flipped,
            //the card is not returning

            //If either TableauColumn in the Play is null, undeal a set of cards;
            //otherwise, undo the move of the card sequence.
            if (prev.From == null)
            {
                UnDeal();
            }


        }
    }
}

