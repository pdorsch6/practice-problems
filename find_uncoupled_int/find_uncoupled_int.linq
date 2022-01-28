<Query Kind="Program" />

void Main()
{
	Console.WriteLine(FindUncoupled(new List<int> { 1, 2, 3, 4, 5, 99, 1, 2, 3, 4, 5 }));
}

// You can define other methods, fields, classes and namespaces here

int FindUncoupled(List<int> nums)
{
	var solution = 0;
	foreach (var n in nums)
	{
		solution = solution ^ n;
	}
	return solution;
}