using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1GoalScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3) LogicManagerScript.Instance.IncreaseScorePlayer1();
    }
}
