namespace GenericsHomework;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public override string ToString()
    {
            string contents = $"{Value}";
            return contents;
    }

    public void Append(T value)
    {
        // To add once Exists method is here
        if (Exists(value)) 
        {
            throw new System.ArgumentException("Duplicate Value");
        }
         

        Node<T> newNode = new(value);
        Node<T> cur = this;

        while (cur.Next != this) { cur = cur.Next; }

        cur.Next = newNode;
        newNode.Next = this;
    }

    public void Clear()
    {
        // base case if list is a single element
        if(this.Next == this)
        {
            return;
        }

        // Reference of next node before clearing 
        Node<T> curNode = this;

        // Loop through list until your at the node before this
        while (curNode.Next != this)
        {
            curNode = curNode.Next;
        }

        // Set node before this to this's next node
        curNode.Next = this.Next;

        // Clear by setting the node to itself 
        this.Next = this;


        // As long as there is no external references you do not need to worry about garbage
        // collection because the .NET garabge collector will collect object that is unreachable
        // which pretty much means if there is no external refence it will eventually be 
        // collected.  After the method finishes the curNode will go out of scope so that 
        // reference does not matter and the closed loop will be collected. 
    }

    public bool Exists(T value)
    {
        // create node to navigate with starting with the first node
        Node<T> curNode = this;

        // since curNode cannot equal this/first node in the loop, we need to do an 
        // intial test to make sure the first node does not have the given value.

        // Use of null forgiveness since doc states validation on node values is not nessasary
        if(curNode.Value!.Equals(value))
        {
            return true;
        }

        // increment current node so we can go into loop. 
        curNode = curNode.Next;

        // loop until initial node, if values are equal return true, otherwise return false.
        while(curNode != this)
        {
            // Use of null forgiveness since doc states validation on node values is not nessasary
            if (curNode.Value!.Equals(value))
            {
                return true;
            }
            curNode = curNode.Next;
        }

        return false;
        
    }


}