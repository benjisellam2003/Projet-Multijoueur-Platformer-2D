using Assets.Scenes;
using UnityEngine;

public class Controlls : MonoBehaviour
{
    Knight knight;
    Archer archer;

    LayerMask groundLayer;
    LayerMask entityLayer;

    void Start()
    {
        const string knightName = "Knight";
        const string archerName = "Archer";

        groundLayer = LayerMask.GetMask("Ground");
        entityLayer = LayerMask.GetMask("Entity");

        if (GameObject.Find(knightName) != null)
        {
            knight = new Knight();
        }
        if (GameObject.Find(archerName) != null)
        {
            archer = new Archer();
        }
    }

    void Update()
    {
        if (knight != null)
        {
            knight.KeyPressed();
        }
        if (archer != null)
        {
            archer.KeyPressed();
        }
    }

    void FixedUpdate()
    {
        knight.AnimatorTree.SetBool("IsGrounded", knight.CharacterObject.GetComponent<Rigidbody2D>().IsTouchingLayers(groundLayer) || knight.CharacterObject.GetComponent<Rigidbody2D>().IsTouchingLayers(entityLayer));
        archer.AnimatorTree.SetBool("IsGrounded", archer.CharacterObject.GetComponent<Rigidbody2D>().IsTouchingLayers(groundLayer) || archer.CharacterObject.GetComponent<Rigidbody2D>().IsTouchingLayers(entityLayer));
    }
}