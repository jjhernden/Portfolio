using System;
using System.Collections.Generic;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ISequence sequence = new Sequence();

            List<ColorChip> bagOfChips = sequence.CreatingBagOfChips();

            List<List<ColorChip>> result = sequence.GetLongestSequence(bagOfChips);
            if (result == null || result.Count == 0)
            {
                    Console.Write(Constants.ErrorMessage);
                    return;
            }
            Console.WriteLine("Determing the longest sequence from this bag of chips:");
            foreach (ColorChip baggedChip in bagOfChips)
            {
                Console.WriteLine($"[{baggedChip.ToString()}]");
            }
            Console.WriteLine($"Longest sequence count: {result[0].Count}");
            Console.Write("Result: ");
            foreach (List<ColorChip> solution in result)
            {    
                foreach (ColorChip chip in solution)        
                {     
                    Console.Write($"[{chip.ToString()}]");    
                }
            }   
        }
    }
}
