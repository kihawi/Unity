using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Entity : MonoBehaviour
{
    
    public virtual void GetDamage()
    {

    }


    public virtual void Die()
    {
        Destroy(this.gameObject);
       

    }

    

}
