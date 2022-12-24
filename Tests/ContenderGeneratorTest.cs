using FluentAssertions;
using NUnit.Framework;
using PickyBrideProblem;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
        public class ContenderGeneratorTest
        {
            private List<Contender> _contenderList;
            private int AmountOfContenders;
            private ContenderGenerator _contenderGenerator;
            public ContenderGeneratorTest()
            {
                _contenderGenerator = new ContenderGenerator();
                AmountOfContenders = 100;
                _contenderGenerator.Init(AmountOfContenders);
                _contenderList = _contenderGenerator.InitContenderList();
            }

            [Test]
            public void UniqueNamesTest()
            {
                var contenderNames = _contenderList.Select(contender => contender.Name);
                contenderNames.Should().OnlyHaveUniqueItems();
            }

            [Test]
            public void UniqueMarksTest()
            {
                var contenderMarks = _contenderList.Select(contender => contender.Mark);
                contenderMarks.Should().OnlyHaveUniqueItems();
            }

            [Test]
            public void CreateContendersList_Generates_Exactly100Contenders()
            {
                _contenderList.Count.Should().Be(AmountOfContenders);
            }
        }
    }