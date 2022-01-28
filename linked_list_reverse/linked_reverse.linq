<Query Kind="Program" />

void Main()
{
	Node<String> a = new Node<String>();
    a.data = "A";
    Node<String> b = new Node<String>();
    b.data = "B";
    Node<String> c = new Node<String>();
    c.data = "C";
    Node<String> d = new Node<String>();
    d.data = "D";
    Node<String> e = new Node<String>();
    e.data = "E";

    a.next = b;
    b.next = c;
    c.next = d;
    d.next = e;
    e.next = null;
	
	var output = a;
	while (output != null)
	{
		Console.WriteLine(output.data);
		output = output.next;
	}
	
	
	var reversed = ReverseLL(a);
	
	while (reversed != null)
	{
		Console.WriteLine(reversed.data);
		reversed = reversed.next;
	}
}

// You can define other methods, fields, classes and namespaces here

Node<string> ReverseLL(Node<string> node)
{
	Node<string> prev = null;
	while (node != null)
	{
		Node<string> next = node.next;
		node.next = prev;
		prev = node;
		node = next;
	}
	return prev;
}

class Node<T> 
{
  public Node<T> next;
  public T data;
}