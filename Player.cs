using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D target;
    [SerializeField] float runSpeed;
    [SerializeField]float jumpForce;
    [SerializeField]Collider2D boxcolliderIsGround2D;
    [SerializeField] LayerMask platformlayerMask;
    [SerializeField] int health = 3;
    public int Health { get => health; set => health = value; }

    public void walk()
    {

        target.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed, target.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && IsGround() == true)
        {
            target.AddForce(Vector2.up * jumpForce);
            //Debug.Log("jump");
            //photonView.RPC("JumpSoundPlay", RpcTarget.AllBuffered);

        }

        if (target.velocity.y < 0f && IsGround() == false)
        {
            target.gravityScale = 1.5f;
            //Debug.Log("dropping");
        }
        else
        {
            target.gravityScale = 1f;
        }

        //if (IsRightWallDet())
        //{
        //    if (Input.GetAxisRaw("Horizontal") > 0)
        //    {
        //        target.velocity = new Vector2(0, target.velocity.y);
        //    }
        //}

        //if (IsLeftWallDet())
        //{
        //    if (Input.GetAxisRaw("Horizontal") < 0)
        //    {
        //        target.velocity = new Vector2(0, target.velocity.y);
        //    }
        //}

        //if (target.velocity.x < -0.1f && Input.GetAxisRaw("Horizontal") < -0.1f)
        //{
        //    photonView.RPC("MainCharSpriteXTrue", RpcTarget.AllBuffered);

        //}
        //else if (target.velocity.x > 0.1f && Input.GetAxisRaw("Horizontal") > -0.1f)
        //{
        //    photonView.RPC("MainCharSpriteXFalse", RpcTarget.AllBuffered);
        //}
        //else
        //{
        //    mainchaRSprite.flipX = mainchaRSprite.flipX;
        //}
    }

    public bool IsGround()
    {
        float extraHeight = 0.1f;

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcolliderIsGround2D.bounds.center, boxcolliderIsGround2D.bounds.size, 0f, Vector2.down, extraHeight, platformlayerMask);
        //Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }

    private void FixedUpdate()
    {
        walk();
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
