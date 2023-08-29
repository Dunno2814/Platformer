using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Static : MonoBehaviour
{
    public static GameObject player, cam, desire, respawn, bullet, bulletspawn;
    public static Rigidbody2D playerRg;
    public static Vector3 playerVec;
    public static bool canShoot, LineView, LookingRight;
    public static float speed, MaxVelo, CoyoteBas, JumpBuff, JumpStr, FallMult, BulletDis;
    public static int bulletCount = 0;

    public static float EnemyLookDis, EnemyLookUpDis;
    private void Update()
    {
        Static.playerVec = player.transform.position;
    }
    public static Vector3 IncreaseX (Vector3 X1, float X2) { return new Vector3(X1.x + X2, X1.y, X1.z); }
    

}
