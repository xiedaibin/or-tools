using System;
using Google.OrTools.LinearSolver;

public class BasicExample
{
    // 主函数，创建一个线性规划问题，并解决它
    static void Main()
    {
        // 使用GLPK（GNU Linear Programming Kit）算法后端创建线性求解器
        Solver solver = Solver.CreateSolver("GLPK");
        // 如果创建失败，则退出函数
        if (solver is null)
        {
            return;
        }

        // 创建变量x和y
        Variable x = solver.MakeNumVar(0.0, 1.0, "x");
        Variable y = solver.MakeNumVar(0.0, 2.0, "y");

        // 打印变量的数量
        Console.WriteLine("变量的数量 = " + solver.NumVariables());

        // 创建一个线性约束，0 <= x + y <= 2
        Constraint ct = solver.MakeConstraint(0.0, 2.0, "ct");
        ct.SetCoefficient(x, 1);
        ct.SetCoefficient(y, 1);

        // 打印约束的数量
        Console.WriteLine("约束的数量 = " + solver.NumConstraints());

        // 创建目标函数，3 * x + y
        Objective objective = solver.Objective();
        objective.SetCoefficient(x, 3);
        objective.SetCoefficient(y, 1);
        objective.SetMaximization();

        // 解决问题
        solver.Solve();

        // 打印解决结果
        Console.WriteLine("解决结果：");
        Console.WriteLine("目标函数的值 = " + solver.Objective().Value());
        Console.WriteLine("x = " + x.SolutionValue());
        Console.WriteLine("y = " + y.SolutionValue());
    }
}