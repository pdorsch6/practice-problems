<Query Kind="Program" />

void Main()
{
	Console.WriteLine(fib(41));
}

// You can define other methods, fields, classes and namespaces here

Dictionary<int, int> mem = new Dictionary<int, int> { {0, 0}, {1, 1} };

int fib(int n)
{
	Console.WriteLine(".");
	if (mem.TryGetValue(n, out var res))
	{
		return res;
	}
	mem[n] = fib(n-1) + fib(n-2);
	return mem[n];
}