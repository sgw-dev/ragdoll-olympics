using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests
{
    public class ExampleSuite {
        [UnityTest]
        public IEnumerator ThisIsAnExampleTest()
        {

            //Example of creating a prefab to test
            //ShopManager shop_manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Shop")).GetComponent<ShopManager>();

            // Testing a condition is equal
            Assert.AreEqual(true, true);

            yield return new WaitForSeconds(0.1f); // Because tests are courtines, they must yield a return at some point
        }
    }
}
