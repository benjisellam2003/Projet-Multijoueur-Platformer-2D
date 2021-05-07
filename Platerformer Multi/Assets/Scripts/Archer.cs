using UnityEngine;

namespace Assets.Scenes
{
    class Archer : Character
    {
        public Archer() : base(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightShift, KeyCode.RightControl, 14, 25, "Archer", "ArcherHpGauge")
        {
        }

        //public override void Attack()
        //{

        //}
    }
}