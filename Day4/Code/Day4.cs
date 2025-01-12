namespace Code;

public class Day4
{
    public int Part1(string[] input)
    {
        var cols = input[0].Length;
        var rows = input.Length;

        return 
            Enumerable.Range(0, rows)
                .SelectMany(row =>
                    Enumerable.Range(0, cols)
                        .Select(col =>
                            input[row][col] == 'X'
                                ? CheckXmas(input, row, col)
                                : 0    
                    )
                )
                .Sum();
    }

    public int Part2(string[] input)
    {
        var cols = input[0].Length;
        var rows = input.Length;

        return 
            Enumerable.Range(0, rows)
                .SelectMany(row =>
                    Enumerable.Range(0, cols)
                        .Select(col =>
                            input[row][col] == 'A'
                                ? CheckXmas2(input, row, col)
                                : 0    
                    )
                )
                .Sum();
    }

    private int CheckXmas2(string[] input, int row, int col)
    {
        return 0;
    }

    private int CheckXmas(string[] input, int row, int col)
    {
        var cols = input[0].Length;
        var rows = input.Length;

        List<bool> xmas = [ 
            col >= 3 && CheckMas(input, row, col, 0, -1),
            (cols - col) >= 4 && CheckMas(input, row, col, 0, 1),
            row >= 3 && CheckMas(input, row, col, -1, 0),
            (rows - row) >= 4 && CheckMas(input, row, col, 1, 0),

            (rows - row) >= 4 && (cols - col) >= 4 && CheckMas(input, row, col, 1, 1),
            row >= 3 && col >= 3 && CheckMas(input, row, col, -1, -1),
            (rows - row) >= 4 && col >= 3 && CheckMas(input, row, col, 1, -1),
            row >= 3 && (cols - col) >= 4 && CheckMas(input, row, col, -1, 1)
        ];

        return xmas.Count(_ => _);
    }

    private bool CheckMas(string[] input, int row, int col, int rowMult, int colMult) =>
        input[row + (1 * rowMult)][col + (1 * colMult)] == 'M' &&
        input[row + (2 * rowMult)][col + (2 * colMult)] == 'A' &&
        input[row + (3 * rowMult)][col + (3 * colMult)] == 'S';
}