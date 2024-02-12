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
        /* To add once Exists method is here
         * if Exists(value) {throw new ArgumentException("Duplicate Value")}
         */

        Node<T> newNode = new(value);
        Node<T> cur = this;

        newNode._next = cur;
        cur._next = newNode;
    }

}
