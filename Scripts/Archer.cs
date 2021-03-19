using UnityEngine;

namespace Assets.Scenes
{
    class Archer : Character
    {
        public Archer(string objectName) : base(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightShift, KeyCode.RightControl, 25)
        {
            CharacterObject = GameObject.Find(objectName);
        }

        public override void Attack()
        {

        }
    }
}