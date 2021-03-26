using UnityEngine;

namespace Assets.Scenes
{
    abstract class Character
    {
        // Champs
        GameObject _characterObject; // GameObject du personnage

        KeyCode _leftKey; // Touche de gauche
        KeyCode _rightKey; // Touche de droite
        KeyCode _jumpKey; // Touche de saut
        KeyCode _attackKey; // Touche d'attaque
        KeyCode _actionKey; // Touche d'action

        int _hp = 100; // Nombre de points de vie

        int _strength; // Dégats infligés à chaque attaque

        const int _DEFAULT_SPEED = 12; // Vitesse de déplacement par défaut
        float _currentSpeed = DEFAULT_SPEED; // Vitesse de déplacement actuelle

        int _acceleration = 1; // Accélération du personnage (Plus il court longtemps plus il accélère)
        const float _ACCELERATION_RATE = 0.1f; // Augmentation de l'accélération

        const int _JUMP_HEIGHT = 10; // Hauteur de saut
        
        bool _isGrounded = true; // Si le joueur est au sol

        // Propriétés
        public GameObject CharacterObject { get => _characterObject; set => _characterObject = value; }

        KeyCode LeftKey { get => _leftKey; set => _leftKey = value; }
        KeyCode RightKey { get => _rightKey; set => _rightKey = value; }
        KeyCode JumpKey { get => _jumpKey; set => _jumpKey = value; }
        KeyCode AttackKey { get => _attackKey; set => _attackKey = value; }
        KeyCode ActionKey { get => _actionKey; set => _actionKey = value; }

        int Hp { get => _hp; set => _hp = value; }
        int Strength { get => _strength; set => _strength = value; }

        public static int DEFAULT_SPEED => _DEFAULT_SPEED;

        public float CurrentSpeed { get => _currentSpeed; set => _currentSpeed = value; }
        public int Acceleration { get => _acceleration; set => _acceleration = value; }

        public static float ACCELERATION_RATE1 => _ACCELERATION_RATE;

        public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }

        public static int JUMP_HEIGHT => _JUMP_HEIGHT;

        // Constructeur
        protected Character(KeyCode leftKey, KeyCode rightKey, KeyCode jumpKey, KeyCode attackKey, KeyCode actionKey, int strength)
        {
            LeftKey = leftKey;
            RightKey = rightKey;
            JumpKey = jumpKey;
            AttackKey = attackKey;
            ActionKey = actionKey;

            _strength = strength;
        }

        // Méthodes
        public void KeyPressed() // Quand une touche est pressée
        {
            if (IsAlive())
            {
                if (Input.GetKey(LeftKey))
                    Move(false);

                if (Input.GetKey(RightKey))
                    Move(true);

                if (Input.GetKeyUp(LeftKey) || Input.GetKeyUp(RightKey))
                    ResetSpeed();

                if (Input.GetKeyDown(JumpKey))
                    Jump();

                if (Input.GetKeyDown(AttackKey))
                    Attack();

                if (Input.GetKeyDown(ActionKey))
                    Action();
            }
        }

        void Move(bool isMovingRight) // Mouvements du joueur : Gauche / Droite
        {
            if (isMovingRight)
            {
                CharacterObject.GetComponent<Rigidbody2D>().velocity += Vector2.right * CurrentSpeed * Time.deltaTime;
            }
            else
            {
                CharacterObject.GetComponent<Rigidbody2D>().velocity += Vector2.left * CurrentSpeed * Time.deltaTime;
            }
            CurrentSpeed += Acceleration * Time.deltaTime;
        }

        void ResetSpeed() // Remise à zéro de la vitesse du personnage
        {
            CurrentSpeed = DEFAULT_SPEED;
        }

        void Jump() // Saut
        {
            if (IsGrounded)
            {
                IsGrounded = false;
                CharacterObject.GetComponent<Rigidbody2D>().velocity += Vector2.up * JUMP_HEIGHT;
            }

            if (CharacterObject.GetComponent<Rigidbody2D>().velocity.y > JUMP_HEIGHT)
            {
                CharacterObject.GetComponent<Rigidbody2D>().velocity = new Vector2(CharacterObject.GetComponent<Rigidbody2D>().velocity.x, JUMP_HEIGHT);
            }
        }

        public virtual void Attack() // Attaque (À l'épée ou à l'arc)
        {

        }

        void Action() // Activation d'un mécanisme ou autre
        {

        }

        void Hit() // Quand le joueur est frappé par un ennemi
        {

        }

        bool IsAlive() // Si le joueur est encore en vie
        {
            return Hp > 0;
        }
    }
}