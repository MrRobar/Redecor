namespace Game.Interfaces
{

    public interface ICommand
    {

        void Execute();
        void Undo();
        void Redo();
    }
}