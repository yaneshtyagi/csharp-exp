namespace CSharp8;

public interface IInterfaceWithMethodImplementation
{
    public bool CanIImplementMethod() => true;

    public bool AnotherImplementedMethod()
    {
        return true;
    }

    public bool UnimplementedMethod();
    
    
}