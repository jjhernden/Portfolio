using System.Collections.Generic;

namespace ChipSecuritySystem
{
    internal interface ISequence
    {
        /// <summary>
        /// Creates a random bag of chips to chose from
        /// </summary>
        /// <returns></returns>
        List<ColorChip> CreatingBagOfChips();

        /// <summary>
        /// Return the solution with the longest sequence
        /// </summary>
        /// <param name="bagOfChips"></param>
        /// <returns></returns>
        List<List<ColorChip>> GetLongestSequence(List<ColorChip> bagOfChips);
    }
}