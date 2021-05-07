using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes
{
    abstract class Character
    {
        // Champs
        GameObject _characterObject; // GameObject du personnage

        Animator _animatorTree; // Arborescence des animations

        KeyCode _leftKey; // Touche de gauche
        KeyCode _rightKey; // Touche de droite
        KeyCode _jumpKey; // Touche de saut
        KeyCode _attackKey; // Touche d'attaque
        KeyCode _actionKey; // Touche d'action

        int _strength; // Dégats infligés à chaque attaque

        const int _DEFAULT_SPEED = 14; // Vitesse de déplacement par défaut
        float _currentSpeed = DEFAULT_SPEED; // Vitesse de déplacement actuelle

        int _acceleration = 1;  // Accélération du personnage (Plus il court longtemps plus il accélère)

        int _jumpHeight; // Hauteur de saut

        Slider _gauge; // Jauge de PV
        Gradient colorsGradient; // Dégradé de la jauge de PV
        Image fill; // Curseur de la jauge de PV

        // Propriétés
        public GameObject CharacterObject { get => _characterObject; set => _characterObject = value; }

        KeyCode LeftKey { get => _leftKey; set => _leftKey = value; }
        KeyCode RightKey { get => _rightKey; set => _rightKey = value; }
        KeyCode JumpKey { get => _jumpKey; set => _jumpKey = value; }
        KeyCode AttackKey { get => _attackKey; set => _attackKey = value; }
        KeyCode ActionKey { get => _actionKey; set => _actionKey = value; }

        int Strength { get => _strength; set => _strength = value; }

        public static int DEFAULT_SPEED => _DEFAULT_SPEED;

        public float CurrentSpeed { get => _currentSpeed; set => _currentSpeed = value; }
        public int Acceleration { get => _acceleration; set => _acceleration = value; }

        public int JumpHeight { get => _jumpHeight; set => _jumpHeight = value; }

        public Slider Gauge { get => _gauge; set => _gauge = value; }
        public Gradient ColorsGradient { get => colorsGradient; set => colorsGradient = value; }
        public Image Fill { get => fill; set => fill = value; }
        public Animator AnimatorTree { get => _animatorTree; set => _animatorTree = value; }

        // Constructeur
        protected Character(KeyCode leftKey, KeyCode rightKey, KeyCode jumpKey, KeyCode attackKey, KeyCode actionKey, int jumpHeight, int strength, string objectName, string gaugeName)
        {
            // Assignation de valeur aux variables
            LeftKey = leftKey;
            RightKey = rightKey;
            JumpKey = jumpKey;
            AttackKey = attackKey;
            ActionKey = actionKey;

            JumpHeight = jumpHeight;

            Strength = strength;

            Gauge = GameObject.Find(gaugeName).GetComponent<Slider>();

            ColorsGradient = new Gradient();
            
            GradientColorKey[] colorKey = new GradientColorKey[5];
            colorKey[0].color = Color.black;
            colorKey[0].time = 0;

            colorKey[1].color = Color.red;
            colorKey[1].time = 0.1f;

            colorKey[2].color = new Color32(255, 128, 0, 255);
            colorKey[2].time = 0.3f;

            colorKey[3].color = Color.yellow;
            colorKey[3].time = 0.5f;

            colorKey[4].color = Color.green;
            colorKey[4].time = 1;

            GradientAlphaKey[] alphaKey = new GradientAlphaKey[1];
            alphaKey[0].alpha = 1;
            alphaKey[0].time = 0;

            ColorsGradient.SetKeys(colorKey, alphaKey);

            CharacterObject = GameObject.Find(objectName);

            Fill = Gauge.GetComponentInChildren<Image>();

            AnimatorTree = CharacterObject.GetComponent<Animator>();
        }

        // Méthodes
        public void KeyPressed() // Quand une touche est pressée
        {
            // Les méthodes sont appelées en fonction de la touche pressée
            if (Input.GetKey(LeftKey))
                Move(false);

            if (Input.GetKey(RightKey))
                Move(true);

            if (!Input.GetKey(LeftKey) && !Input.GetKey(RightKey))
                ResetSpeed();

            if (Input.GetKeyDown(JumpKey))
                Jump();

            if (Input.GetKey(AttackKey))
                Attack();

            if (Input.GetKeyDown(ActionKey))
                Action();

            UpdateHpGauge();
        }

        void Move(bool isMovingRight) // Mouvements du joueur : Gauche / Droite
        {
            if (isMovingRight)
            {
                CharacterObject.GetComponent<Rigidbody2D>().velocity += Vector2.right * CurrentSpeed * Time.deltaTime;
                CharacterObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                CharacterObject.GetComponent<Rigidbody2D>().velocity += Vector2.left * CurrentSpeed * Time.deltaTime;
                CharacterObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            CurrentSpeed += Acceleration * Time.deltaTime;
            AnimatorTree.SetBool("IsRunning", AnimatorTree.GetBool("IsGrounded"));
        }

        void ResetSpeed() // Remise à zéro de la vitesse du personnage
        {
            CurrentSpeed = DEFAULT_SPEED;
            AnimatorTree.SetBool("IsRunning", false);
        }

        void Jump() // Saut
        {
            if (AnimatorTree.GetBool("IsGrounded"))
            {
                AnimatorTree.SetTrigger("Jump");
                AnimatorTree.SetBool("IsGrounded", false);
                CharacterObject.GetComponent<Rigidbody2D>().velocity += Vector2.up * JumpHeight;
            }

            if (CharacterObject.GetComponent<Rigidbody2D>().velocity.y > JumpHeight)
            {
                CharacterObject.GetComponent<Rigidbody2D>().velocity = new Vector2(CharacterObject.GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
            }
        }

        public virtual void Attack() // Attaque (À l'épée ou à l'arc)
        {
            AnimatorTree.SetTrigger("Attack");
        }

        void Action() // Activation d'un mécanisme ou autre
        {

        }

        void UpdateHpGauge()
        {
            Gauge.value = AnimatorTree.GetInteger("HP");

            Fill.color = ColorsGradient.Evaluate(Gauge.normalizedValue);
        }
    }
}