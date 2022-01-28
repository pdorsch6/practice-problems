<Query Kind="Program" />

void Main()
{
	
}

// You can define other methods, fields, classes and namespaces here

class MinStack
{
	Stack<int> BackingStack;
	Stack<int> MinimumStack;
	int Count;

	public MinStack()
	{
		BackingStack = new Stack<int>();
		MinimumStack = new Stack<int>();
		Count = 0;
	}
	
	public void Push(int n)
	{
		if (Count == 0) 
		{
			BackingStack.Push(n);
			MinimumStack.Push(n);
		}
		else
		{
			BackingStack.Push(n);
			MinimumStack.Push(Math.Min(MinimumStack.Peek(), n));
		}
		Count++;
	}
	
	public void Pop()
	{
		if (Count > 0) 
		{
			BackingStack.Pop();
			MinimumStack.Pop();
			Count--;
		}
	}
	
	int GetMinValue()
	{
		return MinimumStack.Peek();
	}
}