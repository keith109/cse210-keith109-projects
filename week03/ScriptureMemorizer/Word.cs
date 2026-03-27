public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide() 
    {
        _isHidden = true;
    }

    public void Show() 
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden; // Cambiado de 'false' a la variable real
    }

    public string GetDisplayText()
    {
        // Si está escondida, devuelve guiones. Si no, devuelve el texto.
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}