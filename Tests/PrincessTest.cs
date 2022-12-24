using FluentAssertions;
using Moq;
using NUnit.Framework;
using PickyBrideProblem;
using System;
using System.Collections.Generic;

namespace Tests
{
    class PrincessTest
    {
        private int AmountOfContenders = 100;
        List<Contender> ContenderListForUnmarriedPrincess()
        {
            List<Contender> contendersForUnmarriedPrincess = new List<Contender>();
            for (int i = AmountOfContenders; i > 0; i--)
            {
                string name = "Contender_" + i;
                contendersForUnmarriedPrincess.Add(new Contender(name, i));
            }
            return contendersForUnmarriedPrincess;
        }

        [Test]
        public void PrincessUnmarried()
        {
            Mock<IContenderGenerator> contenderGenerator = new Mock<IContenderGenerator>();
            List<Contender> contendersForUnmarriedPrincess = ContenderListForUnmarriedPrincess();
            contenderGenerator.Setup(contenderGenerator => contenderGenerator.InitContenderList()).Returns(contendersForUnmarriedPrincess);
            Hall hall = new Hall(contenderGenerator.Object);
            Friend friend = new Friend(hall);
            Princess princess = new Princess(hall, friend);
            princess.SelectBridegroom();
            const int LevelHappinessUnmarriedPrincess = 10;
            princess.GetLevelHappiness().Should().Be(LevelHappinessUnmarriedPrincess);
        }

        List<Contender> ContenderListForPrincessMarriedFirstContender()
        {
            List<Contender> contendersForPrincessMarriedFirstContender = new List<Contender>();
            for (int i = 1; i <= 0.3 * AmountOfContenders; i++)
            {
                string name = "Contender_" + i;
                contendersForPrincessMarriedFirstContender.Add(new Contender(name, i));
            }
            contendersForPrincessMarriedFirstContender.Add(new Contender("Contender_100", 100));
            for (int i = (int)0.3 * AmountOfContenders + 1; i <= AmountOfContenders - 1; i++)
            {
                string name = "Contender_" + i;
                contendersForPrincessMarriedFirstContender.Add(new Contender(name, i));
            }
            return contendersForPrincessMarriedFirstContender;
        }

        [Test]
        public void PrincessMarriedFirstContender()
        {
            Mock<IContenderGenerator> contenderGenerator = new Mock<IContenderGenerator>();
            List<Contender> contendersForPrincessMarriedFirstContender = ContenderListForPrincessMarriedFirstContender();
            contenderGenerator.Setup(contenderGenerator => contenderGenerator.InitContenderList()).Returns(contendersForPrincessMarriedFirstContender);
            Hall hall = new Hall(contenderGenerator.Object);
            Friend friend = new Friend(hall);
            Princess princess = new Princess(hall, friend);
            princess.SelectBridegroom();
            const int LevelHappinessPrincessMarriedFirstContender = 20;
            princess.GetLevelHappiness().Should().Be(LevelHappinessPrincessMarriedFirstContender);
        }

        List<Contender> ContenderListForMarriedBadContender()
        {
            List<Contender> contendersForUnhappyPrincess = new List<Contender>();
            for (int i = 1; i <= AmountOfContenders; i++)
            {
                string name = "Contender_" + i;
                contendersForUnhappyPrincess.Add(new Contender(name, i));
            }
            return contendersForUnhappyPrincess;
        }

        [Test]
        public void PrincessMarriedBadContender()
        {
            Mock<IContenderGenerator> contenderGenerator = new Mock<IContenderGenerator>();
            List<Contender> contendersForUnhappyPrincess = ContenderListForMarriedBadContender();
            contenderGenerator.Setup(contenderGenerator => contenderGenerator.InitContenderList()).Returns(contendersForUnhappyPrincess);
            Hall hall = new Hall(contenderGenerator.Object);
            Friend friend = new Friend(hall);
            Princess princess = new Princess(hall, friend);
            princess.SelectBridegroom();
            const int PrincessIsUnhappy = 0;
            princess.GetLevelHappiness().Should().Be(PrincessIsUnhappy);
        }

        List<Contender> ContenderListForThrowExceptionTest()
        {
            List<Contender> contendersForThrowExceptionTest = new List<Contender>();
            contendersForThrowExceptionTest.Add(new Contender("Contender", 1));
            return contendersForThrowExceptionTest;
        }

        [Test]
        public void ThrowExceptionTest()
        {
            Mock<IContenderGenerator> contenderGenerator = new Mock<IContenderGenerator>();
            List<Contender> contendersForThrowExceptionTest = ContenderListForThrowExceptionTest();
            contenderGenerator.Setup(contenderGenerator => contenderGenerator.InitContenderList()).Returns(contendersForThrowExceptionTest);
            Hall hall = new Hall(contenderGenerator.Object);
            Friend friend = new Friend(hall);
            Princess princess = new Princess(hall, friend);
            princess.Invoking(f => f.SelectBridegroom())
                  .Should().Throw<Exception>().WithMessage("Error: no more contenders!");
        }
    }
}
