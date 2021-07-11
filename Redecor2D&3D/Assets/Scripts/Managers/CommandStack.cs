using System.Collections.Generic;
using Game.Interfaces;

namespace Game.Managers
{

    public class CommandStack
    {

        public List<ICommand> _commandHistory = new List<ICommand>();
        private int _index;

        public void ExecuteCommand(ICommand command)
        {
            if(_index < _commandHistory.Count)
            {
                _commandHistory.RemoveRange(_index, _commandHistory.Count - 1);
            }
            _commandHistory.Add(command);
            command.Execute();
            _index++;
        }

        public void UndoLastCommand()
        {
            if(_commandHistory.Count <= 0)
            {
                return;
            }
            if(_index > 0)
            {
                _commandHistory[_index - 1].Undo();
                _index--;
            }
        }

        public void RedoLastCommand()
        {
            if(_commandHistory.Count <= 0)
            {
                return;
            }
            if(_index < _commandHistory.Count)
            {
                _index++;
                _commandHistory[_index - 1].Execute();
            }
        }
    }
}