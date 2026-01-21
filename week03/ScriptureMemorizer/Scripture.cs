using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();  

    
    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        
        string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        
        foreach (string wordText in wordArray)
        {
            Word word = new Word(wordText);
            _words.Add(word);
        }
    }

    
    public void HideRandomWords(int numberToHide)
    {
        
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        
        if (visibleWords.Count == 0)
        {
            return;
        }

        
        Random random = new Random();
        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            // Pick random index from visible words
            int index = random.Next(0, visibleWords.Count);
            Word selectedWord = visibleWords[index];

            // Hide it
            selectedWord.Hide();

            // Remove from visible list so you don't hide it again
            visibleWords.RemoveAt(index);
        }
    }

    
    public string GetDisplayText()
    {
        string wordsDisplay = "";
        foreach (Word word in _words)
        {
            wordsDisplay += word.GetDisplayText() + " ";
        }

        
        wordsDisplay = wordsDisplay.TrimEnd();

        // Combine reference and words
        return $"{_reference.GetDisplayText()} {wordsDisplay}";
    }

    // Check if all words are hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;  
            }
        }
        return true;  
    }

    
public int GetVisibleWordCount()
{
    int count = 0;
    foreach (Word word in _words)
    {
        if (!word.IsHidden())
        {
            count++;
        }
    }
    return count;
}


public int GetTotalWordCount()
{
    return _words.Count;
}
}