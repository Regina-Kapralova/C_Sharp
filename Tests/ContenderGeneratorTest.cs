using FluentAssertions;
using NUnit.Framework;
using PickyBrideProblem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ContenderGeneratorTest
    {
        private List<Contender> _contenderList;
        private int _amountOfContenders;
        private ContenderGenerator _contenderGenerator;

        public ContenderGeneratorTest()
        {
            _contenderGenerator = new ContenderGenerator();
            _amountOfContenders = 100;
            _contenderGenerator.Init(_amountOfContenders);
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
        public void CreateContendersListOf100ContendersTest()
        {
            _contenderList.Count.Should().Be(_amountOfContenders);
        }

        [Test]
        public void ThrowExceptionCreateListOfNegativeAmountContendersTest()
        {
            ContenderGenerator newContenderGenerator = new ContenderGenerator();
            newContenderGenerator.Invoking(f => f.Init(-1))
                .Should().Throw<Exception>().WithMessage("Error: impossible to create list of less than 0 or more than 100 Contenders!");
            newContenderGenerator.Invoking(f => f.Init(-5))
                .Should().Throw<Exception>().WithMessage("Error: impossible to create list of less than 0 or more than 100 Contenders!");
        }

        [Test]
        public void ThrowExceptionCreateListOfAmountMore100ContendersTest()
        {
            ContenderGenerator newContenderGenerator = new ContenderGenerator();
            newContenderGenerator.Invoking(f => f.Init(101))
                .Should().Throw<Exception>().WithMessage("Error: impossible to create list of less than 0 or more than 100 Contenders!");
            newContenderGenerator.Invoking(f => f.Init(150))
                .Should().Throw<Exception>().WithMessage("Error: impossible to create list of less than 0 or more than 100 Contenders!");
        }
    }
}