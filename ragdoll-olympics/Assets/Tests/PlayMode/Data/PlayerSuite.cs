using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerSuite {
        [UnityTest]
        public IEnumerator UpdatingNameTest()
        {
            yield return new WaitForSeconds(0.1f);
            // UpdateName
            string testName = TestUtils.CreateRandomString(new System.Random(), 15);

            Data.Player player = new Data.Player();
            player.playerName = testName;
            Assert.AreEqual(player.playerName, testName);
        }
        [UnityTest]
        public IEnumerator UpdatingMedalsTest()
        {
            yield return new WaitForSeconds(0.1f);
            System.Random random = new System.Random();

            for (int i = 0; i < 500; i++) // Run with 500 variations
            {
                Data.Player player = new Data.Player();

                int gold = random.Next(Data.Player.MIN_MEDALS,Data.Player.MAX_MEDALS);
                int silver = random.Next(Data.Player.MIN_MEDALS,Data.Player.MAX_MEDALS);
                int bronze = random.Next(Data.Player.MIN_MEDALS,Data.Player.MAX_MEDALS);
                int participation = random.Next(Data.Player.MIN_MEDALS,Data.Player.MAX_MEDALS);

                player.goldMedals = gold;
                player.silverMedals = silver;
                player.bronzeMedals = bronze;
                player.participationMedals = participation;
                Assert.AreEqual(player.goldMedals, gold);
                Assert.AreEqual(player.silverMedals, silver);
                Assert.AreEqual(player.bronzeMedals, bronze);
                Assert.AreEqual(player.participationMedals, participation);
                
            }
        }
        [UnityTest]
        public IEnumerator UpdatingMedalsWithNegativeTest()
        {
            yield return new WaitForSeconds(0.1f);
            System.Random random = new System.Random();

            for (int i = 0; i < 500; i++) // Run with 500 variations
            {
                Data.Player player = new Data.Player();

                player.goldMedals = random.Next(-100000000,0);
                player.silverMedals = random.Next(-100000000,0);
                player.bronzeMedals = random.Next(-100000000,0);
                player.participationMedals = random.Next(-100000000,0);
                Assert.AreEqual(player.goldMedals, 0);
                Assert.AreEqual(player.silverMedals, 0);
                Assert.AreEqual(player.bronzeMedals, 0);
                Assert.AreEqual(player.participationMedals, 0);
            }
        }
    }
}
