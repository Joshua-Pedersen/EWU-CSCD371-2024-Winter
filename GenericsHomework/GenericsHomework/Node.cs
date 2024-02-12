namespace GenericsHomework;

public class Node<T>
{
    public T _value;
    public Node<T> _next { get; private set; }

    public Node(T value)
    {
        _value = value;
        _next = this;
    }

    public override string? ToString()
    {
        if (_value == null) return null;
        
        else
        {
            string contents = $"{_value}";
            return contents;
        }
    }

    public void Append(T value)
    {
        // To add once Exists method is here
        if Exists(value) 
        {
            throw new ArgumentException("Duplicate Value");
        }
         

        Node<T> newNode = new(value);
        Node<T> cur = this;

        while (cur._next != this) { cur = cur._next; }

        cur._next = newNode;
        newNode._next = this;
    }

    public void Clear()
    {
        // base case if list is a single element
        if(this._next == this)
        {
            return;
        }

        // Reference of next node before clearing 
        Node<T> curNode = this;

        // Loop through list until your at the node before this
        while (curNode._next != this)
        {
            curNode = curNode._next;
        }

        // Set node before this to this's next node
        curNode._next = this._next;

        // Clear by setting the node to itself 
        this._next = this;


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
        if(curNode._value == value)
        {
            return true;
        }

        // increment current node so we can go into loop. 
        curNode = curNode._next;

        // loop until initial node, if values are equal return true, otherwise return false.
        while(curNode != this)
        {
            if(Object.Equals(curNode._value, value))
            {
                return true;
            }
            curNode = curNode._next;
        }

        return false;
        
    }


}