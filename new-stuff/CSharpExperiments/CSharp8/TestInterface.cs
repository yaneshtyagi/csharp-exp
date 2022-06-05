namespace CSharp8;

public class TestInterface : IInterfaceWithMethodImplementation
{
    public bool UnimplementedMethod()
    {
        return true;
    }

    public bool AnotherImplementedMethod()
    {
        return false;
    }
    
}