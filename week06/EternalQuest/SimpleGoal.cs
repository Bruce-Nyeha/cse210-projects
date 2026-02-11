
public class SimpleGoal : Goal
{
    
    private bool _isComplete;

    
    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _isComplete = false;
    }

public SimpleGoal(string name, string description, int points, bool isComplete)
: base(name, description, points)
    {
        _isComplete = isComplete;
    }
    

    // Override the RecordEvent method
    public override void RecordEvent()
    {
        _isComplete = true;
    }

    // Override the IsComplete method
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Override GetDetailsString to show [X] or [ ]
    public override string GetDetailsString()
    {
        // If complete show [X], otherwise [ ]
        string checkbox = _isComplete ? "[X]" : "[ ]";
        return $"{checkbox} {GetName()} ({GetDescription()})";
    }

    // Override GetStringRepresentation for saving to file
    public override string GetStringRepresentation()
    {
        // Format: SimpleGoal:name,description,points,isComplete
        return $"SimpleGoal:{GetName()},{GetDescription()},{GetPoints()},{_isComplete}";
    }
}