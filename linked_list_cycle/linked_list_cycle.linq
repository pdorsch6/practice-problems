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
    d.data = "E";

    a.next = b;
    b.next = c;
    c.next = d;
    d.next = e;
    e.next = c;

    Console.WriteLine(ContainsCycle(a));

    Node<String> f = new Node<String>();
    f.next = null;
    Console.WriteLine(ContainsCycle(f));

    Node<String> h = new Node<String>();
    Node<String> i = new Node<String>();
    h.next = i;
    i.next = null;
    Console.WriteLine(ContainsCycle(h));
	
	 Node<String> j = new Node<String>();
    j.next = j;
    Console.WriteLine(ContainsCycle(j));
}

// You can define other methods, fields, classes and namespaces here

class Node<T> 
{
  public Node<T> next;
  public T data;
}

// better solution for memory
bool ContainsCycle(Node<string> node)
{
	if (node == null || node.next == null) { return false; }
	var turtle = node;
	var hare = node.next;
	while (turtle != null && hare != null && hare.next != null)
	{
		if (turtle == hare)
		{
			return true;
		}
		turtle = turtle.next;
		hare = hare.next.next;
	}
	return false;
}

// requires more memory to compute, but guaranteed first time the extra node is seen it will be caught
HashSet<Node<string>> set = new HashSet<Node<string>>();
bool ContainsCycleMoreMem(Node<string> node)
{
	if (node == null)
	{
		return false;
	}
	else if (set.Contains(node)) 
	{
		return true;
	}
	set.Add(node);
	return ContainsCycle(node.next);
}
