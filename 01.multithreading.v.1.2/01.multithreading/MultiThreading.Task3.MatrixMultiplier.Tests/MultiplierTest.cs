using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiThreading.Task3.MatrixMultiplier.Matrices;
using MultiThreading.Task3.MatrixMultiplier.Multipliers;

namespace MultiThreading.Task3.MatrixMultiplier.Tests
{
    [TestClass]
    public class MultiplierTest
    {
        [TestMethod]
        public void MultiplyMatrix3On3Test()
        {
            TestMatrix3On3(new MatricesMultiplier());
            TestMatrix3On3(new MatricesMultiplierParallel());
            ParallelEfficiencyTest();
        }

        [TestMethod]
        public void ParallelEfficiencyTest()
        {
            // todo: implement a test method to check the size of the matrix which makes parallel multiplication more effective than
            // todo: the regular one

            var m1 = new Matrix(9, 9);
            m1.SetElement(0, 0, 34);
            m1.SetElement(0, 1, 2);
            m1.SetElement(0, 2, 6);

            m1.SetElement(1, 0, 5);
            m1.SetElement(1, 1, 4);
            m1.SetElement(1, 2, 54);

            m1.SetElement(2, 0, 2);
            m1.SetElement(2, 1, 9);
            m1.SetElement(2, 2, 8);
            m1.SetElement(0, 0, 34);
            m1.SetElement(0, 1, 2);
            m1.SetElement(0, 2, 6);

            m1.SetElement(1, 0, 5);
            m1.SetElement(1, 1, 4);
            m1.SetElement(1, 2, 54);

            m1.SetElement(2, 0, 2);
            m1.SetElement(2, 1, 9);
            m1.SetElement(2, 2, 8);
            m1.SetElement(0, 0, 34);
            m1.SetElement(0, 1, 2);
            m1.SetElement(0, 2, 6);

            m1.SetElement(1, 0, 5);
            m1.SetElement(1, 1, 4);
            m1.SetElement(1, 2, 54);

            m1.SetElement(2, 0, 2);
            m1.SetElement(2, 1, 9);
            m1.SetElement(2, 2, 8);

            var m2 = new Matrix(9, 9);
            m2.SetElement(0, 0, 12);
            m2.SetElement(0, 1, 52);
            m2.SetElement(0, 2, 85);

            m2.SetElement(1, 0, 5);
            m2.SetElement(1, 1, 5);
            m2.SetElement(1, 2, 54);

            m2.SetElement(2, 0, 5);
            m2.SetElement(2, 1, 8);
            m2.SetElement(2, 2, 9);

            m2.SetElement(0, 0, 12);
            m2.SetElement(0, 1, 52);
            m2.SetElement(0, 2, 85);

            m2.SetElement(1, 0, 5);
            m2.SetElement(1, 1, 5);
            m2.SetElement(1, 2, 54);

            m2.SetElement(2, 0, 5);
            m2.SetElement(2, 1, 8);
            m2.SetElement(2, 2, 9);

            m2.SetElement(0, 0, 12);
            m2.SetElement(0, 1, 52);
            m2.SetElement(0, 2, 85);

            m2.SetElement(1, 0, 5);
            m2.SetElement(1, 1, 5);
            m2.SetElement(1, 2, 54);

            m2.SetElement(2, 0, 5);
            m2.SetElement(2, 1, 8);
            m2.SetElement(2, 2, 9);
            Stopwatch normalstopwatch = Stopwatch.StartNew();
            MatricesMultiplier normal = new MatricesMultiplier();
            var multipliednormal = normal.Multiply(m1, m2);
            var normaltime = normalstopwatch.ElapsedMilliseconds;

            Stopwatch pstopwatch = Stopwatch.StartNew();
            MatricesMultiplierParallel parallel = new MatricesMultiplierParallel();
            var multipliedparallel = parallel.Multiply(m1, m2);
            var paraellelTime = pstopwatch.ElapsedMilliseconds;

            //Assert.AreEqual(448, multiplied.GetElement(0, 0));
            //Assert.AreEqual(1826, multiplied.GetElement(0, 1));
            //Assert.AreEqual(3052, multiplied.GetElement(0, 2));

            //Assert.AreEqual(350, multiplied.GetElement(1, 0));
            //Assert.AreEqual(712, multiplied.GetElement(1, 1));
            //Assert.AreEqual(1127, multiplied.GetElement(1, 2));

            //Assert.AreEqual(109, multiplied.GetElement(2, 0));
            //Assert.AreEqual(213, multiplied.GetElement(2, 1));
            //Assert.AreEqual(728, multiplied.GetElement(2, 2));


            //var m3 = new Matrix(3, 3);
            //m3.SetElement(0, 0, 34);
            //m3.SetElement(0, 1, 2);
            //m3.SetElement(0, 2, 6);

            //m3.SetElement(1, 0, 5);
            //m3.SetElement(1, 1, 4);
            //m3.SetElement(1, 2, 54);

            //m3.SetElement(2, 0, 2);
            //m3.SetElement(2, 1, 9);
            //m3.SetElement(2, 2, 8);

            //var m4 = new Matrix(3, 3);
            //m4.SetElement(0, 0, 12);
            //m4.SetElement(0, 1, 52);
            //m4.SetElement(0, 2, 85);

            //m4.SetElement(1, 0, 5);
            //m4.SetElement(1, 1, 5);
            //m4.SetElement(1, 2, 54);

            //m4.SetElement(2, 0, 5);
            //m4.SetElement(2, 1, 8);
            //m4.SetElement(2, 2, 9);

            //Stopwatch stopwatch1 = Stopwatch.StartNew();
            //stopwatch1.Start();

            //MatricesMultiplier normal = new MatricesMultiplier();
            //var multiplied1 = normal.Multiply(m3, m4);
            //stopwatch1.Stop();
            //TimeSpan ts1 = stopwatch1.Elapsed;

            //Assert.AreEqual(448, multiplied1.GetElement(0, 0));
            //Assert.AreEqual(1826, multiplied1.GetElement(0, 1));
            //Assert.AreEqual(3052, multiplied1.GetElement(0, 2));

            //Assert.AreEqual(350, multiplied1.GetElement(1, 0));
            //Assert.AreEqual(712, multiplied1.GetElement(1, 1));
            //Assert.AreEqual(1127, multiplied1.GetElement(1, 2));

            //Assert.AreEqual(109, multiplied1.GetElement(2, 0));
            //Assert.AreEqual(213, multiplied1.GetElement(2, 1));
            //Assert.AreEqual(728, multiplied1.GetElement(2, 2));

        }

        #region private methods

        void TestMatrix3On3(IMatricesMultiplier matrixMultiplier)
        {
            if (matrixMultiplier == null)
            {
                throw new ArgumentNullException(nameof(matrixMultiplier));
            }

            var m1 = new Matrix(3, 3);
            m1.SetElement(0, 0, 34);
            m1.SetElement(0, 1, 2);
            m1.SetElement(0, 2, 6);

            m1.SetElement(1, 0, 5);
            m1.SetElement(1, 1, 4);
            m1.SetElement(1, 2, 54);

            m1.SetElement(2, 0, 2);
            m1.SetElement(2, 1, 9);
            m1.SetElement(2, 2, 8);

            var m2 = new Matrix(3, 3);
            m2.SetElement(0, 0, 12);
            m2.SetElement(0, 1, 52);
            m2.SetElement(0, 2, 85);

            m2.SetElement(1, 0, 5);
            m2.SetElement(1, 1, 5);
            m2.SetElement(1, 2, 54);

            m2.SetElement(2, 0, 5);
            m2.SetElement(2, 1, 8);
            m2.SetElement(2, 2, 9);

            var multiplied = matrixMultiplier.Multiply(m1, m2);
            Assert.AreEqual(448, multiplied.GetElement(0, 0));
            Assert.AreEqual(1826, multiplied.GetElement(0, 1));
            Assert.AreEqual(3052, multiplied.GetElement(0, 2));

            Assert.AreEqual(350, multiplied.GetElement(1, 0));
            Assert.AreEqual(712, multiplied.GetElement(1, 1));
            Assert.AreEqual(1127, multiplied.GetElement(1, 2));

            Assert.AreEqual(109, multiplied.GetElement(2, 0));
            Assert.AreEqual(213, multiplied.GetElement(2, 1));
            Assert.AreEqual(728, multiplied.GetElement(2, 2));
        }

        #endregion
    }
}
