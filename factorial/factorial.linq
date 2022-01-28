<Query Kind="Program" />

void Main()
{
	Console.WriteLine(factorial(10));
	Console.WriteLine(factorial(3));
	Console.WriteLine(factorial(7));
}

// You can define other methods, fields, classes and namespaces here
Dictionary<int, int> mem = new Dictionary<int, int> { {0, 1} };

int factorial(int n)
{
	Console.WriteLine(".");
	if (mem.TryGetValue(n, out var value))
	{
		return value;
	}
	mem[n] = factorial(n-1) * n;
	return mem[n];
}