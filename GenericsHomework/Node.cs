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
        if (Exists(value)) 
        {
            throw new System.ArgumentException("Duplicate Value");
        }
         

        Node<T> newNode = new(value);
        Node<T> currentNode = this;

        while (currentNode.Next != this) 
        { 
            currentNode = currentNode.Next; 
        }

        currentNode.Next = newNode;
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
        Node<T> currentNode = this;

        // Loop through list until you're at the node before this
        while (currentNode.Next != this)
        {
            currentNode = currentNode.Next;
        }

        // Set node before this to this's next node
        currentNode.Next = this.Next;

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
        Node<T> currentNode = this;

        // since curNode cannot equal this/first node in the loop, we need to do an 
        // intial test to make sure the first node does not have the given value.

        // Use of null forgiveness since doc states validation on node values is not nessasary
        if(currentNode.Value!.Equals(value))
        {
            return true;
        }

        // increment current node so we can go into loop. 
        currentNode = currentNode.Next;

        // loop until initial node, if values are equal return true, otherwise return false.
        while(currentNode != this)
        {
            // Use of null forgiveness since doc states validation on node values is not nessasary
            if (currentNode.Value!.Equals(value))
            {
                return true;
            }
            currentNode = currentNode.Next;
        }

        return false;
        
    }


}
