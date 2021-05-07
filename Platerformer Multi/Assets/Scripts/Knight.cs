using UnityEngine;

namespace Assets.Scenes
{
    class Knight : Character
    {
        public Knight() : base(KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.Q, KeyCode.E, 12, 50, "Knight", "KnightHpGauge")
        {
        }

        //public override void Attack()
        //{

        //}
    }
}