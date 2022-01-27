<Query Kind="Program">
  <RuntimeVersion>6.0</RuntimeVersion>
</Query>

void Main()
{
	var a = "()[]{}".ToCharArray();
	var b = "([{}])".ToCharArray();
	var c = "([]{})".ToCharArray();
	var d = "([)]".ToCharArray();
	var e = "([]}".ToCharArray();
	var f = "[])(".ToCharArray();
	var g = "([})".ToCharArray();
	var h = "".ToCharArray();
	Console.WriteLine(this.IsBalancedStack(a));
	Console.WriteLine(this.IsBalancedStack(b));
	Console.WriteLine(this.IsBalancedStack(c));
	Console.WriteLine(this.IsBalancedStack(d));
	Console.WriteLine(this.IsBalancedStack(e));
	Console.WriteLine(this.IsBalancedStack(f));
	Console.WriteLine(this.IsBalancedStack(g));
	Console.WriteLine(this.IsBalancedStack(h));
}

// You can define other methods, fields, classes and namespaces here


// lets try with a stack instead -- will probably be much better
bool IsBalancedStack(char[] delimiters) 
{
	var stack = new Stack<char>();
	foreach (var d in delimiters) 
	{
		switch(d) 
		{
			case('{'):
			case('('):
			case('['):
				stack.Push(d);
				break;
			case(')'):
				if (stack.Any() && stack.Peek() == '(') 
				{
					stack.Pop();
					break;
				}
				return false;
			case('}'):
				if (stack.Any() && stack.Peek() == '{') 
				{
					stack.Pop();
					break;
				}
				return false;
			case(']'):
				if (stack.Any() && stack.Peek() == '[') 
				{
					stack.Pop();
					break;
				}
				return false;
		}	
	}
	return !stack.Any();
}

// brute force method!!
bool IsBalanced(char[] delimiters)
{
	// return false if the delimiter length is odd
	if (delimiters.Length % 2 == 1)
	{
	 	return false;
	}
	
	while(delimiters.Any())
	{
		var startingLength = delimiters.Length;
		for(int i = 1; i < delimiters.Length; i++)
		{
			Console.WriteLine($"{i} : {String.Join("", delimiters)}");
			if ((delimiters[i-1] == '[' && delimiters[i] == ']')
				|| (delimiters[i-1] == '(' && delimiters[i] == ')')
				|| (delimiters[i-1] == '{' && delimiters[i] == '}'))
			{
				delimiters = delimiters.Where((source, index) => index != i-1 && index != i).ToArray();
				i = i == 1 ? 0 : i-2;
			}
		}
		if (startingLength == delimiters.Length)
		{
			return false;
		}
	}
	return true;
}