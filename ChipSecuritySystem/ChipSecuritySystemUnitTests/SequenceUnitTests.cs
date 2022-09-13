using NUnit.Framework;

namespace ChipSecuritySystem
{
    public class SequenceUnitTests
    {
        /// <summary>
        /// Sequence object
        /// </summary>
        Sequence sequence;

        /// <summary>
        /// Setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
            sequence = new Sequence();
        }

        /// <summary>
        /// Unit test to test creating a bag of chips
        /// </summary>
        [Test]
        public void CreatingBagOfChipsTest()
        {
            
            List<ColorChip> result = sequence.CreatingBagOfChips();

            Assert.IsTrue(result.Any());
        }

        /// <summary>
        /// Unit test for getting a single sequence
        /// </summary>
        [Test]
        public void GetLongestSequenceTest_SingleSequenceExists()
        {
            List<ColorChip> bagOfColoredChips = new List<ColorChip>
            {
                    new ColorChip(Color.Blue, Color.Yellow),
                    new ColorChip(Color.Yellow, Color.Green)
            };

            List<List<ColorChip>> expectedResult = new List<List<ColorChip>>
            {
                new List<ColorChip>
                {
                    new ColorChip(Color.Blue, Color.Yellow),
                    new ColorChip(Color.Yellow, Color.Green)
                }
            };

            List<List<ColorChip>> actualresult = sequence.GetLongestSequence(bagOfColoredChips);

            for (int i = 0; i < actualresult.Count; i++)
            {
                for (int a = 0; a < actualresult.Count; a++)
                {
                    Assert.AreEqual(expectedResult[i][a].StartColor, actualresult[i][a].StartColor);
                    Assert.AreEqual(expectedResult[i][a].EndColor, actualresult[i][a].EndColor);
                }
            }

            Assert.IsTrue(expectedResult.Count == actualresult.Count);
        }

        /// <summary>
        /// Unit test where there are multiple solutions but the longest one is returned
        /// </summary>
        [Test]
        public void GetLongestSequenceTest_MultipleSequencesExists_ReturnGreaterLength()
        {
            List<ColorChip> bagOfColoredChips = new List<ColorChip>
            {
                    new ColorChip(Color.Blue, Color.Yellow),
                    new ColorChip(Color.Yellow, Color.Green),
                    new ColorChip(Color.Yellow, Color.Orange),
                    new ColorChip(Color.Orange, Color.Green)
            };

            List<List<ColorChip>> expectedResult = new List<List<ColorChip>>
            {
                new List<ColorChip>
                {
                    new ColorChip(Color.Blue, Color.Yellow),
                    new ColorChip(Color.Yellow, Color.Orange),
                    new ColorChip(Color.Orange, Color.Green)
                }
            };

            List<List<ColorChip>> actualresult = sequence.GetLongestSequence(bagOfColoredChips);

            for (int i = 0; i < actualresult.Count; i++)
            {
                for (int a = 0; a < actualresult.Count; a++)
                {
                    Assert.AreEqual(expectedResult[i][a].StartColor, actualresult[i][a].StartColor);
                    Assert.AreEqual(expectedResult[i][a].EndColor, actualresult[i][a].EndColor);
                }
            }

            Assert.IsTrue(expectedResult.Count == actualresult.Count);

        }

        /// <summary>
        /// Unit test for there are mutliple solutions and they are both the longest sequence
        /// </summary>
        [Test]
        public void GetLongestSequenceTest_MultipleSequencesExists_ReturnMultipleSolutions()
        {
            List<ColorChip> bagOfColoredChips = new List<ColorChip>
            {
                    new ColorChip(Color.Blue, Color.Yellow),
                    new ColorChip(Color.Blue, Color.Orange),
                    new ColorChip(Color.Yellow, Color.Green),
                    new ColorChip(Color.Orange, Color.Green)
            };

            List<List<ColorChip>> expectedResult = new List<List<ColorChip>>
            {
                new List<ColorChip>
                {
                    new ColorChip(Color.Blue, Color.Yellow),
                    new ColorChip(Color.Yellow, Color.Green)
                },
                new List<ColorChip>
                {
                    new ColorChip(Color.Blue, Color.Orange),
                    new ColorChip(Color.Orange, Color.Green)
                }
            };

            List<List<ColorChip>> actualresult = sequence.GetLongestSequence(bagOfColoredChips);

            for (int i = 0; i < actualresult.Count; i++)
            {
                for (int a = 0; a < actualresult.Count; a++)
                {
                    Assert.AreEqual(expectedResult[i][a].StartColor, actualresult[i][a].StartColor);
                    Assert.AreEqual(expectedResult[i][a].EndColor, actualresult[i][a].EndColor);
                }
            }

            Assert.IsTrue(expectedResult.Count == actualresult.Count);
        }

        /// <summary>
        /// Unit test for multiple solutions but they are the same solution, only returns one
        /// </summary>
        [Test]
        public void GetLongestSequenceTest_DuplicateSolutions_ReturnOneSolution()
        {
            List<ColorChip> bagOfColoredChips = new List<ColorChip>
            {
                    new ColorChip(Color.Blue, Color.Yellow),
                    new ColorChip(Color.Yellow, Color.Green),
                    new ColorChip(Color.Yellow, Color.Green)
            };

            List<List<ColorChip>> expectedResult = new List<List<ColorChip>>
            {
                new List<ColorChip>
                {
                    new ColorChip(Color.Blue, Color.Yellow),
                    new ColorChip(Color.Yellow, Color.Green)
                }
            };

            List<List<ColorChip>> actualresult = sequence.GetLongestSequence(bagOfColoredChips);

            for (int i = 0; i < actualresult.Count; i++)
            {
                for (int a = 0; a < actualresult.Count; a++)
                {
                    Assert.AreEqual(expectedResult[i][a].StartColor, actualresult[i][a].StartColor);
                    Assert.AreEqual(expectedResult[i][a].EndColor, actualresult[i][a].EndColor);
                }
            }

            Assert.IsTrue(expectedResult.Count == actualresult.Count);


        }

        /// <summary>
        /// Unit test where there are no solutions, returns an empty list.
        /// </summary>
        [Test]
        public void GetLongestSequenceTest_NoSolutionsExist_ReturnEmptyList()
        {
            List<ColorChip> bagOfColoredChips = new List<ColorChip>
            {
                    new ColorChip(Color.Blue, Color.Yellow),
                    new ColorChip(Color.Yellow, Color.Orange),
            };

            List<List<ColorChip>> actualresult = sequence.GetLongestSequence(bagOfColoredChips);

            Assert.IsTrue(actualresult.Count == 0);
        }

        /// <summary>
        /// Unit test where the bag is null, then the sequence will return null
        /// </summary>
        [Test]
        public void GetLongestSequenceTest_BagOfChipsIsNull_returnNull()
        {
            List<List<ColorChip>> actualResult = sequence.GetLongestSequence(null);

            Assert.IsNull(actualResult);
        }
    }
}