using UnityEngine;

namespace Assets.Scenes
{
    class Character
    {
        GameObject _characterObject;

        KeyCode _leftKey;
        KeyCode _rightKey;
        KeyCode _jumpKey;
        KeyCode _attackKey;
        KeyCode _actionKey;

        int _hp;
        int _strength;

        const int SPEED = 1;

        public GameObject CharacterObject { get => _characterObject; set => _characterObject = value; }

        KeyCode LeftKey { get => _leftKey; set => _leftKey = value; }
        KeyCode RightKey { get => _rightKey; set => _rightKey = value; }
        KeyCode JumpKey { get => _jumpKey; set => _jumpKey = value; }
        KeyCode AttackKey { get => _attackKey; set => _attackKey = value; }
        KeyCode ActionKey { get => _actionKey; set => _actionKey = value; }

        int Hp { get => _hp; set => _hp = value; }
        int Strength { get => _strength; set => _strength = value; }

        public Character(GameObject characterObject, KeyCode leftKey, KeyCode rightKey, KeyCode jumpKey, KeyCode attackKey, KeyCode actionKey, int hp, int strength)
        {
            CharacterObject = characterObject;

            LeftKey = leftKey;
            RightKey = rightKey;
            JumpKey = jumpKey;
            AttackKey = attackKey;
            ActionKey = actionKey;

            Hp = hp;
            Strength = strength;
        }

        public void KeyPressed(KeyCode key)
        {
            if (IsAlive())
            {
                if (key == LeftKey)
                {
                    Move(false);
                }
                else if (key == RightKey)
                {
                    Move(true);
                }
                else if (key == JumpKey)
                {
                    Jump();
                }
                else if (key == AttackKey)
                {
                    Attack();
                }
                else if (key == ActionKey)
                {
                    Action();
                }
            }
        }

        void Move(bool isMovingRight)
        {
            if (isMovingRight)
            {
                CharacterObject.GetComponent<Rigidbody2D>().velocity += Vector2.right * SPEED;
            }
            else
            {
                CharacterObject.GetComponent<Rigidbody2D>().velocity += Vector2.left * SPEED;
            }
        }

        void Jump()
        {

        }

        void Attack()
        {

        }

        void Action()
        {

        }

        void Hit()
        {

        }

        bool IsAlive()
        {
            return Hp > 0;
        }
    }
}