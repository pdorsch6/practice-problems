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
	
	Console.WriteLine(BSTHeight(root, 0));
	Console.WriteLine(BSTHeight(new BSTNode { Value = 1, Left = null, Right = null }, 0));
	Console.WriteLine(BSTHeight(null, 0));
}

// You can define other methods, fields, classes and namespaces here

int BSTHeight(BSTNode root, int height)
{
	if (root == null)
	{
		return height - 1;
	}
	return Math.Max(BSTHeight(root.Left, height + 1), BSTHeight(root.Right, height + 1));
}

class BSTNode
{
	public int Value { get; set; }
	public BSTNode Left { get; set; }
	public BSTNode Right { get; set; }
}