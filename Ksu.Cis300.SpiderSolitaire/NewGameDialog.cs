/* NewGameDialog.cs
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
    /// A dialog for setting up a new game.
    /// </summary>
    public partial class NewGameDialog : Form
    {
        /// <summary>
        /// The text to show initially as the number of suits.
        /// </summary>
        private const string _initialNumberOfSuits = "4";

        /// <summary>
        /// Gets the game number.
        /// </summary>
        public int GameNumber => (int)uxGameNumber.Value;

        /// <summary>
        /// Gets the number of suits.
        /// </summary>
        public int NumberOfSuits => Convert.ToInt32(uxSuits.SelectedItem);

        /// <summary>
        /// Constructs the dialog.
        /// </summary>
        public NewGameDialog()
        {
            InitializeComponent();
            uxSuits.SelectedItem = _initialNumberOfSuits;
        }
    }
}
