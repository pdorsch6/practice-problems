<Query Kind="Program">
  <RuntimeVersion>6.0</RuntimeVersion>
</Query>

void Main()
{
	var testCases = new TestingInputs 
	{
		TestCases = new List<TestCase> 
		{
			new TestCase 
			{
				ArrayToRotate = new List<int> { 1, 2, 3 },
				NumberToRotate = 1,
				ExpectedArray = new List<int> { 3, 1, 2 },
			},
			new TestCase 
			{
				ArrayToRotate = new List<int> { 1 ,2, 3, 4, 5 },
				NumberToRotate = 3,
				ExpectedArray = new List<int> { 3, 4, 5, 1, 2 },
			},
			new TestCase 
			{
				ArrayToRotate = new List<int> { 1 ,2, 3, 4, 5 },
				NumberToRotate = 6,
				ExpectedArray = new List<int> { 5, 1, 2, 3, 4 },
			},
			new TestCase 
			{
				ArrayToRotate = new List<int> { 1 ,2, 3, 4, 5 },
				NumberToRotate = 5,
				ExpectedArray = new List<int> { 1, 2, 3, 4, 5 },
			},
			new TestCase 
			{
				ArrayToRotate = new List<int> { 1, 2, 3, 4, 5 },
				NumberToRotate = -1,
				ExpectedArray = new List<int> { 2, 3, 4, 5, 1 },
			},
			new TestCase 
			{
				ArrayToRotate = new List<int> { 1, 2, 3, 4, 5 },
				NumberToRotate = -4,
				ExpectedArray = new List<int> { 5, 1, 2, 3, 4 },
			},
			new TestCase 
			{
				ArrayToRotate = new List<int> { 1, 2, 3, 4, 5, 8, 10 },
				NumberToRotate = -11,
				ExpectedArray = new List<int> { 5, 8, 10, 1, 2, 3, 4 },
			},
			new TestCase 
			{
				ArrayToRotate = new List<int> { 1, 2, 3, 4, 5, 8, 10 },
				NumberToRotate = 0,
				ExpectedArray = new List<int> { 1, 2, 3, 4, 5, 8, 10 },
			}
		}
	};
	
	this.RunTests(testCases);
}

// You can define other methods, fields, classes and namespaces here

IEnumerable<int> Rotate(List<int> arrayToRotate, int numToRotate) 
{
	var splitLocation = numToRotate > 0
		? arrayToRotate.Count - numToRotate % arrayToRotate.Count
		: Math.Abs(numToRotate % arrayToRotate.Count);
	var first = arrayToRotate.Take(splitLocation);
	var end = arrayToRotate.Skip(splitLocation);
	return Enumerable.Concat(end, first);
}

void RunTests(TestingInputs inputs) 
{
	foreach (var testCase in inputs.TestCases) 
	{
		var rotationResult = this.Rotate(testCase.ArrayToRotate, testCase.NumberToRotate).ToList(); 
		if(rotationResult.SequenceEqual(testCase.ExpectedArray)) 
		{
			Console.WriteLine($"Success: ({String.Join(",", rotationResult)}) rotated successfully.");
		} 
		else
		{
			Console.WriteLine($"Failure: ({String.Join(",", rotationResult)}) should have been ({String.Join(",", testCase.ExpectedArray)})");
		}
	}
}

class TestingInputs 
{
	public List<TestCase> TestCases { get; set; }
}

class TestCase 
{
	public List<int> ArrayToRotate { get; set; }
	public int NumberToRotate { get; set; }
	public List<int> ExpectedArray { get; set; }
}