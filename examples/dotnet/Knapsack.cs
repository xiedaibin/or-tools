using System;
using System.Collections.Generic;
using System.Linq;
using Google.OrTools.Algorithms;

public class Knapsack
{
    static void Main()
    {
        // 创建一个拟阵背包求解器
        KnapsackSolver solver = new KnapsackSolver(
            KnapsackSolver.SolverType.KNAPSACK_MULTIDIMENSION_BRANCH_AND_BOUND_SOLVER, "KnapsackExample");

        // 拟阵背包的物品价值
        long[] values = GetValues();

        // 拟阵背包的物品重量
        long[,] weights = GetWeights();

        // 拟阵背包的容量
        long[] capacities = GetCapacities();

        // 初始化拟阵背包求解器
        solver.Init(values, weights, capacities);

        // 求解拟阵背包问题
        long computedValue = solver.Solve();

        // 输出最优值
        Console.WriteLine("Optimal Value = " + computedValue);

        // 输出选中的物品
        List<int> packedItems = GetPackedItems(solver, values);
        List<long> packedWeights = GetPackedWeights(solver,values, weights);
        int totalWeight = GetTotalWeight(packedWeights);
        Console.WriteLine("Total value = " + computedValue);
        Console.WriteLine("Total weight: " + totalWeight);
        Console.WriteLine("Packed items: " + string.Join(", ", packedItems));
        Console.WriteLine("Packed weights: " + string.Join(", ", packedWeights));
    }

    private static long[] GetValues()
    {
        return new long[] { 360, 83, 59, 130, 431, 67,  230, 52,  93,  125, 670, 892, 600, 38,  48,  147, 78,
                            256, 63, 17, 120, 164, 432, 35,  92,  110, 22,  42,  50,  323, 514, 28,  87,  73,
                            78,  15, 26, 78,  210, 36,  85,  189, 274, 43,  33,  10,  19,  389, 276, 312 };
    }

    private static long[,] GetWeights()
    {
        return new long[,] { { 7,  0,  30, 22, 80, 94, 11, 81, 70, 64, 59, 18, 0,  36, 3,  8,  15,
                                42, 9,  0,  42, 47, 52, 32, 26, 48, 55, 6,  29, 84, 2,  4,  18, 56,
                                7,  29, 93, 44, 71, 3,  86, 66, 31, 65, 0,  79, 20, 65, 52, 13 } };
    }

    private static long[] GetCapacities()
    {
        return new long[] { 850,850 };
    }

    private static List<int> GetPackedItems(KnapsackSolver solver,long[] values)
    {
        List<int> packedItems = new List<int>();
        for (int i = 0; i < values.Length; i++)
        {
            if (solver.BestSolutionContains(i))
            {
                packedItems.Add(i);
            }
        }
        return packedItems;
    }

    private static List<long> GetPackedWeights(KnapsackSolver solver, long[] values, long[,] weights)
    {
        List<long> packedWeights = new List<long>();
        for (int i = 0; i < values.Length; i++)
        {
            if (solver.BestSolutionContains(i))
            {
                packedWeights.Add(weights[0,i]);
            }
        }
        return packedWeights;
    }

    private static int GetTotalWeight(List<long> packedWeights)
    {
        return packedWeights.Sum(weight => (int)weight);
    }
}