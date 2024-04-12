namespace libs;

public class Goal : GameObject {
    public Goal () : base() {
        this.Type = GameObjectType.Goal;
        this.CharRepresentation = 'G';
        this.Color = ConsoleColor.Cyan;  
    }
}