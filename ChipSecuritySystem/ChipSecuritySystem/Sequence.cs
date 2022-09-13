using System;
using System.Collections.Generic;
using System.Linq;

namespace ChipSecuritySystem
{
    public class Sequence : ISequence
    {
        /// <summary>
        /// Temporty Sequence used when trying to find solutions
        /// </summary>
        private static List<ColorChip> tempSequence;

        /// <summary>
        /// List that has all possible solutions
        /// </summary>
        private static List<List<ColorChip>> allPossibleSolutions;

        /// <summary>
        /// Sequence constructor
        /// </summary>
        public Sequence()
        {
            tempSequence = new List<ColorChip>();
            allPossibleSolutions = new List<List<ColorChip>>();
        }

        /// <summary>
        /// Creates a random bag of chips to chose from
        /// </summary>
        /// <returns></returns>
        public List<ColorChip> CreatingBagOfChips()
        {
            Random random = new Random();
            List<ColorChip> bagOfColoredChips = new List<ColorChip>();
            int numberOfChipsInBag = random.Next(1, 10);
            
            while (numberOfChipsInBag > 0)
            {
                ColorChip chip = new ColorChip((Color)random.Next(5), (Color)random.Next(5));
                bagOfColoredChips.Add(chip);
                numberOfChipsInBag--;
            }

            return bagOfColoredChips;
        }

        /// <summary>
        /// Return the solution with the longest sequence
        /// </summary>
        /// <param name="bagOfChips"></param>
        /// <returns></returns>
        public List<List<ColorChip>> GetLongestSequence(List<ColorChip> bagOfChips)
        {
            int max = 0;
            if (bagOfChips == null)
            {
                Console.WriteLine("Bag of chips is null.");
                return null;
            }

            try
            {
                SequenceOfChips(GetStartingChips(bagOfChips), bagOfChips);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error has occured: {ex.Message}, {ex.StackTrace}");
                throw;
            }
      
                
            for (int i = 0; i < allPossibleSolutions.Count; i++)
            { 
                if (allPossibleSolutions[i].Count > max)
                {
                        max = allPossibleSolutions[i].Count;
                }
            }
            return allPossibleSolutions.Where(solution => solution.Count == max).ToList();
        }

        /// <summary>
        /// Finds all possible solutions and add thems to the AllPossibleSolutionsList
        /// </summary>
        /// <param name="currentChips"></param>
        /// <param name="bagOfChips"></param>
        private void SequenceOfChips(List<ColorChip> currentChips, List<ColorChip> bagOfChips)
        {
            if (currentChips == null || bagOfChips == null)
            {
                Console.WriteLine("Parameter requirements not met.");
                return;
            }
            if (currentChips.Count == 0 || bagOfChips.Count == 0)
            {
                Console.WriteLine("Parameter requirements not met.");
                return;
            }

            for (int i = 0; i < currentChips.Count; i++)
            {
                tempSequence.Add(currentChips[i]);
                bagOfChips.Remove(currentChips[i]);
                if (currentChips[i].EndColor == Color.Green)
                {
                    try
                    {
                        AddPossibleSolution(tempSequence);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error has occured: {ex.Message}, {ex.StackTrace}");
                        throw;
                    }

                    List<ColorChip> nextChipsAfterGreen = GettingNextSetOfChips(currentChips[i], bagOfChips);
                    if (nextChipsAfterGreen == null)
                    {
                        Console.WriteLine("Problem with getting next chips. Value came back as null.");
                        return;
                    }
                    if (nextChipsAfterGreen.Count > 0)
                    {
                        SequenceOfChips(nextChipsAfterGreen, bagOfChips);
                        tempSequence.Remove(currentChips[i]);
                        bagOfChips.Add(currentChips[i]);
                        continue;
                    }
                    else
                    {
                        tempSequence.Remove(currentChips[i]);
                        bagOfChips.Add(currentChips[i]);
                        continue;
                    }
                }
                else
                {
                    List<ColorChip> nextChips = GettingNextSetOfChips(currentChips[i], bagOfChips);
                    if (nextChips == null)
                    {
                        Console.WriteLine("Problem with getting next chips. Value came back as null.");
                        return;
                    }
                    if (nextChips.Count > 0)
                    {
                        SequenceOfChips(nextChips, bagOfChips);
                        tempSequence.Remove(currentChips[i]);
                    }
                    else
                    {
                        tempSequence.Remove(currentChips[i]);
                        bagOfChips.Add(currentChips[i]);
                        continue;
                    }
                }

                bagOfChips.Add(currentChips[i]);
            }
        }

        /// <summary>
        /// Find possible starting chips assuming it starts with blue
        /// </summary>
        /// <param name="bagOfChips"></param>
        /// <returns></returns>
        private List<ColorChip> GetStartingChips(List<ColorChip> bagOfChips)
        {
            if (bagOfChips == null)
            {
                Console.WriteLine("Paremeter Requirements not met.");
                return null;
            }
            if (bagOfChips.Count == 0)
            {
                Console.WriteLine("Paremeter Requirements not met.");
                return null;
            }

            return bagOfChips.Select(chip => chip).Where(chip => chip.StartColor == Color.Blue).ToList();
        }

        /// <summary>
        /// Find next set of chips based on the last previous chip
        /// </summary>
        /// <param name="previousChip"></param>
        /// <param name="bagOfChips"></param>
        /// <returns></returns>
        private List<ColorChip> GettingNextSetOfChips(ColorChip previousChip, List<ColorChip> bagOfChips)
        {
            if (bagOfChips == null)
            {
                Console.WriteLine("Paremeter Requirements not met.");
                return null;
            }
            return bagOfChips.Select(chip => chip).Where(chip => chip.StartColor == previousChip.EndColor).ToList();
        }

        /// <summary>
        /// Add a solution to the possible solutions list
        /// </summary>
        /// <param name="tempSequence"></param>
        private void AddPossibleSolution(List<ColorChip> tempSequence)
        {
            if (tempSequence == null)
            {
                Console.WriteLine("Tempory sequence has no sequence to add.");
                return;
            }

            if (tempSequence.Count == 0)
            {
                Console.WriteLine("Tempory sequence has no sequence to add.");
                return;
            }

            ColorChip[] possibleSolutionArray = new ColorChip[tempSequence.Count];
            tempSequence.CopyTo(possibleSolutionArray);
            List<ColorChip> possibleSolution = possibleSolutionArray.ToList();
            bool duplicate = false;
               
            foreach (List<ColorChip> solution in allPossibleSolutions)
            {
                for (int i = 0; i < solution.Count; i++)
                {
                    if (possibleSolution[i].StartColor == solution[i].StartColor
                        && possibleSolution[i].EndColor == solution[i].EndColor
                        && solution.Count == possibleSolution.Count)
                    {
                        duplicate = true;
                    }
                    else
                    {
                        duplicate = false;
                        break;
                    }
                }
                if (duplicate)
                {
                    break;
                }
            }
            if (!duplicate)
            {
                allPossibleSolutions.Add(possibleSolution);
            }
        }
    }
}