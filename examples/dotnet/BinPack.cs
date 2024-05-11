using Google.OrTools.ConstraintSolver;
using System;
using System.Collections.Generic;

class BinPack
{
    static void Main()
    {
        //// 示例输入：尺寸和数量
        //List<int[]> dimensions = new List<int[]>
        //{
        //    new int[] {10, 5, 2},
        //    new int[] {8, 4, 3},
        //    new int[] {6, 3, 1}
        //}; // 长、宽、高

        //List<int> quantities = new List<int> { 1, 1, 1 }; // 数量

        //var solver = new Solver("PackingProblem");

        //// 变量定义
        //List<IntVar> boxes = new List<IntVar>();
        //foreach (var dimension in dimensions)
        //{
        //    IntVar box = solver.MakeIntVar(0, Int32.MaxValue, "");
        //    boxes.Add(box);
        //}

        //// 添加约束
        //for (int i = 0; i < dimensions.Count; i++)
        //{
        //    // 为每个维度创建一个乘积变量
        //    IntVar[] prodVars = new IntVar[dimensions[i].Length];
        //    for (int j = 0; j < dimensions[i].Length; j++)
        //    {
        //        // 将箱子变量与维度相乘以获得乘积变量
        //        prodVars[j] = solver.MakeProd(boxes[i], dimensions[i][j]).Var();
        //    }
        //    // 添加约束以确保乘积变量之和等于给定的数量
        //    solver.Add(prodVars.Sum() == quantities[i]);
        //}

        //// 目标函数
        //// 创建一个变量表示所有箱子的表面积之和
        //IntVar totalSurfaceArea = solver.MakeSum(boxes.ToArray()).Var();
        //// 最小化总表面积
        //OptimizeVar minimize = solver.MakeMinimize(totalSurfaceArea, 1);

        //// 求解
        //// 定义用于搜索的决策构建器
        //DecisionBuilder db = solver.MakePhase(boxes.ToArray(), Solver.CHOOSE_FIRST_UNBOUND, Solver.ASSIGN_MIN_VALUE);
        //// 开始搜索
        //solver.NewSearch(db, minimize);
        //// 迭代解决方案
        //while (solver.NextSolution())
        //{
        //    // 打印总表面积的值
        //    Console.WriteLine("最小表面积: " + totalSurfaceArea.Value());
        //    // 在找到一个解决方案后结束搜索（可选）
        //    break;
        //}
        //// 结束搜索
        //solver.EndSearch();
    }
}
