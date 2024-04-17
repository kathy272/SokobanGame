namespace libs;

public sealed class InputHandler{

    private static InputHandler? _instance;
    private GameEngine engine;

    public static InputHandler Instance {
        get{
            if(_instance == null)
            {
                _instance = new InputHandler();
            }
            return _instance;
        }
    }

    private InputHandler() {
        //INIT PROPS HERE IF NEEDED
        engine = GameEngine.Instance;
    }

    public void Handle(ConsoleKeyInfo keyInfo)
    {
        GameObject focusedObject = engine.GetFocusedObject();
      GameObject player = engine.GetPlayer();
        GameObject box = engine.GetBox();
        GameObject goal = engine.GetGoal();
        GameObject wall = engine.GetWall();


        if (focusedObject != null) {
              int dx = 0;
        int dy = 0;
            // Handle keyboard input to move the player
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    dy = -1;
                    focusedObject.CheckBoxCollision(box, player, Direction.Up, dx, dy);
                    engine.CanMoveBox(wall, player, box, Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    dy = 1;
                    focusedObject.CheckBoxCollision(box, player, Direction.Down, dx, dy);
                    engine.CanMoveBox(wall, player, box, Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    dx = -1;
                    focusedObject.CheckBoxCollision(box, player, Direction.Left,    dx, dy);
                    engine.CanMoveBox(wall, player, box, Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    dx = 1;
                    focusedObject.CheckBoxCollision(box, player, Direction.Right, dx, dy);
                    engine.CanMoveBox(wall, player, box, Direction.Right);
                    break;
                default:
                    break;
            }
            if (engine.CanMove(focusedObject, box, dx, dy))
            {
             
                focusedObject.Move(dx, dy);
                engine.Render();
            }
            else
            {
Console.WriteLine("You can't move there!");         }
        }
        
    }
 
}