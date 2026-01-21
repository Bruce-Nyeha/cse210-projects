using System;

public class Word
{
    //used private to encapsulate the fields or member variables.
    private string _text;
    private bool _isHidden;

    // then make the constructor

    public  Word(string text)
    {
        
        _text = text;
        _isHidden = false;
    }
    // Methods or functions for this very class
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
        return _isHidden;
    }

    
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }

        return _text;
    }



}