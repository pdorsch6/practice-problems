<Query Kind="Program" />

void Main()
{
	// defining some practice nodes
	//               root
	//              a    b  
	//            c  d     e         
	//           f                 
	//          g  h                
	//                                           
	var h = new BSTNode { Value = 9, Left = null, Right = null };
	var g = new BSTNode { Value = 8, Left = null, Right = null };
	var f = new BSTNode { Value = 7, Left = g, Right = h };
	var e = new BSTNode { Value = 6, Left = null, Right = null };
	var d = new BSTNode { Value = 5, Left = null, Right = null };
	var c = new BSTNode { Value = 4, Left = f, Right = null };
	var b = new BSTNode { Value = 3, Left = null, Right = e };
	var a = new BSTNode { Value = 2, Left = c, Right = d };
	var root = new BSTNode { Value = 1, Left = a, Right = b };
	
	ZigZag(root);
	// expect 1, 3, 4, 7, 8
	
	h = new BSTNode { Value = 9, Left = null, Right = null };
	g = new BSTNode { Value = 190, Left = null, Right = null };
	f = new BSTNode { Value = 80, Left = null, Right = null };
	e = new BSTNode { Value = 170, Left = null, Right = g };
	d = new BSTNode { Value = 60, Left = null, Right = null };
	c = new BSTNode { Value = 40, Left = f, Right = null };
	b = new BSTNode { Value = 150, Left = null, Right = e };
	a = new BSTNode { Value = 50, Left = c, Right = d };
	root = new BSTNode { Value = 100, Left = a, Right = b };
	
	ZigZag(root);
	// expect 100, 150, 40, 190
}

class BSTNode
{
	public int Value { get; set; }
	public BSTNode Left { get; set; }
	public BSTNode Right { get; set; }
}

void ZigZag(BSTNode root)
{
	var level = 0;
	var q = new Queue<BSTNode>();
	q.Enqueue(root);
	while(q.Any()) {
		if(level % 2 == 0)
		{
			Console.WriteLine(q.Peek().Value);
		}
		var currentLength = q.Count;
		for(int i = 0; i < currentLength; i++)
		{
			var node = q.Dequeue();
			if(i == currentLength - 1 && level % 2 == 1)
			{
				Console.WriteLine(node.Value);
			}
			if (node.Left != null) { q.Enqueue(node.Left); }
			if (node.Right != null) { q.Enqueue(node.Right); }
		}
		level++;
	}
}