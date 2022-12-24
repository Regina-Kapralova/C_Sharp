using FluentAssertions;
using Moq;
using NUnit.Framework;
using PickyBrideProblem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    class HallTest
    {
        Hall hall;
        List<Contender> contenders;

        [SetUp]
        public void Setup()
        {
            Mock<IContenderGenerator> contenderGenerator = new Mock<IContenderGenerator>();
            contenders = CreateContenderList();
            contenderGenerator.Setup(contenderGenerator => contenderGenerator.InitContenderList()).Returns(contenders);
            hall = new Hall(contenderGenerator.Object);
            hall.Init();
        }
        List<Contender> CreateContenderList()
        {
            var contenders = new List<Contender>
            {
                new Contender("Артём", 1),
                new Contender("Виктор", 2),
                new Contender("Дмитрий", 3)
            };
            return contenders;
        }

        [Test]
        public void InviteContenderTest()
        {
            Contender firstContender = contenders[0];
            Contender secondContender = contenders[1];
            Contender thirdContender = contenders[2];
            hall.InviteContender().Should().Be(firstContender); 
            hall.InviteContender().Should().Be(secondContender); 
            hall.InviteContender().Should().Be(thirdContender); 
        }

        [Test]
        public void ThrowExceptionTest()
        {
            hall.InviteContender();
            hall.InviteContender();
            hall.InviteContender();
            hall.Invoking(f => f.InviteContender())
                .Should().Throw<Exception>().WithMessage("Error: no more contenders!");
        }
    }
}
