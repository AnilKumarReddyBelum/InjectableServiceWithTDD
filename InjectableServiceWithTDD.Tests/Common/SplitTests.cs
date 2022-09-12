using FluentAssertions;
using InjectableServiceWithTDD.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectableServiceWithTDD.Tests.Common
{
    [TestFixture]
    public class SplitTests
    {
        [Test]
        public void Split_CanConnect_WithGiven_TheCorrect_ApiKey()
        {
            var split = new Split(ApiKey.Value());
            split.SDK.Should().NotBeNull();
        }

        [Test]
        public void Split_CannotBeConnect_WithGiven_TheInCorrect_ApiKey()
        {
            Action split = () => new Split("Wrong Key");
            split.Should().Throw<Exception>();
        }

        [Test]
        public void Split_CannotBeConnect_WithGiven_TheBlank_ApiKey()
        {
            Action split = () => new Split("");
            split.Should().Throw<Exception>().WithMessage("API Key should be set to initialize Split SDK.");
        }

        [Test]
        public void Split_ReturnsOn_WhenUser_PresentInSegment()
        {
            var split = new Split(ApiKey.Value());
            var sut = split.SDK.GetTreatment("AFUser1", "AF_Cache_Service");
            sut.Should().Be("on");
        }

        [Test]
        public void Split_ReturnsOff_WhenUser_NotPresentInSegment()
        {
            var split = new Split(ApiKey.Value());
            var sut = split.SDK.GetTreatment("AFUser2", "AF_Cache_Service");
            sut.Should().Be("off");
        }


        [Test]
        public void Split_ReturnControl_WhenBlankUser_IsPassed_ToTreatment()
        {
            var split = new Split(ApiKey.Value());
            var sut = split.SDK.GetTreatment("", "AF_Cache_Service");
            sut.Should().Be("control");
        }


    }
}
