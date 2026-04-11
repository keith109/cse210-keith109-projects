namespace Shapes;

public abstract class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // Usamos 'abstract' porque no hay un área "por defecto" para una forma genérica
    public abstract double GetArea();
}