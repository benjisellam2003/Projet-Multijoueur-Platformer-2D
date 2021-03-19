using UnityEngine;

namespace Assets.Scenes
{
    class Knight : Character
    {
        public Knight(string objectName) : base(KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.Q, KeyCode.E, 50)
        {
            CharacterObject = GameObject.Find(objectName);
        }

        public override void Attack()
        {

        }
    }
}