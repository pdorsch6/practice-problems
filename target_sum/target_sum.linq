<Query Kind="Program" />

void Main()
{
	var l = new List<int> { 1, 2, 3 };
	var t = 5;
	//Console.WriteLine(TargetSum(l, t));
	Console.WriteLine(TwoSum(l, t));
	
	l = new List<int> { 1, 2, 3 };
	t = 7;
	//Console.WriteLine(TargetSum(l, t));
	Console.WriteLine(TwoSum(l, t));
	
	l = new List<int> { 10, 20, 1, 2, 3, 8, 0 };
	t = 17;
	//Console.WriteLine(TargetSum(l, t));
	Console.WriteLine(TwoSum(l, t));
	
	l = new List<int> { 10, 20, 1, 2, 3, 8, 0, 7 };
	t = 45;
	//Console.WriteLine(TargetSum(l, t));
	Console.WriteLine(TwoSum(l, t));
	
	l = new List<int> { 10, 20, 1, 2, 3, 8, 0, 7 };
	t = 27;
	//Console.WriteLine(TargetSum(l, t));
	Console.WriteLine(TwoSum(l, t));
	
	l = new List<int> { 10, 20, 1, 2, 3, 8, 0, 7 };
	t = 3;
	//Console.WriteLine(TargetSum(l, t));
	Console.WriteLine(TwoSum(l, t));
}

// You can define other methods, fields, classes and namespaces here

public bool TargetSum(List<int> nums, int target)
{
	if (target == 0) { return true; }
	
	bool[,] solutions = new bool[target + 1, nums.Count + 1];
	
	// 0,0 true, but rest of first row false since
	// we cannot make any number other than 0 with 0 coins
	solutions[0, 0] = true;
	for (int i = 1; i < nums.Count + 1; i++)
	{
		for (int j = 0; j < target + 1; j++) 
		{
			solutions[j,i] = solutions[j, i-1] || (j-nums[i-1] >= 0 && solutions[j-nums[i-1], i-1]);
		}
	}
	return solutions[target, nums.Count];
}

public bool TwoSum(List<int> nums, int target)
{
	nums.Sort();
	var s = 0;
	var e = nums.Count - 1;
	
	while (s < e) 
	{
		var sum = nums[s] + nums[e];
		if (sum == target)
		{
			return true;
		}
		else if (sum < target)
		{
			s++;
		}
		else
		{
			e--;
		}
	}
	return false;
}