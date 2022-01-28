<Query Kind="Program" />

void Main()
{
	var queue = new QueueOfStacks();
	queue.Enqueue('a');
	queue.Enqueue('b');
	queue.Enqueue('c');

	Console.WriteLine(queue.Dequeue()); // a
	Console.WriteLine(queue.Dequeue()); // b
	queue.Enqueue('d');
	queue.Enqueue('e');
	Console.WriteLine(queue.Dequeue()); // c
	// stack flip required
	Console.WriteLine(queue.Dequeue()); // d
	Console.WriteLine(queue.Dequeue()); // e
}

// You can define other methods, fields, classes and namespaces here

class QueueOfStacks
{
	Stack<char> Stack1;
	Stack<char> Stack2;

	public QueueOfStacks()
	{
		Stack1 = new Stack<char>();
		Stack2 = new Stack<char>();
	}
	
	public void Enqueue(char n)
	{
		Stack1.Push(n);
	}
	
	public char Dequeue()
	{
		if(!Stack2.Any())
		{
			while (Stack1.Any())
			{
				Stack2.Push(Stack1.Pop());
			}
		}
		return Stack2.Pop();
	}
}