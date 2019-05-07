namespace Main
{
    public interface IType
    {
        IMeasure MeasureType { get; set; }

        IOperation OperationType { get; set; }
    }
}