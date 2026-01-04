namespace Code;

public class Computer
{
    public long RegisterA { get; set; }
    public long RegisterB { get; set; }
    public long RegisterC { get; set; }

    public int[]? Program { get; set; }

    private long _pc = 0;

    private readonly List<long> _output = [];

    public string Run()
    {
        if (Program == null)
            throw new InvalidOperationException("No program loaded.");

        _pc = 0;
        _output.Clear();

        Dictionary<int, Action<int>> instructions = new()
        {
            { 0, Adv },
            { 1, Bxl },
            { 2, Bst },
            { 3, Jnz },
            { 4, Bxc },
            { 5, Out },
            { 6, Bdv },
            { 7, Cdv },
        };

        while (_pc >= 0 && _pc < Program.Length)
        {
            var opCode = Program[_pc];
            var operand = Program[_pc + 1];

            instructions[opCode](operand);
            
            _pc += 2;
        }

        return string.Join(",", _output);
    }

    private long DecodeOperand(int operand) =>
        operand switch
        {
            <= 3 => operand,
            4 => RegisterA,
            5 => RegisterB,
            6 => RegisterC,
            7 => throw new InvalidOperationException($"Reserved operand: {operand}"),
            _ => throw new InvalidOperationException($"Invalid operand: {operand}"),
        };

    private void Adv(int operand) => 
        RegisterA = (long)Math.Floor(RegisterA / Math.Pow(2, DecodeOperand(operand)));

    private void Bxl(int operand) =>
        RegisterB ^= operand;

    private void Bst(int operand) =>
        RegisterB = DecodeOperand(operand) % 8;

    private void Jnz(int operand)
    { 
        if (RegisterA != 0)
        {
            _pc = DecodeOperand(operand) - 2;
        }
    }

    private void Bxc(int operand) =>
        RegisterB ^= RegisterC;

    private void Out(int operand) =>
        _output.Add(DecodeOperand(operand) % 8);

    private void Bdv(int operand) =>
        RegisterB = (long)Math.Floor(RegisterA / Math.Pow(2, DecodeOperand(operand)));

    private void Cdv(int operand) =>
        RegisterC = (long)Math.Floor(RegisterA / Math.Pow(2, DecodeOperand(operand)));
}