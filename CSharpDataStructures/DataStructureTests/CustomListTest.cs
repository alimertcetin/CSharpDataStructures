﻿using System.Collections.Generic;

namespace XIV.DataStructures.Test
{
    public class CustomListTest : DataStructureTest
    {
        const int maximumItemLimit = 100000000;

        public override void Main()
        {
            base.Main();

            stopwatch.Start();
            var list = new List<int>(maximumItemLimit);
            stopwatch.Stop();
            Write("Generic List creation took : " + ElapsedSeconds);

            stopwatch.Restart();
            var customList = new CustomList<int>(maximumItemLimit);
            stopwatch.Stop();
            Write("CustomList creation took : " + ElapsedSeconds);

            stopwatch.Restart();
            for (int i = 0; i < maximumItemLimit; i++)
            {
                list.Add(i);
            }
            stopwatch.Stop();
            Write("Generic List population took : " + ElapsedSeconds);

            stopwatch.Restart();
            for (int i = 0; i < maximumItemLimit; i++)
            {
                customList.Add(i);
            }
            stopwatch.Stop();
            Write("CustomList population took : " + ElapsedSeconds);

            stopwatch.Restart();
            list.Clear();
            stopwatch.Stop();
            Write("List.Clear took : " + ElapsedSeconds);

            stopwatch.Restart();
            customList.Clear();
            stopwatch.Stop();
            Write("CustomList.Clear took : " + ElapsedSeconds);

        }
    }
}
