
public class EternalGoal : Goal
{

    public EternalGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        
    }

    
    public override void RecordEvent()
    {
        
        // The main program will handle adding points
    }

    
    public override bool IsComplete()
    {
        return false;  
    }

    // Override GetDetailsString to show
    public override string GetDetailsString()
    {
        // Always shows [ ] 
        return $"[ ] {GetName()} ({GetDescription()})";
    }

    // Override GetStringRepresentation for saving to file
    public override string GetStringRepresentation()
    {
        
        return $"EternalGoal:{GetName()},{GetDescription()},{GetPoints()}";
    }
}