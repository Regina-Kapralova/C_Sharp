using FluentAssertions;
using Moq;
using NUnit.Framework;
using PickyBrideProblem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class FriendTest
    {
        private Hall hall;
        private Friend friend;
        Mock<IContenderGenerator> contenderGenerator;
        List<Contender> contenderList;

        [SetUp]
        public void Setup()
        {
            contenderGenerator = new Mock<IContenderGenerator>();
            contenderList = CreateContenderList();
            contenderGenerator.Setup(contenderGenerator => contenderGenerator.InitContenderList()).Returns(contenderList);
            hall = new Hall(contenderGenerator.Object);
            hall.Init();
            friend = new Friend(hall);
        }
        List<Contender> CreateContenderList()
        {
            var contenders = new List<Contender>();
            contenders.Add(new Contender("Артём", 1));
            contenders.Add(new Contender("Виктор", 2));
            contenders.Add(new Contender("Дмитрий", 3));
            return contenders;
        }

        [Test]
        public void CompareTest()
        {
            IContender firstContender = hall.InviteContender();
            IContender secondContender = hall.InviteContender();
            IContender thirdContender = hall.InviteContender();

            IContender bestContender = friend.Compare(firstContender, secondContender);
            bestContender.Should().Be(secondContender);

            bestContender = friend.Compare(thirdContender, secondContender);
            bestContender.Should().Be(thirdContender);
        }

        [Test]
        public void ThrowExceptionTest()
        {
            IContender invitedContender = hall.InviteContender();
            Contender firstUninvitedContender = contenderList[0];
            Contender secondUninvitedContender = contenderList[1];

            friend.Invoking(f => f.Compare(invitedContender, firstUninvitedContender))
                .Should().Throw<Exception>().WithMessage("Error: contenders cannot be compared!");
            friend.Invoking(f => f.Compare(secondUninvitedContender, invitedContender))
                .Should().Throw<Exception>().WithMessage("Error: contenders cannot be compared!");
            friend.Invoking(f => f.Compare(firstUninvitedContender, secondUninvitedContender))
                .Should().Throw<Exception>().WithMessage("Error: contenders cannot be compared!");
        }
    }
}
