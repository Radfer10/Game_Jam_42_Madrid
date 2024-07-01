using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public  Material    enemyLed;
    public  Material    friendLed;
    public  Material    disableLed;
    private MeshRenderer    mat;


    public  void    ft_disableLed()
    {
        Material[] materials = mat.materials;
        materials[1] = disableLed;
        mat.materials = materials;
    }

    public  void    ft_enemyLed()
    {
        Material[] materials = mat.materials;
        materials[1] = enemyLed;
        mat.materials = materials;
    }

    public  void    ft_friendLed()
    {
        Material[] materials = mat.materials;
        materials[1] = friendLed;
        mat.materials = materials;
    }
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>();
        mat.materials[1] = disableLed;
        ft_enemyLed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}