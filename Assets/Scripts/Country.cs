using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour
{
    public  void    setDisabled()
    {
        if (transform.GetChild(0) != null)
        {
            transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Tower>().ft_disableLed();
        }
    }

    public  void    setFriend()
    {
        if (transform.GetChild(0) != null)
        {
            transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Tower>().ft_friendLed();
        }
    }

    public  void    setEnemy()
    {
        if (transform.GetChild(0) != null)
        {
            transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Tower>().ft_enemyLed();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
