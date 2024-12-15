
using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2024.Day7;

public sealed class BridgeRepair(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "2024/InputDay7.txt";

    public override long SolvePart1()
    {
        return _inputReader.GetProblemInput(INPUT_FILE_NAME).Sum(IsEquationTrue);
    }

    public override long SolvePart2()
    {
        return _inputReader.GetProblemInput(INPUT_FILE_NAME).Sum(IsEquationTrue);
    }

    public static long IsEquationTrue(string equation)
    {
        var splittedLine = equation.Split(':');
        var equationResult = long.Parse(splittedLine[0]);
        var numbers = splittedLine[1].Split(' ').Skip(1).Select(long.Parse);
        Tree tree = new(null);
        foreach (var number in numbers)
        {
            tree.InsertNumber(number);
        }
        return tree.IsEquationPossible(equationResult) ? equationResult : 0;
    }

    private class Node(long value, Node? plusNode, Node? multNode)
    {
        public long Value { get; set; } = value;
        public Node? PlusNode { get; set; } = plusNode;
        public Node? MultNode { get; set; } = multNode;
    };

    private class Tree(Node? root)
    {
        public Node? Root { get; set; } = root;


        public void InsertNumber(long number)
        {
            if (Root is null)
            {
                Root = new(number, null, null);
            }
            else
            {
                InsertNumberRec(Root, number);
            }
        }

        private void InsertNumberRec(Node node, long number)
        {
            if (node.PlusNode is null && node.MultNode is null)
            {
                node.PlusNode = new Node(node.Value + number, null, null);
                node.MultNode = new Node(node.Value * number, null, null);
            }
            else
            {
                InsertNumberRec(node.PlusNode!, number);
                InsertNumberRec(node.MultNode!, number);
            }
        }
        public bool IsEquationPossible(long equationResult)
        {
            if (Root is null)
            {
                return false;
            }
            return IsEquationPossibleRec(Root, equationResult);
        }

        private bool IsEquationPossibleRec(Node node, long equationResult)
        {
            if (node.PlusNode is null && node.MultNode is null)
            {
                return node.Value == equationResult;
            }
            return IsEquationPossibleRec(node.PlusNode!, equationResult) || IsEquationPossibleRec(node.MultNode!, equationResult);
        }
    }

}
