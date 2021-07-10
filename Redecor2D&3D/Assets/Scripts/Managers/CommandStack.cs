using System.Collections.Generic;
using Game.Interfaces;

namespace Game.Managers
{

    public class CommandStack
    {

        public Stack<ICommand> _commandHistory = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
        }

        public void UndoLastCommand()
        {
            if(_commandHistory.Count <= 0)
            {
                return;
            }
            _commandHistory.Pop().Undo();
        }

        public void RedoLastCommand()
        {
            if(_commandHistory.Count <= 0)
            {
                return;
            }
            _commandHistory.Pop().Redo();
        }
    }
}