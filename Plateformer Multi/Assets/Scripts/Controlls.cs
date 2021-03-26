using Assets.Scenes;
using UnityEngine;

public class Controlls : MonoBehaviour
{
    Knight knight;
    Archer archer;

    LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        const string knightName = "Knight";
        const string archerName = "Archer";

        groundLayer = LayerMask.GetMask("Ground");

        if (GameObject.Find(knightName) != null)
        {
            knight = new Knight(knightName);
        }
        if (GameObject.Find(archerName) != null)
        {
            archer = new Archer(archerName);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        knight.IsGrounded = knight.CharacterObject.GetComponent<Rigidbody2D>().IsTouchingLayers(groundLayer);

        archer.IsGrounded = archer.CharacterObject.GetComponent<Rigidbody2D>().IsTouchingLayers(groundLayer);

        if (knight != null)
        {
            knight.KeyPressed();
        }
        if (archer != null)
        {
            archer.KeyPressed();
        }
    }
}