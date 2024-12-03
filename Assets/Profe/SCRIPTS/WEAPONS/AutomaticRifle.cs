using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Angie.Weapons {


    /// <summary>
    /// EJERCICIO
    /// 
    /// 
    /// Realizar la lógica detras de la recarga de el rifle
    /// 
    /// </summary>
    public class AutomaticRifleVictor : Weapon
    {


        protected internal override void Shoot()
        {
            base.Shoot();
        }

        protected internal override void Reload()
        {
            Debug.Log("Recargo");
        }
    }
}