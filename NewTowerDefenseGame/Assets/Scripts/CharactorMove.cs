using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f; // ˆÚ“®‘¬“x‚ğŠO•”‚©‚ç’²®‰Â”\‚É

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
    }
}
