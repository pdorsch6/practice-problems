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
	Console.WriteLine(this.IsBalanced(a));
	Console.WriteLine(this.IsBalanced(b));
	Console.WriteLine(this.IsBalanced(c));
	Console.WriteLine(this.IsBalanced(d));
	Console.WriteLine(this.IsBalanced(e));
	Console.WriteLine(this.IsBalanced(f));
	Console.WriteLine(this.IsBalanced(g));
	Console.WriteLine(this.IsBalanced(h));
}

// You can define other methods, fields, classes and namespaces here

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