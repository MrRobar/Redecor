using UnityEngine;
using Game.Interfaces;

namespace Game.Commands
{
    public class SetTextureCommand : ICommand
    {

        private SpriteRenderer _spriteRendererToChange;
        private Sprite _originalSprite;
        private Sprite _newSprite;

        public SetTextureCommand(SpriteRenderer renderer, Sprite spriteToSet, Sprite defaultSprite)
        {
            _originalSprite = defaultSprite;
            _spriteRendererToChange = renderer;
            _newSprite = spriteToSet;
        }

        public void Execute()
        {
            _spriteRendererToChange.sprite = _newSprite;
        }

        public void Undo()
        {
            _spriteRendererToChange.sprite = _originalSprite;
        }

        public void Redo()
        {
            //Debug.Log(_newSprite.name);
            //_spriteRendererToChange.sprite = _newSprite;
            Execute();
        }
    }
}