using UnityEngine;
using ScriptableValues;
using Game.Commands;
using Events;

namespace Game.Managers
{

    public class CommandsController : MonoBehaviour
    {

        [SerializeField]
        private EventListener _processDataEventListener;

        [SerializeField]
        private EventListener _undoEventListener;

        [SerializeField]
        private EventListener _redoEventListener;

        [SerializeField]
        private ScriptableSpriteRenderer _rendererToChange;

        [SerializeField]
        private ScriptableSpriteValue _spriteToSet;

        [SerializeField]
        ScriptableSpriteValue _defaultSprite;

        private CommandStack _commandStack = new CommandStack();

        private void OnEnable()
        {
            _processDataEventListener.OnEventHappened += SetTexture;
            _undoEventListener.OnEventHappened += UndoCommand;
            _redoEventListener.OnEventHappened += RedoCommand;
        }

        private void OnDisable()
        {
            _processDataEventListener.OnEventHappened -= SetTexture;
            _undoEventListener.OnEventHappened -= UndoCommand;
            _redoEventListener.OnEventHappened -= RedoCommand;
        }

        private void SetTexture()
        {
            _commandStack.ExecuteCommand(new SetTextureCommand(_rendererToChange.data, _spriteToSet.data, _defaultSprite.data));
        }

        private void UndoCommand()
        {
            _commandStack.UndoLastCommand();
        }

        private void RedoCommand()
        {
            _commandStack.RedoLastCommand();
        }
    }
}