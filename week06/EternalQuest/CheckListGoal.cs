
public class ChecklistGoal : Goal
{
    
    private int _amountCompleted;  
    private int _target;          
    private int _bonus;            

    
    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base(name, description, points)
    {
        _amountCompleted = 0;  
        _target = target;
        _bonus = bonus;
    }


    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) 
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    // Override RecordEvent - increment the counter
    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    // Override IsComplete - check if we've reached the target
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    // Override GetDetailsString to show progress
    public override string GetDetailsString()
    {
        // If complete show [X], otherwise [ ]
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {GetName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    // Override GetStringRepresentation for saving to file
    public override string GetStringRepresentation()
    {
        
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_bonus},{_target},{_amountCompleted}";
    }

    
    public int GetBonus()
    {
        return _bonus;
    }

    
    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    // Method to get target
    public int GetTarget()
    {
        return _target;
    }
}