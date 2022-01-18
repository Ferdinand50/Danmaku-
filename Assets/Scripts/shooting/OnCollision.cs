using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollision : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Enemy")
        {
            Destroy(coll.gameObject);
        }
        GlobalVariableStorage.playerHealth = GlobalVariableStorage.playerHealth - 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (GlobalVariableStorage.playerHealth <= 0)
        {
            //Debug.Log("DEAD");
            //StartCoroutine(waiter());
            SceneManager.LoadScene("Menu");
            Destroy(gameObject);
            
            
        }
    }

        IEnumerator waiter()
{

    yield return new WaitForSeconds(2);
    SceneManager.LoadScene("Menu");
    

}
}
