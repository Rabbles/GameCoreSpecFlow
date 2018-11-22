using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Linq;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Assist.ValueRetrievers;

namespace GameCore.Specs
{
    [Binding]
    public class PlayerCharacterSteps
    {
        private PlayerCharacter _player;

        [Given(@"I'm a new player")]
        public void GivenImANewPlayer()
        {
            _player = new PlayerCharacter();
        }

        [When("I take (.*) damage")]
        public void WhenITakeDamage(int damage)
        {
            _player.Hit(damage);
        }


        [Then(@"My health should now be (.*)")]
        public void ThenMyHealthShouldNowBe(int expectedHealth)
        {
            Assert.Equal(expectedHealth, _player.Health);
        }




        [Then(@"I should be dead")]
        public void ThenIShouldBeDead()
        {
            Assert.True(_player.IsDead);
        }


        [Given(@"I have a damage resistance of (.*)")]
        public void GivenIHaveADamageResistanceOf(int damageResistance)
        {
            _player.DamageResistance = damageResistance;
        }

        [Given(@"I'm an Elf")]
        public void GivenImAnElf()
        {
            _player.Race = "Elf";
        }

        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowingAttributes(Table table)
        {
            //var attributes = table.CreateInstance<PlayerAttributes>();
            dynamic attributes = table.CreateDynamicInstance();
            _player.Race = attributes.Race;
            _player.DamageResistance = attributes.Resistance;
        }

        //Automatic enum conversion
        [Given(@"my class is set to (.*)")]
        public void GivenMyClassIsSetToHealer(CharacterClass character)
        {
            _player.CharacterClass = character;
        }

        [When(@"cast a healing spell")]
        public void WhenCastAHealingSpell()
        {
            _player.CastHealingSpell();
        }


        [Given(@"I have the following magical items")]
        public void GivenIHaveTheFollowingMagicalItems(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"My total magical power should be (.*)")]
        public void ThenMyTotalMagicalPowerShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }


    }
}
