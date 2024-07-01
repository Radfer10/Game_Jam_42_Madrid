using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continent : MonoBehaviour
{

    public  void    setDisabled()
    {
		for(int i = 0; i < this.gameObject.transform.childCount; i++)
		{
			GameObject Go = this.gameObject.transform.GetChild(i).gameObject;
			Go.GetComponent<Country>().setDisabled();
		}
    }

    public  void    setEnemy()
    {
		for(int i = 0; i < this.gameObject.transform.childCount; i++)
		{
			GameObject Go = this.gameObject.transform.GetChild(i).gameObject;
			Go.GetComponent<Country>().setEnemy();
		}
    }

    public  void    setFriend()
    {
		for(int i = 0; i < this.gameObject.transform.childCount; i++)
		{
			GameObject Go = this.gameObject.transform.GetChild(i).gameObject;
			Go.GetComponent<Country>().setFriend();
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
